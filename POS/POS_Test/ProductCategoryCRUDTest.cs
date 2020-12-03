using NUnit.Framework;
using System.Linq;
using System;
using POS_Business;
using POS_Model;

namespace POS_Test
{
    public class ProductCategoryCRUDTest
    {
        ProductCategoryCRUD productCategoryCRUD = new ProductCategoryCRUD();
        public ProductCategory TestProductCategory { get; set; }
        [SetUp]
        public void Setup()
        {

            TestProductCategory = new ProductCategory { ProductCategoryName="testName"};
            
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new PosContext())
            {
                if (db.ProductCategories.Count() >= 1)
                {
                    db.ProductCategories.Remove(db.ProductCategories.Where(x => x.ProductCategoryName == "testName").FirstOrDefault());
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
                beforeCount = db.ProductCategories.Count();

                productCategoryCRUD.Create("testName");

                afterCount = db.ProductCategories.Count();
                
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
                db.ProductCategories.Add(TestProductCategory);
                db.SaveChanges();
                productCategoryCRUD.selectedProductCategory = TestProductCategory;
                beforeCount = db.ProductCategories.Count();
                productCategoryCRUD.Delete(TestProductCategory.ProductCategoryName);
                afterCount = db.ProductCategories.Count();
            }
            Assert.AreEqual(beforeCount - 1, afterCount);
        }
        [Test]
        public void WhenUpdatingAUser_UsersPropertiesAreUpdating()
        {
            using (var db = new PosContext())
            {
                db.ProductCategories.Add(TestProductCategory);
                db.SaveChanges();
                productCategoryCRUD.selectedProductCategory = TestProductCategory;
                db.ProductCategories.Where(x => x.ProductCategoryID == productCategoryCRUD.selectedProductCategory.ProductCategoryID).FirstOrDefault().ProductCategoryName = "Test2";
            }
            Assert.AreEqual("Test2", productCategoryCRUD.selectedProductCategory.ProductCategoryName);
        }
    }
}