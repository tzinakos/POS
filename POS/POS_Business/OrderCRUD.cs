using System;
using System.Collections.Generic;
using System.Text;
using POS_Model;
using System.Linq;
using System.IO;

namespace POS_Business
{
    public class OrderCRUD : MasterCRUD
    {
        public List<Order> currentOrders = new List<Order>();
        public override void Read()
        {
            throw new NotImplementedException();
        }

        public void Create(int tableID)
        {
            Order newOrder = new Order { TableID = tableID, OrderDate = DateTime.Now, currentProducts = new List<Product>() };
            using (var db = new PosContext())
            {
             
                db.Orders.Add(newOrder );
                db.Tables.Find(tableID).Orders.Add(newOrder);
                db.SaveChanges();
                newOrder.OrderID = db.Orders.Where(x => x.TableID == tableID).FirstOrDefault().OrderID;
                currentOrders.Add(newOrder);
            }
        }


        public void Remove(int orderID)
        {
            using (var db = new PosContext())
            {
                db.Orders.Remove(db.Orders.Find(orderID));
                db.SaveChanges();
            }

            for (int i =0; i < currentOrders.Count; i++)
            {
                if (currentOrders[i].OrderID == orderID)
                {
                    currentOrders.RemoveAt(i);
                }
            }
        }
        public List<Product> GetProducts(int orderID)
        {
            int id = 0;
            List<Product> returnList = new List<Product>();
            using (var db = new PosContext())
            {
                id = (from o in db.Orders
                where o.OrderID == orderID
                select o.OrderID).FirstOrDefault();
            }
            foreach(var item in currentOrders)
            {
                if (item.OrderID == id)
                {
                    returnList= item.currentProducts;
                }
                
            }
            return returnList;
        }

        public List<Order> GetOrders(int tableID)
        {
            using (var db = new PosContext())
            {
                return (from o in db.Orders
                        join t in db.Tables
                        on o.TableID equals t.TableID
                        where t.TableID == tableID
                        select o).ToList();
               // return (db.Tables.Find(tableID).Orders).ToList();
            }
        }

        public void SelectOrder(int tableID)
        {
            foreach (var item in currentOrders)
            {
                if (item.TableID == tableID)
                {
                    selectedOrder = item;
                }
            }
        }

