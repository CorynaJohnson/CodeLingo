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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeLingo.Quiz3
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
        }

        private void Answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Answer1.Text.ToLower().Trim() == "/*" && Answer2.Text.ToLower().Trim() == "*/")
            {
                Code.Foreground = new SolidColorBrush(Colors.DarkGreen); 
                QuizTemplate.current_score = 100;
            }
            else
            {
                Code.Foreground = new SolidColorBrush(Colors.Black);
                QuizTemplate.current_score = 0;
            }
        }
    }
}
