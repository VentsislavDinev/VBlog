namespace VBlog.Web.Common
{
    using System;

    public static class CacheSetting
    {
        public static class SitemapNodes
        {
            public const string Key = "SitemapNodes";
            public static TimeSpan SlidingExpiration = TimeSpan.FromDays(1);
        }
    }
}