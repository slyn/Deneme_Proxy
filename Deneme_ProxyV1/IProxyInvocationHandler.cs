using System;
using System.Reflection;

namespace Deneme_ProxyV1
{
    public interface IProxyInvocationHandler
    {
        Object Invoke(Object proxy, MethodInfo method, Object[] parameters);
    }
}
