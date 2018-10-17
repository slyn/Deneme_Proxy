using System;

namespace Deneme_DispatchProxy_Decorate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var logger = new Logger();
            var calcFactory = new CalculatorFactory(logger);
            var calc = calcFactory.CreateCalculator();

            calc.Add(3, 4);
        }
    }
}
