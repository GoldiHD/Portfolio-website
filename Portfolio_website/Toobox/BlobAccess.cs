using Azure.Storage.Blobs;
using System.IO;
using System.Threading.Tasks;

namespace Portfolio_website.Toobox
{
    public class BlobAccess
    {
        public async static Task<string> UploadImage(Stream picture, string name)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(SingleTon.getResources("connectionStringBlob"),"images");
            await blobContainerClient.UploadBlobAsync(name, picture);
            return blobContainerClient.GetBlobClient(name).Uri.ToString();
        }
    }
}
