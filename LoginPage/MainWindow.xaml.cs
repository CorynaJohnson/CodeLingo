using System;
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
using DevOne.Security.Cryptography.BCrypt;
using System.Data.SqlClient;



namespace LoginPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SqlConnection myConnection = Connect_to_Database();

            //example read from sql server
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from CL_UserInformation",
                                                         myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["Column1"].ToString());
                    Console.WriteLine(myReader["Column2"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            


            //close the connection to the database
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private SqlConnection Connect_to_Database()
        {
            SqlConnection myConnection = new SqlConnection("user id=CodeLingo_app;" +
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameField.Text;
            string username = UserNameField.Text;
            string password = PasswordField.Password;
            password = Hash_Password(password);
            Insert_UserInformation(name, username, password);
        }

        private void Insert_UserInformation(string name, string username, string password)
        {
            SqlConnection myConnection = Connect_to_Database();
            

            //preventing SQL injection example
            var sql = "INSERT INTO CL_UserInformation (m_name, m_username, m_password)" +
                "VALUES (@name_val, @username_val, @password_val);";

            using (var cmd = new SqlCommand(sql, myConnection))
            {
                cmd.Parameters.Add("@name_val", name);
                cmd.Parameters.Add("@username_val", username);
                cmd.Parameters.Add("@password_val", password);
                cmd.Connection = myConnection;
                cmd.ExecuteNonQuery();
            }
            myConnection.Close();
        }

        /*******************************************
        * Purpose: Will hash the user's password.
        ********************************************/
        private string Hash_Password(string password)
        {
            string salt = BCryptHelper.GenerateSalt(6);
            var hashedPassword = BCryptHelper.HashPassword(password, salt);
            Console.WriteLine(BCryptHelper.CheckPassword(password, hashedPassword));
            return hashedPassword;
        }
        //public void CreateMyPasswordTextBox()
        //{
        //    // Create an instance of the TextBox control.
        //    System.Windows.Forms.TextBox Password = new System.Windows.Forms.TextBox();
        //    // Set the maximum length of text in the control to eight.
        //    Password.MaxLength = 8;
        //    // Assign the asterisk to be the password character.
        //    Password.PasswordChar = '*';
        //}
    }
}
