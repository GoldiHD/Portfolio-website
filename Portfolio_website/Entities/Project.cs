

using Newtonsoft.Json;

namespace Portfolio_website.Entities
{
    public class Project
    {
        [JsonProperty(PropertyName = "id")]
        public string PKId { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
        public string smallDescriptiom { get; set; }
        public string description { get; set; }
        public string imagePath { get; set; } 
        public string trelloLink { get; set; }
        public string githubLink { get; set; }
        public Links[] otherLinks { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public Project(string _name, string _smallDescriptiom, string _description, string _imagePath, int _id, string _trelloLink, string _githubLink, Links[] _otherLinks = null)
        {
            name = _name;
            smallDescriptiom = _smallDescriptiom;
            description = _description;
            imagePath = _imagePath;
            Id = _id;
            PKId = "Project_" + Id;
            trelloLink = _trelloLink;
            githubLink = _githubLink;
            otherLinks = _otherLinks;
            if(otherLinks == null)
            {
                otherLinks = new Links[0];
            }
        }

    }
    public struct Links
    {
        public string name;
        public string link;
    }
}
