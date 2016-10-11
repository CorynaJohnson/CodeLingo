using System;
using System.Collections.Generic;
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
        public LandingPage(string username)
        {
            InitializeComponent();
            LandingTitle.Content = LandingTitle.Content + username + "!";
        }

        /******************************************************
        * Purpose: Get the pages in each of the lessons
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
                    Page p = asm.CreateInstance(n, true) as Page;
                    pages.Add(p);
                }
            }
            return pages;
        }


        /******************************************************
        * Purpose: Go to the first lesson
        ******************************************************/
        private void Lesson1Button_Click(object sender, RoutedEventArgs e)
        {
            List<Page> pages = GetPagesInLesson(1);
            LessonTemplate page = new LessonTemplate(1, pages);
            page.Show();
            this.Hide();
        }
    }
}
