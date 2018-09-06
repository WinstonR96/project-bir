using MascotApp_WS.Models.Request;
using MascotApp_WS.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using MascotApp_WS.Models;
using System.Net.Mail;

namespace MascotApp_WS.Controllers
{
    public class RegisterController : ApiController
    {
        // POST api/values
        public RegisterResponse Post([FromBody]RegisterRequest rr)
        {
            RegisterResponse registerresponse = new RegisterResponse();
            StringBuilder query = new StringBuilder();
            string usuario = rr.Usuario;
            string email = rr.Email;
            string password = GetMD5(rr.Contrasena);
            string token = GetMD5(rr.Contrasena + rr.Email);
            string url_foto = "http://www.iconarchive.com/download/i103458/paomedia/small-n-flat/profile.ico";
            string values = "'"+usuario+"'" + "," + "'"+email + "'" + "," + "'"+password+ "'" + "," + "'"+token+ "'" + "," + 1 + "," + "'"+url_foto+"'" + ","+ 0;
            bool res;
            DataSet ds = InstruccionesSql.ejecutar_select("SELECT * FROM Usuarios WHERE Usuario = '" + usuario + "'OR Email = '" + email + "'");
            Usuarios u = new Usuarios();
            if (ds.Tables?[0].Rows.Count > 0)
            {
                registerresponse.CodigoMensaje = "1";
                registerresponse.Mensaje = "Usuario ya existe";
            }
            else
            {
                res = InstruccionesSql.ejecutar_comando("INSERT INTO Usuarios (Usuario, Email, Contrasena, Token, Rol, Foto_Perfil, Estado) VALUES ("+values+")");
                
                if (res)
                {
                    DataSet usuarioRegistrado = InstruccionesSql.ejecutar_select("SELECT * FROM Usuarios WHERE Usuario ='" + usuario + "'");
                    if (usuarioRegistrado.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow usuariosrecord in usuarioRegistrado.Tables[0].Rows)
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
                    string url = "http://localhost:52043/api/v1/validate/" + u.Id;
                    try
                    {
                        MailMessage correo = new MailMessage();
                        correo.From = new MailAddress("wijurost@gmail.com");
                        correo.To.Add(email);
                        correo.Subject = "Active su cuenta para seguir";
                        correo.Body = "Para activar su cuenta dirijase al siguiente link: " + url;
                        correo.IsBodyHtml = true;
                        correo.Priority = MailPriority.Normal;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        string SCuentaCorreo = "soportebucompany@gmail.com";
                        string sPasswordCorreo = "Bucompany2017";
                        smtp.Credentials = new NetworkCredential(SCuentaCorreo, sPasswordCorreo);
                        smtp.Send(correo);
                        registerresponse.CodigoMensaje = "2";
                        registerresponse.Mensaje = "Verifique su correo para activar la cuenta";

                    }catch(Exception e)
                    {
                        registerresponse.CodigoMensaje = "3";
                        registerresponse.Mensaje = e.Message.ToString();
                    }
                }
            }
                return registerresponse;
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
