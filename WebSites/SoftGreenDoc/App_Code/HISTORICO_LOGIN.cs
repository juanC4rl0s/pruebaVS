using System.Linq;
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using SoftGreenDoc;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Xml.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLCLASS;

namespace BLL
{
    public class HISTORICO_LOGIN
    {
        #region Variables

        private System.Decimal _ID_HISTORICO_LOGIN;
        private System.Decimal _ID_USUSARIO;
        private System.String _IP_LOGIN;
        private System.String _UBICACION;
        private System.String _ACTIVO;
        private System.DateTime _FECHA_INGRESO;
        private System.DateTime _FECHA_SALIDA;
        private System.Decimal _IDUSUARIOCREO;
        private System.DateTime _FECHACREO;
        private System.Decimal _IDUSUARIOMODIFICO;
        private System.DateTime _FECHAMODIFICO;

        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal ID_HISTORICO_LOGIN
        {
            get { return _ID_HISTORICO_LOGIN; }
            set { _ID_HISTORICO_LOGIN = value; }
        }

        public System.Decimal ID_USUSARIO
        {
            get { return _ID_USUSARIO; }
            set { _ID_USUSARIO = value; }
        }

        public System.String IP_LOGIN
        {
            get { return _IP_LOGIN; }
            set { _IP_LOGIN = value; }
        }

        public System.String UBICACION
        {
            get { return _UBICACION; }
            set { _UBICACION = value; }
        }

        public System.String ACTIVO
        {
            get { return _ACTIVO; }
            set { _ACTIVO = value; }
        }
        
        public System.DateTime FECHA_INGRESO
        {
            get { return _FECHA_INGRESO; }
            set { _FECHA_INGRESO = value; }
        }

        public System.DateTime FECHA_SALIDA
        {
            get { return _FECHA_SALIDA; }
            set { _FECHA_SALIDA = value; }
        }

        public System.Decimal IDUSUARIOCREO
        {
            get { return _IDUSUARIOCREO; }
            set { _IDUSUARIOCREO = value; }
        }

        public System.DateTime FECHACREO
        {
            get { return _FECHACREO; }
            set { _FECHACREO = value; }
        }

        public System.Decimal IDUSUARIOMODIFICO
        {
            get { return _IDUSUARIOMODIFICO; }
            set { _IDUSUARIOMODIFICO = value; }
        }

        public System.DateTime FECHAMODIFICO
        {
            get { return _FECHAMODIFICO; }
            set { _FECHAMODIFICO = value; }
        }

        #endregion

        #region Constructores

        public HISTORICO_LOGIN(System.Decimal ID_HISTORICO_LOGIN, System.Decimal ID_USUSARIO,  System.String IP_LOGIN,
            System.String UBICACION, System.String ACTIVO, System.DateTime FECHA_INGRESO,
            System.DateTime FECHA_SALIDA, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_HISTORICO_LOGIN = ID_HISTORICO_LOGIN;
            _ID_USUSARIO = ID_USUSARIO;
            _IP_LOGIN = IP_LOGIN;
            _UBICACION = UBICACION;
            _ACTIVO = ACTIVO;
            _FECHA_INGRESO = FECHA_INGRESO;
            _FECHA_SALIDA = FECHA_SALIDA;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }

        public HISTORICO_LOGIN(System.Decimal ID_USUSARIO, System.String IP_LOGIN,
            System.String UBICACION, System.String ACTIVO, System.DateTime FECHA_INGRESO,
            System.DateTime FECHA_SALIDA, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_USUSARIO = ID_USUSARIO;
            _IP_LOGIN = IP_LOGIN;
            _UBICACION = UBICACION;
            _ACTIVO = ACTIVO;
            _FECHA_INGRESO = FECHA_INGRESO;
            _FECHA_SALIDA = FECHA_SALIDA;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }
        #endregion

        #region Métodos

