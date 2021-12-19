using CrimsonEngine.SimpleGame.Game_objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CrimsonEngine.SimpleGame
{
    [XmlRoot("ROOMS")]
    public class MultipleRooms
    {
        [XmlElement("ROOM")]
        public List<Room> Rooms { get; set; }
        [XmlAttribute("ID")]
        public string Id { get; set; } = "ROOM." + Guid.NewGuid().ToString();
    
        public MultipleRooms()
        {
            Rooms = new List<Room>();
        }
    }
}
