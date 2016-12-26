using System.Xml.Serialization;

namespace XMLReader
{
        /// </summary>
        [XmlRoot("map")]
        public class Map
        {

            [XmlAttribute("width")]
            public int Width = 0;

            [XmlAttribute("height")]
            public int Height = 0;

            [XmlElement("objectgroup")]
            public ObjectGroup[] ObjectGroup;

            public Map() { }
        }

        /// <summary>
        /// Represents the Object group tag in a map layer
        /// </summary>
        [XmlRootAttribute("objectgroup")]
        public class ObjectGroup
        {
            [XmlAttribute("name")]
            public string Name;

            [XmlElement("object")]
            public TiledObject[] TiledObject;
        }

        /// <summary>
        /// Represents the Object tag in an Object group
        /// </summary>
        [XmlRootAttribute("object")]
        public class TiledObject
        {
            [XmlAttribute("gid")]
            public int GID;
            [XmlAttribute("x")]
            public float X;
            [XmlAttribute("y")]
            public float Y;
            [XmlAttribute("rotation")]
            public float Rotation;

            [XmlElement("properties")]
            public Properties Properties;


            public void ToDictionary()
            {

            }
        }

        /// <summary>
        /// Represents the Properties container in an Object
        /// </summary>
        [XmlRootAttribute("properties")]
        public class Properties
        {
            [XmlElement("property")]
            public Property[] Property;
        }

        /// <summary>
        /// Represents an individual Property in a Properties container.
        /// </summary>
        [XmlRootAttribute("property")]
        public class Property
        {
            [XmlAttribute("name")]
            public string Name;
            [XmlAttribute("value")]
            public string Value;
        }
 }
