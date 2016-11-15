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
    /// Interaction logic for Page10.xaml
    /// </summary>
    public partial class Page10 : Page
    {
        public Page10()
        {
            InitializeComponent();
            //AddHandler(FrameworkElement.MouseDownEvent, new MouseButtonEventHandler(Label_MouseDown), true);
        }        

        private void Drop1_Drop(object sender, DragEventArgs e)
        {
            Label lab = sender as Label;
            if (lab != null)
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    //get the data in the argument passed
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    lab.Content = dataString;

                }
            }
        }
        bool isSelected = false;
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isSelected = true;
            UpdateUIElementPosistion(sender as Control);
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isSelected = false;
        }

        
        void UpdateUIElementPosistion(Control element)
        {
            System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(delegate ()
            {
                while (isSelected)
                {
                    element.Dispatcher.Invoke(new Action(delegate ()
                    {
                        element.Margin = new Thickness(Mouse.GetPosition(null).X, Mouse.GetPosition(null).Y, 0, 0);
                    }));
                    
                }
                
            }));
            t1.Start();
        }
    }
}
