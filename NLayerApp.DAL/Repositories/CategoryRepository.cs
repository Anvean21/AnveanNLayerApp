﻿using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
   public class CategoryRepository : IRepository<Category>
    {

        private StoreContext db;

        public CategoryRepository(StoreContext context)
        {
            this.db = context;
        }
        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category cat = db.Categories.Find(id);
            if (cat!=null)
            {
                db.Categories.Remove(cat);
            }
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return db.Categories.Where(predicate).ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public void Update(Category item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
