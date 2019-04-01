using Abp.Localization;
using System.Collections.Generic;

namespace VBlog.Data.ViewModel.Layout
{
    public class LanguageSelectionViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }
    }
}
