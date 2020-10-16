using Microsoft.Win32;
using System;
using System.Collections.Generic;

using System.Windows;

namespace AutoLister
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            
            
        }

        private void AddLectionButton_Click(object sender, RoutedEventArgs e)
        {
            var AddLectionWindow = new AddLection();
            AddLectionWindow.Show();
            this.Close();
        }
    }
}
