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

namespace CodeLingo.Quiz6
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
            QuizTemplate.current_score = 0;
        }

        private void Answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Answer.Text.Trim() == "25")
            {
                QuizTemplate.current_score = 100;
            }
            else
            {
                QuizTemplate.current_score = 0;
            }
        }
    }
}
