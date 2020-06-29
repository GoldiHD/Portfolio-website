using System.Text.Json;
using System.Text.Json.Serialization;

namespace Portfolio_website.Entities
{
    public class Project
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string SmallDescriptiom { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string TrelloLink { get; set; }
        public string GithubLink { get; set; }
        public Links[] OtherLinks { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        /*
        public Project(string _name, string _smallDescriptiom, string _description, string _imagePath, string _trelloLink, string _githubLink, Links[] _otherLinks = null)
        {
            Name = _name;
            SmallDescriptiom = _smallDescriptiom;
            Description = _description;
            ImagePath = _imagePath;
            Id = System.Guid.NewGuid().ToString();
            TrelloLink = _trelloLink;
            GithubLink = _githubLink;
            OtherLinks = _otherLinks;
            if (OtherLinks == null)
            {
                OtherLinks = new Links[0];
            }
        }
        */

    }
    public struct Links
    {
        public string name;
        public string link;
    }
}
