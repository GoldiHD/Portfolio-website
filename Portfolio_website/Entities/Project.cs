﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio_website.Entities
{
    public class Project
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        public string name { get; set; }
        public string smallDescriptiom { get; set; }
        public string description { get; set; }
        public Byte[] Image { get; set; }
        public string trelloLink { get; set; }
        public string githubLink { get; set; }
        public List<Links> otherLinks { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public Project(string _name, string _smallDescriptiom, string _description, Byte[] _image, int _id, string _trelloLink, string _githubLink, List<Links> _otherLinks = null)
        {
            name = _name;
            smallDescriptiom = _smallDescriptiom;
            description = _description;
            Image = _image;
            Id = _id;
            trelloLink = _trelloLink;
            githubLink = _githubLink;
            otherLinks = _otherLinks;
            if(otherLinks == null)
            {
                otherLinks = new List<Links>();
            }
        }

        private void ConvertImageToByteArray(System.Drawing. imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

        public void GetPicture(picture)
        {
            return Encoding.Convert()';
        }
    }
    public struct Links
    {
        public string name;
        public string link;
    }
}
