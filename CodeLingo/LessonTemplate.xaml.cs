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

namespace CodeLingo
{
    /// <summary>
    /// Interaction logic for LessonTemplate.xaml
    /// </summary>
    public partial class LessonTemplate : Window
    {
        int actual_page = 0;
        int current_page {
            get
            {
                return actual_page;
            }
            set
            {
                actual_page = value;
                LessonFrame.Navigate(pages[value]);
            }
        }

        List<Page> pages;

        public LessonTemplate(int lesson_number, List<Page> lesson_pages)
        {
            InitializeComponent();
            Title.Content = Title.Content + lesson_number.ToString();
            pages = lesson_pages;
            current_page = 0;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //if 0, go back to landing page
            if (current_page == 0) ;
                //nope
            //else, continue to previous page
            else
                current_page--;
            
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            //if max page, continue to quiz/next lesson
            if (current_page != (pages.Count-1))
                current_page++;
            //else, go to next available page
        
        }
    }
}
