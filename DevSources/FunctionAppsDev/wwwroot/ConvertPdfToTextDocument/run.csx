#r "System.Drawing"
#r "System.IO"

using System.Text;
using System.IO;
using System.Drawing.Imaging;

using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using Microsoft.ProjectOxford.Vision;

public static async Task<string> Run(Stream pdfStream, string name, TraceWriter log)
{
    var imageList = GetImages(pdfStream);
    log.Info($"{name} file contains {imageList.Count} pages");

    var resultDocument = new StringBuilder();
    foreach (var eachImage in imageList)
    {
        using (var ms = new MemoryStream())
        {
            eachImage.Save(ms, ImageFormat.Png);
            ms.Seek(0, SeekOrigin.Begin);
            string text = await CovertImageToText(ms);
            resultDocument.Append($"{text}");
        }
    }

    return resultDocument.ToString();
}

public static List<System.Drawing.Image> GetImages(Stream pdfStream)
{
    List<System.Drawing.Image> images = new List<System.Drawing.Image>();

    using (var reader = new PdfReader(pdfStream))
    {
        var parser = new PdfReaderContentParser(reader);
        ImageRenderListener listener = null;

        for (var pageNum = 1; pageNum <= reader.NumberOfPages; pageNum++)
        {
            listener = new ImageRenderListener();
            parser.ProcessContent(pageNum, listener);

            if (listener.Images.Count > 0)
            {
                foreach (var each in listener.Images)
                {
                    images.Add(each.Key);
                }
            }
        }
    }

    return images;
}

internal class ImageRenderListener : IRenderListener
{

    Dictionary<System.Drawing.Image, string> images = new Dictionary<System.Drawing.Image, string>();

    public Dictionary<System.Drawing.Image, string> Images
    {
        get { return images; }
    }

    public void BeginTextBlock() { }

    public void EndTextBlock() { }

    public void RenderImage(ImageRenderInfo renderInfo)
    {
        PdfImageObject image = renderInfo.GetImage();
        PdfName filter = (PdfName)image.Get(PdfName.FILTER);

        //int width = Convert.ToInt32(image.Get(PdfName.WIDTH).ToString());
        //int bitsPerComponent = Convert.ToInt32(image.Get(PdfName.BITSPERCOMPONENT).ToString());
        //string subtype = image.Get(PdfName.SUBTYPE).ToString();
        //int height = Convert.ToInt32(image.Get(PdfName.HEIGHT).ToString());
        //int length = Convert.ToInt32(image.Get(PdfName.LENGTH).ToString());
        //string colorSpace = image.Get(PdfName.COLORSPACE).ToString();

        /* It appears to be safe to assume that when filter == null, PdfImageObject 
         * does not know how to decode the image to a System.Drawing.Image.
         * 
         * Uncomment the code above to verify, but when I've seen this happen, 
         * width, height and bits per component all equal zero as well. */
        if (filter != null)
        {
            System.Drawing.Image drawingImage = image.GetDrawingImage();

            string extension = ".";

            if (filter == PdfName.DCTDECODE)
            {
                extension += PdfImageObject.ImageBytesType.JPG.FileExtension;
            }
            else if (filter == PdfName.JPXDECODE)
            {
                extension += PdfImageObject.ImageBytesType.JP2.FileExtension;
            }
            else if (filter == PdfName.FLATEDECODE)
            {
                extension += PdfImageObject.ImageBytesType.PNG.FileExtension;
            }
            else if (filter == PdfName.LZWDECODE)
            {
                extension += PdfImageObject.ImageBytesType.CCITT.FileExtension;
            }

            /* Rather than struggle with the image stream and try to figure out how to handle 
             * BitMapData scan lines in various formats (like virtually every sample I've found 
             * online), use the PdfImageObject.GetDrawingImage() method, which does the work for us. */
            this.Images.Add(drawingImage, extension);
        }
    }

    public void RenderText(TextRenderInfo renderInfo) { }
}

public static async Task<string> CovertImageToText(Stream imgStream)
{
    var client = new VisionServiceClient(
        GetEnv("VISION_API_KEY"),
        GetEnv("VISION_API_ENDPOINT"));
    var ocrResult = await client.RecognizeTextAsync(imgStream);
    var resultString = new StringBuilder();

    foreach (var eachRegion in ocrResult.Regions)
    {
        foreach (var eachLine in eachRegion.Lines)
        {
            foreach (var eachWord in eachLine.Words)
            {
                resultString.Append($"{eachWord.Text} ");
            }
            resultString.AppendLine();
        }
    }
    return resultString.ToString();
}

public static string GetEnv(string name)
{
    return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
}