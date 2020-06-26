using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Portfolio_website.Toobox
{
    public class BlobAccess
    {
        public async static Task<string> UploadImage(Stream picture, string name)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(SingleTon.getResources("connectionStringBlob"),"images");
            BlobClient BC = blobContainerClient.GetBlobClient(name);
            await BC.UploadAsync(picture, new BlobHttpHeaders() { ContentType = "image/jpeg" });// a extenstion detecting system should be created
            return blobContainerClient.GetBlobClient(name).Uri.ToString();
        }
    }
}
