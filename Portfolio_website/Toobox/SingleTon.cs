using Portfolio_website.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace Portfolio_website.Toobox
{
    public class SingleTon
    {
        private static readonly ResourceManager resx = new ResourceManager("Portfolio_website.Resourceses.ConstData", Assembly.GetExecutingAssembly());
        private static List<Project> projectsInstance;
        private static SQLConnector SQLConnectorInstance;

        public static Project StaticGetProject(int id)
        {
            //Dummy data
            //should access api point and draw data from DB
            if (projectsInstance == null)
            {
                projectsInstance = new List<Project>();
                projectsInstance.Add(new Project("Project1", "this is project 1", "This project is a project that contains things", "", 0, "goog.com", "google.com"));
                projectsInstance.Add(new Project("Project2", "this is project 2", "This project is a project that contains even more things", "", 1, "goog.com", "google.com"));
                projectsInstance.Add(new Project("Project3", "this is project 3", "This project is a project that contains less then the others", "", 2, "goog.com", "google.com", new Links[] { new Links { name = "Link", link = "www.google.com"  } }));
            }
            return projectsInstance[id];
        }

        public static List<Project> StaticGetAllProjects()
        {
            //just to Initialse test data;
            StaticGetProject(0);
            return projectsInstance;
        }

        public static string getResources(string Access)
        {
            return resx.GetString(Access);
        }

        public static SQLConnector GetSQLConnector()
        {
            if(SQLConnectorInstance == null)
            {
                SQLConnectorInstance = new SQLConnector();
            }
            return SQLConnectorInstance;
        }

    }
}
