using System;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace SampleForSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Figure()
            {
                Name = "Triangle",
                SideCount = 3,
                SideLength = 2,
                
           
            };
            
            List<Figure> figList = new List<Figure>() { triangle, triangle, triangle };
                
            Dictionary<string, Figure> figDic = new Dictionary<string, Figure>();
           
            for (int i = 1; i < 5; i++)
            {
                figDic.Add($"Треугольник{i}", new Figure
                {
                    Name = $"Name{i}",
                    SideCount = 2,
                    SideLength = 3,
                    Figure1 = new Figure
                    {
                        Name = $"SubName{i}",
                        SideCount = 3,
                        SideLength = 8,
                        Figure1 = new Figure
                        {
                            Name = $"SUBSubName{i}",
                            SideLength = 3,
                            SideCount = 88
                        }
                    }
                });
            }

            var serDic = JsonConvert.SerializeObject(figDic, Formatting.Indented);
            //Console.WriteLine(serDic);
            Dictionary<string, int> dic2 = new Dictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                dic2.Add($"dklfjj{i}", i);
            }
            string dic2ser = JsonConvert.SerializeObject(dic2.Keys, Formatting.Indented);


            var fig = new Figure();

            var jsonFromObj = Figure.SerializeObjToJson(triangle);
            var objFromJson = Figure.DeserializeFromJson(jsonFromObj);
            var jsonFromList = Figure.SerializeListToJson(figList);
            var jsonFromDic = Figure.SerializeDictToJson(figDic);
            var listFromJson = Figure.DeserializeListFromJson(jsonFromList);
            var dicFromJson = Figure.DeserializeDicFromJson(jsonFromDic);
            Console.WriteLine($"Это возврат метода SerializeObj: {jsonFromObj}");
            Console.WriteLine($"Это возврат метода SerializeList:{jsonFromList}");
            Console.WriteLine($"Это возврат метода SerializeDict: (вложенный)  {jsonFromDic}");
            Console.WriteLine($"Это возврат метода DeserializeObjFromJson: {objFromJson.Name} {objFromJson.SideCount}" +
                $" {objFromJson.SideLength}{objFromJson.Figure1} \n");

            Console.WriteLine($"Это возврат метода DeserializeListFromJson: \n");
            foreach (var item in listFromJson)
            {
                Console.WriteLine($" {item.Name}{item.SideCount}{item.SideLength}");
            }

            Console.WriteLine($"Это возврат метода DeserializeDicFromJson  \n");
            foreach (var item in dicFromJson)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine($"{item.Value.Name} {item.Value.SideLength} " +
                    $"{item.Value.SideLength} {item.Value.Figure1}");
            }






        }
    }
}
