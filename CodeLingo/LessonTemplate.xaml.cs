using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace CodeLingo
{
    /// <summary>
    /// Interaction logic for LessonTemplate.xaml
    /// </summary>
    public partial class LessonTemplate : Window
    {
        int lessonnumber = 0;
        int actual_page = 0;
        string username;
        int current_page {
            get
            {
                return actual_page;
            }
            set
            {
                actual_page = value;
                if (current_page == (pages.Count - 1))
                {
                    Home_Button.Visibility = Visibility.Visible;
                }
                LessonFrame.Navigate(pages[value]);
            }
        }

        List<Page> pages;

        public LessonTemplate(int lesson_number, List<Page> lesson_pages, string name)
        {
            InitializeComponent();
            username = name;
            lessonnumber = lesson_number;
            Title.Content = Title.Content + lesson_number.ToString();
            pages = lesson_pages;
            current_page = 0;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //if 0, go back to landing page
            if (current_page == 0)
            {
                LandingPage page = new LandingPage();
                page.Show();
                this.Hide();
            }
            //else, continue to previous page
            else
                current_page--;
            if (current_page != (pages.Count - 1))
            {
                Home_Button.Visibility = Visibility.Hidden;
            }

        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            //if max page, continue to quiz/next lesson
            if (current_page != (pages.Count-1))
                current_page++;
            //else, go to next available page
            if(current_page == (pages.Count-1))
            {
                Home_Button.Visibility = Visibility.Visible;

            }
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            LessonComplete();
            LandingPage page = new LandingPage(username);
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

        private void LessonComplete()
        {
            string completed;
            using (SqlConnection myConnection = Connect_to_Database())
            {
                SqlDataReader myReaderPass = null;

                string myCommandPass = "SELECT userID FROM CL_User WHERE m_username = @username_val";
                using (SqlCommand cmd = new SqlCommand(myCommandPass, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username_val", username);

                    myReaderPass = cmd.ExecuteReader();

                    if (myReaderPass.Read())
                    {
                        int user_id = Int32.Parse(myReaderPass["userID"].ToString());
                        
                        myCommandPass = "SELECT m_completed FROM CL_Lessons WHERE userID = @userid AND lessonID = @lessonnumber";
                        using (SqlCommand command = new SqlCommand(myCommandPass, myConnection))
                        {
                            command.Parameters.AddWithValue("@userid", user_id);
                            command.Parameters.AddWithValue("@lessonnumber", lessonnumber);
                            myReaderPass = command.ExecuteReader();

                            if (myReaderPass.Read())
                            {
                                completed = myReaderPass["m_completed"].ToString();

                                if (completed != "True")
                                {
                                    var sql = "INSERT INTO CL_Lessons (lessonID, m_lesson_name, m_completed, userID) VALUES (@lessonnumber,'LessonComplete', 1, @userid)";
                                    using (var cmd1 = new SqlCommand(sql, myConnection))
                                    {
                                        cmd1.Parameters.AddWithValue("@userid", user_id);
                                        cmd1.Parameters.AddWithValue("@lessonnumber", lessonnumber);
                                        cmd1.Connection = myConnection;
                                        cmd1.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                var sql = "INSERT INTO CL_Lessons (lessonID, m_lesson_name, m_completed, userID) VALUES (@lessonnumber,'LessonComplete', 1, @userid)";
                                using (var cmd1 = new SqlCommand(sql, myConnection))
                                {
                                    cmd1.Parameters.AddWithValue("@userid", user_id);
                                    cmd1.Parameters.AddWithValue("@lessonnumber", lessonnumber);
                                    cmd1.Connection = myConnection;
                                    cmd1.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                myConnection.Close();
            }
        }
    }
}
