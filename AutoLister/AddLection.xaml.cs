using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace AutoLister
{
    /// <summary>
    /// Логика взаимодействия для AddLection.xaml
    /// </summary>
    public partial class AddLection : Window
    {
        List<Student> Students = new List<Student>();
        string SavingPath;
        public AddLection()
        {

            InitializeComponent();
        }
        void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var l1 = new Lection(Students, ThemeField.Text, date.DisplayDate);
            var exel = new ExcelApp();
            exel.AddLection(ThemeField.Text,date.DisplayDate, l1.Students);
            exel.SaveBook(SavingPath, $"{ThemeField.Text}_{date.DisplayDate:dd.MM.yy}.xls");

        }

        void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {

                var OPF = new System.Windows.Forms.OpenFileDialog();
                OPF.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                if (OPF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CSVReader reader = new CSVReader();
                    Students = reader.ReadList(OPF.FileName);
                    SelectedFile.Text = OPF.FileName;
                }
               
            
        }
        private void SelectSavePath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if( dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 SavingPath = dialog.SelectedPath; 
            }
        }
    }
}
