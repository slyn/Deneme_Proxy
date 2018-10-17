using System.ComponentModel;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace Deneme_RealProxy
{
    public class RealBase<TEntity> : RealProxy where TEntity : class
    {
        private readonly object _obj;
        public RealBase(TEntity obj): base(typeof(TEntity))
        {
            _obj = obj;
        }
        public override IMessage Invoke(IMessage msg)
        {
            ReturnMessage returnMessage = null;

            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;

            //var arguments = methodCall.Args;
            //var methodName = methodCall.MethodName;
            //var returnType = methodInfo?.ReturnType;

            try
            {
                var result = methodInfo.Invoke(_obj, methodCall.InArgs);
                returnMessage = new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (TargetInvocationException exception)
            {
                returnMessage = new ReturnMessage(exception.InnerException, methodCall);
            }

            return returnMessage;
        }
    }
}
