using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_website.Entities
{
    public class Project
    {
        public string name;
        public string smallDescriptiom;
        public string description;
        public string imagePath;
        public int id;
        public string trelloLink;
        public string githubLink;
        public List<Links> otherLinks;

        public Project(string _name, string _smallDescriptiom, string _description, string _imagePath, int _id, string _trelloLink, string _githubLink, List<Links> _otherLinks = null)
        {
            name = _name;
            smallDescriptiom = _smallDescriptiom;
            description = _description;
            imagePath = _imagePath;
            id = _id;
            trelloLink = _trelloLink;
            githubLink = _githubLink;
            otherLinks = _otherLinks;
            if(otherLinks == null)
            {
                otherLinks = new List<Links>();
            }
        }
    }
    public struct Links
    {
        public string name;
        public string link;
    }
}
