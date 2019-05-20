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
using System.Net;
using System.Net.Mail;
using MailSenderLib;
using Lesson1.Components;
using Xceed;

namespace Lesson1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            EmailSendServiceClass.Send(email.Text, PasswordBox.Password);
        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnLeftButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemsControl tab_control)) return;
            tab_control.RightButtonVisible = true;
            tab_control.LeftButtonVisible = MainTabControl.SelectedIndex > 0;
            if (tab_control.LeftButtonVisible)
                MainTabControl.SelectedIndex--;  
        }

        private void OnRightButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemsControl tab_control)) return;
            tab_control.LeftButtonVisible = true;
            tab_control.RightButtonVisible = MainTabControl.SelectedIndex < MainTabControl.Items.Count-1;
            if (tab_control.RightButtonVisible)
                MainTabControl.SelectedIndex++;
        }

        private void GoToSheduler_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 0;
        }
    }
}
