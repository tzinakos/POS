using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using POS_Model;


namespace POS_Business
{
    public class AllergenCRUD : MasterCRUD
    {
        public override void Read()
        {
            using (var db = new PosContext())
            {
                allergenList = (db.Allergens.Select(a => a)).ToList();
            }
        }

        public string Read(int allergenID)
        {
            using (var db = new PosContext())
            {
                return db.Allergens.Where(a => a.AllergenID == allergenID).Select(a => a.AllergenName).FirstOrDefault();
            }
        }

        public void SelectAllergen(int allergenID)
        {
            using (var db = new PosContext())
            {
                selectedAllergen = db.Allergens.Where(a => a.AllergenID == allergenID).Select(a => a).FirstOrDefault();
            }
        }

        public void Create(string allergenName)
        {
            using (var db = new PosContext())
            {
                db.Allergens.Add(new Allergen { AllergenName=allergenName});
                db.SaveChanges();
            }
        }

        public void Remove(int allergenId)
        {
            using (var db = new PosContext())
            {
                db.Allergens.Remove(db.Allergens.Find(allergenId));
                db.SaveChanges();
            }
        }
        public void Update(string name, string newName)
        {
            using (var db = new PosContext())
            {
                db.Allergens.Where(a => a.AllergenName == name).Select(a => a).SingleOrDefault().AllergenName = newName;
                db.SaveChanges();
            }
        }
    }
}
