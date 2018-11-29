using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace storage
{
    class Program
    {
        static void Main(string[] args)
        {
  
        }

        public void segundo()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storage13net;AccountKey=AhDlxuw3BZ3XhhFvgJUNmvVDBoiUZFXwrZoty/hLCiXdFzR2B/wXVnzlbS/dnRIt7oC/jn8mcvNYoaDluvercg==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference("rm331283");
            table.CreateIfNotExistsAsync();

            var entity = new Aluno("331283", "Sao Paulo");
            entity.Nome = "Joao";
            entity.Email = "nunsei@gmail.com";
            table.ExecuteAsync(TableOperation.Insert(entity));

            Console.Read();
            Console.WriteLine("Hello World!");
        }

        public void primeiro()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storage13net;AccountKey=AhDlxuw3BZ3XhhFvgJUNmvVDBoiUZFXwrZoty/hLCiXdFzR2B/wXVnzlbS/dnRIt7oC/jn8mcvNYoaDluvercg==;EndpointSuffix=core.windows.net");
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("rm331283");
            try
            {
                container.CreateIfNotExistsAsync();
            }
            catch { container.CreateIfNotExistsAsync().Wait(); }

            var blob = container.GetBlockBlobReference("MyGod2.txt");
            blob.UploadTextAsync("5+1= 10 acerto miseravi");

            var sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write,
                SharedAccessExpiryTime = DateTime.Now.AddYears(5)
            });

            Console.WriteLine(blob.Uri + sas);
            Console.Read();


            Console.WriteLine("Hello World!");
        }
    }
}
