using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using POS_Model;

namespace POS_Business
{
    public class Program
    {
        public static void Main()
        {
            //using (var db = new PosContext())
            //{
            //    UserRole manager = new UserRole { UserRoleName = "Manager" };
            //    UserRole waiter = new UserRole { UserRoleName = "Waiter" };
            //    UserRole bartender = new UserRole { UserRoleName = "Bartender" };
            //    UserRole sheff = new UserRole { UserRoleName = "Sheff" };
            //    db.UserRoles.Add(manager);
            //    db.UserRoles.Add(waiter);
            //    db.UserRoles.Add(bartender);
            //    db.UserRoles.Add(sheff);
            //    db.SaveChanges();
            //}
            using (var db = new PosContext())
            {
                //TableStatus free = new TableStatus { TableStatusName = "Open" };
                //db.TableStatuses.Add(free);
                //db.SaveChanges();
                //Table table1 = new Table { TableName = "Table 9", UserID = 16, TableStatusID = 2, TableSeats = 4, TableSite = "In" };
                //Table table2 = new Table { TableName = "Table 2", UserID = 16, TableStatusID = 1, TableSeats = 4, TableSite = "In" };
                //Table table3 = new Table { TableName = "Table 3", UserID = 16, TableStatusID = 1, TableSeats = 4, TableSite = "In" };
                //Table table4 = new Table { TableName = "Table 4", UserID = 16, TableStatusID = 1, TableSeats = 4, TableSite = "In" };
                //Table table5 = new Table { TableName = "Table 5", UserID = 16, TableStatusID = 1, TableSeats = 4, TableSite = "Out" };
                //Table table6 = new Table { TableName = "Table 6", UserID = 16, TableStatusID = 1, TableSeats = 4, TableSite = "Out" };
                //Table table7 = new Table { TableName = "Table 7", UserID = 16, TableStatusID = 1, TableSeats = 4, TableSite = "Out" };
                //Table table8 = new Table { TableName = "Table 8", UserID = 16, TableStatusID = 1, TableSeats = 4, TableSite = "Out" };
                //db.Tables.Add(table1);
                //db.Tables.Add(table2);
                //db.Tables.Add(table3);
                //db.Tables.Add(table4);
                //db.Tables.Add(table5);
                //db.Tables.Add(table6);
                //db.Tables.Add(table7);
                //db.Tables.Add(table8);
                //db.SaveChanges();
            }
           
        }
    }
    public abstract class MasterCRUD
    {
        public List<Table> tablesList = new List<Table>();
        public List<User> usersList = new List<User>();
        public List<UserRole> userRolesList = new List<UserRole>();
        

        public User selectedUser { get; set; }
        public UserRole selectedUserRole { get; set; }
        public Table selectedTable { get; set; }

        public abstract void Read();

        public void GetUserRoles()
        {
            using (var db = new PosContext())
            {
                userRolesList = db.UserRoles.Select(x => x).ToList();
            }
        }

        
    }
}
