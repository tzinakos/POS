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
using POS_Model;

namespace POS_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserCRUD userCRUD = new UserCRUD();
        TableCRUD tableCRUD = new TableCRUD();
        string selectedTableSite = "";

        bool loggedIn = false;
        public MainWindow()
        {
            InitializeComponent();
            RefreshUsersList();
            RefreshTablesList(selectedTableSite);
        }


        public void RefreshUsersList()
        {
            Style style = this.FindResource("usersListBoxStyle") as Style;

            if (loggedIn == false)
            {

                int userListCount = usersList.Items.Count;
                for (int i = 2; i < userListCount; i++)
                {
                    usersList.Items.RemoveAt(2);
                }
                userCRUD.Read();
                foreach (var x in userCRUD.usersList)
                {
                    usersList.Items.Add(new ListBoxItem { Content = x.UserName });
                }

                for (int i = 2; i < usersList.Items.Count; i++)
                {

                    (usersList.Items[i] as ListBoxItem).Style = style;
                }

            }
            else
            {
                int userListCount = usersList.Items.Count;
                for (int i = 2; i < userListCount; i++)
                {
                    usersList.Items.RemoveAt(2);
                }
                nameLabel.Content = userCRUD.selectedUser.UserName;
                userButton.Content = "Log Out";
                ListBoxItem userPoints = new ListBoxItem { Content = $"Your Points: {userCRUD.selectedUser.UserPoints}" };
                ListBoxItem userRole = new ListBoxItem { Content = $"Role: {userCRUD.GetUserRole(userCRUD.selectedUser.UserID)}" };
                Button changePassword = new Button { Content = "Change Password" };
                changePassword.Click += new RoutedEventHandler(ChangePasswordClick);
                usersList.Items.Add(userRole);
                usersList.Items.Add(userPoints);
                usersList.Items.Add(changePassword);
            }
                
            


        }

        public void RefreshTablesList(string tableSite)
        {
            int tablesList = tableList.Items.Count;
            for (int i = 0; i < tablesList; i++)
            {
                tableList.Items.RemoveAt(0);
            }
            tableCRUD.Read();
            Style style = this.FindResource("tableBoxItem") as Style;
            foreach (var x in tableCRUD.tablesList)
            {
                if (x.TableSite==tableSite)
                {
                    ListBoxItem newItem = new ListBoxItem { Content = x.TableName };
                    newItem.MouseLeftButtonDown += new MouseButtonEventHandler(tableList_MouseRightButtonDown);
                    newItem.Style = style;
                    tableList.Items.Add(newItem);
                }
            }
            
            foreach (var table in tableCRUD.tablesList)
            {
                foreach (var item in tableList.Items)
                {
                    if ((item as ListBoxItem).Content == table.TableName)
                    {
                        if (table.TableStatusID == 1)
                        {
                            (item as ListBoxItem).BorderBrush = new SolidColorBrush { Color = new Color { A = 100, R = 0, G = 255, B = 0 } };
                        
                        }
                        else if (table.TableStatusID == 2)
                        {
                            (item as ListBoxItem).BorderBrush = new SolidColorBrush { Color = new Color { A = 100, R = 255, G = 0, B = 0 } };
                        }
                    }
                }
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

       

        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (usersList.SelectedItem != null)
            {
                if (loggedIn == false)
                {
                    Password.Opacity = 1; Password.IsEnabled = true;
                    LogIn.Opacity = 1; LogIn.IsEnabled = true;
                    userCRUD.SelectUser(((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString());
                    userNameLabel.Content = $"Hi {userCRUD.selectedUser.UserName}, Enter Password to continue";
                }
            }
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (userCRUD.selectedUser.UserPassword == Password.Password)
            {
                userLogInGrid.Width = new GridLength(0);
                tablesGrid.Width = new GridLength(100, GridUnitType.Star);
                loggedIn = true;
                nameLabel.Content = userCRUD.selectedUser.UserName;
                RefreshUsersList();
                RefreshTablesList(selectedTableSite);
            }
            else
            {
                
            }
        }

        private void ChangePasswordClick(object sender, RoutedEventArgs e)
        {
            ChangePasswordPopUp.IsOpen = true;
        }

        private void tableList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            doubleClickOnTable.IsOpen = false;
            doubleClickOnTable.IsOpen = true;
           
            nameLabel.Content = ((sender as ListBox).SelectedItem as ListBoxItem).Content;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            doubleClickOnTable.IsOpen = false;
        }

        private void DeleteTable_Click(object sender, RoutedEventArgs e)
        {
            tableCRUD.Delete(tableCRUD.selectedTable.TableName);
            RefreshTablesList(selectedTableSite);
            doubleClickOnTable.IsOpen = false;
        }

        private void tableList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tableList.SelectedItem != null)
            {
                tableCRUD.selectTable(((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString());
                tableNameLable.Content = tableCRUD.selectedTable.TableName;
                reservationPanel.IsEnabled = true;
            }
        }

        private void ReserveTable_Click(object sender, RoutedEventArgs e)
        {
            tableCRUD.UpdateTableStatus(tableCRUD.selectedTable.TableName, 1);
            tableCRUD.CancelReservation(tableCRUD.selectedTable.TableID);
            RefreshTablesList(selectedTableSite);
            doubleClickOnTable.IsOpen = false;
        }

        private void tableList_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddTablePopUp.IsOpen = false;
            AddTablePopUp.IsOpen = true;
        }

        private void CreateTableCancel_Click(object sender, RoutedEventArgs e)
        {
            AddTablePopUp.IsOpen = false;
        }

        private void CreateTable_Click(object sender, RoutedEventArgs e)
        {
            string tableSite = (tableSiteComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            tableCRUD.Create(tableName.Text, tableSite, userCRUD.selectedUser.UserID,  int.Parse(tableSeats.Text));
            RefreshTablesList(selectedTableSite);
            AddTablePopUp.IsOpen = false;
        }

        private void UpdateTable_Click(object sender, RoutedEventArgs e)
        {
            doubleClickOnTable.IsOpen=false;
            UpdateTablePopUp.IsOpen = true;

        }

        private void updateTableCancel_Click(object sender, RoutedEventArgs e)
        {
            UpdateTablePopUp.IsOpen = false;
        }

        private void UpdateTableButton_Click(object sender, RoutedEventArgs e)
        {
            var tableiD = tableCRUD.selectedTable.TableID;
            tableCRUD.Update(tableCRUD.selectedTable.TableID,updateTableName.Text,int.Parse(updateTableSeats.Text), (updateTableSiteComboBox.SelectedItem as ComboBoxItem).Content.ToString());
            RefreshTablesList(selectedTableSite);
            UpdateTablePopUp.IsOpen = false;
        }

        private void tableSiteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                selectedTableSite = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();
                RefreshTablesList(selectedTableSite);
            }
        }

        private void HumBurger_Click(object sender, RoutedEventArgs e)
        {
            usersList.IsEnabled = !usersList.IsEnabled;
        }

        private void cancelChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordPopUp.IsOpen = false;
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            var user = userCRUD.selectedUser;
            if (user.UserPassword == oldPassword.Password && newPassword.Password == repeatNewPassword.Password)
            {
                userCRUD.Update(user.UserID, user.UserName, newPassword.Password, user.UserPoints, user.UserRoleID, true);
                ChangePasswordPopUp.IsOpen = false;
            }
            else if (user.UserPassword != oldPassword.Password)
            {

            }else if (newPassword.Password != repeatNewPassword.Password)
            {

            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tableCRUD.Reserve(tableCRUD.selectedTable.TableID, ReservationName.Text, ReservationPhone.Text, (DateTime)ReservationdatePicker.SelectedDate, int.Parse(ReservationNoOfGuests.Text));
            tableCRUD.UpdateTableStatus(tableCRUD.selectedTable.TableName, 2);
            RefreshTablesList(selectedTableSite);
            reservationPanel.IsEnabled = false;

        }

        private void dummyButton_Click(object sender, RoutedEventArgs e)
        {
            reservationPanel.IsEnabled = !reservationPanel.IsEnabled;
        }
    }
}
