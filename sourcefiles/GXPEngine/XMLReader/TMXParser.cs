using System.IO;
using System.Xml.Serialization;

namespace XMLReader
{
    class TMXParser
    {

        public TMXParser()
        {
        }

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

            return map;
        }
    }
}
