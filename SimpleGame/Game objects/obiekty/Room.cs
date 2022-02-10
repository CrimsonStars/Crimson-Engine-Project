using CrimsonEngine.Graphics;
using CrimsonEngine.Simple_math;
using CrimsonEngine.SimpleGame.Game_objects;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CrimsonEngine.SimpleGame
{
    [XmlRoot("ROOM")]
    public class Room : XmlBasics
    {
        [XmlArray("DIRECTIONS"), XmlArrayItem("DIR")]
        public List<KeyValuePair<string,string>> Directions;
        // id and 
        [XmlArray("ITEMS"), XmlArrayItem("ITEM")]
        public List<KeyValuePair<string, Polygon>> Items { get; set; }
        public Basic2D Background { get; set; }

        public Room()
        {
            Id = "ROOM." + Guid.NewGuid().ToString();
            Items = new List<KeyValuePair<string, Polygon>>();
            Directions = new List<KeyValuePair<string, string>>();
            Descriptions = new List<string>();
            Name = "Room - " + Id;
            DeveloperComment = "";
        }

        public Room(
            string NAME,
            IEnumerable<string> ITEMS,
            IEnumerable<string> DIRECTIONS,
            IEnumerable<string> DESCRIPTIONS,
            string DEV_COMMENT = ""
            )
        {
            Items = new List<KeyValuePair<string, Polygon>>();
            Directions = new List<KeyValuePair<string, string>>();
            Descriptions = new List<string>();
            Name = NAME;
            Id = String.Concat("ROOM.", Guid.NewGuid().ToString());

            if (string.IsNullOrEmpty(DEV_COMMENT))
            {
                DeveloperComment = DEV_COMMENT;
            }

            foreach (var i in ITEMS)
            {
                //Items.Add(i);
            }

            //foreach (var i in DIRECTIONS)
            //{
            //    Directions.Add(i);
            //}

            foreach (var i in DESCRIPTIONS)
            {
                Descriptions.Add(i);
            }
        }

        public IEnumerable<(string,string)> GetDirections()
        {
            List<(string, string)> result;
            result= new List<(string,string)>();

            foreach(var i in Directions)
            {

            }

            return result;
        }

        public string GetMap()
        {
            string result = String.Format("ROOM '{0}' MAP:\n", this.Id);

            foreach (var i in Directions)
            {
                result += String.Format("{0}", i);
            }

            return result;
        }

    }
}
