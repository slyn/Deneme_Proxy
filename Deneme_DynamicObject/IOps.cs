using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme_DynamicObject
{
    public interface IOps
    {
        string Name { get; set; }
        int Add(int a, int b);
    }
}
