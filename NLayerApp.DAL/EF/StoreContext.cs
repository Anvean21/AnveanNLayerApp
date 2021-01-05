using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
   public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreDbInitializer());
        }
        public StoreContext(string connectionString)
            :base(connectionString)
        {

        }
        
    }
}
