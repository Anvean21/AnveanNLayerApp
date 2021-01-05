using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.EF;

namespace NLayerApp.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext db;

        public ProductRepository(StoreContext context)
        {
            this.db = context;
        }
        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product prod = db.Products.Find(id);
            if (prod!=null)
            db.Products.Remove(prod);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
           return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public void Update(Product item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
