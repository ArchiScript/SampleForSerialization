using System;
using System.Collections.Generic;
using System.Text;

namespace SampleForSerialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
