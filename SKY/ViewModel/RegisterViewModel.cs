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
    /// The view model for the Register page
    /// </summary>
  public class RegisterViewModel: BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// Email of the user
        /// </summary>
        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        /// <summary>
        /// Firstname of the user
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// lastname of the user
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// password of the user
        /// </summary>
        public string Password { get; set; }



        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning {  get; set;}

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
        public RegisterViewModel()
        {
            //Create command
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }



        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            
                await RunCommand(() => this.RegisterIsRunning, async () => 
                {

                    /*
                    var email = Email;
                    var firstname = Firstname;
                    var lastname = Lastname;
                    var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                    var EncryptedPass= Eramake.eCryptography.Encrypt(pass);*/

                    if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                    {  
                        MessageBox.Show("Please fill in all the fields");
                    }
                    else
                    {
                        await Task.Delay(5000);
                        using (SqlConnection conn = new SqlConnection(DatabaseConnection.DBString))
                        {
                            conn.Open();
                            string query = "SELECT * FROM [User] WHERE user_Email = '" + email + "'";
                            SqlDataAdapter sqlData = new SqlDataAdapter(query, conn);
                            DataTable dt = new DataTable();
                            sqlData.Fill(dt);

                            if (dt.Rows.Count == 1)
                            {
                                MessageBox.Show("User already exists");
                            }
                            else
                            {
                                string query1 = "INSERT INTO [User](user_FirstName,user_LastName,user_Email,user_Password) VALUES(@fn, @ln, @e, @pwd)";
                                SqlCommand command = new SqlCommand(query1, conn);
                                command.CommandType = CommandType.Text;
                                command.Parameters.AddWithValue("@fn", Firstname);
                                command.Parameters.AddWithValue("@ln", Lastname);
                                command.Parameters.AddWithValue("@e", Email);
                                command.Parameters.AddWithValue("@pwd", Password);

                                try
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("You have been registered successfully");

                                    Firstname = "";
                                    Lastname = "";
                                    Email = "";
                                    Password = "";

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally { conn.Close(); }
                            }
                        }
                           
                    }

                    

                   
                }); 
               
        }

        public async Task LoginAsync()
        {
            //Go to the Login page
            //IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Login;
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Login;

            await Task.Delay(1);
        }
    }
}
