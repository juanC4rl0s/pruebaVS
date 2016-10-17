using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BLL;
/// <summary>
/// Summary description for conexionSQL
/// </summary>

namespace SQLCLASS
{
    public class conexionSQL
    {
        SqlConnection SQLconn = new SqlConnection();
        public DataTable dt = new DataTable();
        public static DataTable DTGLOBAL = new DataTable();

        public conexionSQL()
        {
            SQLconn.ConnectionString = ConfigurationManager.ConnectionStrings["SQLServerBD"].ConnectionString;
        }
        /// <summary>
        /// use este metodo para sentencias de SELECT
        /// </summary>
        /// <param name="comand">LE RECOMINDO PARA (SELECT)</param>
        public void retriveDate(string comand)
        {
            try
            {
                SQLconn.Open();
                SqlDataAdapter adt = new SqlDataAdapter(comand, SQLconn);
                adt.Fill(dt);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('Ha ocurrido un error al conectar a la BD " + ex.Message + "');</script>");
            }
            finally
            {
                SQLconn.Close();
            }
        }

        public void obtenerDataTable(string comand)
        {
            try
            {
                //String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\" + "obtenerDataTableQUERY" + ".txt";
                //string texto = comand;
                //System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
                //sw.WriteLine(texto);
                //sw.Close();

                dt = new DataTable();
                DTGLOBAL = new DataTable();
                SQLconn.Open();
                SqlDataAdapter adt = new SqlDataAdapter(comand, SQLconn);
                adt.Fill(dt);
                adt.Fill(DTGLOBAL);
                if (dt.Rows.Count > 0)
                {
                    PERSONASCER.dtrespuesta = dt;
                    //HttpContext.Current.Response.Write("<script>alert('El comando se ha ejecutado " + dt.Rows[0]["IDPERSONA"].ToString() + " ');</script>");
                }
            }
            catch (Exception ex)
            {
                String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\" + "obtenerDataTableERROR" + ".txt";
                string texto = ex.Message + " " + ex.Source + " " + ex.StackTrace + " " + ex.InnerException + " ";
                System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
                sw.WriteLine(texto);
                sw.Close();
                HttpContext.Current.Response.Write("<script>alert('Ha ocurrido un error al conectar a la BD " + ex.Message + "');</script>");
            }
            finally
            {
                SQLconn.Close();
            }
        }
        
        /// <summary>
        /// use este metodo para sentencias de INSERT, UPDATE Y DELETE
        /// </summary>
        /// <param name="comand">LE RECOMIENDO PARA (UPDATE)</param>
        public void executeComando(string comand)
        {
            try
            {
                //String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\" + "executeComandoQUERY" + ".txt";
                //string texto = comand;
                //System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
                //sw.WriteLine(texto);
                //sw.Close();

                SQLconn.Open();
                SqlCommand SQLcom = new SqlCommand(comand, SQLconn);
                int rowAfectada = SQLcom.ExecuteNonQuery();
                if (rowAfectada > 0)
                {
                    //HttpContext.Current.Response.Write("<script>alert('El comando se ha ejecutado');</script>");
                }
                else
                {
                    //HttpContext.Current.Response.Write("<script>alert('Ocurrio un error en la BD, Intentelo de nuevo');</script>");
                }
            }
            catch (Exception ex)
            {
                String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\" + "executeComandoERROR" + ".txt";
                string texto = ex.Message + " " + ex.Source + " " + ex.StackTrace + " " + ex.InnerException + " ";
                System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
                sw.WriteLine(texto);
                sw.Close();
                HttpContext.Current.Response.Write("<script>alert('Ha ocurrido un error al conectar a la BD " + ex.Message + "');</script>");
            }
            finally
            {
                SQLconn.Close();
            }
        }
    }
}