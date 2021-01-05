using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.Services;

namespace NLayerApp.WEB.Util
{
    public class ProductModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
        }
    }
}