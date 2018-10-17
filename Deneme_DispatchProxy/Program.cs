using System;
using System.Reflection;

namespace Deneme_DispatchProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var opsInstance = new Ops();
            var proxy = DispatchProxy.Create<IOps, OpsProxy>();

            ((OpsProxy)proxy).SetTarget(opsInstance);

            proxy.Add(3, 4);
            proxy.Multiply(3, 4);
            // DynamicObject de metotlar . dan sonra bilinmiyor. 
            // DispatchProxy create ile verilen interface kullanılabiliyor.
            // virtual property/method olup olmaması öenmli değil
        }
    }
}
