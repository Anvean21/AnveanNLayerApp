using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interfaces;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IProductService productService;
        public HomeController(IProductService serv)
        {
            productService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<ProductDTO> prodDtos = productService.GetProducts();                                   //.ForMember("CategoryName", opt => opt.MapFrom(c => c.CategoryName))
            var mapper = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var prods =  mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(prodDtos);
            return View(prods);
        }
        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }
    }
}