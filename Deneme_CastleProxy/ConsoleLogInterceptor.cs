using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Deneme_CastleProxy
{
    public class ConsoleLogInterceptor: IInterceptor
    {
        private int indentation;

        public void Intercept(IInvocation invocation)
        {
            try
            {
                indentation++;
                Console.WriteLine(string.Format("{0} ! {1}", new string(' ', indentation), invocation.Method.Name));
                invocation.Proceed();
            }
            finally
            {
                indentation--;
            }
        }
    }
}
