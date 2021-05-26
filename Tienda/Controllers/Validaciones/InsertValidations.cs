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
            if (tienda.Marca.Count(m => m.Codigo == marca.Codigo) > 0) return false;
            if (tienda.Marca.Count(m => m.Descripcion == marca.Descripcion) > 0) return false;

            return true;
        }

        public static bool validarTipoProducto(this TIENDADBEntities tienda, TipoProducto tipoProducto)
        {
            if (tienda.TipoProducto.Count(tp => tp.Codigo == tipoProducto.Codigo) > 0) return false;
            if (tienda.TipoProducto.Count(tp => tp.Nombre == tipoProducto.Nombre) > 0) return false;

            return true;
        }
    }
}