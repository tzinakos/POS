using NUnit.Framework;
using System.Linq;
using System;
using POS_Business;
using POS_Model;

namespace POS_Test
{
    public class UserCRUDTest
    {
        UserCRUD userCRUD = new UserCRUD();
        public User TestUser { get; set; }
        [SetUp]
        public void Setup()
        {
            
            TestUser = new User { IsActive = true, StartDate = DateTime.Today, 
                UserName = "testName", UserPassword = "", UserPoints = "0" , UserRoleID =1};
            
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new PosContext())
            {
                if (db.Users.Count() >= 5)
                {
                    db.Users.Remove(db.Users.Where(x => x.UserName == "testName").FirstOrDefault());
                    db.SaveChanges();
                }
            }
        }

        [Test]
        public void WhenAddingAUsers_UsersTableCountIsIncrementedByOne()
        {
            int beforeCount = 0;
            int afterCount = 0;
            using (var db = new PosContext())
            {
                beforeCount = db.Users.Count();

                userCRUD.Create("Manager", TestUser.UserName, TestUser.UserPassword, TestUser.StartDate);

                afterCount = db.Users.Count();
                
            }
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [Test]
        public void WhenDeletingAUser_UsersTableCountIsDecrementedByOne()
        {
            int beforeCount = 0;
            int afterCount = 0;
            using (var db = new PosContext())
            {
                db.Users.Add(TestUser);
                db.SaveChanges();
                userCRUD.selectedUser = TestUser;
                beforeCount = db.Users.Count();
                userCRUD.Delete(TestUser.UserID);
                afterCount = db.Users.Count();
            }
            Assert.AreEqual(beforeCount - 1, afterCount);
        }
        [Test]
        public void WhenUpdatingAUser_UsersPropertiesAreUpdating()
        {
            using (var db = new PosContext())
            {
                db.Users.Add(TestUser);
                db.SaveChanges();
                userCRUD.selectedUser = TestUser;
                db.Users.Where(x => x.UserID == userCRUD.selectedUser.UserID).FirstOrDefault().UserName = "Test2";
            }
            Assert.AreEqual("Test2", userCRUD.selectedUser.UserName);
        }
    }
}