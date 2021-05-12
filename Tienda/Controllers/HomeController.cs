using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class HomeController : Controller
    {
        private TIENDADBEntities tienda = new TIENDADBEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMarca(FormCollection collection)
        {
            Marca marca = new Marca()
            {
                Codigo = decimal.TryParse(collection["marca.Codigo"].ToString(), out decimal codigo) ? (decimal?)codigo : null,
                Descripcion = collection["marca.Descripcion"].ToString()
            };

            tienda.Marca.Add(marca);
            tienda.SaveChanges();

            return Redirect("Insert");
        }

        [HttpPost]
        public ActionResult AddTipoProducto(FormCollection collection)
        {
            TipoProducto tipoProducto = new TipoProducto()
            {
                Codigo = decimal.TryParse(collection["tipoProducto.Codigo"].ToString(), out decimal codigo) ? (decimal?)codigo : null,
                Nombre = collection["tipoProducto.Nombre"].ToString(),
            };

            tienda.TipoProducto.Add(tipoProducto);
            tienda.SaveChanges();

            return Redirect("Insert");
        }


        [HttpPost]
        public ActionResult AddProducto(FormCollection collection)
        {
            Producto producto = new Producto()
            {
                MarcaId = decimal.TryParse(collection["Marca"].ToString(), out decimal marcaId) ? (decimal?)marcaId : null,
                TipoProductoId = decimal.TryParse(collection["TipoProducto"].ToString(), out decimal tipoProductoId) ? (decimal?)tipoProductoId : null,
                Descripcion = collection["producto.Descripcion"].ToString(),
                Talla = collection["producto.Talla"].ToString(),
                Color = collection["producto.Color"].ToString(),
                Precio = decimal.TryParse(collection["producto.Precio"].ToString(), out decimal precio) ? (decimal?)precio : null,
                Stock = decimal.TryParse(collection["producto.Stock"].ToString(), out decimal stock) ? (decimal?)stock : null
            };

            tienda.Producto.Add(producto);
            tienda.SaveChanges();

            return Redirect("Insert");
        }

        public ActionResult List()
        {
            return View(tienda.Producto.ToList());
        }

        [HttpPost]
        public ActionResult FindProduct(FormCollection collection)
        {
            string nombreBusqueda = collection["buscar"];

            return View("List", tienda.Producto.Where(p => p.Descripcion.Contains(nombreBusqueda)).ToList());
        }

        [HttpPost]
        public ActionResult generarTickect(FormCollection collection)
        {
            foreach (string date in collection) {
                if (collection[date].Contains("true")) {
                    if (decimal.TryParse(date, out decimal productoId))
                    {
                        Producto producto = tienda.Producto.Where(p => p.ProductoId == productoId).FirstOrDefault();

                        Ticket ticket = new Ticket()
                        {
                            Fecha = DateTime.Now,
                            Importe = producto.Precio,
                            CantidadProductos = 1
                        };

                        tienda.Ticket.Add(ticket);

                        TicketDetalle ticketDetalle = new TicketDetalle()
                        {
                            TicketId = ticket.TicketId,
                            ProductoId = producto.ProductoId
                        };

                        tienda.TicketDetalle.Add(ticketDetalle);
                        tienda.SaveChanges();
                    }
                }
            }

            return View("List", tienda.Producto.ToList());
        }
    }
}