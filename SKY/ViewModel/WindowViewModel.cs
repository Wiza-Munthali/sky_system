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

        private ApplicationPage currentPage = ApplicationPage.Login;
        public ApplicationPage CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

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
