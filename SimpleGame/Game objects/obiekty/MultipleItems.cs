using CrimsonEngine.SimpleGame.Game_objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CrimsonEngine.SimpleGame
{
    [XmlRoot("items")]
    public class MultipleItems
    {
        [XmlElement("item")]
        public List<Item> Items { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; } = "ITEMS." + Guid.NewGuid().ToString();

        public MultipleItems()
        {
            Items = new List<Item>();
        }
    }
}
