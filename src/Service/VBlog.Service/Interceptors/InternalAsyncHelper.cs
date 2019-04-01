using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Service.Interceptors
{

    /// <summary>
    /// The internal async helper.
    /// </summary>
    internal static class InternalAsyncHelper
    {
        /// <summary>
        /// The await task with post action and finally.
        /// </summary>
        /// <param name="actualReturnValue">
        /// The actual return value.
        /// </param>
        /// <param name="postAction">
        /// The post action.
        /// </param>
        /// <param name="finalAction">
        /// The final action.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task AwaitTaskWithPostActionAndFinally(Task actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        {
            Exception exception = null;

            try
            {
                await actualReturnValue;
                await postAction();
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        /// <summary>
        /// The await task with post action and finally and get result.
        /// </summary>
        /// <param name="actualReturnValue">
        /// The actual return value.
        /// </param>
        /// <param name="postAction">
        /// The post action.
        /// </param>
        /// <param name="finalAction">
        /// The final action.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<T> AwaitTaskWithPostActionAndFinallyAndGetResult<T>(Task<T> actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        {
            Exception exception = null;

            try
            {
                var result = await actualReturnValue;
                await postAction();
                return result;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        /// <summary>
        /// The call await task with post action and finally and get result.
        /// </summary>
        /// <param name="taskReturnType">
        /// The task return type.
        /// </param>
        /// <param name="actualReturnValue">
        /// The actual return value.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="finalAction">
        /// The final action.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object CallAwaitTaskWithPostActionAndFinallyAndGetResult(Type taskReturnType, object actualReturnValue, Func<Task> action, Action<Exception> finalAction)
        {
            return typeof(InternalAsyncHelper)
                .GetMethod("AwaitTaskWithPostActionAndFinallyAndGetResult", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod(taskReturnType)
                .Invoke(null, new object[] { actualReturnValue, action, finalAction });
        }
    }
}
