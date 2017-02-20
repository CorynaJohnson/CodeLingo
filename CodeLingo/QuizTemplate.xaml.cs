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
    /// Interaction logic for QuizTemplate.xaml
    /// </summary>
    public partial class QuizTemplate : Window
    {
        int quiznumber = 0;
        int actual_page = 0;
        public static int current_score;
        string username;
        int current_page
        {
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
                QuizFrame.Navigate(pages[value]);
            }
        }

        List<Page> pages;

        public QuizTemplate(int quiz_number, List<Page> quiz_pages, string name)
        {
            InitializeComponent();
            username = name;
            quiznumber = quiz_number; //lesson that matches quizzes
            Title.Content = Title.Content + quiz_number.ToString();
            pages = quiz_pages;
            current_page = 0;
            //current_page = 10;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //if 0, go back to landing page
            if (current_page == 0)
            {
                LandingPage page = new LandingPage(username);
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
            //go to next available page
            if (current_page != (pages.Count - 1))
            {
                if(current_score == 100)
                    System.Windows.Forms.MessageBox.Show("Correct!");
                else if (current_score > 0 && current_score < 100)
                    System.Windows.Forms.MessageBox.Show("Partial Credit!");
                else
                    System.Windows.Forms.MessageBox.Show("Incorrect!");
                QuizComplete();
                current_page++;
            }
            //if last page, show home button
            if (current_page == (pages.Count - 1))
            {
                //if (current_score > 0)
                //    System.Windows.Forms.MessageBox.Show("Correct!");
                //else
                //    System.Windows.Forms.MessageBox.Show("Incorrect!");
                Home_Button.Visibility = Visibility.Visible;
            }
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            if (current_score == 100)
                System.Windows.Forms.MessageBox.Show("Correct!");
            else if (current_score > 0 && current_score < 100)
                System.Windows.Forms.MessageBox.Show("Partial Credit!");
            else
                System.Windows.Forms.MessageBox.Show("Incorrect!");
            QuizComplete();
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

        private void QuizComplete()
        {
            using (SqlConnection myConnection = Connect_to_Database())
            {
                SqlDataReader myReaderPass = null;

                string myCommandPass = "SELECT userID FROM CL_User WHERE m_username = @username_val";
                //ReadFromDatabase("SELECT userID FROM CL_User WHERE m_username = @0", username);

                using (SqlCommand cmd = new SqlCommand(myCommandPass, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username_val", username);

                    myReaderPass = cmd.ExecuteReader();

                    if (myReaderPass.Read())
                    {
                        int user_id = Int32.Parse(myReaderPass["userID"].ToString());

                        string myCommand = "SELECT quizID FROM CL_Quizzes WHERE lessonID=@lessonnumber AND m_quiz_number=@quiznumber";

                        using (SqlCommand cmd1 = new SqlCommand(myCommand, myConnection))
                        {
                            cmd1.Parameters.AddWithValue("@quiznumber", (current_page + 1));
                            cmd1.Parameters.AddWithValue("@lessonnumber", quiznumber);

                            myReaderPass = cmd1.ExecuteReader();

                            if (myReaderPass.Read())
                            {
                                int quizid = Int32.Parse(myReaderPass["quizID"].ToString());

                                string selectcheck = "SELECT * FROM CL_Scores WHERE userID=@userID AND quizID=@quizID";
                                using (SqlCommand cmd2 = new SqlCommand(selectcheck, myConnection))
                                {
                                    cmd2.Parameters.AddWithValue("@quizID", quizid);
                                    cmd2.Parameters.AddWithValue("@userID", user_id);

                                    myReaderPass = cmd2.ExecuteReader();
                                    
                                    if (myReaderPass.Read())
                                    {
                                        var sql = "UPDATE CL_Scores SET m_score=@score" +
                                        " WHERE userID=@userid AND quizID=@quiznumber;";
                                        using (var command = new SqlCommand(sql, myConnection))
                                        {
                                            command.Parameters.AddWithValue("@userid", user_id);
                                            command.Parameters.AddWithValue("@quiznumber", quizid);
                                            command.Parameters.AddWithValue("@score", current_score);
                                            command.Connection = myConnection;
                                            command.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        var sql = "INSERT INTO CL_Scores (userID, quizID, m_score)" +
                                        "VALUES (@userid, @quiznumber, @score);";
                                        using (var command = new SqlCommand(sql, myConnection))
                                        {
                                            command.Parameters.AddWithValue("@userid", user_id);
                                            command.Parameters.AddWithValue("@quiznumber", quizid);
                                            command.Parameters.AddWithValue("@score", current_score);
                                            command.Connection = myConnection;
                                            command.ExecuteNonQuery();
                                        }
                                    }                                   
                                }
                            }
                        }
                    }
                    myConnection.Close();
                }
            }
        }

        private Dictionary<string, string> ReadFromDatabase(string command, params object[] args)
        {
            using (SqlConnection myConnection = Connect_to_Database())
            {
                SqlDataReader myReaderPass = null;
                using (SqlCommand cmd = new SqlCommand(command, myConnection))
                {
                    for (int i = 0; i < args.Count(); i++)
                        cmd.Parameters.AddWithValue("@" + i, args[i]);

                    myReaderPass = cmd.ExecuteReader();
                    Dictionary<string, string> dict = Enumerable.Range(0, myReaderPass.FieldCount).ToDictionary(i => myReaderPass.GetName(i), i => myReaderPass.GetValue(i).ToString()); 
                    myConnection.Close();
                    return dict;
                }
            }
        }

    }
}
