using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio_website.Entities;
using Portfolio_website.Toobox;

namespace Portfolio_website.Pages
{
    public class ProjectPageModel : PageModel
    {
        public Project project { get; set; }
        public void OnGet(int id)
        {
            project = SingleTon.GetSQLConnector().GetProjects().Result[id];
        }
    }
}