using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using POS_Model;


namespace POS_Business
{
    public class ProductCategoryCRUD : MasterCRUD
    {
        List<ProductCategory> starters = new List<ProductCategory>();
        List<ProductCategory> main = new List<ProductCategory>();
        List<ProductCategory> deserts = new List<ProductCategory>();
        List<ProductCategory> fizzyDrinks = new List<ProductCategory>();
        List<ProductCategory> drinks = new List<ProductCategory>();
        List<ProductCategory> coffees = new List<ProductCategory>();
        public override void Read()
        {
            using (var db = new PosContext())
            {
                productCategoriesList = db.ProductCategories.Select(pc => pc).ToList();
            }
        }

        public ProductCategory Read(string productCategoryName)
        {
            using ( var db = new PosContext())
            {
                return db.ProductCategories.Where(pc => pc.ProductCategoryName == productCategoryName).Select(p => p).FirstOrDefault();
            }
        }

        public void SelectProductCategory(string productCategoryName)
        {
            using (var db = new PosContext())
            {
                selectedProductCategory = db.ProductCategories.Where(pc => pc.ProductCategoryName == productCategoryName)
                    .Select(pc => pc).FirstOrDefault();
            }
        }

        public void Create(string productCategoryName)
        {
            using (var db = new PosContext())
            {
                db.ProductCategories.Add(new ProductCategory { ProductCategoryName = productCategoryName });
                db.SaveChanges();
            }
        }

        public void Update(string productCategoryName, string newProductCategoryName)
        {
            using (var db = new PosContext())
            {
                db.ProductCategories.Where(pc => pc.ProductCategoryName == productCategoryName)
                    .Select(pc => pc).FirstOrDefault().ProductCategoryName = newProductCategoryName;
                db.SaveChanges();
            }
            
        }
        public void Delete(string productCategoryName)
        {
            using (var db = new PosContext())
            {
                db.ProductCategories.Remove(db.ProductCategories.Where(pc => pc.ProductCategoryName == productCategoryName).FirstOrDefault());
                db.SaveChanges();
            }
        }
    }
}
