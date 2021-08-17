using System;
using System.Collections.Generic;
using System.Text;

namespace SampleForSerialization
{
    [Serializable]
    class Figure
    {
        public string Name { get; set; }
        public int SideCount { get; set; }
        public double SideLength { get; set; }
        public Figure Figure1 { get; set; }
    }
}
