using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBlog.Service.Interceptors
{
    using Abp.Application.Services;

    using Castle.Core;
    using Castle.MicroKernel;

    /// <summary>
    /// The measure duration interceptor registrar.
    /// </summary>
    public static class MeasureDurationInterceptorRegistrar
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        public static void Initialize(IKernel kernel)
        {
            kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        /// <summary>
        /// The kernel_ component registered.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="handler">
        /// The handler.
        /// </param>
        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (typeof(IApplicationService).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(MeasureDurationInterceptor)));
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(MeasureDurationAsyncInterceptor)));
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(MeasureDurationWithPostAsyncActionInterceptor)));
            }
        }
    }
}
