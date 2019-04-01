using Castle.Core.Logging;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace VBlog.Service.Interceptors
{
    /// <summary>
    /// The measure duration interceptor.
    /// </summary>
    public class MeasureDurationInterceptor : IInterceptor
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasureDurationInterceptor"/> class.
        /// </summary>
        public MeasureDurationInterceptor()
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
            //Before method execution
            var stopwatch = Stopwatch.StartNew();

            //Executing the actual method
            invocation.Proceed();

            //After method execution
            stopwatch.Stop();
            Logger.InfoFormat(
                "MeasureDurationInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000"));
        }
    }
}
