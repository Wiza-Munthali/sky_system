using System;
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
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning;

        #endregion

        #region Command

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel()
        {
            //Create command
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }



        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter"> the <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task Login(object parameter)
        {
                await Task.Delay(500);

                var name = this.Name;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
        }
    }
}
