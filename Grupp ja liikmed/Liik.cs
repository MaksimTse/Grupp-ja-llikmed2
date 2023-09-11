using System;
using System.Collections.Generic;

namespace Grupp_ja_liikmed
{
    public class Liik
    {
        public string Name { get; }
        public int Age { get; }

        public Liik(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }
}
