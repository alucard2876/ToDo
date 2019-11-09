using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDo
{
    /// <summary>
    /// Interaction logic for MessageBoxOvveride.xaml
    /// </summary>
    public partial class MessageBoxOvveride : Window
    {
        public MessageBoxOvveride()
        {
            InitializeComponent();
        }
        public MessageBoxOvveride(string mess = "", string title = "")
        {
            InitializeComponent();
            Message.Text = mess;
            TitleName.Text = title;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
