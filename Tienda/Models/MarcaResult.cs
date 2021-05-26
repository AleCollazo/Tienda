using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda.Models
{
    public class MarcaResult
    {
        public MarcaResult()
        {
            inputCodigo = new InputCodigo();
            inputDescripcion = new InputDescripcion();
        }
        public string Mensaje { get; set; }
        public bool Show { get; set; }
        public bool Error { get; set; }
        public InputCodigo inputCodigo { get; }
        public InputDescripcion inputDescripcion { get; }
    }

    public class InputCodigo
    {
        public bool Valido { get; set; }
        public string MensajeError { get; set; }
    }

    public class InputDescripcion
    {
        public bool Valido { get; set; }
        public string MensajeError { get; set; }
    }
}