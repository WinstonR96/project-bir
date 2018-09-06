using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MascotApp_WS.Models
{
    public class LoginResponse
    {
        public string CodigoMensaje { get; set; }
        public string Mensaje { get; set; }
        public Usuarios usuario { get; set; }
    }
}