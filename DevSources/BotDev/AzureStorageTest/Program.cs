using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace AzureStorageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 저장소 연결 문자열 가져오기
            string storageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            string containerName = CloudConfigurationManager.GetSetting("ContainerName");

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    
                    Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Name);
                    
                    
                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    // do somethig 
                }
            }

            Console.ReadKey();
        }
    }
}
