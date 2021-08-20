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

        public Person(string name, int age)
        {
            name = Name;
            age = Age;

        }
        private string StrangeName(string name)
        {
            return name + " ибн Хаттаб";
        }
    }

}
