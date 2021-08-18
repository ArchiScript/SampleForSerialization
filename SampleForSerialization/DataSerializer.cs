using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace SampleForSerialization
{
    class DataSerializer
    {

        public string SerializeObjToJson(object obj)
        {
            string strObj = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return strObj;
        }
        
       /* public string SerializeListToJson(List<object> objList)
        {
            string strListOfObj = JsonConvert.SerializeObject(objList, Formatting.Indented);
            return strListOfObj;
        }
        
        public string SerializeDictToJson(Dictionary<string, object> objDic)
        {
            string strDict = JsonConvert.SerializeObject(objDic, Formatting.Indented);
            return strDict;
        }*/
        
        public object DeserializeFromJson(string strJson)
        {
            var Obj = JsonConvert.DeserializeObject<object>(strJson);
            return Obj;
        }
       
       /* public List<object> DeserializeListFromJson(string listJson)
        {
            var listObj = JsonConvert.DeserializeObject<List<object>>(listJson);
            return listObj;
        }
       
        public Dictionary<string, object> DeserializeDicFromJson(string dicJson)
        {
            var dicObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(dicJson);
            return dicObj;
        }*/
        
        public void BinarySerializer(object obj, string path)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate))
            {
                binForm.Serialize(filestream, obj);
            }
        }
       
        public object BinaryDeserialize(string path)
        {
            object obj = null;
                BinaryFormatter binForm = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                obj = binForm.Deserialize(fileStream);
            }

            return obj;
        }
    }
}
