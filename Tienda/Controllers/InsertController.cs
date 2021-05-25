using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;
using Tienda.Controllers.Validaciones;

namespace Tienda.Controllers
{
    public class InsertController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        // GET: Insert
        public ActionResult Index()
        {
            return View(new InsertError { show = false});
        }


        [HttpPost]
        public ActionResult AddMarca(FormCollection collection)
        {
            string mensajeSalida = "";
            try
            {
                if (!decimal.TryParse(collection["marca.Codigo"].ToString(), out decimal codigo))
                    throw new Exception("Error al convertir el código de marca a decimal");

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

                    if (tienda.validarMarca(marca))
                    {
                        tienda.Marca.Add(marca);
                        tienda.SaveChanges();
                        mensajeSalida = LocalResources.Resources.añadidaMarcaMsg;
                    }
                    else 
                    {
                        mensajeSalida = LocalResources.Resources.marcaRepetidaMsg;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View("Index", 
                    new InsertError 
                    { 
                        Mensaje = LocalResources.Resources.errorAñadirMarcaMsg,
                        show = true,
                        error = true
                    });
            }
            return View("Index",
                new InsertError
                {
                    Mensaje = mensajeSalida,
                    show = true,
                    error = false
                });
        }


        [HttpPost]
        public ActionResult AddTipoProducto(FormCollection collection)
        {
            string mensajeSalida = "";
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

                    if (tienda.validarTipoProducto(tipoProducto))
                    {
                        tienda.TipoProducto.Add(tipoProducto);
                        tienda.SaveChanges();
                        mensajeSalida = LocalResources.Resources.añadidoTipoProductoMsg;
                    }
                    else
                    {
                        mensajeSalida = LocalResources.Resources.tipoProductoRepetidoMsg;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View("Index",
                    new InsertError
                    {
                        Mensaje = LocalResources.Resources.errorAñadirTipoProductoMsg,
                        show = true,
                        error = true
                    });
            }
            return View("Index",
                new InsertError
                {
                    Mensaje = mensajeSalida,
                    show = true,
                    error = false
                });
        }


        [HttpPost]
        public ActionResult AddProducto(FormCollection collection)
        {
            try
            {
                if (!decimal.TryParse(collection["Marca"].ToString(), out decimal marcaId))
                    throw new Exception("Error al convertir la marca a decimal");

                if (!decimal.TryParse(collection["TipoProducto"].ToString(), out decimal tipoProductoId))
                    throw new Exception();

                string descripcion = collection["producto.Descripcion"].ToString();
                if (string.IsNullOrEmpty(descripcion))
                    throw new Exception();

                if(!decimal.TryParse(collection["producto.Precio"].ToString(), out decimal precio))
                    throw new Exception();

                if(!decimal.TryParse(collection["producto.Stock"].ToString(), out decimal stock))
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
                return View("Index",
                    new InsertError
                    {
                        Mensaje = LocalResources.Resources.errorAñadirProducto,
                        show = true,
                        error = true
                    });
            }
            return View("Index",
                new InsertError
                {
                    Mensaje = LocalResources.Resources.añadidoProducto,
                    show = true,
                    error = false
                });
        }
    }
}