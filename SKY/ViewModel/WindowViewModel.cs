using System.Windows;
using System.Windows.Input;

namespace SKY
{

    /// <summary>
    /// The view model for the custom flat window
    /// </summary>
  public class WindowViewModel: BaseViewModel
    {
        #region Private Member

        private Window mWindow;

        #endregion

        #region Public Properties
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;
        }

        #endregion
    }
}
