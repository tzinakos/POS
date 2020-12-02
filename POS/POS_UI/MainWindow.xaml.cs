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
using POS_Business;

namespace POS_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserCRUD userCRUD = new UserCRUD();
        public MainWindow()
        {
            InitializeComponent();
            RefreshUsersList();
        }


        public void RefreshUsersList()
        {
            int userListCount = usersList.Items.Count;
            for (int i = 2; i < userListCount; i++)
            {
                usersList.Items.RemoveAt(2);
            }
            userCRUD.Read();
            foreach(var x in userCRUD.usersList)
            {
                usersList.Items.Add(x.UserName);
            }
            
               
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserPopUp.IsOpen = true;
        }

        private void ACancelButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserPopUp.IsOpen = false;
        }

        private void AUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            
             var userRoleName = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
             userCRUD.Create(userRoleName, userName.Text, userPassword.Password, (DateTime)datePicker.SelectedDate);
             RefreshUsersList();
            AddUserPopUp.IsOpen = false;


        }
    }
}
