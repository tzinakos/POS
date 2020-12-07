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

                //db.Allergens.Add(new Allergen { AllergenName = "Sesame" });
                //db.SaveChanges();
                ////ProductCategory DipsAndColdStarters = new ProductCategory { ProductCategoryName = "Dips & Cold Starters" };
                //Product taramosalata = new Product
                //{
                //    AllergenID = 13,
                //    ProductCategoryID = 5,
                //    ProductDescription = "Cod's roe, olive oil and lemon juice.",
                //    ProductName = "Taramosalata",
                //    ProductQuantity = 10,
                //    ProductPrice = 3.75
                //};
                //Product Houmous = new Product
                //{
                //    AllergenID = 16,
                //    ProductCategoryID = 5,
                //    ProductDescription = "Chick peas, sesame seeds, tahini, olive oil, lemon and garlic.",
                //    ProductName = "Humous",
                //    ProductQuantity = 60,
                //    ProductPrice = 3.75
                //};

                //Product Tahini = new Product
                //{
                //    AllergenID = 16,
                //    ProductCategoryID = 5,
                //    ProductDescription = "Sesame seeds, olive oil, lemon and garlic.",
                //    ProductName = "Tahini",
                //    ProductQuantity = 40,
                //    ProductPrice = 3.75
                //};

                //Product Tzatziki = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 5,
                //    ProductDescription = "Greek Yaghurt with cucumber, garlic and mint.",
                //    ProductName = "Tzatziki",
                //    ProductQuantity = 120,
                //    ProductPrice = 3.75
                //};

                //Product Aubergine = new Product
                //{
                //    AllergenID = 16,
                //    ProductCategoryID = 5,
                //    ProductDescription = "Sesame seeds, crushed aubergine, olive oil and lemon.",
                //    ProductName = "Aubergine",
                //    ProductQuantity = 30,
                //    ProductPrice = 3.50
                //};

                //Product Gigantes = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 5,
                //    ProductDescription = "Butter Beans in tomato and Worcester sauce.",
                //    ProductName = "Gigantes",
                //    ProductQuantity = 100,
                //    ProductPrice = 3.50
                //};

                //Product GreenOlives = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 5,
                //    ProductDescription = "Green Olives with coriander seeds, garlic and lemon.",
                //    ProductName = "Green Olives",
                //    ProductQuantity = 100,
                //    ProductPrice = 3.50
                //};
                //db.Products.Add(GreenOlives);
                //db.Products.Add(Gigantes);
                //db.Products.Add(Aubergine);
                //db.Products.Add(Tzatziki);
                //db.Products.Add(Tahini);
                //db.Products.Add(Houmous);
                //db.Products.Add(taramosalata);
                //db.Allergens.Find(9).AllergenName = "None";
                //db.SaveChanges();




                ////ProductCategory HotStarters = new ProductCategory { ProductCategoryName = "Hot starters" };
                //Product Loukaniko = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 6,
                //    ProductDescription = "Spicy Greek pork sausage.",
                //    ProductName = "Loukanico",
                //    ProductQuantity = 100,
                //    ProductPrice = 3.95
                //};
                //Product Pastourma = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 6,
                //    ProductDescription = "Spicy Greek beef sausage.",
                //    ProductName = "Pastourma",
                //    ProductQuantity = 100,
                //    ProductPrice = 3.95
                //};
                //Product Keftedes = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 6,
                //    ProductDescription = "4 pcs of pork meatballs with potato & herbs, deep fried.",
                //    ProductName = "Keftedes",
                //    ProductQuantity = 60,
                //    ProductPrice = 3.95
                //};
                //Product Dolmades = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 6,
                //    ProductDescription = "Stuffed vine leaves.",
                //    ProductName = "Dolmades",
                //    ProductQuantity = 100,
                //    ProductPrice = 3.95
                //};
                //Product Halloumi = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 6,
                //    ProductDescription = "Cyprus cheese, charcoal grilled.",
                //    ProductName = "Halloumi",
                //    ProductQuantity = 100,
                //    ProductPrice = 3.95
                //};
                //db.Products.Add(Halloumi);
                //db.Products.Add(Dolmades);
                //db.Products.Add(Keftedes);
                //db.Products.Add(Pastourma);
                //db.Products.Add(Loukaniko);
                //db.Allergens.Find(15).AllergenName = "Dairy";
                //db.SaveChanges();

                ////ProductCategory FishStarters = new ProductCategory { ProductCategoryName = "Fish Starters" };
                //Product kingPrawns = new Product
                //{
                //    AllergenID = 13,
                //    ProductCategoryID = 7,
                //    ProductDescription = "3 pcs of charcoal grilled king prawns.",
                //    ProductName = "Butterfly King Prawns",
                //    ProductQuantity = 100,
                //    ProductPrice = 8.95
                //};
                //Product Octopus = new Product
                //{
                //    AllergenID = 13,
                //    ProductCategoryID = 7,
                //    ProductDescription = "Charcoal grilled, marinated in olive oil and red wine vinegar.",
                //    ProductName = "Octopus",
                //    ProductQuantity = 50,
                //    ProductPrice = 10.95
                //};
                //Product kalamari = new Product
                //{
                //    AllergenID = 13,
                //    ProductCategoryID = 7,
                //    ProductDescription = "Charcoal grilled Kalamari",
                //    ProductName = "Fresh Grilled Kalamari",
                //    ProductQuantity = 50,
                //    ProductPrice = 8.95
                //};
                //db.Products.Add(kingPrawns);
                //db.Products.Add(Octopus);
                //db.Products.Add(kalamari);
                //db.SaveChanges();

                ////ProductCategory Kebaps = new ProductCategory { ProductCategoryName = "Kebaps" };
                //Product ChickenKebap = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 8,
                //    ProductDescription = "2 skewers Marinated in yoghurt served with chips",
                //    ProductName = "Chicken Kebap",
                //    ProductQuantity = 50,
                //    ProductPrice = 12.95
                //};
                //Product LambKebap = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 8,
                //    ProductDescription = "2 skewers served with chips",
                //    ProductName = "Lamb Kebap",
                //    ProductQuantity = 50,
                //    ProductPrice = 12.95
                //};
                //Product PorkKebap = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 8,
                //    ProductDescription = "2 skewers served with chips",
                //    ProductName = "Pork Kebap",
                //    ProductQuantity = 50,
                //    ProductPrice = 12.95
                //};
                //db.Products.Add(ChickenKebap);
                //db.Products.Add(LambKebap);
                //db.Products.Add(PorkKebap);
                //db.SaveChanges();

                ////ProductCategory SteaksAndBarbecue = new ProductCategory { ProductCategoryName = "Steaks & Barbecue" };
                //Product Sirloin = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 9,
                //    ProductDescription = "Served with mushroom & chips",
                //    ProductName = "Sirloin Steak",
                //    ProductQuantity = 10,
                //    ProductPrice = 20.95
                //};
                //Product LambCuttlers = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 9,
                //    ProductDescription = "Served with chips",
                //    ProductName = "Lamb Cuttlers",
                //    ProductQuantity = 10,
                //    ProductPrice = 17.95
                //};
                //Product TboneSteak = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 9,
                //    ProductDescription = "Served with mushroom & chips",
                //    ProductName = "T-bone Steak",
                //    ProductQuantity = 10,
                //    ProductPrice = 20.95
                //};

                //db.Products.Add(Sirloin);
                //db.Products.Add(LambCuttlers);
                //db.Products.Add(TboneSteak);
                //db.SaveChanges();
                ////ProductCategory Vegetarian = new ProductCategory { ProductCategoryName = "Vegeterian" };
                //Product Moussaka = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 10,
                //    ProductDescription = "Layers of sliced aubergine, potato, courgette, mushroom topped with bechamel sauce. Served with salad.",
                //    ProductName = "Moussaka",
                //    ProductQuantity = 10,
                //    ProductPrice = 12.95
                //};
                //Product VegDolmades = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 10,
                //    ProductDescription = "Vine leaves stuffed with rice, fresh herbs, spices and tomato. Served with salad.",
                //    ProductName = "Vegetarian Dolmades",
                //    ProductQuantity = 10,
                //    ProductPrice = 11.50
                //};
                //Product VillageMacaroni = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 10,
                //    ProductDescription = "Pasta, Halloumi & mint.",
                //    ProductName = "Village Macaroni",
                //    ProductQuantity = 3,
                //    ProductPrice = 9.95
                //};
                //db.Products.Add(Moussaka);
                //db.Products.Add(VegDolmades);
                //db.Products.Add(VillageMacaroni);
                //db.SaveChanges();
                ////ProductCategory IceCreams = new ProductCategory { ProductCategoryName = "Ice Creams" };
                //Product Tartufo = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 11,
                //    ProductDescription = "A zabaglione ice cream centre, covered with a thick layer of chocolate ice cream and coated with cocoa powder.",
                //    ProductName = "Tartufo Nero",
                //    ProductQuantity = 6,
                //    ProductPrice = 4.90
                //};
                //Product Coppa = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 11,
                //    ProductDescription = "Ice Cream ripple with black cherry.",
                //    ProductName = "Coppa Amarena",
                //    ProductQuantity = 6,
                //    ProductPrice = 4.90
                //};
                //Product CoppaMenta = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 11,
                //    ProductDescription = "Mint ice cream ripple with chocolate sauce.",
                //    ProductName = "Coppa Menta",
                //    ProductQuantity = 6,
                //    ProductPrice = 4.90
                //};
                //db.Products.Add(Tartufo);
                //db.Products.Add(Coppa);
                //db.Products.Add(CoppaMenta);
                //db.SaveChanges();
                ////ProductCategory Cakes = new ProductCategory { ProductCategoryName = "Cakes" };
                //Product Profiteroles = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 12,
                //    ProductDescription = "Choux pastry filled with light cream and covered in a soft dark chocolate sauce.",
                //    ProductName = "Profiteroles",
                //    ProductQuantity = 6,
                //    ProductPrice = 4.90
                //};
                //Product Tiramisu = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 12,
                //    ProductDescription = "Layers of savoiardi biscuits soaked with espresso coffee, mascarpone cheese, and amaretto, dusted with cocoa powder.",
                //    ProductName = "Tiramisu",
                //    ProductQuantity = 6,
                //    ProductPrice = 4.90
                //};
                //Product Frutti = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 12,
                //    ProductDescription = "A pastry base topped with cream and a layer of sponge topped with fruits of the forest. Served with ice cream.",
                //    ProductName = "Frutti di Bosco",
                //    ProductQuantity = 6,
                //    ProductPrice = 4.90
                //};

                //db.Products.Add(Profiteroles);
                //db.Products.Add(Tiramisu);
                //db.Products.Add(Frutti);
                //db.SaveChanges();
                ////ProductCategory Drinks = new ProductCategory { ProductCategoryName = "Drinks" };
                //Product Siaciliano = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 14,
                //    ProductDescription = "Orange juice Sambuca & vodka.",
                //    ProductName = "Siaciliano",
                //    ProductQuantity = 100,
                //    ProductPrice = 7.20
                //};
                //Product Garibaldi = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 14,
                //    ProductDescription = "Orange juice & Campari",
                //    ProductName = "Garibaldi",
                //    ProductQuantity = 100,
                //    ProductPrice = 7.20
                //};
                //Product VerdeAcqua = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 14,
                //    ProductDescription = "Mint Vodka, Limoncello, Gin & tonic water",
                //    ProductName = "Verde Acqua",
                //    ProductQuantity = 100,
                //    ProductPrice = 7.20
                //};


                //db.Products.Add(Siaciliano);
                //db.Products.Add(Garibaldi);
                //db.Products.Add(VerdeAcqua);
                //db.SaveChanges();

                ////ProductCategory FizzyDrinks = new ProductCategory { ProductCategoryName = "Fizzy Drinks" };
                //Product Water = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 13,
                //    ProductDescription = "Still Mineral Water.",
                //    ProductName = "Water",
                //    ProductQuantity = 100,
                //    ProductPrice = 2.00
                //};
                //Product SWater = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 13,
                //    ProductDescription = "Sparkling Mineral Water.",
                //    ProductName = "Sparkling Water",
                //    ProductQuantity = 100,
                //    ProductPrice = 2.00
                //};
                //Product Cola = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 13,
                //    ProductDescription = "Cola Drink.",
                //    ProductName = "Cola",
                //    ProductQuantity = 100,
                //    ProductPrice = 2.00
                //};
                //Product AJuice = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 13,
                //    ProductDescription = "Apple Juice in a carton.",
                //    ProductName = "Apple Juice",
                //    ProductQuantity = 100,
                //    ProductPrice = 2.00
                //};

                //db.Products.Add(Water);
                //db.Products.Add(SWater);
                //db.Products.Add(AJuice);
                //db.SaveChanges();
                ////ProductCategory Coffee = new ProductCategory { ProductCategoryName = "Coffee" };
                //Product esspresso = new Product
                //{
                //    AllergenID = 9,
                //    ProductCategoryID = 15,
                //    ProductDescription = "Esspresso.",
                //    ProductName = "Esspresso",
                //    ProductQuantity = 100,
                //    ProductPrice = 1.70
                //};
                //Product Latte = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 15,
                //    ProductDescription = "Latte.",
                //    ProductName = "Latte",
                //    ProductQuantity = 100,
                //    ProductPrice = 2.00
                //};
                //Product HotChocolate = new Product
                //{
                //    AllergenID = 15,
                //    ProductCategoryID = 15,
                //    ProductDescription = "HotChocolate.",
                //    ProductName = "HotChocolate",
                //    ProductQuantity = 100,
                //    ProductPrice = 2.00
                //};
                //db.Products.Add(esspresso);
                //db.Products.Add(Latte);
                //db.Products.Add(HotChocolate);
                //db.SaveChanges();
                //db.ProductCategories.Add(DipsAndColdStarters);
                //db.ProductCategories.Add(HotStarters);
                //db.ProductCategories.Add(FishStarters);
                //db.ProductCategories.Add(Kebaps);
                //db.ProductCategories.Add(SteaksAndBarbecue);
                //db.ProductCategories.Add(Vegetarian);
                //db.ProductCategories.Add(IceCreams);
                //db.ProductCategories.Add(Cakes);
                //db.ProductCategories.Add(FizzyDrinks);
                //db.ProductCategories.Add(Drinks);
                //db.ProductCategories.Add(Coffee);
                //db.SaveChanges();


                //Allergen celery = new Allergen { AllergenName = "Celery" };
                //Allergen Gluten = new Allergen { AllergenName = "Gluten" };
                //Allergen Eggs = new Allergen { AllergenName = "Eggs" };
                //Allergen Fish = new Allergen { AllergenName = "Fish" };
                //Allergen nuts = new Allergen { AllergenName = "Nuts" };
                //Allergen Milk = new Allergen { AllergenName = "Milk" };

                //db.Allergens.Add(celery);
                //db.Allergens.Add(Gluten);
                //db.Allergens.Add(Eggs);
                //db.Allergens.Add(Fish);
                //db.Allergens.Add(nuts);
                //db.Allergens.Add(Milk);
                //db.SaveChanges();
                //db.TableStatuses.Add(new TableStatus { TableStatusName = "Reserved" });
                //db.SaveChanges();
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
        public Order selectedOrder { get; set; }

        public Reservation selectedReservation { get; set; }

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
