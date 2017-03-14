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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            QuizTemplate.current_score = 0;
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            QuizTemplate.current_score = 0;
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "True")
                QuizTemplate.current_score = 0;
            else
                QuizTemplate.current_score = 100;
        }
    }
}
