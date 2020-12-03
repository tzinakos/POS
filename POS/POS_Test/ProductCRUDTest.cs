using NUnit.Framework;
using System.Linq;
using System;
using POS_Business;
using POS_Model;

namespace POS_Test
{
    public class ProductCRUDTest
    {
        ProductCRUD productCrud = new ProductCRUD();
        public Product TestProduct { get; set; }
        public int allergentID { get; set; }
        public int productCategoryID { get; set; }
        [SetUp]
        public void Setup()
        {
            
            using (var db = new PosContext())
            {
                productCategoryID = db.ProductCategories.Where(pc => pc.ProductCategoryName == "Test").Select(pc => pc.ProductCategoryID).FirstOrDefault();
                allergentID = db.Allergens.Where(a => a.AllergenName == "Test").Select(a => a.AllergenID).FirstOrDefault();
            }
            TestProduct = new Product
            {
                AllergenID = allergentID,
                ProductCategoryID = productCategoryID,
                ProductDescription = "TestDescription",
                ProductName = "TestName",
                ProductPrice = 2.5,
                ProductQuantity = 3
            };

        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new PosContext())
            {
                if (db.Products.Count() >= 1)
                {
                    db.Products.Remove(db.Products.Where(x => x.ProductName == "TestName"||x.ProductName=="Test2").FirstOrDefault());
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
                beforeCount = db.Products.Count();

                productCrud.Create( "TestName", 2.5, "TestDescription", 3, productCategoryID, allergentID);

                afterCount = db.Products.Count();

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
                db.Products.Add(TestProduct);
                db.SaveChanges();
                productCrud.selectedProduct = TestProduct;
                beforeCount = db.Products.Count();
                productCrud.Remove(TestProduct.ProductName);
                afterCount = db.Products.Count();
            }
            Assert.AreEqual(beforeCount - 1, afterCount);
        }
        [Test]
        public void WhenUpdatingAUser_UsersPropertiesAreUpdating()
        {
            using (var db = new PosContext())
            {
                db.Products.Add(TestProduct);
                db.SaveChanges();
                productCrud.selectedProduct = TestProduct;
                db.Products.Where(x => x.ProductID == productCrud.selectedProduct.ProductID).FirstOrDefault().ProductName = "Test2";
            }
            Assert.AreEqual("Test2", productCrud.selectedProduct.ProductName);
        }
    }
}