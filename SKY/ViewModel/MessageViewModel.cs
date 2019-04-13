using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SKY
{
    /// <summary>
    /// A view model for the addpage page
    /// </summary>
    public class MessageViewModel : BaseViewModel
    {
        #region Public Properties
       

        /// <summary>
        /// Email details
        /// </summary>
        public string emailTo { get; set; }
        public string emailSubject { get; set; }
        public string emailMessage { get; set; }

        /// <summary>
        /// Text details
        /// </summary>
        public string textTo { get; set; }
        public string textMessage { get; set; }



        /// <summary>
        /// A flag indicating if the AddPage command is running
        /// </summary>
        public bool MessageIsRunning { get; set; }
        #endregion

        #region Command
        /// <summary>
        /// The command to take you to the dashboard
        /// </summary>
        public ICommand HomeCommand { get; set; }

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand EmailCommand { get; set; }

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
        public ICommand TextCommand { get; set; }

        #endregion

        #region Construtor

        public MessageViewModel()
        {
            //create Command
            HomeCommand = new RelayCommand(async () => await Home());
            EmailCommand = new RelayParameterizedCommand(async (parameter) => await EmailAsync(parameter));
            DashCommand = new RelayCommand(async () => await DashBoard());
            ReminderCommand = new RelayCommand(async () => await Reminder());
            SetiingsCommand = new RelayCommand(async () => await Settings());
            RepairCommand = new RelayCommand(async () => await Repair());
            HelpCommand = new RelayCommand(async () => await Help());
            TextCommand = new RelayParameterizedCommand(async (parameter) => await TextAsync(parameter));


        }


        #endregion

        
         



        /// <summary>
        /// Sending email
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task EmailAsync(object parameter)
        {
            await RunCommand(() => this.MessageIsRunning, async () =>
            {
                await Task.Delay(5000);
                try
                {
                    EmailInfo.credential = new NetworkCredential(EmailInfo.username, EmailInfo.password);
                    EmailInfo.client = new SmtpClient(EmailInfo.smtp);
                    EmailInfo.client.Port = Convert.ToInt32(EmailInfo.port);
                    EmailInfo.client.EnableSsl = true;
                    EmailInfo.client.Credentials = EmailInfo.credential;
                    EmailInfo.message = new MailMessage { From = new MailAddress(EmailInfo.username + EmailInfo.smtp.Replace("smtp.", "@"), "Sky Electronics", Encoding.UTF8) };
                    EmailInfo.message.To.Add(new MailAddress(emailTo));

                    if (!string.IsNullOrEmpty(emailSubject))
                    {
                        EmailInfo.message.Subject = emailSubject;
                        EmailInfo.message.Body = emailMessage;
                        EmailInfo.message.BodyEncoding = Encoding.UTF8;
                        EmailInfo.message.IsBodyHtml = true;
                        EmailInfo.message.Priority = MailPriority.Normal;
                        EmailInfo.message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        EmailInfo.client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
                        string userstate = "Sending...";
                        EmailInfo.client.SendAsync(EmailInfo.message,userstate);
                    }
                    
                }
                catch
                {

                }
            });
        }

        /// <summary>
        /// Feedback for the email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.",e.UserState),"Message",MessageBoxButton.OK, MessageBoxImage.Information);
            if(e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Your email has been successfully sent.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Sending text
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public async Task TextAsync(object parameter)
        {
            await RunCommand(() => this.MessageIsRunning, async () =>
            {
                await Task.Delay(5000);
                try
                {
                    
                }
                catch
                {

                }
            });
        }

        #region Navigation

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

        #endregion
    }
}
