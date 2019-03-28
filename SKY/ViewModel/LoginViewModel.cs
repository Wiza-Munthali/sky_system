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
  public class LoginViewModel: BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning {  get; set;}

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
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register a new user
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel()
        {
            //Create command
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }



        #endregion

        /// <summary>
        /// A boolean value to ensure the database is connected
        /// </summary>
        /// <returns></returns>
        public bool IsServerConnected()
        {
            using (var Connect = new SqlConnection(DatabaseConnection.DBString))
            {
                try
                {
                    Connect.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
            
                await RunCommand(() => this.LoginIsRunning, async () => 
                {
                    VisibilityMod = true;
                    var email = Email;
                    var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                    var EncryptedPass = Eramake.eCryptography.Encrypt(pass);

                    if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(pass))
                    {
                        MessageBox.Show("Please fill in all the fields");
                        VisibilityMod = false;
                    }
                    else
                    {
                        if (IsServerConnected())
                        {
                            using (SqlConnection conn = new SqlConnection(DatabaseConnection.DBString))
                            {
                                conn.Open();
                                string query = "SELECT * FROM [User] WHERE user_Email = '" + email + "' AND user_Password = '" + pass + "';";
                                SqlDataAdapter sqlData = new SqlDataAdapter(query, conn);
                                DataTable dt = new DataTable();
                                sqlData.Fill(dt);
                                await Task.Delay(5000);
                                if (dt.Rows.Count == 1)
                                {

                                    //Go to Homepage
                                    ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.HomePage;
                                }
                                else
                                {
                                    VisibilityMod = false;
                                    MessageBox.Show("Please check your credentials");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry the server is down at the moment, Please try again later");
                        }

                    }

                   
                
                
                    
                    
                }); 
               
        }

        public async Task RegisterAsync()
        {
            //Go to the register page
            //IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Signin;
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.SignUp;

            await Task.Delay(1);
        }
    }
}
