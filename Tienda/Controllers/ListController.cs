using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class ListController : Controller
    {
        private TIENDADBEntities tienda = new TIENDADBEntities();

        // GET: List
        public ActionResult Index()
        {
            return View(tienda.Producto.ToList());
        }

        [HttpPost]
        public ActionResult FindProduct(FormCollection collection)
        {
            string nombreBusqueda = collection["buscar"];

            return View("Index", tienda.Producto.Where(p => p.Descripcion.Contains(nombreBusqueda)).ToList());
        }

        [HttpPost]
        public ActionResult generarTickect(FormCollection collection)
        {
            foreach (string date in collection)
            {
                if (collection[date].Contains("true"))
                {
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

            return View("Index", tienda.Producto.ToList());
        }
    }
}