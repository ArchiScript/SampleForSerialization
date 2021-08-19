using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SampleForSerialization
{
    [Serializable]
  public  class Figure
    {
        public string Name { get; set; }
        public int SideCount { get; set; }
        public double SideLength { get; set; }
        public Figure Figure1 { get; set; }
                
    }




}