        public static decimal HISTORICO_LOGINRegistrar(System.Decimal ID_USUSARIO, System.String IP_LOGIN,
           System.String UBICACION, System.DateTime FECHA_INGRESO)
        {
            try
            {
                DateTime FECHACREO = DateTime.Now;
                object Id;
                //inserta en la tabla sin retornar valor.
                string TableName = "HISTORICO_LOGIN";
                string SqlText = @"Insert into " + TableName + @" (ID_USUSARIO, IP_LOGIN, UBICACION,
ACTIVO, FECHA_INGRESO, IDUSUARIOCREO, FECHACREO, FECHAMODIFICO) 
values (" + ID_USUSARIO + ",'" + IP_LOGIN + "', '" + UBICACION + @"', 'SI', 
convert(datetime, '" + FECHA_INGRESO.Year + "-" + FECHA_INGRESO.Month + "-" + FECHA_INGRESO.Day + " " + FECHA_INGRESO.Hour
+ ":" + FECHA_INGRESO.Minute + ":" + FECHA_INGRESO.Second + @"', 120), " + ID_USUSARIO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " +
" convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120))";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                string SqlText2 = "select max(ID_HISTORICO_LOGIN) ID_HISTORICO_LOGIN FROM HISTORICO_LOGIN where IDUSUARIOCREO = " + ID_USUSARIO;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText2);
                decimal IDSELECCIONADO = Convert.ToDecimal(DBAdmin2.dt.Rows[0]["ID_HISTORICO_LOGIN"]);
                return IDSELECCIONADO;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public static decimal HISTORICO_LOGINRegistrar(System.Decimal ID_HISTORICO_LOGIN, System.Decimal ID_USUSARIO, System.String IP_LOGIN,
            System.String UBICACION, System.String ACTIVO, System.DateTime FECHA_INGRESO,
            System.DateTime FECHA_SALIDA, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                if (ID_HISTORICO_LOGIN == 0)
                {
                    object Id;
                    //inserta en la tabla sin retornar valor.
                    string TableName = "HISTORICO_LOGIN";
                    string SqlText = @"Insert into " + TableName + @" (ID_USUSARIO, IP_LOGIN, UBICACION,
ACTIVO, FECHA_INGRESO, FECHA_SALIDA, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values (" + ID_USUSARIO + ", '" + IP_LOGIN + "', '" + UBICACION + "', '" + ACTIVO + @"', 
convert(datetime, '" + FECHA_INGRESO.Year + "-" + FECHA_INGRESO.Month + "-" + FECHA_INGRESO.Day + " " + FECHA_INGRESO.Hour
+ ":" + FECHA_INGRESO.Minute + ":" + FECHA_INGRESO.Second + @"', 120), 
convert(datetime, '" + FECHA_SALIDA.Year + "-" + FECHA_SALIDA.Month + "-" + FECHA_SALIDA.Day + " " + FECHA_SALIDA.Hour
+ ":" + FECHA_SALIDA.Minute + ":" + FECHA_SALIDA.Second + "', 120), " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120))";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    string SqlText2 = "select max(ID_HISTORICO_LOGIN) ID_HISTORICO_LOGIN FROM HISTORICO_LOGIN where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_HISTORICO_LOGIN"]);
                    return IDSELECCIONADO;
                }
                else
                {
                    return ID_HISTORICO_LOGIN;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool HISTORICO_LOGINActualizarbyID_HISTORICO_LOGIN(System.Decimal ID_HISTORICO_LOGIN, System.Decimal ID_USUSARIO, System.String IP_LOGIN,
            System.String UBICACION, System.String ACTIVO, System.DateTime FECHA_INGRESO,
            System.DateTime FECHA_SALIDA, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "HISTORICO_LOGIN";
                string SqlText = @"Update " + TableName + @" set 
                     ID_USUSARIO = "+ ID_USUSARIO +@"
					 IP_LOGIN = '" + IP_LOGIN + @"',
                     UBICACION = '" + UBICACION + @"',
                     ACTIVO = '" + ACTIVO + @"',
                     FECHA_INGRESO = convert(datetime, '" + FECHA_INGRESO.Year + "-" + FECHA_INGRESO.Month + "-" + FECHA_INGRESO.Day + " " + FECHA_INGRESO.Hour
+ ":" + FECHA_INGRESO.Minute + ":" + FECHA_INGRESO.Second + @"', 120),
                     FECHA_SALIDA = convert(datetime, '" + FECHA_SALIDA.Year + "-" + FECHA_SALIDA.Month + "-" + FECHA_SALIDA.Day + " " + FECHA_SALIDA.Hour
+ ":" + FECHA_SALIDA.Minute + ":" + FECHA_SALIDA.Second + @"', 120),
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120)
                    where ID_HISTORICO_LOGIN = " + ID_HISTORICO_LOGIN + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool HISTORICO_LOGINEliminarbyID_HISTORICO_LOGIN(System.Decimal ID_HISTORICO_LOGIN, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "HISTORICO_LOGIN";
                string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     ACTIVO = 'NO'
					where ID_HISTORICO_LOGIN = " + ID_HISTORICO_LOGIN + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<DCHISTORICO_LOGIN> HISTORICO_LOGINObtenerbyID_HISTORICO_LOGIN(System.Decimal ID_HISTORICO_LOGIN, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "HISTORICO_LOGIN";
                string SqlText = @"select ID_HISTORICO_LOGIN, ID_USUSARIO, IP_LOGIN, UBICACION, ACTIVO, FECHA_INGRESO, FECHA_SALIDA, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from HISTORICO_LOGIN where ACTIVO = 'SI' AND ID_HISTORICO_LOGIN = " + ID_HISTORICO_LOGIN;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCHISTORICO_LOGIN> lst = new List<DCHISTORICO_LOGIN>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCHISTORICO_LOGIN
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_HISTORICO_LOGIN"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_HISTORICO_LOGIN"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_USUSARIO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_USUSARIO"]),
                            (System.String)(dtrespuesta.Rows[i]["IP_LOGIN"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IP_LOGIN"]),
                            (System.String)(dtrespuesta.Rows[i]["UBICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["UBICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHA_INGRESO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHA_INGRESO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHA_SALIDA"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHA_SALIDA"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"])
                        )
                    );
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<DCHISTORICO_LOGIN>();
            }
        }

        public static List<DCHISTORICO_LOGIN> HISTORICO_LOGINObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "HISTORICO_LOGIN";
                string SqlText = @"select ID_HISTORICO_LOGIN, ID_USUSARIO, IP_LOGIN, UBICACION, ACTIVO, FECHA_INGRESO, FECHA_SALIDA, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from HISTORICO_LOGIN WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCHISTORICO_LOGIN> lst = new List<DCHISTORICO_LOGIN>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCHISTORICO_LOGIN
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_HISTORICO_LOGIN"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_HISTORICO_LOGIN"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_USUSARIO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_USUSARIO"]),
                            (System.String)(dtrespuesta.Rows[i]["IP_LOGIN"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IP_LOGIN"]),
                            (System.String)(dtrespuesta.Rows[i]["UBICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["UBICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHA_INGRESO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHA_INGRESO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHA_SALIDA"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHA_SALIDA"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"])
                        )
                    );
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<DCHISTORICO_LOGIN>();
            }
        }

        public static List<DCHISTORICO_LOGIN> HISTORICO_LOGINObtenerbyCriterio(System.String IP_LOGIN, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "HISTORICO_LOGIN";
                string SqlText = @"select ID_HISTORICO_LOGIN, ID_USUSARIO, IP_LOGIN, UBICACION, ACTIVO, FECHA_INGRESO, FECHA_SALIDA, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from HISTORICO_LOGIN WHERE ACTIVO = 'SI' AND IP_LOGIN LIKE '" + IP_LOGIN + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCHISTORICO_LOGIN> lst = new List<DCHISTORICO_LOGIN>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCHISTORICO_LOGIN
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_HISTORICO_LOGIN"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_HISTORICO_LOGIN"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_USUSARIO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_USUSARIO"]),
                            (System.String)(dtrespuesta.Rows[i]["IP_LOGIN"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IP_LOGIN"]),
                            (System.String)(dtrespuesta.Rows[i]["UBICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["UBICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHA_INGRESO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHA_INGRESO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHA_SALIDA"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHA_SALIDA"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"])
                        )
                    );
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<DCHISTORICO_LOGIN>();
            }
        }

        #endregion

    }

    #region DataContract
    [DataContract]
    public class DCHISTORICO_LOGIN
    {
        #region Variables

        private System.Decimal dtcID_HISTORICO_LOGIN;
        private System.Decimal dtcID_USUSARIO;
        private System.String dtcIP_LOGIN;
        private System.String dtcUBICACION;
        private System.String dtcACTIVO;
        private System.DateTime dtcFECHA_INGRESO;
        private System.DateTime dtcFECHA_SALIDA;
        private System.Decimal dtcIDUSUARIOCREO;
        private System.DateTime dtcFECHACREO;
        private System.Decimal dtcIDUSUARIOMODIFICO;
        private System.DateTime dtcFECHAMODIFICO;

        #endregion

        #region Propiedades
        [DataMember]
        public System.Decimal ID_HISTORICO_LOGIN
        {
            get { return dtcID_HISTORICO_LOGIN; }
            set { dtcID_HISTORICO_LOGIN = value; }
        }
        [DataMember]
        public System.Decimal ID_USUSARIO
        {
            get { return dtcID_USUSARIO; }
            set { dtcID_USUSARIO = value; }
        }
        [DataMember]
        public System.String IP_LOGIN
        {
            get { return dtcIP_LOGIN; }
            set { dtcIP_LOGIN = value; }
        }
        [DataMember]
        public System.String UBICACION
        {
            get { return dtcUBICACION; }
            set { dtcUBICACION = value; }
        }
        [DataMember]
        public System.String ACTIVO
        {
            get { return dtcACTIVO; }
            set { dtcACTIVO = value; }
        }
        [DataMember]
        public System.DateTime FECHA_INGRESO
        {
            get { return dtcFECHA_INGRESO; }
            set { dtcFECHA_INGRESO = value; }
        }
        [DataMember]
        public System.DateTime FECHA_SALIDA
        {
            get { return dtcFECHA_SALIDA; }
            set { dtcFECHA_SALIDA = value; }
        }
        [DataMember]
        public System.Decimal IDUSUARIOCREO
        {
            get { return dtcIDUSUARIOCREO; }
            set { dtcIDUSUARIOCREO = value; }
        }
        [DataMember]
        public System.DateTime FECHACREO
        {
            get { return dtcFECHACREO; }
            set { dtcFECHACREO = value; }
        }
        [DataMember]
        public System.Decimal IDUSUARIOMODIFICO
        {
            get { return dtcIDUSUARIOMODIFICO; }
            set { dtcIDUSUARIOMODIFICO = value; }
        }
        [DataMember]
        public System.DateTime FECHAMODIFICO
        {
            get { return dtcFECHAMODIFICO; }
            set { dtcFECHAMODIFICO = value; }
        }
       
        #endregion

        #region Constructores
        public DCHISTORICO_LOGIN(System.Decimal cID_HISTORICO_LOGIN, System.Decimal cID_USUSARIO, System.String cIP_LOGIN, 
            System.String cUBICACION, System.String cACTIVO, System.DateTime cFECHA_INGRESO,
            System.DateTime cFECHA_SALIDA, System.Decimal cIDUSUARIOCREO,
            System.DateTime cFECHACREO, System.Decimal cIDUSUARIOMODIFICO, System.DateTime cFECHAMODIFICO)
        {
            dtcID_HISTORICO_LOGIN = cID_HISTORICO_LOGIN;
            dtcID_USUSARIO = cID_USUSARIO;
            dtcIP_LOGIN = cIP_LOGIN;
            dtcUBICACION = cUBICACION;
            dtcACTIVO = cACTIVO;
            dtcFECHA_INGRESO = cFECHA_INGRESO;
            dtcFECHA_SALIDA = cFECHA_SALIDA;
            dtcIDUSUARIOCREO = cIDUSUARIOCREO;
            dtcFECHACREO = cFECHACREO;
            dtcIDUSUARIOMODIFICO = cIDUSUARIOMODIFICO;
            dtcFECHAMODIFICO = cFECHAMODIFICO;
        }

        #endregion

    }
    #endregion
}
