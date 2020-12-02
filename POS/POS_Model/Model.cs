using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace POS_Model
{
    public class PosContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Table> Tables { get; set; }
        public DbSet<TableStatus> TableStatuses {get;set;}
        public DbSet<Reservation> Reservations {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Pos;");

    }


    public class User
    {
        //UserTable Attributes
        public int UserID { get; set; } //User Table Primary Key
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPoints { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        //Reference Attributes
        public UserRole UserRole { get; set; } // A iser can have one User Role
        public int UserRoleID {get;set;} //Foreghn Key to UserRole table

        public List<Table> Tables = new List<Table>(); // A user can have many tables
    }

    public class UserRole
    {
        //UserRole Attributes
        public int UserRoleID { get; set; } //UserRole Table Primary Key
        public string UserRoleName { get; set; }
        //Reference Attributes
        public List<User> Users = new List<User>(); // A UserRole can have many Users
    }

    public class Table
    { 
        //Table Attributes
        public int TableID { get; set; }//Table Table Primary Key
        public string TableName { get; set; } 
        public int TableSeats { get; set; }
        //Reference Attributes
        public TableStatus TableStatus { get; set; } // A Table can have one Table Status
        public int TableStatusID { get; set; } //Foreign Key to TableStatus Table

        public int UserID { get; set; } // Foreign Key to Users Table
        public User Users { get; set; } // A Table can have one User

        public List<Reservation> Reservations = new List<Reservation>(); // One Table can have many Reservations
    }

    public class TableStatus
    {
        //TableStatus Attributes
        public int TableStatusID { get; set; } // TableStatus Primary Key
        public string TableStatusName { get; set; }
        //Reference Atributes 
        public List<Table> Tables = new List<Table>(); // A TableStatus can have many Tables
    }

    public class Reservation
    {
        //Reservation Table Attributes
        public int ReservationID { get; set; } //Reservation Table Primary Key
        public string ReservationName { get; set; }
        public string ReservationTelephoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
        //Reference Atributes 
        public int TableID { get; set; } // Foreign Key to Table Table
        public Table Table { get; set; } // A Reservation can have one Table
        
    }
}
