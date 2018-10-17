using System;
using System.Reflection;

namespace Deneme_DispatchProxy
{
    public class OpsProxy:DispatchProxy
    {
        private object target;

        public void SetTarget(object target)
        {
            this.target = target;
        }
        
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine("begin");
            var result = targetMethod.Invoke(target, args);
            Console.WriteLine("end");

            return result;
        }
    }
}
