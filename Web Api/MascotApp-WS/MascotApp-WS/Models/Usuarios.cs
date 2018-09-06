using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MascotApp_WS.Models
{
    public class Usuarios
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Token { get; set; }
        public string Foto_Perfil { get; set; }
        public string Fecha_Creacion { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }
}