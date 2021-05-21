using log4net;
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
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        // GET: List
        public ActionResult Index()
        {
            List<Producto> productos = new List<Producto>();
            
            try
            {
                using (TIENDADBEntities tienda = new TIENDADBEntities())
                {
                    productos = tienda.Producto.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View();
            }
            
            return View(productos);
        }

        [HttpPost]
        public ActionResult FindProduct(FormCollection collection)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (TIENDADBEntities tienda = new TIENDADBEntities())
                {
                    string nombreBusqueda = collection["buscar"];
                    productos = tienda.Producto.Where(p => p.Descripcion.Contains(nombreBusqueda)).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View();
            }

            return View("Index", productos);
        }

        [HttpPost]
        public ActionResult generarTickect(FormCollection collection)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (TIENDADBEntities tienda = new TIENDADBEntities())
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

                    productos = tienda.Producto.ToList();
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View();
            }

            return View("Index", productos);
        }
    }
}