using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using POS_Model;


namespace POS_Business
{
    public class TableCRUD : MasterCRUD
    {
        public void Create(string tableName, string tableSite, int userID = 1, int tableStatusID = 1, int tableSeets = 4)
        {
            using (var db = new PosContext())
            {
                db.Tables.Add(new Table
                {
                    TableName = tableName,
                    TableSeats = tableSeets,
                    TableStatusID = 1,
                    UserID = userID,
                    TableSite = tableSite
                });

                db.SaveChanges();
            }
        }
        public override void Read()
        {
            using (var db = new PosContext())
            {
               
                tablesList = db.Tables.Select(t => t).OrderBy(t =>t.TableName).ToList();
               
            }
        }
        public void Update(int tableID, string tableName, int tableSteats, string tableSite)
        {
            using (var db = new PosContext())
            {
                db.Tables.Where(t => t.TableID == tableID).FirstOrDefault().TableName = tableName;
                db.Tables.Where(t => t.TableID == tableID).FirstOrDefault().TableSeats = tableSteats;
                db.Tables.Where(t => t.TableID == tableID).FirstOrDefault().TableSite = tableSite;
                db.SaveChanges();
            }
        }
        public  void Delete(string table)
        {
            using (var db = new PosContext())
            {
                db.Tables.Remove(db.Tables.Where(t => t.TableName == table).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void selectTable(string tableName)
        {
            using (var db = new PosContext())
            {
                selectedTable = db.Tables.Where(t => t.TableName == tableName).FirstOrDefault();
            }
        }
        public void UpdateTableStatus(string tableName, int statusID)
        {
            using (var db = new PosContext())
            {
                db.Tables.Where(t => t.TableName == tableName).FirstOrDefault().TableStatusID = statusID;
                db.SaveChanges();
            }
        }

        public void Reserve(int tableID, string name, string telephoneNumber, DateTime dateTime ,int numberOfGuests)
        {
            using (var db = new PosContext())
            {
                db.Reservations.Add(new Reservation { ReservationName = name, NumberOfGuests = numberOfGuests, 
                    ReservationDate = dateTime, ReservationTelephoneNumber = telephoneNumber, TableID = tableID});
                db.SaveChanges();
            }
        }
        public void CancelReservation(int tableID)
        {
            using (var db = new PosContext())
            {
                db.Reservations.Remove(db.Reservations.Find((from r in db.Reservations
                                                             join t in db.Tables
                                                             on r.TableID equals t.TableID
                                                             where t.TableID == tableID
                                                             select r.ReservationID).FirstOrDefault()));
                db.SaveChanges();
            }
        }

        public List<Reservation> GetReservations(Table table)
        {
            using (var db = new PosContext())
            {
                return (from r in db.Reservations
                        join t in db.Tables
                        on r.TableID equals t.TableID
                        where t.TableID == table.TableID
                        select r).ToList();
            }
        }

    }
}
