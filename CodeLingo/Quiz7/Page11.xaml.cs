﻿using System;
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

namespace CodeLingo.Quiz7
{
    /// <summary>
    /// Interaction logic for Page11.xaml
    /// </summary>
    public partial class Page11 : Page
    {
        public Page11()
        {
            InitializeComponent();
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            QuizTemplate.current_score = 0;
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "True")
                QuizTemplate.current_score = 100;
            else
                QuizTemplate.current_score = 0;
        }
    }
}
