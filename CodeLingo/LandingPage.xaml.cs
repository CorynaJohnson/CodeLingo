using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public string name;
        private float score_total;
        public LandingPage()
        {
            InitializeComponent();
            LandingTitle.Content = LandingTitle.Content + getUserName() + "!";
        }
        public LandingPage(string username)
        {
            InitializeComponent();
            name = username;
            LandingTitle.Content = LandingTitle.Content + username + "!";
            ViewableQuizzes();
            ViewableScores();
        }

        public string getUserName()
        {
            return name;
        }

        /******************************************************
        * Purpose: Get the pages in each of the lessons
        * Usage: Folder must be in format: Lesson#
        *        Pages must be in format: Page#
        ******************************************************/
        public static List<Page> GetPagesInLesson(int lesson)
        {
            List<Page> pages = new List<Page>();
            Assembly asm = Assembly.GetExecutingAssembly();
            string name_space = "CodeLingo.Lesson" + lesson.ToString();

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == name_space)
                {
                    string n = type.Namespace + "." + type.Name;
                    if (type.Name.Length < 6)
                    {
                        Page p = asm.CreateInstance(n, true) as Page;
                        pages.Add(p);
                    }
                }
            }
            //this loop is here because Page10+will be out of order because VS doesn't know that 9 < 10 -_-
            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == name_space)
                {
                    string n = type.Namespace + "." + type.Name;
                    if (type.Name.Length == 6)
                    {
                        Page p = asm.CreateInstance(n, true) as Page;
                        pages.Add(p);
                    }
                }
            }

            return pages;
        }

        /******************************************************
        * Purpose: Get the pages in each of the quizzes
        * Usage: Folder must be in format: Quiz#
        *        Pages must be in format: Page#
        ******************************************************/
        public static List<Page> GetPagesInQuiz(int quiz)
        {
            List<Page> pages = new List<Page>();
            Assembly asm = Assembly.GetExecutingAssembly();
            string name_space = "CodeLingo.Quiz" + quiz.ToString();

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == name_space)
                {
                    string n = type.Namespace + "." + type.Name;
                    if (type.Name.Length < 6)
                    {
                        Page p = asm.CreateInstance(n, true) as Page;
                        pages.Add(p);
                    }
                }
            }
            //this loop is here because Page10+will be out of order because VS doesn't know that 9 < 10 -_-
            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == name_space)
                {
                    string n = type.Namespace + "." + type.Name;
                    if (type.Name.Length == 6)
                    {
                        Page p = asm.CreateInstance(n, true) as Page;
                        pages.Add(p);
                    }
                }
            }

            return pages;
        }


        /******************************************************
        * Purpose: Go to the first lesson
        ******************************************************/
        //private void Lesson1Button_Click(object sender, RoutedEventArgs e)
        //{
        //    List<Page> pages = GetPagesInLesson(1);
        //    LessonTemplate page = new LessonTemplate(1, pages);
        //    page.Show();
        //    this.Hide();
        //}


        /******************************************************
        * Purpose: Look at each button_Uid and go to the 
        *           lesson that suits the number in Uid
        ******************************************************/
        private void lesson_button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int button_id = Int32.Parse(button.Uid);
            List<Page> pages = GetPagesInLesson(button_id);
            LessonTemplate page = new LessonTemplate(button_id, pages, name);
            page.Show();
            this.Hide();
        }

        private void ViewableQuizzes()
        {
            if (IsLessonComplete(2))
                Quiz2Button.Visibility = Visibility.Visible;
            if (IsLessonComplete(3))
                Quiz3Button.Visibility = Visibility.Visible;
            if (IsLessonComplete(4))
                Quiz4Button.Visibility = Visibility.Visible;
            if (IsLessonComplete(5))
                Quiz5Button.Visibility = Visibility.Visible;
        }

        private void ViewableScores()
        {
            if (IsScored(2))
            {
                Quiz2Score.Content = score_total + "%";
                Quiz2Score.Visibility = Visibility.Visible;
            }
            if (IsScored(3))
            {
                Quiz3Score.Content = score_total + "%";
                Quiz3Score.Visibility = Visibility.Visible;
            }
            if (IsScored(4))
            {
                Quiz4Score.Content = score_total + "%";
                Quiz4Score.Visibility = Visibility.Visible;
            }
            if (IsScored(5))
            {
                Quiz5Score.Content = score_total + "%";
                Quiz5Score.Visibility = Visibility.Visible;
            }
        }

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

        private bool IsLessonComplete(int lessonnumber)
        {
            bool isComplete = false;
            using (SqlConnection myConnection = Connect_to_Database())
            {
                SqlDataReader myReaderPass = null;

                string myCommandPass = "SELECT userID FROM CL_User WHERE m_username = @username_val";
                using (SqlCommand cmd = new SqlCommand(myCommandPass, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username_val", name);

                    myReaderPass = cmd.ExecuteReader();

                    if (myReaderPass.Read())
                    {
                        int user_id = Int32.Parse(myReaderPass["userID"].ToString());

                        myCommandPass = "SELECT * FROM CL_LessonsCompleted WHERE userID = @userid AND lessonID = @lessonnumber";
                        using (SqlCommand command = new SqlCommand(myCommandPass, myConnection))
                        {
                            command.Parameters.AddWithValue("@userid", user_id);
                            command.Parameters.AddWithValue("@lessonnumber", lessonnumber);
                            myReaderPass = command.ExecuteReader();

                            if (myReaderPass.Read())
                            {
                                isComplete = true;
                            }
                        }
                    }
                }

                myConnection.Close();
            }
            return isComplete;
        }

        private bool IsScored(int quiznumber)
        {
            bool isScored = false;
            using (SqlConnection myConnection = Connect_to_Database())
            {
                SqlDataReader myReaderPass = null;

                string myCommandPass = "SELECT userID FROM CL_User WHERE m_username=@username_val";
                using (SqlCommand cmd = new SqlCommand(myCommandPass, myConnection))
                {
                    cmd.Parameters.AddWithValue("@username_val", name);

                    myReaderPass = cmd.ExecuteReader();

                    if (myReaderPass.Read())
                    {
                        int user_id = Int32.Parse(myReaderPass["userID"].ToString());

                        myCommandPass = "SELECT m_score FROM CL_Scores WHERE userID=@userid AND quizID IN" +
                            " (SELECT quizID FROM CL_Quizzes WHERE lessonID=@lessonnumber)";


                        using (SqlCommand command = new SqlCommand(myCommandPass, myConnection))
                        {
                            command.Parameters.AddWithValue("@userid", user_id);
                            command.Parameters.AddWithValue("@lessonnumber", quiznumber);
                            myReaderPass = command.ExecuteReader();

                            List<int> scores = new List<int>();
                            if (myReaderPass.HasRows)
                                isScored = true;
                            else
                                isScored = false;
                            while (myReaderPass.HasRows)
                            {
                                while (myReaderPass.Read())
                                    //scores[i] = Int32.Parse(myReaderPass["m_score"].ToString());
                                    scores.Add(Int32.Parse(myReaderPass.GetValue(0).ToString()));                                
                                myReaderPass.NextResult();                                
                            }
                            
                            if(isScored)
                            {
                                for (int i = 0; i < scores.Count; i++)
                                    score_total += scores[i];
                                score_total /= scores.Count*100;
                                score_total *= 100;
                                score_total = (float) Math.Round(score_total, 1);
                            }
                        }
                    }
                }

                myConnection.Close();
            }
            return isScored;
        }

        /***************************************
        *   Returns user to the login page
        ***************************************/
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginPage page = new LoginPage();
            page.Show();
            this.Hide();
        }

        /******************************************************
        * Purpose: Look at each button_Uid and go to the 
        *           quiz that suits the number in Uid
        ******************************************************/
        private void Quiz_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int button_id = Int32.Parse(button.Uid);
            List<Page> pages = GetPagesInQuiz(button_id);
            QuizTemplate page = new QuizTemplate(button_id, pages, name);
            page.Show();
            this.Hide();
        }
    }
}
