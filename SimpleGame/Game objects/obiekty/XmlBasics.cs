using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CrimsonEngine.SimpleGame.Game_objects
{
    public class XmlBasics
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        public string DeveloperComment { get; set; }

        [XmlArray("descriptions"),XmlArrayItem("desc")]
        public List<String> Descriptions = new List<string>();

        public void AddDescription(string TEXT)
        {
            if(!String.IsNullOrEmpty(TEXT))
            {
                Descriptions.Add(TEXT);
            }
        }

        public IEnumerable<string> ReadDescriptions()
        {
            return Descriptions;
        }

        public XmlBasics()
        {
        }

        public string GetDescription(int INDEX = 0)
        {
            string result = "";

            if (INDEX == 0)
            {
                Random rnd = new Random();
                result = Descriptions[rnd.Next(0, Descriptions.Count)];
            }
            else if (INDEX > 0)
            {
                result = Descriptions[INDEX];
            }
            else
            {
                result = "ERROR: Description index isn't valid";
            }

            return result;
        }
    }
}
