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

             [XmlElement("tileset")]
             public Tileset Tileset;

             [XmlElement("layer")]
             public Layer[] Layer;

            [XmlElement("objectgroup")]
            public ObjectGroup[] ObjectGroup;

            public Map() { }
    }


    [XmlRoot("tileset")]
    public class Tileset
    {
        public Tileset() { }

        [XmlAttribute("name")]
        public string NameTile;

        [XmlAttribute("tileheight")]
        public int TileHeight = 0;

        [XmlAttribute("tilewidth")]
        public int TileWidth = 0;

        [XmlElement("image")]
        public Image Image;

        [XmlElement("tile")]
        public Tile Tile;
    }

    [XmlRoot("image")]
    public class Image
    {
        [XmlAttribute("source")]
        public string Source;
        [XmlAttribute("width")]
        public int Width;
        [XmlAttribute("height")]
        public int Height;

    }


    [XmlRoot("tile")]
    public class Tile
    {
        public Tile() { }

        [XmlAttribute("id")]
        public int ID = 0;

        [XmlElement("properties")]
        public Properties[] Properties;

    }

    [XmlRoot("properties")]
    public class Properties
    {
        public Properties() { }
        [XmlElement("property")]
        public Property[] Property;

    }

    [XmlRoot("property")]
    public class Property
    {
        public Property() { }

        [XmlAttribute("name")]
        public string PropName;

        [XmlAttribute("value")]
        public bool Value;
    }


    [XmlRoot("layer")]
    public class Layer
    {
        public Layer() { }

        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("width")]
        public int width = 0;

        [XmlAttribute("height")]
        public int height = 0;

        [XmlElement("data")]
        public Data Data;

        public int[,] mapData()
        {
            string[] csvData = Data.InnerXml.Split(',');
            int[,] TwoData = new int[width, height];

            for (int widt = 0; widt < TwoData.GetLength(0); widt++)
            {
                for (int hei = 0; hei < TwoData.GetLength(1); hei++)
                {
                    TwoData[widt, hei] = int.Parse(csvData[widt * width + hei]);
                }
            }
            return TwoData;
        }

  }


    [XmlRoot("data")]
    public class Data
    {
        public Data() { }

        [XmlAttribute("encoding")]
        public string Encoding;

        [XmlText]
        public string InnerXml;
    }

    /// <summary>
    /// Represents the Object group tag in a map layer
    /// </summary>
    [XmlRoot("objectgroup")]
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
    [XmlRoot("object")]
     public class TiledObject
    {
        [XmlAttribute("gid")]
        public int GID;

        [XmlAttribute("height")]
        public float Height;

        [XmlAttribute("id")]
        public int ID;

        [XmlAttribute("name")]
        public string Name;

        [XmlElement("properties")]
        public ObjectProperties[] Properties;

        [XmlElement("polygon")]
        public Polygon Polygon;

        [XmlAttribute("rotation")]
        public float Rotation;

        [XmlAttribute("width")]
        public float Width;

        [XmlAttribute("x")]
        public float X;

        [XmlAttribute("y")]
        public float Y;

    }

    [XmlRoot("polygon")]
    public class Polygon
    {
        [XmlAttribute("points")]
        public string Points;
    }

    /// <summary>
    /// Represents the Properties container in an Object
    /// </summary>
    [XmlRoot("properties")]
    public class ObjectProperties
    {
            [XmlElement("property")]
            public ObjectProperty Property;
    }

        /// <summary>
        /// Represents an individual Property in a Properties container.
        /// </summary>
    [XmlRoot("property")]
    public class ObjectProperty
    {
        [XmlAttribute("name")] public string Name;

        [XmlAttribute("value")] public string Value;
    }
 }
