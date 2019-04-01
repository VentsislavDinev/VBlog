using Abp.Application.Navigation;

namespace VBlog.Data.ViewModel.Layout
{

    /// <summary>
    /// The top menu view model.
    /// </summary>
    public class TopMenuViewModel
    {
        /// <summary>
        /// Gets or sets the main menu.
        /// </summary>
        public UserMenu MainMenu { get; set; }

        /// <summary>
        /// Gets or sets the active menu item name.
        /// </summary>
        public string ActiveMenuItemName { get; set; }
    }
}
