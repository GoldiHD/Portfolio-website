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

    }
    public class Links
    {
        public string name { get; set; }
        public string link { get; set; }
    }
}
