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
            SqlConnection myConnection = new SqlConnection("user id=coryna_johnson;" +
                                       "password=918210927Cj;" +
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
            /* preventing SQL injection example
            txtNam = getRequestString("CustomerName");
            txtAdd = getRequestString("Address");
            txtCit = getRequestString("City");
            txtSQL = "INSERT INTO Customers (CustomerName,Address,City) Values(@0,@1,@2)";
            db.Execute(txtSQL,txtNam,txtAdd,txtCit);*/

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
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
