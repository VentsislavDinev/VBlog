using Castle.Core.Logging;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace VBlog.Service.Interceptors
{

    /// <summary>
    /// The measure duration async interceptor.
    /// </summary>
    public class MeasureDurationAsyncInterceptor : IInterceptor
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasureDurationAsyncInterceptor"/> class.
        /// </summary>
        public MeasureDurationAsyncInterceptor()
        {
            Logger = NullLogger.Instance;
        }

        /// <summary>
        /// The intercept.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        public void Intercept(IInvocation invocation)
        {
            if (IsAsyncMethod(invocation.Method))
            {
                InterceptAsync(invocation);
            }
            else
            {
                InterceptSync(invocation);
            }
        }

        /// <summary>
        /// The intercept async.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        private void InterceptAsync(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Calling the actual method, but execution has not been finished yet
            invocation.Proceed();

            //We should wait for finishing of the method execution
            ((Task)invocation.ReturnValue)
                .ContinueWith(task =>
                {
                    //After method execution
                    stopwatch.Stop();
                    Logger.InfoFormat(
                        "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                        invocation.MethodInvocationTarget.Name,
                        stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                        );
                });
        }

        /// <summary>
        /// The intercept sync.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        private void InterceptSync(IInvocation invocation)
        {
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();

            //After method execution
            stopwatch.Stop();
            this.Logger.InfoFormat(
                "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000"));
        }

        /// <summary>
        /// The is async method.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (method.ReturnType == typeof(Task) || (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }
    }
}
