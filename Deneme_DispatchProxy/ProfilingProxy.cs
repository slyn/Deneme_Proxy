//using System;
//using System.Diagnostics;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;

//namespace Deneme_DispatchProxy
//{
//    public class ProfilingProxy<TInterface,TService> : DispatchProxy 
//        where TInterface : class
//        where TService: class,TInterface,new()
//    {
//        private TService decorated;
//        private bool excludeProperties;
//        private string[] methodsToExcludeFromProfiling;

//        public static TInterface CreateProxy(TService decorated,ProfilingConfiguration config = null)
//        {
//            // call the base class static method to create proxy instance, set the
//            // passed in params and return it
//            object proxy = Create<TInterface,TService>();
//            ((ProfilingProxy)proxy).SetParameters(decorated,config);

//            return (T)proxy;
//        }

//        protected override object Invoke(
//            MethodInfo targetMethod, object[] args)
//        {
//            object result = default(object);
//            result = InvokeInternal(targetMethod,
//                        args,
//                        !ShouldNotProfile(targetMethod));

//            return result;
//        }

//        // See if the current method qualifies for not being profiled i.e. in the
//        // exclusion list or a property with property exclusion enabled.
//        private bool ShouldNotProfile(MethodInfo targetMethod)
//        {
//            return (methodsToExcludeFromProfiling != null &&
//                        methodsToExcludeFromProfiling
//                            .Contains(targetMethod.Name)) ||
//                        (targetMethod.IsProperty() &&
//                            excludeProperties);
//        }

//        private object InvokeInternal(
//            MethodInfo targetMethod,
//                object[] args, bool doProfiling)
//        {
//            object result;
//            Stopwatch stopwatch = null;

//            if (doProfiling)
//            {
//                stopwatch = Stopwatch.StartNew();
//            }

//            result = targetMethod.Invoke(this.decorated, args);

//            // see if this method invocation was an async one
//            var resultAsTask = result as Task;

//            if (resultAsTask != null)
//            {
//                // if yes, then attach a continuation 
//                // when the original task completes
//                resultAsTask.ContinueWith(task =>
//                {
//                    var property = task.GetType()
//                                       .GetTypeInfo()
//                                       .GetProperties()
//                                       .FirstOrDefault(p => p.Name == "Result");

//                    if (property != null)
//                    {
//                        // get the task result
//                        result = property.GetValue(task);

//                        if (doProfiling)
//                        {
//                            stopwatch.Stop();
//                            Log.Logger.Information(
//                                $"ASYNC: Method {this.decorated.GetType().FullName}:{targetMethod.Name} executed in " +
//                                $"{stopwatch.Elapsed.ToString()}");
//                        }
//                    }
//                });
//            }
//            else
//            {
//                if (doProfiling)
//                {
//                    stopwatch.Stop();
//                    Log.Logger.Information(
//                    $"Method {this.decorated.GetType().FullName}:{targetMethod.Name} executed in " +
//                    $"{stopwatch.Elapsed.ToString()}");
//                }
//            }

//            return result;
//        }

//        private void SetParameters(TService decorated, ProfilingConfiguration configuration)
//        {
//            this.decorated = decorated;
//            this.excludeProperties =
//                configuration?.ExcludeProperties ?? true;
//            this.methodsToExcludeFromProfiling =
//                configuration?.MethodNamesToExclude;
//        }
//    }

//    ///
//    /// A simple configuration data structure to pass to the  to let
//    /// it know which methods to exclude from profiling and whether or not to exclude properties from
//    /// being profiled. The default of the ExcludeProperties will be treated as "true" by the
//    /// ProfilingProxy internally
//    /// 

//    public sealed class ProfilingConfiguration
//    {
//        public string[] MethodNamesToExclude { get; set; }

//        public bool ExcludeProperties { get; set; } = true;
//    }

//    internal static class MethodInfoExtensions
//    {
//        internal static bool IsProperty(this MethodInfo methodInfo)
//            => methodInfo.Name.StartsWith("get_") ||
//                methodInfo.Name.StartsWith("set_");
//    }
//}
