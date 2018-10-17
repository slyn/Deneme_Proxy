using System;
using System.Collections.Generic;
using System.Text;

namespace Deneme_CastleProxy
{
    public class Operator
    {
        public string Name { get; set; } = "husnu";
        public virtual int Age { get; set; } = 1111;

        public virtual int Add(int a, int b)
        {
            return a + b;
        }
        public virtual int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
