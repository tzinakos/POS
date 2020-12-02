using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using POS_Model;


namespace POS_Business
{
    public class TableCRUD : MasterCRUD
    {
        public void Create(string tableName, int userID = 1, int tableStatusID = 1, int tableSeets = 4)
        {
            using (var db = new PosContext())
            {
                db.Tables.Add(new Table
                {
                    TableName = tableName,
                    TableSeats = tableSeets,
                    TableStatusID = tableStatusID,
                    UserID = userID
                });

                db.SaveChanges();
            }
        }
        public override void Read()
        {
            using (var db = new PosContext())
            {
                tablesList = db.Tables.Select(t => t).ToList();
            }
        }
        public void Update(int tableID, string tableName, int tableSteats, int userID, int statusId)
        {
            using (var db = new PosContext())
            {
                db.Tables.Find(db.Tables.Where(t => t.TableID == tableID)).TableName = tableName;
                db.Tables.Find(db.Tables.Where(t => t.TableID == tableID)).TableSeats = tableSteats;
                db.Tables.Find(db.Tables.Where(t => t.TableID == tableID)).UserID = userID;
                db.Tables.Find(db.Tables.Where(t => t.TableID == tableID)).TableStatusID = statusId;
                db.SaveChanges();
            }
        }
        public override void Delete(int id)
        {
            using (var db = new PosContext())
            {
                db.Tables.Remove(db.Tables.Where(t => t.TableID == id).FirstOrDefault());
                db.SaveChanges();
            }
        }

        
    }
}
