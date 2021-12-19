using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CrimsonEngine.XmlParser
{
    public static class XmlParser
    {
        public static String FilePath { get; set; }

        public static void ParseSingleElement<T>(string FILEPATH, string ROOTNAME = null)
        {
            Object o;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(FILEPATH))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));//, new XmlRootAttribute(ROOTNAME));

                o = serializer.Deserialize(sr);
            }
        }
        
        public static List<T> ParseListOfElements<T>(string FILEPATH, string ROOTNAME = null)
        {
            List<T> o;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(FILEPATH))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));//, new XmlRootAttribute(ROOTNAME));
                o = (List<T>)serializer.Deserialize(sr);
            }

            return o;
        }
    }
}
