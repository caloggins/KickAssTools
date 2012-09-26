namespace KickAss.Tools.Serialization
{
    using System;

    public interface ISerializer
    {
        string Serialize<T>(T objectToSerialize);
        T Deserialize<T>(string xml);
        T Deserialize<T>(string xml, Type[] types);
    }
}