using log4net;
using MvcPaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;
using static Tienda.MvcApplication;

namespace Tienda.Controllers
{
    public class ListController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);
        // GET: List
        public ActionResult Index(int? page)
        {

            try
            {
                using (TIENDADBEntities tienda = new TIENDADBEntities())
                {
                    ProductosContainer.Productos = tienda.Producto.ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View();
            }

            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var pageListProducts = ProductosContainer.Productos.ToPagedList(currentPageIndex, 10);
            
            return View(pageListProducts);
        }

        public ActionResult FindProduct(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var pageListProducts = ProductosContainer.Productos.ToPagedList(currentPageIndex, 10);

            return View("Index", pageListProducts);
        }

        public ActionResult generarTickect(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var pageListProducts = ProductosContainer.Productos.ToPagedList(currentPageIndex, 10);

            return View("Index",pageListProducts);
        }

        public ActionResult AjaxPage(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var pageListProducts = ProductosContainer.Productos.ToPagedList(currentPageIndex, 10);
            return PartialView("_ListaProductos", pageListProducts);
        }

        [HttpPost]
        public ActionResult FindProduct(FormCollection collection)
        {
            

            try
            {
                using (TIENDADBEntities tienda = new TIENDADBEntities())
                {
                    string nombreBusqueda = collection["buscar"];
                    ProductosContainer.Productos = tienda.Producto.Where(p => p.Descripcion.Contains(nombreBusqueda)).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View("Index");
            }

            int currentPageIndex = 0;
            var pageListProducts = ProductosContainer.Productos.ToPagedList(currentPageIndex, 10);

            return View("Index", pageListProducts);
        }

        [HttpPost]
        public ActionResult generarTickect(int? page, FormCollection collection)
        {

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
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.Message, ex);
                return View("Index");
            }

            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var pageListProducts = ProductosContainer.Productos.ToPagedList(currentPageIndex, 10);

            return View("Index", pageListProducts);
        }
    }
}