using System;
using Castle.DynamicProxy;

namespace Deneme_CastleProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProxyGenerator generator = new ProxyGenerator();
            
            var opItem = generator.CreateClassProxy<Operator>(new ConsoleLogInterceptor(),);
            
            var addResult = opItem.Add(5, 6);

            var age = opItem.Age; // intercepted - virtual property
            var name = opItem.Name; // not intercepted  - non virtual
        }
    }
}
