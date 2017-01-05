using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLReader
{
    public class TmxParser
    {

        public TmxParser()
        {}

        /// <summary>
        /// Parse a TMX file
        /// </summary>
        public Map Parse(string filename)
        {
            //serializer should serialize a Map class as XML
            XmlSerializer serializer = new XmlSerializer(typeof(Map));

            //open file, and read Map class from it
            TextReader reader = new StreamReader(filename);
            Map map = serializer.Deserialize(reader) as Map;
            reader.Close();

            Console.WriteLine("\n TMX filename is " + filename);
            Console.WriteLine(map);

            return map;
        }
    }
}
