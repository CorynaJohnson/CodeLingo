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

namespace CodeLingo.Quiz5
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
            QuizTemplate.current_score = 0;
        }

        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            Label lab = sender as Label;
            if (lab != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(lab, lab.Content.ToString(), DragDropEffects.Copy);
            }
        }

        private void Target_Drop(object sender, DragEventArgs e)
        {
            Label lab = sender as Label;
            e.Handled = true;
            string temp = (string)e.Data.GetData(DataFormats.StringFormat);
            lab.Content = temp;
            checkAnswer();
        }

        private void checkAnswer()
        {
            if (Header.Content.ToString() == "cout << \"Enter your age: \";" && Using.Content.ToString() == "cin >> age;")
            {
                QuizTemplate.current_score = 100;
            }
            else if (Header.Content.ToString() == "cout << \"Enter your age: \";" || Using.Content.ToString() == "cin >> age;")
            {
                QuizTemplate.current_score = 50;
            }
            else
                QuizTemplate.current_score = 0;

        }
    }
}
