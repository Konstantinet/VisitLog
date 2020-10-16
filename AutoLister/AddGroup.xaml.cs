using Microsoft.Win32;
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

namespace AutoLister
{
    /// <summary>
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        public AddGroup()
        {
            InitializeComponent();
        }
        Group group = new Group();
        private void SelectGroupListPathButton_Click(object sender, RoutedEventArgs e)
        {
            var OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == true) 
            {
                group.GetMembersFromFile(OPF.FileName);
            }
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
