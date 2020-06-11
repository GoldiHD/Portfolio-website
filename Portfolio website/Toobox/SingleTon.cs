using Portfolio_website.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_website.Toobox
{
    public class SingleTon
    {
        private static List<Project> projectsInstance;

        public static Project GetProject(int id)
        {
            //Dummy data
            //should access api point and draw data from DB
            if (projectsInstance == null)
            {
                projectsInstance = new List<Project>();
                projectsInstance.Add(new Project("Project1", "this is project 1", "This project is a project that contains things", "path", 0, "goog.com", "google.com"));
                projectsInstance.Add(new Project("Project2", "this is project 2", "This project is a project that contains even more things", "path", 1, "goog.com", "google.com"));
                projectsInstance.Add(new Project("Project3", "this is project 3", "This project is a project that contains less then the others", "path", 2, "goog.com", "google.com", new List<Links>() { new Links { name = "Link", link = "www.google.com"  } }));
            }
            return projectsInstance[id];
        }

        public static List<Project> GetAllProjects()
        {
            //just to Initialse;
            GetProject(0);
            return projectsInstance;
        }

    }
}
