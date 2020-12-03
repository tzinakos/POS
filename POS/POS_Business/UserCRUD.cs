using POS_Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace POS_Business
{
    public class UserCRUD : MasterCRUD
    {
        //Create Method For Users: It Creates new Users and adds them to the User Table in the Database.
        public void Create(string userRoleName, string userName, string userPassword, DateTime startDate)
        {
            using (var db = new PosContext())
            {

                int userRoleID = db.UserRoles.Where(u => u.UserRoleName == userRoleName).Select(x => x.UserRoleID).FirstOrDefault();
                User newUser = new User
                {
                    UserName = userName,
                    UserPassword = userPassword,
                    IsActive = true,
                    StartDate = startDate,
                    UserPoints = "0",
                    UserRoleID = userRoleID
                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        // Read Method For Users: It can Get All the Users From the User table in the Database.
        public override void Read()
        {
            using (var db = new PosContext()) 
            {
                usersList = db.Users.Select(x => x).ToList();
            } 
        }

        public void Update(int id, string name, string password, string points, int userRoleID, bool isActive)
        {
            using (var db = new PosContext())
            {
                db.Users.Where(i => i.UserID == id).FirstOrDefault().UserName = name;
                db.Users.Where(i => i.UserID == id).FirstOrDefault().UserPassword = password;
                db.Users.Where(i => i.UserID == id).FirstOrDefault().UserPoints = points;
                db.Users.Where(i => i.UserID == id).FirstOrDefault().IsActive = isActive;
                db.Users.Where(i => i.UserID == id).FirstOrDefault().UserRoleID = userRoleID;
                db.SaveChanges();
            }
        }
        public  void Delete(int id)
        {
            using (var db = new PosContext())
            {
                db.Users.Remove(db.Users.Find(id));
                db.SaveChanges();
            }
        }

        public void SelectUser(string name)
        {
            using (var db = new PosContext())
            {
                selectedUser = db.Users.Where(u => u.UserName == name).FirstOrDefault();
            }
        }

        public string GetUserRole(int userID)
        {
            using (var db = new PosContext())
            {

                return (from u in db.Users
                        join ur in db.UserRoles
                        on u.UserRoleID equals ur.UserRoleID
                        where u.UserID == userID
                        select ur.UserRoleName).FirstOrDefault();
                    
                    
            }
        }
    }
}
