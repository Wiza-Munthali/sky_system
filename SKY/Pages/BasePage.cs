using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System;

namespace SKY
{
    /// <summary>
    /// A base page for all pages to gain base functionallity
    /// </summary>
    public class BasePage : Page
    {

        #region Public Properties

        /// <summary>
        /// The animation that plays when the page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation that plays when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time the slide animation takes to complete

        /// </summary>
        public float SlideSecond { get; set; } = 0.8f;

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            //if we animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            //Listen out the page loading
            this.Loaded += BasePage_Loaded;
 
        }
        #endregion

        #region Animation Load/Unload

        /// <summary>
        /// Once the page is loaded, perform any required animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //Animate the page in
            await AnimateIn();
        }

        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            //make sure we have something to do
            if (this.PageLoadAnimation == PageAnimation.None)
                return;
            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    //Start the animation
                    await this.SlideAndFadeInFromRight(SlideSecond);
                    break;

            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            //make sure we have something to do
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;
            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    //Start the animation
                    await this.SlideAndFadeOutToLeft(SlideSecond);
                    break;

            }
        }
        #endregion
    }

    /// <summary>
    /// A base page with added ViewModel support
    /// </summary>
    public class BasePage<VM>: Page
        where VM: BaseViewModel, new()
    {
        #region Private Member

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private VM mViewModel;
        #endregion


        #region Public Properties


        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        public VM ViewModel {
            get { return mViewModel; }
            set
            {
                //If nothing has changed, return
                if (mViewModel == value)
                    return;

                //update the value
                mViewModel = value;

                // Set the data context for this page
                this.DataContext = mViewModel;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            // Create a default view model
            this.ViewModel = new VM();
        }
        #endregion


    }
}
