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
    public class SECCIONES
    {
        #region Variables

        private System.Decimal _ID_SECCION;
        private System.Decimal _ID_MODULO;
        private System.String _NOMBRE;
        private System.String _DESCRIPCION;
        private System.String _ACTIVO;
        private System.Decimal _IDUSUARIOCREO;
        private System.DateTime _FECHACREO;
        private System.Decimal _IDUSUARIOMODIFICO;
        private System.DateTime _FECHAMODIFICO;

        private List<ACCESOS> _ACCESOS = new List<ACCESOS>();

        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal ID_SECCION
        {
            get { return _ID_SECCION; }
            set { _ID_SECCION = value; }
        }
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

        public List<ACCESOS> ACCESOS
        {
            get { return _ACCESOS; }
            set { _ACCESOS = value; }
        }

        #endregion

        #region Constructores

        public SECCIONES(System.Decimal ID_SECCION, System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
                 System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                 System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_SECCION = ID_SECCION;
            _ID_MODULO = ID_MODULO;
            _NOMBRE = NOMBRE;
            _DESCRIPCION = DESCRIPCION;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;

        }

        public SECCIONES(System.Decimal ID_SECCION, System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
                 System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                 System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO, List<ACCESOS> ACCESOS)
        {
            _ID_SECCION = ID_SECCION;
            _ID_MODULO = ID_MODULO;
            _NOMBRE = NOMBRE;
            _DESCRIPCION = DESCRIPCION;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
            _ACCESOS = ACCESOS;
        }
        //public SECCIONES(System.Decimal ID_SECCION, System.String NOMBRE, System.String DESCRIPCION,
        //        System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
        //        System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        //{
        //    _ID_SECCION = ID_SECCION;
        //    _NOMBRE = NOMBRE;
        //    _DESCRIPCION = DESCRIPCION;
        //    _ACTIVO = ACTIVO;
        //    _IDUSUARIOCREO = IDUSUARIOCREO;
        //    _FECHACREO = FECHACREO;
        //    _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
        //    _FECHAMODIFICO = FECHAMODIFICO;

        //}

        public SECCIONES(System.Decimal ID_MODULO,System.String NOMBRE, System.String DESCRIPCION,
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
        #endregion

        #region Métodos

        public static decimal SECCIONESRegistrar(System.Decimal ID_SECCION, System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
            System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
            System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                if (ID_SECCION == 0)
                {
                    object Id;
                    //inserta en la tabla sin retornar valor.
                    string TableName = "SECCIONES";
                    string SqlText = @"Insert into " + TableName + @" (ID_MODULO,NOMBRE, DESCRIPCION,
ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values ('" + ID_MODULO + "','" + NOMBRE + "', '" + DESCRIPCION + "', '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + "', 120))";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    string SqlText2 = "select max(ID_SECCION) ID_SECCION FROM SECCIONES where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_SECCION"]);
                    return IDSELECCIONADO;
                }
                else
                {
                    return ID_SECCION;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool SECCIONESActualizarbyID_SECCION(System.Decimal ID_SECCION, System.Decimal ID_MODULO, System.String NOMBRE, System.String DESCRIPCION,
            System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
            System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "SECCIONES";
                string SqlText = @"Update " + TableName + @" set 
                     ID_SECCION = " + ID_SECCION + @",
					 ID_MODULO = '" + ID_MODULO + @"',
					 NOMBRE = '" + NOMBRE + @"',
                     DESCRIPCION = '" + DESCRIPCION + @"',
                     ACTIVO = '" + ACTIVO + @"',
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
					where ID_SECCION = " + ID_SECCION + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SECCIONESEliminarbyID_SECCION(System.Decimal ID_SECCION, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "SECCIONES";
                string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     ACTIVO = 'NO'
					where ID_SECCION = " + ID_SECCION + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<SECCIONES> SECCIONESObtenerbyID_SECCION(System.Decimal ID_SECCION, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "SECCIONES";
                string SqlText = @"select ID_SECCION,ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from SECCIONES where ACTIVO = 'SI' AND ID_SECCION = " + ID_SECCION;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<SECCIONES> lst = new List<SECCIONES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new SECCIONES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"])
                        )
                    );
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<SECCIONES>();
            }
        }

        public static List<SECCIONES> SECCIONESObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "SECCIONES";
                string SqlText = @"select ID_SECCION,ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from SECCIONES WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<SECCIONES> lst = new List<SECCIONES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new SECCIONES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
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
                return new List<SECCIONES>();
            }
        }

        public static List<SECCIONES> SECCIONESObtenerbyCriterio(System.String NOMBRE, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "SECCIONES";
                string SqlText = @"select ID_SECCION,ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from SECCIONES WHERE ACTIVO = 'SI' AND NOMBRE LIKE '" + NOMBRE + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<SECCIONES> lst = new List<SECCIONES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new SECCIONES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"])
                        )
                    );
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<SECCIONES>();
            }
        }

        #endregion

        #region METODOS JUAN
        public static List<SECCIONES> SECCIONESObtenerTODO()
        {
            try
            {
                string TableName = "SECCIONES";
                string SqlText = @"select ID_SECCION, ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from SECCIONES WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<SECCIONES> lst = new List<SECCIONES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new SECCIONES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
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
                return new List<SECCIONES>();
            }
        }

        public static List<SECCIONES> SECCIONESObtenerbyIdModulo(System.String ID_MODULO)
        {
            try
            {
                string TableName = "SECCIONES";
                string SqlText = @"select ID_SECCION,ID_MODULO, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from SECCIONES WHERE ACTIVO = 'SI' AND ID_MODULO LIKE '" + ID_MODULO + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<SECCIONES> lst = new List<SECCIONES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    decimal idSeccion = dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"]);
                    lst.Add
                    (
                        new SECCIONES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"]),
                            BLL.ACCESOS.ACCESOSObtenerByIDSeccion(idSeccion)
                        )
                    );
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<SECCIONES>();
            }
        }

        #endregion

    }

    #region DataContract
    [DataContract]
    public class DCSECCIONES
    {
        #region Variables

        private System.Decimal dcID_SECCION;
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
        public System.Decimal ID_SECCION
        {
            get { return dcID_SECCION; }
            set { dcID_SECCION = value; }
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
        public DCSECCIONES(System.Decimal nID_SECCION, System.String nNOMBRE, System.String nDESCRIPCION,
                System.String nACTIVO, System.Decimal nIDUSUARIOCREO, System.DateTime nFECHACREO,
                System.Decimal nIDUSUARIOMODIFICO, System.DateTime nFECHAMODIFICO)
        {
            dcID_SECCION = nID_SECCION;
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
