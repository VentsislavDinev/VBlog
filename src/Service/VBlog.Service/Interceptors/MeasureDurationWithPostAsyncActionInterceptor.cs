using Castle.Core.Logging;
using Castle.DynamicProxy;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace VBlog.Service.Interceptors
{

    /// <summary>
    /// The measure duration with post async action interceptor.
    /// </summary>
    public class MeasureDurationWithPostAsyncActionInterceptor : IInterceptor
    {
        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasureDurationWithPostAsyncActionInterceptor"/> class.
        /// </summary>
        public MeasureDurationWithPostAsyncActionInterceptor()
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

            //Wait task execution and modify return value
            if (invocation.Method.ReturnType == typeof(Task))
            {
                invocation.ReturnValue = InternalAsyncHelper.AwaitTaskWithPostActionAndFinally(
                    (Task)invocation.ReturnValue,
                    async () => await TestActionAsync(invocation),
                    ex =>
                    {
                        LogExecutionTime(invocation, stopwatch);
                    });
            }
            else //Task<TResult>
            {
                invocation.ReturnValue = InternalAsyncHelper.CallAwaitTaskWithPostActionAndFinallyAndGetResult(
                    invocation.Method.ReturnType.GenericTypeArguments[0],
                    invocation.ReturnValue,
                    async () => await TestActionAsync(invocation),
                    ex =>
                    {
                        LogExecutionTime(invocation, stopwatch);
                    });
            }
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
            LogExecutionTime(invocation, stopwatch);
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
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }

        /// <summary>
        /// The test action async.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task TestActionAsync(IInvocation invocation)
        {
            Logger.Info("Waiting after method execution for " + invocation.MethodInvocationTarget.Name);
            await Task.Delay(200); //Here, we can await another methods. This is just for test.
            Logger.Info("Waited after method execution for " + invocation.MethodInvocationTarget.Name);
        }

        /// <summary>
        /// The log execution time.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        /// <param name="stopwatch">
        /// The stopwatch.
        /// </param>
        private void LogExecutionTime(IInvocation invocation, Stopwatch stopwatch)
        {
            stopwatch.Stop();
            Logger.InfoFormat(
                "MeasureDurationWithPostAsyncActionInterceptor: {0} executed in {1} milliseconds.",
                invocation.MethodInvocationTarget.Name,
                stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                );
        }
    }
}
