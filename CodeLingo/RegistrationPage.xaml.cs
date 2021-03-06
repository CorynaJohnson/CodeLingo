﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;



namespace CodeLingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
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
        * Purpose: Will verify valid username and 
        *   verify the passwords are the same.
        ********************************************/
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameField.Text;
            string username = UserNameField.Text;
            string password = PasswordField.Password;
            string passwordverify = PasswordFieldVerify.Password;

            NameError.Visibility = Visibility.Hidden;
            UserNameError.Visibility = Visibility.Hidden;
            EmptyPasswordError.Visibility = Visibility.Hidden;
            PasswordError.Visibility = Visibility.Hidden;
            
            //
            SqlConnection myConnection = Connect_to_Database();

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select m_username from CL_User",
                                                     myConnection);
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                if (myReader["m_username"].ToString() != "")
                {
                    if (myReader["m_username"].ToString() == username)
                    {
                        UserNameError.Visibility = Visibility.Visible;
                        break;
                    }
                }
            }
            //

            
            //checking for blank or invalid fields
            if (name == "")
            {
                NameError.Visibility = Visibility.Visible;
            }
            if (username == "")
            {
                UserNameError.Visibility = Visibility.Visible;
            }

            if (password == "")
            {
                if (password == passwordverify)
                    EmptyPasswordError.Visibility = Visibility.Visible;
                if (PasswordError.Visibility == Visibility.Visible)
                    PasswordError.Visibility = Visibility.Hidden;
            }
            if (password != passwordverify)
            {
                PasswordError.Visibility = Visibility.Visible;
                PasswordField.Clear();
                PasswordFieldVerify.Clear();
                //reset password fields
            }
            if (UserNameError.Visibility == Visibility.Hidden)
            {
                if (password != "" && password == passwordverify)
                    if (name != "")
                        if (username != "")
                        {
                            //connect and insert user information
                            myConnection.Close();
                            password = Hash_Password(password);
                            Insert_UserInformation(name, username, password);
                            //go to login page
                            LoginPage page = new LoginPage();
                            page.RegistrationSuccessful.Visibility = Visibility.Visible;
                            page.Show();
                            this.Hide();
                        }
            }
            else
                myConnection.Close();
        }

        /*******************************************
        * Purpose: Will insert user information into
        *   the database.
        ********************************************/
        private void Insert_UserInformation(string name, string username, string password)
        {
            SqlConnection myConnection = Connect_to_Database();

            //preventing SQL injection... hopefully
            var sql = "INSERT INTO CL_User (m_name, m_username, m_password)" +
                "VALUES (@name_val, @username_val, @password_val);";

            using (var cmd = new SqlCommand(sql, myConnection))
            {
                cmd.Parameters.AddWithValue("@name_val", name);
                cmd.Parameters.AddWithValue("@username_val", username);
                cmd.Parameters.AddWithValue("@password_val", password);
                cmd.Connection = myConnection;
                cmd.ExecuteNonQuery();
            }
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /*******************************************
        * Purpose: Will hash the user's password.
        ********************************************/
        static private string Hash_Password(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 12);
            return hashedPassword;
        }

        /*******************************************
        * Purpose: Will bring the user back to the 
        *   login page
        ********************************************/
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoginPage page = new LoginPage();
            page.Show();
            this.Hide();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                button_Click(null, null);
        }
    }
}
