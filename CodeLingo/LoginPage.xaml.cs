using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace CodeLingo
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /*******************************************
        * Purpose: Will login the user.
        ********************************************/
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //LandingPage page = new LandingPage(UserNameField.Text);
            //page.Show();
            //this.Hide();


            if (ValidateUser())
            {
                System.Windows.Forms.MessageBox.Show("Login Successful");

                LandingPage page = new LandingPage(UserNameField.Text);
                page.Show();
                this.Hide();
            }

            else
                System.Windows.Forms.MessageBox.Show("Login failed");
        }

        /*******************************************
        * Purpose: Change to the register page.
        ********************************************/
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage page = new RegistrationPage();
            this.RegistrationSuccessful.Visibility = Visibility.Hidden;
            page.Show();
            this.Hide();
        }

        /*******************************************
        * Purpose: Will connect to the database.
        ********************************************/
        private SqlConnection Connect_to_Database()
        {
            SqlConnection myConnection = new SqlConnection("MultipleActiveResultSets=True;" +
                                       "user id=CodeLingo_app;" +
                                       "password=password;" +
                                       "server=aura.students.cset.oit.edu;");
            //open the connection to the database
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return myConnection;
        }

        /*******************************************
        * Purpose: Validates the user's password.
        ********************************************/
        static private bool ValidatePassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        /*******************************************
        * Purpose: Validates the user.
        ********************************************/
        private bool ValidateUser()
        {
            string username = UserNameField.Text;
            string password = PasswordField.Password;
            bool validuser = false;

            using (SqlConnection myConnection = Connect_to_Database())
            {
                SqlDataReader myReaderPass = null;

                string myCommandPass = "select m_password from CL_User WHERE m_username = @username_val";
                using (SqlCommand cmd = new SqlCommand(myCommandPass, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username_val", username);

                    myReaderPass = cmd.ExecuteReader();
                   
                    if (myReaderPass.Read())
                    {
                        string orig = myReaderPass["m_password"].ToString();
                        if (ValidatePassword(password, orig))
                        {
                            validuser = true;
                        }
                    }
                }
                myConnection.Close();
            }
            return validuser;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                LoginButton_Click(null, null);
        }
    }
}
