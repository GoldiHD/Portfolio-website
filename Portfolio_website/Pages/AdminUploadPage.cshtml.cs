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

        public async Task OnPostSavePicture()
        {
            if (Upload != null)
            {

                List<Links> linksSperated = new List<Links>();
                if (Name != null)
                {
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
                        await SingleTon.GetSQLConnector().AddNewItemToContainerAsync(new Entities.Project(Name, smallDescription, Description, await BlobAccess.UploadImage(Upload.OpenReadStream(), Upload.FileName), SingleTon.GetSQLConnector().GetNextID().Result, TrelloLink, Github, linksSperated.ToArray()));
                    }
                    catch (Exception ex)
                    { Console.WriteLine(ex.Message); }
                }

                //testTextURI = await BlobAccess.UploadImage(Upload.OpenReadStream(), Upload.FileName);
            }
        }
    }
}