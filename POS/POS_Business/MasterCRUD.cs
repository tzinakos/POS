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
        public abstract void Delete(int id);

        public void GetUserRoles()
        {
            using (var db = new PosContext())
            {
                userRolesList = db.UserRoles.Select(x => x).ToList();
            }
        }
    }
}
