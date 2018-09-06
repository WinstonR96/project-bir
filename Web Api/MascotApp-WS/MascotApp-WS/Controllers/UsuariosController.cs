using MascotApp_WS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MascotApp_WS.Controllers
{
    public class UsuariosController : ApiController
    {
        
        // GET api/values
        public UsuariosResponse Get()
        {           
            DataSet ds = InstruccionesSql.ejecutar_select("SELECT * FROM Usuarios");
            Usuarios u = null;
            UsuariosResponse UR = new UsuariosResponse();
            List<Usuarios> usuarios = new List<Usuarios>();
            if (ds.Tables?[0].Rows.Count > 0)
            {
                usuarios = new List<Usuarios>(ds.Tables[0].Rows.Count);
                int i = 0;
                foreach (DataRow usuariosrecord in ds.Tables[0].Rows)
                {
                    u = new Usuarios();
                    u.Id = usuariosrecord["Id"].ToString();
                    u.Usuario = usuariosrecord["Usuario"].ToString();
                    u.Email = usuariosrecord["Email"].ToString();
                    u.Contrasena = usuariosrecord["Contrasena"].ToString();
                    u.Token = usuariosrecord["Token"].ToString();
                    u.Foto_Perfil = usuariosrecord["Foto_Perfil"].ToString();
                    u.Fecha_Creacion = usuariosrecord["Fecha_Creacion"].ToString();
                    u.Rol = usuariosrecord["Rol"].ToString();
                    u.Estado = usuariosrecord["Estado"].ToString();
                    usuarios.Add(u);
                    i++;
                }

                UR.CodigoMensaje = "1";
                UR.Mensaje = "Exitoso";
                UR.usuarios = usuarios;
            }
            else
            {
                UR.CodigoMensaje = "0";
                UR.Mensaje = "No hay información";
                UR.usuarios = usuarios;
            }
            return UR;
        }
       

        // GET api/values/5
        public Usuarios Get(int id)
        {
            DataSet ds = InstruccionesSql.ejecutar_select("SELECT * FROM Usuarios WHERE Estado = 1 and Id ='"+id+"'");
            Usuarios u = new Usuarios();
            if (ds.Tables?[0].Rows.Count > 0)
            {
                foreach(DataRow usuariosrecord in ds.Tables[0].Rows)
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
                
               
            }
            return u;
        }
              
        

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
