using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UboneBot.Model;

namespace UboneBot.Utils
{
    public class UbqoneBlobHelper
    {
        string containerName = "";
        string StorageConnectionString = string.Empty;
        CloudBlobContainer storageContainer;

        public UbqoneBlobHelper()
        {
            // 저장소 연결 문자열 가져오기
            StorageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            containerName = CloudConfigurationManager.GetSetting("ContainerName");

            // 저장소 계정 가져오기
            // 여기서 runtime 에러나면 Web.config에 가서 저장소 계정 액세스 키를 설정하세요
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);

            // blob 클라이언트 생성.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // 기존의 컨테이너 참조 가져오기
            storageContainer = blobClient.GetContainerReference(containerName);
        }

        public Uri UploadFilesToAzureStorage(string fileName, Stream stream)
        {
            CloudBlockBlob blockBlob = storageContainer.GetBlockBlobReference(fileName);
            blockBlob.UploadFromStream(stream);

            return blockBlob.StorageUri.PrimaryUri;
        }

        public List<BlockBlob> ListBlobs()
        {
            BlockBlob blob;
            List<BlockBlob> blobs = new List<BlockBlob>();

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in storageContainer.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob cloudBlob = (CloudBlockBlob)item;
                    //Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Name);
                    blob = new BlockBlob
                    {
                        Name = cloudBlob.Name,
                        Uri = cloudBlob.Uri.ToString(),
                        ContentLength = cloudBlob.Properties.Length
                    };
                    blobs.Add(blob);
                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    // do somethig 
                }
            }

            return blobs;
        }
    }
}