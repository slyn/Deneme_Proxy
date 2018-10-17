using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme_DynamicObject
{
    public class Ops:IOps
    {
        public string Name { get; set; } = "husnu";
        public virtual int Age { get; set; } = 1111;

        public int Add(int a, int b)
        {
            return a + b;
        }
        public virtual int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
