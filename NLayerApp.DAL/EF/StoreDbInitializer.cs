using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
    public class StoreDbInitializer : DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {
            var category1 = new Category { Name = "Games" };
            var category2 = new Category { Name = "Food" };
            var category3 = new Category { Name = "Cars" };
            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);

            db.SaveChanges();
            var product1 = new Product { Name = "Car", Category = category3, Description = "Something about cars", Price = 1000 };
            var product2 = new Product { Name = "Game", Category = category1, Description = "Something about games", Price = 100 };
            var product3 = new Product { Name = "Food", Category = category2, Description = "Something about Food", Price = 10 };
            db.Products.Add(product1);
            db.Products.Add(product2);
            db.Products.Add(product3);
            db.SaveChanges();
            base.Seed(db);
        }
    }
}
