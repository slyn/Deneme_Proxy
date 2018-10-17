using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme_RealProxy
{
    public interface IOps
    {
        int Age { get; set; }
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
}
