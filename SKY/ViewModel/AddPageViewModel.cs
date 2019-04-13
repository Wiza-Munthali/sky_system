using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SKY
{
    /// <summary>
    /// A view model for the addpage page
    /// </summary>
    public class AddPageViewModel : BaseViewModel
    {
        #region Public Properties
        

        /// <summary>
        /// String that holds the serial
        /// </summary>
        public string Serial;

        /// <summary>
        /// Customer details
        /// </summary>
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Brand { get; set; }
        public string Desc { get; set; }
        public string Cid { get; set; }


        /// <summary>
        /// A flag indicating if the AddPage command is running
        /// </summary>
        public bool AddPageIsRunning { get; set; }
        #endregion

        #region Command
        /// <summary>
        /// The command to take you to the dashboard
        /// </summary>
        public ICommand HomeCommand { get; set; }

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand AddCommand { get; set; }

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

        #endregion

        #region Construtor

        public AddPageViewModel()
        {
            //create Command
            HomeCommand = new RelayCommand(async () => await Home());
            AddCommand = new RelayParameterizedCommand(async (parameter) => await AddAsync(parameter));
            DashCommand = new RelayCommand(async () => await DashBoard());
            ReminderCommand = new RelayCommand(async () => await Reminder());
            SetiingsCommand = new RelayCommand(async () => await Settings());
            RepairCommand = new RelayCommand(async () => await Repair());
            HelpCommand = new RelayCommand(async () => await Help());

            //Generating the serial
            SKGL.Generate generate = new SKGL.Generate();
            Serial = generate.doKey(300);
        }


        #endregion

        
         




        public async Task AddAsync(object parameter)
        {

            if (string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname) || string.IsNullOrEmpty(Phone))
            {
                MessageBox.Show("Please fill in all the required fields");
            }
            else
            {
                await Task.Delay(1);
                using (SqlConnection conn = new SqlConnection(DatabaseConnection.DBString))
                {
                    conn.Open();
                    string query = "SELECT * FROM [sky_Device] WHERE serial_NO = '" + Serial + "'";
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sqlData.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Device already exists");
                    }
                    else
                    {
                        
                        string query0 = "SELECT * FROM [sky_Customer] WHERE customer_PhoneNumber = '" + Phone + "'";
                        SqlDataAdapter sqlData0 = new SqlDataAdapter(query, conn);
                        DataTable dt0 = new DataTable();
                        sqlData.Fill(dt0);
                        if (dt0.Rows.Count ==1)
                        {
                            string select = "Select customer_ID FROM [sky_Customer] WHERE customer_PhoneNumber ='" + Phone + "' AND customer_Email='" + Email + "'";

                            try
                            {
                                conn.Open();
                                SqlCommand sql = new SqlCommand(select, conn);
                                SqlDataReader sqlData1;

                                sqlData1 = sql.ExecuteReader();
                                while (sqlData1.Read())
                                {
                                    Cid = sqlData1.GetValue(0).ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { conn.Close(); }
                        }
                        else if(dt0.Rows.Count == 0)
                        {
                            // Inserting in the customer table
                            string query1 = "INSERT INTO [sky_Customer](customer_FirstName,customer_LastName,customer_Email,customer_PhoneNumber) VALUES(@fn, @ln, @e, @pn)";
                            SqlCommand command = new SqlCommand(query1, conn);
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@fn", Firstname);
                            command.Parameters.AddWithValue("@ln", Lastname);
                            command.Parameters.AddWithValue("@e", Email);
                            command.Parameters.AddWithValue("@pn", Phone);



                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }

                            string select = "Select customer_ID FROM [sky_Customer] WHERE customer_PhoneNumber ='" + Phone + "' AND customer_Email='" + Email + "'";

                            try
                            {
                                conn.Open();
                                SqlCommand sql = new SqlCommand(select, conn);
                                SqlDataReader sqlData1;

                                sqlData1 = sql.ExecuteReader();
                                while (sqlData1.Read())
                                {
                                    Cid = sqlData1.GetValue(0).ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { conn.Close(); }

                            // Inserting in the device table
                            string query2 = "INSERT INTO [sky_Device](device_Name,serial_NO,description,Customer_ID) VALUES(@dn, @sn, @d, @cid)";
                            SqlCommand command1 = new SqlCommand(query2, conn);
                            command1.CommandType = CommandType.Text;
                            command1.Parameters.AddWithValue("@dn", Brand);
                            command1.Parameters.AddWithValue("@sn", Serial);
                            command1.Parameters.AddWithValue("@d", Desc);
                            command1.Parameters.AddWithValue("@cid", Cid);

                            try
                            {
                                conn.Open();
                                command1.ExecuteNonQuery();
                                MessageBox.Show("You have been registered successfully");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { conn.Close(); }
                        }
                        else
                        {
                            string select = "Select customer_ID FROM [sky_Customer] WHERE customer_PhoneNumber ='" + Phone + "' AND customer_Email='" + Email + "'";

                            try
                            {
                                conn.Open();
                                SqlCommand sql = new SqlCommand(select, conn);
                                SqlDataReader sqlData1;

                                sqlData1 = sql.ExecuteReader();
                                while (sqlData1.Read())
                                {
                                    Cid = sqlData1.GetValue(0).ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { conn.Close(); }

                            // Inserting in the device table
                            string query2 = "INSERT INTO [sky_Device](device_Name,serial_NO,description,Customer_ID) VALUES(@dn, @sn, @d, @cid)";
                            SqlCommand command1 = new SqlCommand(query2, conn);
                            command1.CommandType = CommandType.Text;
                            command1.Parameters.AddWithValue("@dn", Brand);
                            command1.Parameters.AddWithValue("@sn", Serial);
                            command1.Parameters.AddWithValue("@d", Desc);
                            command1.Parameters.AddWithValue("@cid", Cid);

                            try
                            {
                                conn.Open();
                                command1.ExecuteNonQuery();
                                MessageBox.Show("You have been registered successfully","Notification",MessageBoxButton.OK,MessageBoxImage.Information);


                               


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally { conn.Close(); }
                        }
                        
                    }
                }
                }
            
            
            
        }

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

    }
}
