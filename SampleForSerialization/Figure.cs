using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SampleForSerialization
{
    [Serializable]
    class Figure
    {
        public string Name { get; set; }
        public int SideCount { get; set; }
        public double SideLength { get; set; }
        public Figure Figure1 { get; set; }



        public static string SerializeObjToJson(Figure figure)
        {
            string strObj = JsonConvert.SerializeObject(figure, Formatting.Indented);
            return strObj;
        }
        public static string SerializeListToJson(List<Figure> figList)
        {
            string strListOfObj = JsonConvert.SerializeObject(figList, Formatting.Indented);
            return strListOfObj;
        }
        public static string SerializeDictToJson(Dictionary<string, Figure> figDic)
        {
            string strDict = JsonConvert.SerializeObject(figDic, Formatting.Indented);
            return strDict;
        }
        public static Figure DeserializeFromJson(string strJson)
        {
            var figObj = JsonConvert.DeserializeObject<Figure>(strJson);
            return figObj;
        }
        public static List<Figure> DeserializeListFromJson(string listJson)
        {
            var listObj = JsonConvert.DeserializeObject<List<Figure>>(listJson);
            return listObj;
        }
        public static Dictionary<string, Figure>DeserializeDicFromJson(string dicJson)
        {
            var dicObj = JsonConvert.DeserializeObject<Dictionary<string, Figure>>(dicJson);
            return dicObj;
        }
    }


   
}
