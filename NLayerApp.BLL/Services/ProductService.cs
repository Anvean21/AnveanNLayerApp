using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork Database { get; set; }
        public ProductService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен id продукта","");
            }
            var prod = Database.Products.Get(id.Value);
            if (prod == null)
            {
                throw new ValidationException("Продукт не найден", "");
            }
            return new ProductDTO { Name = prod.Name, Id = prod.Id, CategoryId = prod.CategoryId, Description = prod.Description,CategoryName = prod.Category.Name, Price = prod.Price };
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>().ForMember("CategoryName", opt=> opt.MapFrom(c=> c.Category.Name))).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }
    }
}
