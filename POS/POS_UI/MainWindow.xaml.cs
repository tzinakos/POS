using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using POS_Business;
using POS_Model;
using System.Collections.Generic;

namespace POS_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserCRUD userCRUD = new UserCRUD();
        TableCRUD tableCRUD = new TableCRUD();
        ProductCategoryCRUD productCategoryCRUD = new ProductCategoryCRUD();
        ProductCRUD productCRUD = new ProductCRUD();
        OrderCRUD orderCRUD = new OrderCRUD();
        AllergenCRUD allergenCRUD = new AllergenCRUD();
        string selectedTableSite = "";
        public int TotalItems { get; set; } = 0;
        public double TotalPrice { get; set; } = 0;
        public Dictionary<Order,List<Product>> newOrder = new Dictionary<Order,List<Product>>();

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
                for (int i = 1; i < userListCount; i++)
                {
                    usersList.Items.RemoveAt(1);
                }
                userCRUD.Read();
                foreach (var x in userCRUD.usersList)
                {
                    usersList.Items.Add(new ListBoxItem { Content = x.UserName });
                }

                for (int i = 1; i < usersList.Items.Count; i++)
                {
                    
                    (usersList.Items[i] as ListBoxItem).Style = style;
                }
                Button AddUser = new Button
                {
                    Content = "Add User",
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 120,
                    Height = 40,
                    Foreground = Brushes.White,
                    Background = new SolidColorBrush { Color = new Color { A = 0, G = 128, R = 0, B = 0 } },
                    BorderBrush = new SolidColorBrush { Color = new Color { A = 255, G = 255, R = 0, B = 0 } },
                    VerticalAlignment = VerticalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };
                AddUser.Click += new RoutedEventHandler(Button_Click);
                usersList.Items.Add(AddUser);
              
            }
            else
            {
                int userListCount = usersList.Items.Count;
                for (int i = 1; i < userListCount; i++)
                {
                    usersList.Items.RemoveAt(1);
                }
                nameLabel.Content = userCRUD.selectedUser.UserName;
                //userButton.Content = "Log Out";
                ListBoxItem userPoints = new ListBoxItem { Content = $"Your Points: {userCRUD.selectedUser.UserPoints}" };
                ListBoxItem userRole = new ListBoxItem { Content = $"Role: {userCRUD.GetUserRole(userCRUD.selectedUser.UserID)}" };
                Button changePassword = new Button
                {
                    Content = "Change Password",
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 120,
                    Height = 40,
                    Foreground = Brushes.White,
                    Background = new SolidColorBrush { Color = new Color { A = 0, G = 128, R = 0, B = 0 } },
                    BorderBrush = new SolidColorBrush { Color = new Color { A = 255, G = 255, R = 0, B = 0 } },
                    VerticalAlignment = VerticalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };
                Button LogOut = new Button
                {
                    Content = "Log Out",
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 120,
                    Height = 40,
                    Foreground = Brushes.White,
                    Background = new SolidColorBrush { Color = new Color { A = 0, G = 128, R = 0, B = 0 } },
                    BorderBrush = new SolidColorBrush { Color = new Color { A = 255, G = 255, R = 0, B = 0 } },
                    VerticalAlignment = VerticalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

               
                changePassword.Click += new RoutedEventHandler(ChangePasswordClick);
                
                LogOut.Click += new RoutedEventHandler(LogOutClick);
               
               
                usersList.Items.Add(LogOut);
                usersList.Items.Add(userRole);
                usersList.Items.Add(userPoints);
                usersList.Items.Add(changePassword);
            }
                
            


        }
        private void LogOutClick(object sender, RoutedEventArgs e)
        {
            nameLabel.Content = "Log In";
            loggedIn = false;
            RefreshUsersList();
            usersList.IsEnabled = true;
            tablesGrid.Width = new GridLength(0);
            productsGrid.Width = new GridLength(0);

            reservationPanel.IsEnabled = false;
            OrderPanel.IsEnabled = false;
            userLogInGrid.Width = new GridLength(100, GridUnitType.Star);
        }

        private void AddUserP(object sender, RoutedEventArgs e)
        {
            AddUserPopUp.IsEnabled = true;
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
                    newItem.MouseRightButtonDown += new MouseButtonEventHandler(ListBoxItem_MouseRightButtonDown);
                    newItem.Style = style;
                    tableList.Items.Add(newItem);
                }
            }
            
            foreach (var table in tableCRUD.tablesList)
            {

                if (orderCRUD.GetOrders(table.TableID).Count >= 1)
                {
                    table.TableStatusID = 2;
                }
                else if (tableCRUD.GetReservations(table).Count >= 1)
                {
                    table.TableStatusID = 3;
                }
                else table.TableStatusID = 1;

                foreach (var item in tableList.Items)
                {
                    
                    if ((item as ListBoxItem).Content.ToString() == table.TableName)
                    {
                        


                        if (table.TableStatusID == 2)
                        {
                            (item as ListBoxItem).BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 255, R = 125, G = 0, B = 0 } };
                            
                        
                        }
                        else if (table.TableStatusID == 3)
                        {
                            (item as ListBoxItem).BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 255, R = 125, G = 125, B = 0 } };
                        }
                        else if (table.TableStatusID == 1)
                        {
                            (item as ListBoxItem).BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 255, R = 0, G = 125, B = 0 } };
                            
                        }
                    }
                }
            }
        }
        public void RefreshSubcategoryList(string selectedCategory)
        {
            subcategoryList.Items.Clear();
            productCategoryCRUD.Read();
            Style style = this.FindResource("usersListBoxStyle") as Style;
            
            switch (selectedCategory)
            {
                case "Starters": 
                    foreach(var category in productCategoryCRUD.productCategoriesList)
                    {
                        if (category.ProductCategoryID == 5 || category.ProductCategoryID == 6 || category.ProductCategoryID == 7)
                        {
                            subcategoryList.Items.Add(new ListBoxItem { Content= category.ProductCategoryName});
                            
                        }
                    }
                break;
                case "Main":
                    foreach (var category in productCategoryCRUD.productCategoriesList)
                    {
                        if (category.ProductCategoryID == 8 || category.ProductCategoryID == 9 || category.ProductCategoryID == 10)
                        {
                            subcategoryList.Items.Add(new ListBoxItem { Content = category.ProductCategoryName });
                        }
                    }
                    break;
                case "Deserts":
                    foreach (var category in productCategoryCRUD.productCategoriesList)
                    {
                        if (category.ProductCategoryID == 11 || category.ProductCategoryID == 12 )
                        {
                            subcategoryList.Items.Add(new ListBoxItem { Content = category.ProductCategoryName });
                        }
                    }
                    break;
                case "Drinks":
                    foreach (var category in productCategoryCRUD.productCategoriesList)
                    {
                        if (category.ProductCategoryID == 13 || category.ProductCategoryID == 14 || category.ProductCategoryID == 15)
                        {
                            subcategoryList.Items.Add(new ListBoxItem { Content = category.ProductCategoryName });
                        }
                    }
                    break;
                default:
                    break;
            }
            foreach(var subcategory in subcategoryList.Items)
            {
                (subcategory as ListBoxItem).Style = style;
            }
        }

        public void RefreshReservationDetails(POS_Model.Table selectedTable)
        {
            reservationListBox.Items.Clear();
            var reservations = tableCRUD.GetReservations(selectedTable);

            foreach (var item in reservations)
            {

                //Main Grid
                Grid reservationDetailGrid = new Grid { Width = 350, Height = 150,   Name = $"{item.ReservationName}" };
               
                ColumnDefinition column1 = new ColumnDefinition();
                RowDefinition row1 = new RowDefinition { Height = new GridLength(30) };
                RowDefinition row2 = new RowDefinition{Height = new GridLength(120)};
                reservationDetailGrid.ColumnDefinitions.Add(column1);
                reservationDetailGrid.RowDefinitions.Add(row1);
                reservationDetailGrid.RowDefinitions.Add(row2);

                Label reservationID = new Label
                {
                    Content = $"Reservation ID: {item.ReservationID}",
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center, HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2)
                };
                Grid.SetRow(reservationID, 0);
                reservationDetailGrid.Children.Add(reservationID);
                //Grid for main details attacjed to main grid row1

                Grid mainDetails = new Grid { Width = 350};
                
                RowDefinition row3 = new RowDefinition { Height = new GridLength(30)};
                RowDefinition row4 = new RowDefinition { Height = new GridLength(30) };
                RowDefinition row5 = new RowDefinition { Height = new GridLength(30) };
                RowDefinition row6 = new RowDefinition { Height = new GridLength(30) };
                mainDetails.RowDefinitions.Add(row3);
                mainDetails.RowDefinitions.Add(row4);
                mainDetails.RowDefinitions.Add(row5);
                mainDetails.RowDefinitions.Add(row6);

                ColumnDefinition column2 = new ColumnDefinition();
                ColumnDefinition column3 = new ColumnDefinition();
                mainDetails.ColumnDefinitions.Add(column2);
                mainDetails.ColumnDefinitions.Add(column3);


                Label reservationName = new Label
                {
                    Content = $"Reservation Name: ",
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250,
                   
                };

                Label reservationNameValue = new Label
                {
                    Content = $"{item.ReservationName}",
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250,
                   
                };

                Label reservationPhone = new Label
                {
                    Content = $"Reservation Phone: ",
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250,
                    
                };

                Grid.SetRow(reservationPhone, 1);
                Grid.SetColumn(reservationPhone, 0);

                Label reservationPhoneValue = new Label
                {
                    Content = item.ReservationTelephoneNumber,
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250
                   
                };

         

                Grid.SetRow(reservationPhoneValue, 1);
                Grid.SetColumn(reservationPhoneValue, 1);


                mainDetails.Children.Add(reservationPhone);
                mainDetails.Children.Add(reservationPhoneValue);

                Label reservationDate = new Label
                {
                    Content = $"Reservation Date: ",
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250
                    
                };

                Grid.SetRow(reservationDate, 2);
                Grid.SetColumn(reservationDate, 0);
                mainDetails.Children.Add(reservationDate);

                Label reservationDateValue = new Label
                {
                    Content = item.ReservationDate,
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250
                };

                Grid.SetRow(reservationDateValue, 2);
                Grid.SetColumn(reservationDateValue, 1);
                mainDetails.Children.Add(reservationDateValue);

                Label reservationGuests = new Label
                {
                    Content = "Guests: ",
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250
                };

                Grid.SetRow(reservationGuests, 3);
                Grid.SetColumn(reservationGuests, 0);
                mainDetails.Children.Add(reservationGuests);

                Label reservationGuestsValue = new Label
                {
                    Content = item.NumberOfGuests,
                    Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    VerticalAlignment = VerticalAlignment.Top,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                    BorderThickness = new Thickness(0, 0, 0, 2),
                    Width = 250
                };

                Grid.SetRow(reservationGuestsValue, 3);
                Grid.SetColumn(reservationGuestsValue, 1);
                mainDetails.Children.Add(reservationGuestsValue);


                Grid.SetRow(reservationName, 0);
                Grid.SetRow(reservationNameValue, 0);
                Grid.SetColumn(reservationNameValue, 1);
                Grid.SetColumn(reservationName, 0);
                mainDetails.Children.Add(reservationName);
                mainDetails.Children.Add(reservationNameValue);



                Grid.SetRow(mainDetails, 1);
                reservationDetailGrid.Children.Add(mainDetails);
                
                reservationListBox.Items.Add(reservationDetailGrid);


            }
        }
        private void RefreshProducts(ProductCategory selectedProductCategory)
        {
            productsList.Items.Clear();
            foreach (var selectedCategory in productCRUD.GetProducts(selectedProductCategory))
            {
                if (selectedCategory.ProductQuantity != 0)
                {
                    Grid product = new Grid { Width = 250, Height = 150, Margin = new Thickness(10, 10, 10, 10), Background = new SolidColorBrush { Color = new Color { A = 200, R = 30, G = 33, B = 36 } } };
                    RowDefinition row1 = new RowDefinition { Height = new GridLength(60) };
                    RowDefinition row2 = new RowDefinition { Height = new GridLength(90) };
                    ColumnDefinition column0 = new ColumnDefinition { Width = new GridLength(180) };
                    ColumnDefinition column1 = new ColumnDefinition { Width = new GridLength(70) };
                    product.ColumnDefinitions.Add(column0);
                    product.ColumnDefinitions.Add(column1);
                    product.RowDefinitions.Add(row2);
                    product.RowDefinitions.Add(row1);

                    Label productName = new Label
                    {
                        Content = selectedCategory.ProductName,
                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 200, R = 255, G = 255, B = 255 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        FontSize = 20,
                        BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } }
                        //     BorderThickness = new Thickness(0, 0, 0, 2),


                    };
                    productName.MouseDoubleClick += new MouseButtonEventHandler(onProductDoubleClick);

                    Grid.SetColumn(productName, 0);
                    Grid.SetRow(productName, 0);
                    product.Children.Add(productName);
                    Label productPrice = new Label
                    {
                        Content = $"Price:\n£{selectedCategory.ProductPrice}",
                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 255, R = 0, G = 128, B = 0 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                        //    BorderThickness = new Thickness(0, 0, 0, 2),

                    };

                    Grid.SetColumn(productPrice, 1);
                    Grid.SetRow(productPrice, 0);
                    product.Children.Add(productPrice);

                    TextBlock productDescription = new TextBlock
                    {

                        Text = $"Description:\n\"{selectedCategory.ProductDescription}\"",

                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 200, R = 255, G = 255, B = 255 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        TextWrapping = new TextWrapping { },
                        Width = 250
                        ,
                        FontStyle = FontStyles.Italic
                    };
                    Label productAllergen = new Label
                    {
                        Content = $"Allergens:\n{allergenCRUD.Read(selectedCategory.AllergenID)}",
                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 255, R = 128, G = 0, B = 0 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 255, G = 255, B = 255 } },
                        //    BorderThickness = new Thickness(0, 0, 0, 2),

                    };

                    Grid.SetColumn(productAllergen, 1);
                    Grid.SetRow(productAllergen, 1);
                    product.Children.Add(productAllergen);

                    productDescription.MaxWidth = 150;
                    Grid.SetColumnSpan(productDescription, 2);
                    Grid.SetColumn(productDescription, 0);
                    Grid.SetRow(productDescription, 1);
                    product.Children.Add(productDescription);
                    Border border = new Border { Margin = new Thickness(-3), BorderThickness = new Thickness(2), BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 100, R = 0, G = 128, B = 0 } } };
                    Grid.SetColumn(border, 0);
                    Grid.SetColumnSpan(border, 2);
                    Grid.SetRow(border, 0);
                    Grid.SetRowSpan(border, 2);
                    product.Children.Add(border);

                    product.MouseRightButtonDown += new MouseButtonEventHandler(makeProuctUnavailable);
                    productsList.Items.Add(product);
                }
                else
                {
                    Grid product = new Grid { Width = 250, Height = 150, Margin = new Thickness(10, 10, 10, 10), Background = new SolidColorBrush { Color = new Color { A = 50, R = 30, G = 33, B = 36 } } };
                    RowDefinition row1 = new RowDefinition { Height = new GridLength(60) };
                    RowDefinition row2 = new RowDefinition { Height = new GridLength(90) };
                    ColumnDefinition column0 = new ColumnDefinition { Width = new GridLength(180) };
                    ColumnDefinition column1 = new ColumnDefinition { Width = new GridLength(70) };
                    product.ColumnDefinitions.Add(column0);
                    product.ColumnDefinitions.Add(column1);
                    product.RowDefinitions.Add(row2);
                    product.RowDefinitions.Add(row1);

                    Label productName = new Label
                    {
                        Content = selectedCategory.ProductName,
                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 255, G = 255, B = 255 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        FontSize = 20,
                        BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 255, G = 255, B = 255 } }
                        //     BorderThickness = new Thickness(0, 0, 0, 2),


                    };
                   

                    Grid.SetColumn(productName, 0);
                    Grid.SetRow(productName, 0);
                    product.Children.Add(productName);
                    Label productPrice = new Label
                    {
                        Content = $"Price:\n£{selectedCategory.ProductPrice}",
                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 0, G = 128, B = 0 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 255, G = 255, B = 255 } },
                       

                    };

                    Grid.SetColumn(productPrice, 1);
                    Grid.SetRow(productPrice, 0);
                    product.Children.Add(productPrice);

                    TextBlock productDescription = new TextBlock
                    {

                        Text = $"Description:\n\"{selectedCategory.ProductDescription}\"",

                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 255, G = 255, B = 255 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        TextWrapping = new TextWrapping { },
                        Width = 250
                        ,
                        FontStyle = FontStyles.Italic
                    };
                    Label productAllergen = new Label
                    {
                        Content = $"Allergens:\n{allergenCRUD.Read(selectedCategory.AllergenID)}",
                        Foreground = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 128, G = 0, B = 0 } },
                        VerticalAlignment = VerticalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Left,
                        BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 255, G = 255, B = 255 } },
                        

                    };

                    Grid.SetColumn(productAllergen, 1);
                    Grid.SetRow(productAllergen, 1);
                    product.Children.Add(productAllergen);

                    productDescription.MaxWidth = 150;
                    Grid.SetColumnSpan(productDescription, 2);
                    Grid.SetColumn(productDescription, 0);
                    Grid.SetRow(productDescription, 1);
                    product.Children.Add(productDescription);
                    Border border = new Border { Margin = new Thickness(-3), BorderThickness = new Thickness(2), BorderBrush = new SolidColorBrush { Color = new System.Windows.Media.Color { A = 50, R = 0, G = 128, B = 0 } } };
                    Grid.SetColumn(border, 0);
                    Grid.SetColumnSpan(border, 2);
                    Grid.SetRow(border, 0);
                    Grid.SetRowSpan(border, 2);
                    product.Children.Add(border);

                    product.MouseRightButtonDown += new MouseButtonEventHandler(makeProductAvailable);
                    productsList.Items.Add(product);
                }
            }
           
        }

        private void makeProductAvailable(object sender, MouseButtonEventArgs e)
        {
            productCRUD.SetProductQuantity(productCRUD.selectedProduct, 100);
            RefreshProducts(productCategoryCRUD.selectedProductCategory);
        }

        private void makeProuctUnavailable(Object sender, MouseButtonEventArgs e)
        {
            productCRUD.SetProductQuantity(productCRUD.selectedProduct, 0);
            RefreshProducts(productCategoryCRUD.selectedProductCategory);

        }
        public void RefreshOrderList(Table selectedTable)
        {
            Style style = this.FindResource("usersListBoxStyle") as Style;
            TotalPrice = 0;
            TotalItems = 0;
            if (orderCRUD.GetOrders(selectedTable.TableID).Count == 0) // if there are no any orders in the opened table
            {
                orderCRUD.Create(selectedTable.TableID);

                orderCRUD.SelectOrder(selectedTable.TableID);
                newOrder.Add(orderCRUD.selectedOrder, new List<Product>());
                
            }
            else { orderCRUD.SelectOrder(selectedTable.TableID); }
           
          

            OrderList.Items.Clear();
            newOrder[orderCRUD.selectedOrder].Clear();

            foreach (var item in orderCRUD.GetProducts(orderCRUD.selectedOrder.OrderID))
            {
                OrderList.Items.Add(new ListBoxItem { Content = item.ProductName, Style = style });
                TotalItems++;
                TotalPrice += item.ProductPrice;
            }

            
            OrderTotalItems.Content = TotalItems;
            orderTotalPrice.Content = $"£ {Math.Round(TotalPrice)}";


        }

        public void RefreshOrderList(Order selectedOrder, Product selectedProduct)
        {
            Style style = this.FindResource("usersListBoxStyle") as Style;
            // selectedOrder.
            
            orderCRUD.selectedOrder.currentProducts.Add(selectedProduct);
            sendOrderButton.Opacity = 1; 
            newOrder[orderCRUD.selectedOrder].Add(selectedProduct);
            OrderList.Items.Add(new ListBoxItem { Content = productCRUD.selectedProduct.ProductName });
            TotalItems++;
            TotalPrice += selectedProduct.ProductPrice;
            OrderTotalItems.Content = TotalItems;
            orderTotalPrice.Content = $"£ {Math.Round(TotalPrice)}";
        }
        

        private void onProductDoubleClick(object sender, RoutedEventArgs e)
        {
            productCRUD.SelectProduct((sender as Label).Content.ToString());
            RefreshOrderList(orderCRUD.selectedOrder, productCRUD.selectedProduct);
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
                (tableSiteList.Items[0] as ListBoxItem).IsSelected = true;
                userLogInGrid.Width = new GridLength(0);
                tablesGrid.Width = new GridLength(100, GridUnitType.Star);
                usersList.IsEnabled = false;
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
                doubleClickOnTable.IsOpen = false;
                doubleClickOnTable.IsOpen = true;
                tableCRUD.selectTable(((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString());
                tableNameLable.Content = tableCRUD.selectedTable.TableName;
                
            }
        }

        private void ReserveTable_Click(object sender, RoutedEventArgs e)
        {
            reservationPanel.IsEnabled = true;
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
        //reserveTable
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tableCRUD.Reserve(tableCRUD.selectedTable.TableID, ReservationName.Text, ReservationPhone.Text, (DateTime)ReservationdatePicker.SelectedDate, int.Parse(ReservationNoOfGuests.Text));
            tableCRUD.UpdateTableStatus(tableCRUD.selectedTable.TableName, 3);
            RefreshTablesList(selectedTableSite);
            reservationPanel.IsEnabled = false;

        }

        private void dummyButton_Click(object sender, RoutedEventArgs e)
        {
            reservationPanel.IsEnabled = !reservationPanel.IsEnabled;
        }

        private void ListBoxItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddUserPopUp.IsOpen = true;
        }

        private void ReservationInformation_Click(object sender, RoutedEventArgs e)
        {
            doubleClickOnTable.IsOpen = false;
            RefreshReservationDetails(tableCRUD.selectedTable);
            ReservationDetailsPopup.IsOpen = false;
            ReservationDetailsPopup.IsOpen = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ReservationDetailsPopup.IsOpen = false;
        }

        private void productCategoriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productsList.Items.Clear();
            var selectedCategory = ((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString();
            RefreshSubcategoryList(selectedCategory);
            (subcategoryList.Items[0] as ListBoxItem).IsSelected = true;
            //subcategoryList
        }

        private void subcategoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem != null)
            {
                productsList.Items.Clear();
                productCategoryCRUD.selectedProductCategory = productCategoryCRUD.Read(((sender as ListBox).SelectedItem as ListBoxItem).Content.ToString());
                RefreshProducts(productCategoryCRUD.selectedProductCategory);
            }
        }

        private void OpenTable_Click(object sender, RoutedEventArgs e)
        {

            RefreshOrderList(tableCRUD.selectedTable);
            orderTableName.Content = tableCRUD.selectedTable.TableName;
            UserName.Text = userCRUD.selectedUser.UserName;
            OrderPanel.IsEnabled = true;
            tablesGrid.Width = new GridLength(0);
            doubleClickOnTable.IsOpen = false;
            productsGrid.Width = new GridLength(100, GridUnitType.Star);
            (productCategoriesListBox.Items[1] as ListBoxItem).IsSelected = true;
            (subcategoryList.Items[0] as ListBoxItem).IsSelected = true;
            RefreshTablesList(selectedTableSite);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            productsGrid.Width = new GridLength(0);
            OrderPanel.IsEnabled = false;
            tablesGrid.Width = new GridLength(100, GridUnitType.Star);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            orderCRUD.SendItemsToPrinters(orderCRUD.selectedOrder, newOrder[orderCRUD.selectedOrder], userCRUD.selectedUser.UserName);
            newOrder[orderCRUD.selectedOrder].Clear();
            productsGrid.Width = new GridLength(0);
            OrderPanel.IsEnabled = false;
            tablesGrid.Width = new GridLength(100, GridUnitType.Star);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            orderCRUD.PrintBill(orderCRUD.selectedOrder, TotalItems, TotalPrice);
            productsGrid.Width = new GridLength(0);
            OrderPanel.IsEnabled = false;
            tablesGrid.Width = new GridLength(100, GridUnitType.Star);
            orderCRUD.Remove(orderCRUD.selectedOrder.OrderID);
            RefreshTablesList(selectedTableSite);


        }
        //CancelReservation
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            tableCRUD.CancelReservation(tableCRUD.selectedReservation.ReservationID);
            RefreshReservationDetails( tableCRUD.selectedTable);
            RefreshTablesList(selectedTableSite);
          //  rese
        }

        private void reservationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem!=null) {
                var item = ((sender as ListBox).SelectedItem as Grid).Name;
                tableCRUD.SelectReservation(item);
            }
        }
    }
}
