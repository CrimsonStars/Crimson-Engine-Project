using CrimsonEngine.Graphics;
using CrimsonEngine.Simple_math;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CrimsonEngine.SimpleGame.Game_objects
{
    [XmlRoot("item")]
    public class Item : XmlBasics
    {

        [XmlElement("weight")]
        public float Weight { get; set; }

        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("active_area")]
        public string ActiveAreaString { get; set; }

        public Basic2D Sprite { get; set; }

        private Polygon[] ActiveAreas { get; set; }

        public Item(
            string NAME,
            string ID, 
            float WEIGHT, 
            string TYPE
            )
        {
            Descriptions = new List<string>();
            Name = NAME;
            Id = ID;
            Weight = WEIGHT;
            Type = TYPE;

        }

        public void AddActiveArea(string INPUT)
        {
            if (!string.IsNullOrEmpty(INPUT))
            {
                INPUT = INPUT.Replace("\t", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace(" ", string.Empty);

                ActiveAreaString = INPUT;
                ActiveAreas[ActiveAreas.Length] = GetPolygonFromActiveAreaString(); 
            }
        }

        public Polygon GetPolygonFromActiveAreaString()
        {
            Polygon result = new Polygon();

            if (!string.IsNullOrEmpty(ActiveAreaString))
            {
                ActiveAreaString = ActiveAreaString
                    .Replace("\t", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace(" ", string.Empty);
                var points = ActiveAreaString.Split(';');

                foreach (var point in points)
                {
                    var coordinates = point.Split(',');

                    try
                    {
                        result.AddPoint(float.Parse(coordinates[0]), float.Parse(coordinates[1]));
                    }
                    catch (System.Exception e)
                    {
                        // TODO: Display proper message
                        System.Console.WriteLine(e.ToString());
                    }
                }
            }

            return result;
        }

    }
}
