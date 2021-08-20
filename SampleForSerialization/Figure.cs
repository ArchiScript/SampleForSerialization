using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SampleForSerialization
{
    [Serializable]
    public class Figure
    {
        public string Name { get; set; }
        public int SideCount { get; set; }
        public double SideLength { get; set; }
        public Figure Figure1 { get; set; }



        

        public static int Multiply(int num1, int num2)
        {
            int result = num1 * num2;
            return result;
        }
        public void Display(Figure fig)
        {
            Console.WriteLine($"Название фигуры {fig.Name}  Кол-во сторон{fig.SideCount} Длина сторон{fig.SideLength} Вложенная фигура{fig.Figure1}");
        }
       
    }




}
