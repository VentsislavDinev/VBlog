using Abp.Application.Navigation;
using System.Collections.Generic;

namespace VBlog.Data.ViewModel.Layout
{
    public class SocialMenuViewModel
    {
        public IReadOnlyList<UserMenu> SocialMenu { get; set; }
    }
}
