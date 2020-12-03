using NUnit.Framework;
using System.Linq;
using System;
using POS_Business;
using POS_Model;

namespace POS_Test
{
    public class AllergenCRUDTest
    {
        AllergenCRUD allergenCRUD = new AllergenCRUD();
        public Allergen TestAllergen { get; set; }
        [SetUp]
        public void Setup()
        {

           TestAllergen = new Allergen { AllergenName="testName"};
            
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new PosContext())
            {
                if (db.Allergens.Count() >= 1)
                {
                    db.Allergens.Remove(db.Allergens.Where(x => x.AllergenName == "testName").FirstOrDefault());
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
                beforeCount = db.Allergens.Count();

                allergenCRUD.Create("testName");

                afterCount = db.Allergens.Count();
                
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
                db.Allergens.Add(TestAllergen);
                db.SaveChanges();
                allergenCRUD.selectedAllergen = TestAllergen;
                beforeCount = db.Allergens.Count();
                allergenCRUD.Remove(TestAllergen.AllergenID);
                afterCount = db.Allergens.Count();
            }
            Assert.AreEqual(beforeCount - 1, afterCount);
        }
        [Test]
        public void WhenUpdatingAUser_UsersPropertiesAreUpdating()
        {
            using (var db = new PosContext())
            {
                db.Allergens.Add(TestAllergen);
                db.SaveChanges();
                allergenCRUD.selectedAllergen = TestAllergen;
                db.Allergens.Where(x => x.AllergenID == allergenCRUD.selectedAllergen.AllergenID).FirstOrDefault().AllergenName = "Test2";
            }
            Assert.AreEqual("Test2", allergenCRUD.selectedAllergen.AllergenName);
        }
    }
}