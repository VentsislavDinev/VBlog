using Abp.Application.Services;

namespace VBlog.Web.Common.Crypto
{
    public interface ISanitizer : IApplicationService
    {
        string Sanitize(string html);
    }
}