        public void PrintBill(Order selectedOrder, int totalItems, double totalPrice)
        {
            List<Product> starters = new List<Product>();

            List<Product> mains = new List<Product>();

            List<Product> deserts = new List<Product>();

            List<Product> drinks = new List<Product>();

            
            File.WriteAllText(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bill.txt", string.Empty);
            foreach (var item in selectedOrder.currentProducts)
            {
                if (item.ProductCategoryID == 5 || item.ProductCategoryID == 6 || item.ProductCategoryID == 7)
                {
                    starters.Add(item);
                }
                else if (item.ProductCategoryID == 8 || item.ProductCategoryID == 9 || item.ProductCategoryID == 10)
                {
                    mains.Add(item);
                }
                else if (item.ProductCategoryID == 11 || item.ProductCategoryID == 12)
                {
                    deserts.Add(item);
                }
                else drinks.Add(item);
            }
            using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bill.txt", true))
            {
                string tableName = "";
                string userName = "";
                using (var db = new PosContext())
                {
                    tableName = (from o in db.Orders
                                 join t in db.Tables
                                 on o.TableID equals t.TableID
                                 where o.OrderID == selectedOrder.OrderID
                                 select t.TableName).FirstOrDefault();
                    userName = (from o in db.Orders
                                join t in db.Tables
                                on o.TableID equals t.TableID
                                join u in db.Users
                                on t.UserID equals u.UserID
                                where o.OrderID == selectedOrder.OrderID
                                select u.UserName).FirstOrDefault();
                }

                file.WriteLine($"Santa's Restaurant");
                file.WriteLine($"Date: {DateTime.Now}\n__________");


            }

            if (starters.Count > 1)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bill.txt", true))
                {
                    file.WriteLine("Starters:");

                    foreach (var item in starters)
                    {

                        file.WriteLine($"{item.ProductName}| £{item.ProductPrice}");
                    }
                    file.WriteLine("__________");
                }
            }
            if (mains.Count > 1)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bill.txt", true))
                {
                    file.WriteLine("Mains:");

                    foreach (var item in mains)
                    {

                        file.WriteLine($"{item.ProductName}| £{item.ProductPrice}");
                    }
                    file.WriteLine("__________");
                }
            }
            if (deserts.Count > 1)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bill.txt", true))
                {
                    file.WriteLine("Deserts:");

                    foreach (var item in deserts)
                    {

                        file.WriteLine($"{item.ProductName}| £{item.ProductPrice}");
                    }
                    file.WriteLine("__________");
                }
            }
            if (drinks.Count > 1)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bill.txt", true))
                {
                    file.WriteLine("Drinks:");

                    foreach (var item in drinks)
                    {

                        file.WriteLine($"{item.ProductName}| £{item.ProductPrice}");
                    }
                    file.WriteLine("__________");
                }
            }
            using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bill.txt", true))
            {
                file.WriteLine($"Total Items: {totalItems}");
                file.WriteLine($"Total Price: {totalPrice}");
                file.WriteLine($"______________________");
                file.WriteLine($"Thank You For Choosing Santa's Restaurant");
            }


        }
            

        public void SendItemsToPrinters(Order selectedOrder, List<Product> products)
        {
            List<string> starters = new List<string>();

            List<string> mains = new List<string>();

            List<string> deserts = new List<string>();

            List<string> drinks = new List<string>();

            File.WriteAllText(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Kitchen.txt", string.Empty);
            File.WriteAllText(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bar.txt", string.Empty);
            foreach (var item in products)
            {
                if (item.ProductCategoryID == 5 || item.ProductCategoryID == 6 || item.ProductCategoryID == 7)
                {
                    starters.Add(item.ProductName);
                }
                else if (item.ProductCategoryID == 8 || item.ProductCategoryID == 9 || item.ProductCategoryID == 10)
                {
                    mains.Add(item.ProductName);
                }
                else if (item.ProductCategoryID == 11 || item.ProductCategoryID == 12)
                {
                    deserts.Add(item.ProductName);
                }
                else drinks.Add(item.ProductName);
            }
            using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Kitchen.txt", true))
            { string tableName = "";
                string userName = "";
                using (var db = new PosContext()) 
                {
                    tableName = (from o in db.Orders
                                 join t in db.Tables
                                 on o.TableID equals t.TableID
                                 where o.OrderID == selectedOrder.OrderID
                                 select t.TableName).FirstOrDefault();
                    userName = (from o in db.Orders
                                 join t in db.Tables
                                 on o.TableID equals t.TableID
                                 join u in db.Users
                                 on t.UserID equals u.UserID
                                 where o.OrderID == selectedOrder.OrderID
                                 select u.UserName).FirstOrDefault();
                }

                file.WriteLine($"Table: {tableName}\n__________");
                file.WriteLine($"User: {userName}\n__________");


            }

            if (starters.Count > 1) {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Kitchen.txt", true))
                {
                    file.WriteLine("Starters:");

                    foreach (var item in starters)
                    {
                        
                            file.WriteLine(item);
                    }
                    file.WriteLine("__________");
                }
            }
            if (mains.Count > 1)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Kitchen.txt", true))
                {
                    file.WriteLine("Mains:");

                    foreach (var item in mains)
                    {

                        file.WriteLine(item);
                    }
                    file.WriteLine("__________");
                }
            }
            if (deserts.Count > 1)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Kitchen.txt", true))
                {
                    file.WriteLine("Deserts:");

                    foreach (var item in deserts)
                    {

                        file.WriteLine(item);
                    }
                    file.WriteLine("__________");
                }
            }
            if (drinks.Count > 1)
            {
                using (StreamWriter file = new StreamWriter(@"C:\Users\User\github\POS\POS\POS_Business\Printer\Bar.txt", true))
                {
                    file.WriteLine("Drinks:");

                    foreach (var item in drinks)
                    {

                        file.WriteLine(item);
                    }
                    file.WriteLine("__________");
                }
            }

        }
    }
}
