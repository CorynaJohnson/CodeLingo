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

namespace CodeLingo.Quiz2
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
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
            if (step1.Content.ToString() == "Define the Problem" && step2.Content.ToString() == "Requirement Specification" &&
                step3.Content.ToString() == "Design" && step4.Content.ToString() == "Implementation" &&
                step5.Content.ToString() == "Testing and Verification" && step6.Content.ToString() == "Repeat steps 3-5" &&
                step7.Content.ToString() == "Maintenance")
            {
                QuizTemplate.current_score = 100;
            }
            else if (step1.Content.ToString() == "Define the Problem" || step2.Content.ToString() == "Requirement Specification" ||
                step3.Content.ToString() == "Design" || step4.Content.ToString() == "Implementation" ||
                step5.Content.ToString() == "Testing and Verification" || step6.Content.ToString() == "Repeat steps 3-5" ||
                step7.Content.ToString() == "Maintenance")
            {
                QuizTemplate.current_score = 50;
            }
            else
                QuizTemplate.current_score = 0;

        }
    }
}
