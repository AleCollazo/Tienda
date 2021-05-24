using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class InsertController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        // GET: Insert
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddMarca(FormCollection collection)
        {
            try
            {
                if (!decimal.TryParse(collection["marca.Codigo"].ToString(), out decimal codigo))
                    throw new Exception();

                string descripcion = collection["marca.Descripcion"].ToString();
                if (string.IsNullOrEmpty(descripcion))
                    throw new Exception();

                using (TIENDADBEntities tienda = new TIENDADBEntities())
                {
                    Marca marca = new Marca()
                    {
                        Codigo = codigo,
                        Descripcion = descripcion
                    };

                    tienda.Marca.Add(marca);
                    tienda.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View("Index");
            }
            return View("Index");
        }


        [HttpPost]
        public ActionResult AddTipoProducto(FormCollection collection)
        {
            try
            {
                if (!decimal.TryParse(collection["tipoProducto.Codigo"].ToString(), out decimal codigo))
                    throw new Exception();

                string nombre = collection["tipoProducto.Nombre"].ToString();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception();

                using (TIENDADBEntities tienda = new TIENDADBEntities())
                {
                    TipoProducto tipoProducto = new TipoProducto()
                    {
                        Codigo =  codigo,
                        Nombre = nombre,
                    };

                    tienda.TipoProducto.Add(tipoProducto);
                    tienda.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View("Index");
            }
            return View("Index");
        }


        [HttpPost]
        public ActionResult AddProducto(FormCollection collection)
        {
            try
            {
                if (!decimal.TryParse(collection["Marca"].ToString(), out decimal marcaId))
                    throw new Exception();

                if (!decimal.TryParse(collection["TipoProducto"].ToString(), out decimal tipoProductoId))
                    throw new Exception();

                string descripcion = collection["producto.Descripcion"].ToString();
                if (string.IsNullOrEmpty(descripcion))
                    throw new Exception();

                if(!decimal.TryParse(collection["producto.Precio"].ToString(), out decimal precio))
                    throw new Exception();

                if(decimal.TryParse(collection["producto.Stock"].ToString(), out decimal stock))
                    throw new Exception();

                using (TIENDADBEntities tienda = new TIENDADBEntities())
                {
                    Producto producto = new Producto()
                    {
                        MarcaId = marcaId,
                        TipoProductoId = tipoProductoId,
                        Descripcion = descripcion,
                        Talla = collection["producto.Talla"].ToString(),
                        Color = collection["producto.Color"].ToString(),
                        Precio = precio,
                        Stock = stock
                    };

                    tienda.Producto.Add(producto);
                    tienda.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View("Index");
            }
            return View("Index");
        }
    }
}