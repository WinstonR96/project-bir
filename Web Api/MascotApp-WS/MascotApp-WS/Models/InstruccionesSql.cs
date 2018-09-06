using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MascotApp_WS.Models
{
    public static class InstruccionesSql
    {
        private static string connString = "data source=A1528361\\SQLEXPRESS; Initial catalog=MascotApp; Integrated Security = True";


        public static DataSet ejecutar_select(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public static bool ejecutar_comando(string comando)
        {
            bool rta = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    SqlCommand cm = new SqlCommand(comando, con);
                    cm.ExecuteNonQuery();
                    rta = true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("[ejecutar_comando] Error: " + e.Message);
            }
            return rta;
        }
    }
}