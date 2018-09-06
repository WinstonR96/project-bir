using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MascotApp_WS.Models.Response
{
    public class AdopcionResponse
    {
        public string CodigoMensaje { get; set; }
        public string Mensaje { get; set; }
        public List<Adopcion> adopcion { get; set; }
    }
}