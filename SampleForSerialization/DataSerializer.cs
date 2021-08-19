using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace SampleForSerialization
{
    public class DataSerializer
    {

        public string SerializeToJson<T>(T obj)
        {
            string strObj = (string)JsonConvert.SerializeObject(obj, Formatting.Indented);
            return strObj;
        }
        public void SerializeToJson<T>(T obj, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        public T DeserializeFromJson<T>(string obj)
        {
            T serializedObj = JsonConvert.DeserializeObject<T>(obj);
            return serializedObj;
        }


        public void BinarySerializer<T>(T obj, string path)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate))
            {
                binForm.Serialize(filestream, obj);
            }
        }

        public T BinaryDeserialize<T>(string path)
        {
            T obj;
            BinaryFormatter binForm = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = (T)binForm.Deserialize(fileStream);
            }

            return obj;
        }

        public void SerializeToXml<T>(T obj, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fileStream, obj);
            }
        }

        public T DeserializeFromXml<T>(string path)
        {
            T obj;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = (T)serializer.Deserialize(fileStream);
            }
            return obj;
        }

    }
}
