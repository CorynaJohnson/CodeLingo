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
    /// Interaction logic for Lesson_IDE_Setup.xaml
    /// </summary>
    public partial class Lesson_IDE_Setup : Window
    {
        public Lesson_IDE_Setup()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LandingPage page = new LandingPage("Temp");
            page.Show();
            this.Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
