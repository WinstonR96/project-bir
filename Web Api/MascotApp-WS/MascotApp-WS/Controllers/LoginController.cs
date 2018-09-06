using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using MascotApp_WS.Models;
using MascotApp_WS.Models.Request;

namespace MascotApp_WS.Controllers
{
    public class LoginController : ApiController
    {
        public LoginResponse Post([FromBody]LoginRequest lr)
        {
            LoginResponse loginresponse = new LoginResponse();
            string usuario = lr.Usuario;
            string email = lr.Email;
            string password = GetMD5(lr.Contrasena);
            DataSet ds = InstruccionesSql.ejecutar_select("SELECT * FROM Usuarios WHERE Usuario = '" + usuario + "'OR Email = '" + email + "'");
            Usuarios u = new Usuarios();
            if ((ds.Tables.Count != 0) && (ds.Tables[0].Rows.Count > 0))
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
                    loginresponse.CodigoMensaje = "0";
                    loginresponse.Mensaje = "Usuario no activado";
                    loginresponse.usuario = u;
                }
                if (u.Estado == "1")
                {
                    if (u.Contrasena == password)
                    {
                        loginresponse.CodigoMensaje = "01";
                        loginresponse.Mensaje = "Correcto";
                        loginresponse.usuario = u;
                    }
                    else
                    {
                        loginresponse.CodigoMensaje = "02";
                        loginresponse.Mensaje = "Contraseña Incorrecta";
                        loginresponse.usuario = null;
                    }
                }
                if (u.Estado == "2")
                {
                    loginresponse.CodigoMensaje = "2";
                    loginresponse.Mensaje = "Usuario eliminado";
                    loginresponse.usuario = u;
                }

                if (int.Parse(u.Estado) >= int.Parse("3"))
                {
                    loginresponse.CodigoMensaje = "4";
                    loginresponse.Mensaje = "Ocurrio un error";
                    loginresponse.usuario = null;
                }
            }
            else
            {
                loginresponse.CodigoMensaje = "3";
                loginresponse.Mensaje = "Usuario no existe";
                loginresponse.usuario = null;
            }
            return loginresponse;

        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
