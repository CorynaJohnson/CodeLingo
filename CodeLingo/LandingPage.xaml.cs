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
using System.Windows.Shapes;

namespace CodeLingo
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public LandingPage(string username)
        {
            InitializeComponent();
            LandingTitle.Content = LandingTitle.Content + username + "!";
        }

        private void Lesson1Button_Click(object sender, RoutedEventArgs e)
        {
            Lesson_IDE_Setup page = new Lesson_IDE_Setup();
            page.Show();
            this.Hide();
        }
    }
}
