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
    public class ValidateController : ApiController
    {


        // GET: api/Validate/5
        public ValidateResponse Get(int id)
        {
            ValidateResponse vr = new ValidateResponse();
            DataSet ds = InstruccionesSql.ejecutar_select("SELECT * FROM Usuarios WHERE Id ='" + id + "'");
            Usuarios u = new Usuarios();
            bool res;
            if (ds.Tables?[0].Rows.Count > 0)
            {
                foreach (DataRow usuariosrecord in ds.Tables[0].Rows)
                {
                    u.Id = usuariosrecord["Id"].ToString();
                    u.Usuario = usuariosrecord["Usuario"].ToString();
                    u.Email = usuariosrecord["Email"].ToString();
                    u.Contrasena = usuariosrecord["Contrasena"].ToString();
                    u.Token = usuariosrecord["Token"].ToString();
                    u.Foto_Perfil = usuariosrecord["Foto_Perfil"].ToString();
                    u.Fecha_Creacion = usuariosrecord["Fecha_Creacion"].ToString();
                    u.Rol = usuariosrecord["Rol"].ToString();
                    u.Estado = usuariosrecord["Estado"].ToString();
                }

                if (u.Estado == "0")
                {
                    res = InstruccionesSql.ejecutar_comando("UPDATE Usuarios SET Estado = 1 WHERE Id ='" + id + "'");
                    if (res)
                    {
                        vr.CodigoMensaje = "1";
                        vr.Mensaje = "Activado";
                    }
                    else
                    {
                        vr.CodigoMensaje = "2";
                        vr.Mensaje = "Error";
                    }
                }
                else
                {
                    vr.CodigoMensaje = "3";
                    vr.Mensaje = "Usuario activado";
                }
            }
            else
            {
                vr.CodigoMensaje = "4";
                vr.Mensaje = "No encontrado";
            }
            return vr;
        }

    } 
}

