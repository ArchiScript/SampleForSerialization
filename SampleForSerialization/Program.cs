using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


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
            var person = new Person ( "Славик", 12 );
            
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


            DataSerializer dataSerializer = new DataSerializer();

            string path = Path.Combine("G:", "C#Projects", "SampleForSerialization", "SerializationFiles");
            string binPath = $"{path}\\binSer.txt";
            string xmlPath = $"{path}\\xmlSer.xml";
            string jsonPath = $"{path}\\jsonSer.json";

            string jsonFromObj = dataSerializer.SerializeToJson<Figure>(triangle) ;
            
            var objFromJson = dataSerializer.DeserializeFromJson<Figure>(jsonFromObj);
            var jsonFromList = dataSerializer.SerializeToJson<List<Figure>>(figList);
            var jsonFromDic = dataSerializer.SerializeToJson<Dictionary<string,Figure>>(figDic);

                        var listFromJson = dataSerializer.DeserializeFromJson<List<Figure>>(jsonFromList);
            var dicFromJson = dataSerializer.DeserializeFromJson<Dictionary<string, Figure>>(jsonFromDic);
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

            
            dataSerializer.BinarySerializer(figList, binPath);


            var binSer = dataSerializer.BinaryDeserialize<List<Figure>>(binPath);
            foreach (var item in binSer)
            {
                Console.WriteLine($"Это вывод метода BinaryDeserialize " +
                    $"{item.Name} {item.SideCount} {item.SideLength} {item.Figure1}");
            }

            dataSerializer.SerializeToXml<Figure>(triangle, xmlPath);

           var xmlSer = dataSerializer.DeserializeFromXml<Figure>(xmlPath);
            Console.WriteLine(xmlSer.Name);

            dataSerializer.SerializeToJson<Person>(person, jsonPath);

            var fig = new Figure();
            fig.Display(triangle);
            Console.WriteLine(Figure.Multiply(3, 5));
            var per = new Person();
            per.

        }
    }
}
