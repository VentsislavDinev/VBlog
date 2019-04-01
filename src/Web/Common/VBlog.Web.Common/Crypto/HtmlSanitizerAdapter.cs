namespace VBlog.Web.Common.Crypto
{
    using Abp.Application.Services;
    using Ganss.XSS;

    public class HtmlSanitizerAdapter : ApplicationService, ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}