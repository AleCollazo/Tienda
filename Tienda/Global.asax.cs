using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tienda.Models;

namespace Tienda
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ProductosContainer.Productos = new List<Producto>();
        }

        public static class ProductosContainer
        {
            public static List<Producto> Productos { get; set; }
        }
    }
}
