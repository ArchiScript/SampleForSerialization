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
            var serTriangle = JsonConvert.SerializeObject(triangle);
            List<Figure> figList = new List<Figure>() { triangle, triangle, triangle };
        }
    }
}
