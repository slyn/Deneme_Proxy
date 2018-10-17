using System;
using System.Dynamic;
using System.Reflection;

namespace Deneme_DynamicObject
{
    public class Wrapper : DynamicObject
    {
        readonly object _target;

        public Wrapper(object target)
        {
            _target = target;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine("before invoking " + binder.Name);

            result = _target.GetType().InvokeMember(binder.Name, BindingFlags.InvokeMethod, null, _target, args);

            Console.WriteLine("after invoking " + binder.Name);
            return true;
        }
    }
}
