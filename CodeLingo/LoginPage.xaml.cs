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
using BCrypt.Net;
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection myConnection = Connect_to_Database();

            bool validusername = false;
            bool validpassword = false;
            string username = UserNameField.Text;
            string password = PasswordField.Password;

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select m_username from CL_UserInformation",
                                                     myConnection);
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                if (myReader["m_username"].ToString() != "")
                {
                    if (myReader["m_username"].ToString() == username)
                    {
                        validusername = true;
                        myConnection.Close();
                        break;
                    }
                }
            }

            if (validusername)
            {
                myConnection = Connect_to_Database();

                SqlDataReader myReaderPass = null;

                string myCommandPass = "select m_password from CL_UserInformation WHERE m_username = '"+username+"'";
                SqlCommand cmd = new SqlCommand(myCommandPass, myConnection);
                
                myReaderPass = cmd.ExecuteReader();
                if (myReaderPass.Read())
                {
                        string orig = myReaderPass["m_password"].ToString();
                        //Console.WriteLine(pass);
                        Console.WriteLine(orig);
                        if(ValidatePassword(password, orig))
                        {
                            validpassword = true;
                        }
                }


                if (validpassword && validusername)
                {
                    System.Windows.Forms.MessageBox.Show("Login Suc");
                    //go to home screen for app
                }

                myConnection.Close();

            }
        }

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

        static private bool ValidatePassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }


    }
}
