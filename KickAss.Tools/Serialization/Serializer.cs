namespace KickAss.Tools.Serialization
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class Serializer : ISerializer
    {
        public string Serialize<T>(T objectToSerialize)
        {
            var serializer = new XmlSerializer(typeof(T));
            var writer = new StringWriter();

            serializer.Serialize(writer, objectToSerialize);

            return writer.ToString();
        }

        public T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = new StringReader(xml);

            var t = (T)serializer.Deserialize(reader);

            return t;
        }

        public T Deserialize<T>(string xml, Type[] types)
        {
            var serializer = new XmlSerializer(typeof (T), types);
            var reader = new StringReader(xml);

            var t = (T) serializer.Deserialize(reader);

            return t;
        }
    }
}