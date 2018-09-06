using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MascotApp_WS.Models
{
    public class Adopcion
    {
        public string Fundacion { get; set; }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ciudad { get; set; }
        public string Raza { get; set; }
        public string Edad { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }
    }
}