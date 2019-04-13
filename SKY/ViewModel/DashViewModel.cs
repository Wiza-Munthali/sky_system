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
  public class DashViewModel: BaseViewModel
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
        /// The command to send you to the Add page
        /// </summary>
        public ICommand AddPageCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DashViewModel()
        {
            //Create command
            DashCommand = new RelayCommand(async () => await DashBoard());
            ReminderCommand = new RelayCommand(async () => await Reminder());
            SetiingsCommand = new RelayCommand(async () => await Settings());
            RepairCommand = new RelayCommand(async () => await Repair());
            AddPageCommand = new RelayCommand(async () => await AddPage());

        }



        #endregion




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
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task Settings()
        {
            //Go to the settings page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Settings;
            await Task.Delay(1);


        }

        /// <summary>
        /// Goes to the reminder page
        /// </summary>
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task Reminder()
        {
            //Go to the reminder page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Reminder;
            await Task.Delay(1);


        }


        /// <summary>
        /// Goes to the Add page
        /// </summary>
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task AddPage()
        {
            //Go to the add page
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.AddPage;
            await Task.Delay(1);


        }

    }
}
