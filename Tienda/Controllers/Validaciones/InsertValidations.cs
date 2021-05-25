using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tienda.Models;

namespace Tienda.Controllers.Validaciones
{
    public static class InsertValidations
    {
        public static bool validarMarca(this TIENDADBEntities tienda, Marca marca)
        {
            if (tienda.Marca.Count(m => m.Codigo.Equals(marca.Codigo)) > 1) return false;
            if (tienda.Marca.Count(m => m.Descripcion.Equals(marca.Descripcion)) > 1) return false;

            return true;
        }

        public static bool validarTipoProducto(this TIENDADBEntities tienda, TipoProducto tipoProducto)
        {
            if (tienda.TipoProducto.Count(tp => tp.Codigo.Equals(tipoProducto.Codigo)) > 1) return false;
            if (tienda.TipoProducto.Count(tp => tp.Nombre.Equals(tipoProducto.Nombre)) > 1) return false;

            return true;
        }
    }
}