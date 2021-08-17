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
                SideLength = 2
            };
            var serTriangle = JsonConvert.SerializeObject(triangle, Formatting.Indented);
            List<Figure> figList = new List<Figure>() { triangle, triangle, triangle };
            var serListTriangle = JsonConvert.SerializeObject(figList, Formatting.Indented);
            // Console.WriteLine(serTriangle);
            //Console.WriteLine(serListTriangle);
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
            Console.WriteLine(serDic);
            Dictionary<string, int> dic2 = new Dictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                dic2.Add($"dklfjj{i}", i);
            }
            string dic2ser = JsonConvert.SerializeObject(dic2.Keys, Formatting.Indented);
            Console.WriteLine(dic2ser);
        }
    }
}
