using NUnit.Framework;
using System.Linq;
using System;
using POS_Business;
using POS_Model;

namespace POS_Test
{
    public class TablesCRUDTest
    {
        TableCRUD tableCRUD = new TableCRUD();
        public Table TestTable { get; set; }
        [SetUp]
        public void Setup()
        {

           TestTable = new Table { TableName = "testName", TableSeats = 4, TableSite = "In", TableStatusID = 1, UserID=16 };
            
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new PosContext())
            {
                if (db.Tables.Count() >= 10)
                {
                    db.Tables.Remove(db.Tables.Where(x => x.TableName == "testName").FirstOrDefault());
                    db.SaveChanges();
                }
            }
        }

        [Test]
        public void WhenAddingAUTable_TablesTableCountIsIncrementedByOne()
        {
            int beforeCount = 0;
            int afterCount = 0;
            using (var db = new PosContext())
            {
                beforeCount = db.Tables.Count();

                tableCRUD.Create("testName", "In", 16, 1, 4);

                afterCount = db.Tables.Count();
                
            }
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [Test]
        public void WhenDeletingATable_TablesTableCountIsDecrementedByOne()
        {
            int beforeCount = 0;
            int afterCount = 0;
            using (var db = new PosContext())
            {
                db.Tables.Add(TestTable);
                db.SaveChanges();
                tableCRUD.selectedTable = TestTable;
                beforeCount = db.Tables.Count();
                tableCRUD.Delete(TestTable.TableName);
                afterCount = db.Tables.Count();
            }
            Assert.AreEqual(beforeCount - 1, afterCount);
        }
        [Test]
        public void WhenUpdatingAUser_UsersPropertiesAreUpdating()
        {
            using (var db = new PosContext())
            {
                db.Tables.Add(TestTable);
                db.SaveChanges();
                tableCRUD.selectedTable = TestTable;
                db.Tables.Where(x => x.TableID == tableCRUD.selectedTable.TableID).FirstOrDefault().TableName = "Test2";
            }
            Assert.AreEqual("Test2", tableCRUD.selectedTable.TableName);
        }
    }
}