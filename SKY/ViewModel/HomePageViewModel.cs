using System;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SKY
{

    /// <summary>
    /// The view model for the login page
    /// </summary>
  public class HomePageViewModel: BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// flag for visibilty
        /// </summary>
        private bool flag;
        public bool VisibilityMod
        {
            get => flag;
            set
            {
                flag = value;
                OnPropertyChanged("VisibilityMod");
            }
        }

        #endregion

        #region Command
        /// <summary>
        /// The command to take you to the dashboard
        /// </summary>
        public ICommand HomeCommand { get; set; }



        /// <summary>
        /// The command to take you to the dashboard
        /// </summary>
        public ICommand DashCommand { get; set; }

        /// <summary>
        /// The command to take you to the reminder page
        /// </summary>
        public ICommand ReminderCommand { get; set; }

        /// <summary>
        /// The command to send you to the settings page
        /// </summary>
        public ICommand SetiingsCommand { get; set; }


        /// <summary>
        /// The command to send you to the repair page
        /// </summary>
        public ICommand RepairCommand { get; set; }

        /// <summary>
        /// The command to send you to the repair page
        /// </summary>
        public ICommand HelpCommand { get; set; }

        /// <summary>
        /// The command to send you to the repair page
        /// </summary>
        public ICommand MessageCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HomePageViewModel()
        {
            //Create command
            HomeCommand = new RelayCommand(async () => await Home());
            DashCommand = new RelayCommand(async () => await DashBoard());
            ReminderCommand = new RelayCommand(async () => await Reminder());
            SetiingsCommand = new RelayCommand(async () => await Settings());
            RepairCommand = new RelayCommand(async () => await Repair());
            HelpCommand = new RelayCommand(async () => await Help());
            MessageCommand = new RelayCommand(async () => await Message());
        }



        #endregion

        /// <summary>
        /// Goes to the Home
        /// </summary>
        public async Task Home()
        {
            //Go to the home page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.HomePage;
            await Task.Delay(1);


        }


        /// <summary>
        /// Goes to the dash
        /// </summary>
        public async Task DashBoard()
        {
            //Go to the dashboard page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.DashBoard;
            await Task.Delay(1);

               
        }

        public async Task Repair()
        {
            //Go to the repair page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Repair;

            await Task.Delay(1);
        }

        /// <summary>
        /// Goes to the settings page
        /// </summary>
        public async Task Settings()
        {
            //Go to the settings page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Settings;
            await Task.Delay(1);


        }

        /// <summary>
        /// Goes to the reminder page
        /// </summary>
        public async Task Reminder()
        {
            //Go to the reminder page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Reminder;
            await Task.Delay(1);


        }


        /// <summary>
        /// Goes to the help page
        /// </summary>
        public async Task Help()
        {
            //Go to the help page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Help;
            await Task.Delay(1);


        }

        /// <summary>
        /// Goes to the message page
        /// </summary>
        public async Task Message()
        {
            //Go to the help page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Message;
            await Task.Delay(1);


        }
    }
}
