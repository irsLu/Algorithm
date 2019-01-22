using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Xml;
using System.Xml.Serialization;

public class XMLSerialized : ISerializable
{
    public T Deserialize<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return default(T);
        }

        using (XmlReader xr = new XmlTextReader(filePath))
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            T data = (T) xs.Deserialize(xr);

            if (null != data)
            {
                return data;
            }
        }

        return default(T);
    }

    public void Serialize<T>(string filePath, T Data)
    {
        using (XmlTextWriter xw = new XmlTextWriter(filePath, null))
        {
            XmlSerializer sl = new XmlSerializer(Data.GetType());
            sl.Serialize(xw,Data);
        }
    }
}
