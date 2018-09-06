using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MascotApp_WS.Models.Request
{
    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
    }
}