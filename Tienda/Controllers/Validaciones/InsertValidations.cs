using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers.Validaciones
{
    public static class InsertValidations
    {
        public static bool validarMarcaCamposRepetidos(this TIENDADBEntities tienda, Marca marca)
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

    public static class InsertMarcaValidations
    {
        public static MarcaResult validarDatos(this FormCollection collection, out Marca marca)
        {
            MarcaResult marcaResult = new MarcaResult();
            marca = new Marca();

            string codigoStr = collection["codigo"].ToString();
            decimal codigo = 0;
            if (string.IsNullOrEmpty(codigoStr))
            {
                marcaResult.Error = true;
                marcaResult.inputCodigo.Valido = false;
                marcaResult.inputCodigo.MensajeError = LocalResources.Resources.errorMsgRequired;
            }
            else if (!decimal.TryParse(codigoStr, out codigo))
            {
                marcaResult.Error = true;
                marcaResult.inputCodigo.Valido = false;
                marcaResult.inputCodigo.MensajeError = LocalResources.Resources.errorMsgNumber;
            }
            else
                marcaResult.inputCodigo.Valido = true;
                
            string descripcion = collection["descripcion"].ToString();
            if (string.IsNullOrEmpty(descripcion))
            {
                marcaResult.Error = true;
                marcaResult.inputDescripcion.Valido = false;
                marcaResult.inputDescripcion.MensajeError = LocalResources.Resources.errorMsgRequired;
            }
            else
                marcaResult.inputDescripcion.Valido = true;
            
            if (!marcaResult.Error) {
                marca.Codigo = codigo;
                marca.Descripcion = descripcion;
            }

            return marcaResult;
        }

        public static bool validar(this Marca marca, ref MarcaResult marcaResult)
        {
            bool res = false;
            using (TIENDADBEntities tienda = new TIENDADBEntities())
            {
                res = true;
                if (tienda.Marca.Count(m => m.Codigo == marca.Codigo) > 0)
                {
                    marcaResult.inputCodigo.Valido = false;
                    marcaResult.inputCodigo.MensajeError = LocalResources.Resources.errorCodigoRepetido;
                    res = false;
                }
                
                if (tienda.Marca.Count(m => m.Descripcion == marca.Descripcion) > 0)
                {
                    marcaResult.inputDescripcion.Valido = false;
                    marcaResult.inputDescripcion.MensajeError = LocalResources.Resources.errorDescripciónRepetida;
                    res = false;
                }
                
                if (res)
                {
                    tienda.Marca.Add(marca);
                    tienda.SaveChanges();
                    marcaResult.Show = true;
                    marcaResult.Mensaje = LocalResources.Resources.añadidaMarcaMsg;
                }
                else
                {
                    marcaResult.Error = true;
                    marcaResult.Show = true;
                    marcaResult.Mensaje = LocalResources.Resources.marcaRepetidaMsg;
                }
            }

            return res;
        }
    }
}