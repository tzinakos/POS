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
            
            using (var db = new PosContext())
            {
                
            }
           
        }
    }
    public abstract class MasterCRUD
    {
        public List<Allergen> allergenList = new List<Allergen>();
        public List<Table> tablesList = new List<Table>();
        public List<User> usersList = new List<User>();
        public List<UserRole> userRolesList = new List<UserRole>();
        public List<ProductCategory> productCategoriesList = new List<ProductCategory>();
        public List<Product> productsList = new List<Product>();
        

        public User selectedUser { get; set; }
        public UserRole selectedUserRole { get; set; }
        public Table selectedTable { get; set; }
        public Allergen selectedAllergen { get; set; }
        public ProductCategory selectedProductCategory { get; set; }
        public Product selectedProduct { get; set; }

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
