using MascotApp_WS.Models;
using MascotApp_WS.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MascotApp_WS.Controllers
{
    public class MascotasController : ApiController
    {
        public AdopcionResponse Get()
        {
            AdopcionResponse ar = new AdopcionResponse();
            Adopcion a = null;
            DataSet ds = InstruccionesSql.ejecutar_select("SELECT f.Nombre AS Fundacion, m.* FROM Adopciones a INNER JOIN Mascotas m ON a.Id = m.Id INNER JOIN Fundaciones f ON m.Id = a.Id; ");
            if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
            {
                List<Adopcion> la = new List<Adopcion>(ds.Tables[0].Rows.Count);
                foreach(DataRow mascotas in ds.Tables[0].Rows)
                {
                    a = new Adopcion();
                    a.Fundacion = mascotas["Fundacion"].ToString();
                    a.Id = mascotas["Id"].ToString();
                    a.Nombre = mascotas["Nombre"].ToString();
                    a.Descripcion = mascotas["Descripcion"].ToString();
                    a.Ciudad = mascotas["Ciudad"].ToString();
                    a.Raza = mascotas["Raza"].ToString();
                    a.Edad = mascotas["Edad"].ToString();
                    a.Foto = mascotas["Foto"].ToString();
                    a.Estado = mascotas["Estado"].ToString();
                    la.Add(a);
                }
                ar.CodigoMensaje = "1";
                ar.Mensaje = "Ok";
                ar.adopcion = la;
            }
            else
            {
                ar.CodigoMensaje = "0";
                ar.Mensaje = "No hay información";
                ar.adopcion = null;
                
            }
            return ar;
        }

        public MascotaDetalleResponse Get(int Id)
        {
            MascotaDetalleResponse mdr = new MascotaDetalleResponse();
            DataSet ds = InstruccionesSql.ejecutar_select("SELECT f.Nombre AS Fundacion, m.* FROM Adopciones a INNER JOIN Mascotas m ON a.Id = m.Id INNER JOIN Fundaciones f ON m.Id = a.Id WHERE m.Id ='" + Id + "'");
            Adopcion ad = new Adopcion();
            if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
            {
                foreach(DataRow mascota in ds.Tables[0].Rows)
                {
                    ad.Fundacion = mascota["Fundacion"].ToString();
                    ad.Id = mascota["Id"].ToString();
                    ad.Nombre = mascota["Nombre"].ToString();
                    ad.Descripcion = mascota["Descripcion"].ToString();
                    ad.Ciudad = mascota["Ciudad"].ToString();
                    ad.Raza = mascota["Raza"].ToString();
                    ad.Edad = mascota["Edad"].ToString();
                    ad.Foto = mascota["Foto"].ToString();
                    ad.Estado = mascota["Estado"].ToString();
                }
                mdr.CodigoMensaje = "1";
                mdr.Mensaje = "0";
                mdr.adopcion = ad;
            }
            else
            {
                mdr.CodigoMensaje = "0";
                mdr.Mensaje = "No existe";
                mdr.adopcion = null;
            }
                return mdr;
        }

    }
}
