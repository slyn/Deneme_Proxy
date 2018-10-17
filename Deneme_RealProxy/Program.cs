using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme_RealProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ops = new Operations();
                var proxy = (IOps) new RealBase<IOps>(ops).GetTransparentProxy();
                proxy.Add(3, 4);
                var a = proxy.Age;
                //var b = ((dynamic) proxy).Name; // hata
                //Console.WriteLine("b");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

    }
}
