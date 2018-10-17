using System;
using System.Collections.Generic;
using System.Text;

namespace Deneme_DispatchProxy_Decorate
{
    public class Logger:ILogger
    {
        public void Log(string text)

        {
            Console.WriteLine(text);
        }
    }
}
