//namespace VBlog.Web.Common.Caching
//{
//    using Abp.Application.Services;
//    using System;
//    using System.Web;

//    public class InMemoryCache : ApplicationService, ICacheService
//    {
//        public T Get<T>(string cacheID, Func<T> getItemCallback) where T : class
//        {
//            T item = HttpRuntime.Cache.Get(cacheID) as T;
//            if (item == null)
//            {
//                item = getItemCallback();
//                HttpContext.Current.Cache.Insert(cacheID, item);
//            }
//            return item;
//        }

//        public void Clear(string cacheId)
//        {
//            HttpRuntime.Cache.Remove(cacheId);
//        }
//    }
//}