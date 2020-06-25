using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_website.Entities;
using Portfolio_website.Toobox;

namespace Portfolio_website.Pages
{
    public class AdminUploadPageModel : PageModel
    {
        public string testTextURI;
        private static Stream pictureStream;
        private static string pictureName;

        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string smallDescription { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string links { get; set; }
        [BindProperty]
        public string TrelloLink { get; set; }
        [BindProperty]
        public string Github { get; set; }

        public async Task OnPostAsync()
        {
            if (Upload != null)
            {
                pictureStream = Upload.OpenReadStream();
                pictureName = Upload.Name;
                //testTextURI = await BlobAccess.UploadImage(Upload.OpenReadStream(), Upload.FileName);
            }
        }
        public async Task OnPostSaveProject()
        {
            List<Links> linksSperated = new List<Links>();
            if (links == "")
            {
                string[] SplitLinks = links.Split(',');
                foreach (string element in SplitLinks)
                {
                    string[] temp = element.Split(' ');
                    linksSperated.Add(new Links { link = temp[1], name = temp[0] });
                }
            }
            try
            {
                await SingleTon.GetSQLConnector().AddNewItemToContainerAsync(new Entities.Project(Name, smallDescription, Description, await BlobAccess.UploadImage(pictureStream, pictureName), SingleTon.GetSQLConnector().GetProjects().Result.Last().Id + 1, TrelloLink, Github, linksSperated));
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            pictureStream = null;
            pictureName = "";
        }
    }
}