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
    /// Interaction logic for Page8.xaml
    /// </summary>
    public partial class Page8 : Page
    {
        public Page8()
        {
            InitializeComponent();
            QuizTemplate.current_score = 0;
        }
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            QuizTemplate.current_score = 0;
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "A")
                QuizTemplate.current_score = 0;
            else if (rb.Name == "B")
                QuizTemplate.current_score = 0;
            else if (rb.Name == "C")
                QuizTemplate.current_score = 100;
            else if (rb.Name == "D")
                QuizTemplate.current_score = 0;
        }
    }
}
