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
    public class MODULOS
    {
        #region Variables

        private System.Decimal _ID_MODULO;
        private System.String _NOMBRE;
        private System.String _DESCRIPCION;
        private System.String _ACTIVO;
        private System.Decimal _IDUSUARIOCREO;
        private System.DateTime _FECHACREO;
        private System.Decimal _IDUSUARIOMODIFICO;
        private System.DateTime _FECHAMODIFICO;

        List<SECCIONES> _SECCIONES = new List<SECCIONES>();

        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal ID_MODULO
        {
            get { return _ID_MODULO; }
            set { _ID_MODULO = value; }
        }

        public System.String NOMBRE
        {
            get { return _NOMBRE; }
            set { _NOMBRE = value; }
        }

        public System.String DESCRIPCION
        {
            get { return _DESCRIPCION; }
            set { _DESCRIPCION = value; }
        }

        public System.String ACTIVO
        {
            get { return _ACTIVO; }
            set { _ACTIVO = value; }
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

        public List<SECCIONES> SECCIONES
        {
            get { return _SECCIONES; }
            set { _SECCIONES = value; }
        }

        #endregion

        #region Constructores

        public MODULOS(System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
                System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO, List<SECCIONES> SECCIONES)
        {
            _ID_MODULO = ID_MODULO;
            _NOMBRE = NOMBRE;
            _DESCRIPCION = DESCRIPCION;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
            _SECCIONES = SECCIONES;
        }


        public MODULOS(System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
                System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_MODULO = ID_MODULO;
            _NOMBRE = NOMBRE;
            _DESCRIPCION = DESCRIPCION;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }

        public MODULOS(System.String NOMBRE, System.String DESCRIPCION,
                System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _NOMBRE = NOMBRE;
            _DESCRIPCION = DESCRIPCION;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }
        #endregion

        #region Métodos

        public static decimal MODULOSRegistrar(System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
            System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
            System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                if (ID_MODULO == 0)
                {
                    object Id;
                    //inserta en la tabla sin retornar valor.
                    string TableName = "MODULOS";
                    string SqlText = @"Insert into " + TableName + @" (NOMBRE, DESCRIPCION,
ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values ('" + NOMBRE + "', '" + DESCRIPCION + "', '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + "', 120))";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    string SqlText2 = "select max(ID_MODULO) ID_MODULO FROM MODULOS where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_MODULO"]);
                    return IDSELECCIONADO;
                }
                else
                {
                    return ID_MODULO;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool MODULOSActualizarbyID_MODULO(System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
            System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
            System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "MODULOS";
                string SqlText = @"Update " + TableName + @" set 
                     ID_MODULO = " + ID_MODULO + @"
					 NOMBRE = '" + NOMBRE + @"',
                     DESCRIPCION = '" + DESCRIPCION + @"',
                     ACTIVO = '" + ACTIVO + @"',
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
					where ID_MODULO = " + ID_MODULO + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool MODULOSEliminarbyID_MODULO(System.Decimal ID_MODULO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "MODULOS";
                string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     ACTIVO = 'NO'
					where ID_MODULO = " + ID_MODULO + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<DCMODULOS> MODULOSObtenerbyID_MODULO(System.Decimal ID_MODULO, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "MODULOS";
                string SqlText = @"select ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from MODULOS where ACTIVO = 'SI' AND ID_MODULO = " + ID_MODULO;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCMODULOS> lst = new List<DCMODULOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCMODULOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
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
                return new List<DCMODULOS>();
            }
        }

        public static List<DCMODULOS> MODULOSObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "MODULOS";
                string SqlText = @"select ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from MODULOS WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCMODULOS> lst = new List<DCMODULOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCMODULOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
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
                return new List<DCMODULOS>();
            }
        }

        public static List<DCMODULOS> MODULOSObtenerbyCriterio(System.String NOMBRE, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "MODULOS";
                string SqlText = @"select ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from MODULOS WHERE ACTIVO = 'SI' AND NOMBRE LIKE '" + NOMBRE + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCMODULOS> lst = new List<DCMODULOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCMODULOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
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
                return new List<DCMODULOS>();
            }
        }

        #endregion

        #region METODOS JUAN
        public static List<MODULOS> MODULOSObtenerTODOS()
        {
            try
            {
                string TableName = "MODULOS";
                string SqlText = @"select ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from MODULOS WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<MODULOS> lst = new List<MODULOS>();

                //List<SECCIONES> ListSECCION = BLL.SECCIONES.SECCIONESObtenerbyIdModulo();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    string IDMODULO = dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ?"":dtrespuesta.Rows[i]["ID_MODULO"].ToString();
                lst.Add
                    (
                        
                        new MODULOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"]),
                            BLL.SECCIONES.SECCIONESObtenerbyIdModulo(IDMODULO)
                        )
                    );
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<MODULOS>();
            }
        }

        #endregion
    }

    #region DataContract
    [DataContract]
    public class DCMODULOS
    {
        #region Variables

        private System.Decimal dcID_MODULO;
        private System.String dcNOMBRE;
        private System.String dcDESCRIPCION;
        private System.String dcACTIVO;
        private System.Decimal dcIDUSUARIOCREO;
        private System.DateTime dcFECHACREO;
        private System.Decimal dcIDUSUARIOMODIFICO;
        private System.DateTime dcFECHAMODIFICO;

        #endregion

        #region Propiedades
        [DataMember]
        public System.Decimal ID_MODULO
        {
            get { return dcID_MODULO; }
            set { dcID_MODULO = value; }
        }
        [DataMember]
        public System.String NOMBRE
        {
            get { return dcNOMBRE; }
            set { dcNOMBRE = value; }
        }
        [DataMember]
        public System.String DESCRIPCION
        {
            get { return dcDESCRIPCION; }
            set { dcDESCRIPCION = value; }
        }
        [DataMember]
        public System.String ACTIVO
        {
            get { return dcACTIVO; }
            set { dcACTIVO = value; }
        }
        [DataMember]
        public System.Decimal IDUSUARIOCREO
        {
            get { return dcIDUSUARIOCREO; }
            set { dcIDUSUARIOCREO = value; }
        }
        [DataMember]
        public System.DateTime FECHACREO
        {
            get { return dcFECHACREO; }
            set { dcFECHACREO = value; }
        }
        [DataMember]
        public System.Decimal IDUSUARIOMODIFICO
        {
            get { return dcIDUSUARIOMODIFICO; }
            set { dcIDUSUARIOMODIFICO = value; }
        }
        [DataMember]
        public System.DateTime FECHAMODIFICO
        {
            get { return dcFECHAMODIFICO; }
            set { dcFECHAMODIFICO = value; }
        }

        #endregion

        #region Constructores
        public DCMODULOS(System.Decimal nID_MODULO, System.String nNOMBRE, System.String nDESCRIPCION,
                System.String nACTIVO, System.Decimal nIDUSUARIOCREO, System.DateTime nFECHACREO,
                System.Decimal nIDUSUARIOMODIFICO, System.DateTime nFECHAMODIFICO)
        {
            dcID_MODULO = nID_MODULO;
            dcNOMBRE = nNOMBRE;
            dcDESCRIPCION = nDESCRIPCION;
            dcACTIVO = nACTIVO;
            dcIDUSUARIOCREO = nIDUSUARIOCREO;
            dcFECHACREO = nFECHACREO;
            dcIDUSUARIOMODIFICO = nIDUSUARIOMODIFICO;
            dcFECHAMODIFICO = nFECHAMODIFICO;
        }

        #endregion

    }
    #endregion
}
