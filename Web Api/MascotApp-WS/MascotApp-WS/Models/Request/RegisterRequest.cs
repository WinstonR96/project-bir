using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MascotApp_WS.Models.Request
{
    public class RegisterRequest
    {
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}