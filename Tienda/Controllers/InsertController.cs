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
        private TIENDADBEntities tienda = new TIENDADBEntities();

        // GET: Insert
        public ActionResult Index()
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

            return Redirect("Index");
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

            return Redirect("Index");
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

            return Redirect("Index");
        }
    }
}