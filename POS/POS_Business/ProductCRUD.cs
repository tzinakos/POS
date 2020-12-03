using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using POS_Model;

namespace POS_Business
{
    class ProductCRUD : MasterCRUD
    {
        public override void Read()
        {
            using (var db = new PosContext())
            {
                productsList = db.Products.Select(p => p).ToList();
            }
          
        }

        public string Read(int productID)
        {
            using (var db = new PosContext())
            {
                return db.Products.Where(p => p.ProductID == productID).Select(p => p.ProductName).FirstOrDefault();
            }
        }

        public void SelectProduct(string productName)
        {
            using (var db = new PosContext())
            {
                selectedProduct = db.Products.Where(p => p.ProductName == productName).Select(p => p).FirstOrDefault();
            }
        }

        public void Create(string productName, double productPrice, string productDescription, int productQuantity, int categoryID, int allergentID)
        {
            using (var db = new PosContext())
            {
                db.Products.Add(new Product
                {
                    ProductCategoryID = categoryID,
                    ProductDescription = productDescription,
                    ProductName = productName,
                    ProductPrice = productPrice,
                    ProductQuantity = productQuantity,
                    AllergenID = allergentID
                });
                db.SaveChanges();
            }
        }

        public void Remove(string productName)
        {
            using (var db = new PosContext())
            {
                db.Products.Remove(db.Products.Where(p => p.ProductName == productName).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public void Update(int productID, string productName, double productPrice, string productDescription, int quantity, int categoryID, int allergentID)
        {
            using (var db = new PosContext())
            {
                db.Products.Where(p => p.ProductID == productID).Select(p => p).FirstOrDefault().ProductName = productName;
                db.Products.Where(p => p.ProductID == productID).Select(p => p).FirstOrDefault().ProductPrice =productPrice;
                db.Products.Where(p => p.ProductID == productID).Select(p => p).FirstOrDefault().ProductDescription = productDescription;
                db.Products.Where(p => p.ProductID == productID).Select(p => p).FirstOrDefault().ProductQuantity = quantity;
                db.Products.Where(p => p.ProductID == productID).Select(p => p).FirstOrDefault().ProductCategoryID = categoryID;
                db.Products.Where(p => p.ProductID == productID).Select(p => p).FirstOrDefault().AllergenID = allergentID;
                db.SaveChanges();
            }
        }
    }
}
