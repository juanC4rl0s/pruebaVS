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
    public class USUARIOS
    {
        #region Variables

        private System.Decimal _ID_USUARIO;
        private System.Decimal _ID_PERSONA;
        private System.String _LOGIN;
        private System.String _CONTRASENIA;
        private System.String _ACTIVO;
        private System.Decimal _IDUSUARIOCREO;
        private System.DateTime _FECHACREO;
        private System.Decimal _IDUSUARIOMODIFICO;
        private System.DateTime _FECHAMODIFICO;
        
        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal ID_USUARIO
        {
            get { return _ID_USUARIO; }
            set { _ID_USUARIO = value; }
        }

        public System.Decimal ID_PERSONA
        {
            get { return _ID_PERSONA; }
            set { _ID_PERSONA = value; }
        }

        public System.String LOGIN
        {
            get { return _LOGIN; }
            set { _LOGIN = value; }
        }

        public System.String CONTRASENIA
        {
            get { return _CONTRASENIA; }
            set { _CONTRASENIA = value; }
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

        #endregion

        #region Constructores

        /// <summary>
        /// Carga los datos del Usuario si existe en BD, si no existe El objeto Usuario tendra _ID_USUARIO = -1 y _ACTIVO= "NO"
        /// </summary>
        /// <param name="LOGIN"></param>
        /// <param name="PASSWORD"></param>
        public USUARIOS(System.String LOGIN, System.String PASSWORD)
        {

            DataTable user = USUARIOSObtenerbyLogin(LOGIN);
            if (user.Rows.Count > 0)
            {
                if (user.Rows[0]["CONTRASENIA"].ToString().Equals(PASSWORD))
                {
                    _ID_USUARIO = Convert.ToDecimal(user.Rows[0]["ID_USUARIO"].Equals(null) ? 0 : user.Rows[0]["ID_USUARIO"]);
                    _ID_PERSONA = Convert.ToDecimal(user.Rows[0]["ID_PERSONA"].Equals(null) ? 0 : user.Rows[0]["ID_PERSONA"]);
                    _LOGIN = Convert.ToString(user.Rows[0]["LOGIN"].Equals(null) ? "" : user.Rows[0]["LOGIN"]);
                    _CONTRASENIA = Convert.ToString(user.Rows[0]["CONTRASENIA"].Equals(null) ? "" : user.Rows[0]["CONTRASENIA"]);
                    _ACTIVO = Convert.ToString(user.Rows[0]["ACTIVO"].Equals(null) ? "NO" : user.Rows[0]["ACTIVO"]);
                    _IDUSUARIOCREO = Convert.ToDecimal(user.Rows[0]["IDUSUARIOCREO"].Equals(null) ? 0 : user.Rows[0]["IDUSUARIOCREO"]);
                    _FECHACREO = Convert.ToDateTime(user.Rows[0]["FECHACREO"].Equals(null) ? new DateTime() : user.Rows[0]["FECHACREO"]);
                    _IDUSUARIOMODIFICO = Convert.ToDecimal(user.Rows[0]["IDUSUARIOMODIFICO"].Equals(null) ? 0 : user.Rows[0]["IDUSUARIOMODIFICO"]);
                    _FECHAMODIFICO = Convert.ToDateTime(user.Rows[0]["FECHAMODIFICO"].Equals(null) ? new DateTime() : user.Rows[0]["FECHAMODIFICO"]);

                }
                else
                { //si el usuario no existe retorna -1
                    _ID_USUARIO = -1;
                    _ACTIVO = "NO";

                }
            }
        }

        public USUARIOS()
        {
            _ID_USUARIO = -1;
            _ACTIVO = "NO";
        }

        public USUARIOS(System.Decimal ID_USUARIO, System.Decimal ID_PERSONA,  System.String LOGIN,
            System.String CONTRASENIA, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_USUARIO = ID_USUARIO;
            _ID_PERSONA = ID_PERSONA;
            _LOGIN = LOGIN;
            _CONTRASENIA = CONTRASENIA;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }

        public USUARIOS(System.Decimal ID_PERSONA, System.String LOGIN,
            System.String CONTRASENIA, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_PERSONA = ID_PERSONA;
            _LOGIN = LOGIN;
            _CONTRASENIA = CONTRASENIA;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }
        #endregion

        #region Métodos

        public static decimal USUARIOSRegistrar(System.Decimal ID_USUARIO, System.Decimal ID_PERSONA, System.String LOGIN,
            System.String CONTRASENIA, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                if (ID_USUARIO == 0)
                {
                    object Id;
                    //inserta en la tabla sin retornar valor.
                    string TableName = "USUARIOS";
                    string SqlText = @"Insert into " + TableName + @" (ID_PERSONA, LOGIN, CONTRASENIA,
ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values ("+ ID_PERSONA + ", '" + LOGIN + "', '" + CONTRASENIA + "', '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120))";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    string SqlText2 = "select max(ID_USUARIO) ID_USUARIO FROM USUARIOS where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_USUARIO"]);
                    return IDSELECCIONADO;
                }
                else
                {
                    return ID_USUARIO;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool USUARIOSActualizarbyID_USUARIO(System.Decimal ID_USUARIO, System.Decimal ID_PERSONA, System.String LOGIN,
            System.String CONTRASENIA, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "USUARIOS";
                string SqlText = @"Update " + TableName + @" set 
                     ID_PERSONA = "+ ID_PERSONA +@"
					 LOGIN = '" + LOGIN + @"',
                     CONTRASENIA = '" + CONTRASENIA + @"',
                     ACTIVO = '" + ACTIVO + @"',
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
					where ID_USUARIO = " + ID_USUARIO + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool USUARIOSEliminarbyID_USUARIO(System.Decimal ID_USUARIO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "USUARIOS";
                string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     ACTIVO = 'NO'
					where ID_USUARIO = " + ID_USUARIO + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<DCUSUARIOS> USUARIOSObtenerbyID_USUARIO(System.Decimal ID_USUARIO, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "USUARIOS";
                string SqlText = @"select ID_USUARIO, ID_PERSONA, LOGIN, CONTRASENIA, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from USUARIOS where ACTIVO = 'SI' AND ID_USUARIO = " + ID_USUARIO;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCUSUARIOS> lst = new List<DCUSUARIOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCUSUARIOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_USUARIO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_USUARIO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_PERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_PERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["LOGIN"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["LOGIN"]),
                            (System.String)(dtrespuesta.Rows[i]["CONTRASENIA"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CONTRASENIA"]),
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
                return new List<DCUSUARIOS>();
            }
        }

        public static List<DCUSUARIOS> USUARIOSObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "USUARIOS";
                string SqlText = @"select ID_USUARIO, ID_PERSONA, LOGIN, CONTRASENIA, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from USUARIOS WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCUSUARIOS> lst = new List<DCUSUARIOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCUSUARIOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_USUARIO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_USUARIO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_PERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_PERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["LOGIN"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["LOGIN"]),
                            (System.String)(dtrespuesta.Rows[i]["CONTRASENIA"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CONTRASENIA"]),
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
                return new List<DCUSUARIOS>();
            }
        }

        public static List<DCUSUARIOS> USUARIOSObtenerbyCriterio(System.String LOGIN, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "USUARIOS";
                string SqlText = @"select ID_USUARIO, ID_PERSONA, LOGIN, CONTRASENIA, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from USUARIOS WHERE ACTIVO = 'SI' AND LOGIN LIKE '" + LOGIN + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCUSUARIOS> lst = new List<DCUSUARIOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCUSUARIOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_USUARIO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_USUARIO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_PERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_PERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["LOGIN"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["LOGIN"]),
                            (System.String)(dtrespuesta.Rows[i]["CONTRASENIA"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CONTRASENIA"]),
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
                return new List<DCUSUARIOS>();
            }
        }

        public static DataTable USUARIOSObtenerbyLogin(System.String LOGIN)
        {
            try
            {
                string TableName = "USUARIOS";
                string SqlText = @"select ID_USUARIO, ID_PERSONA, LOGIN, CONTRASENIA, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from USUARIOS WHERE ACTIVO = 'SI' AND LOGIN LIKE '" + LOGIN + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                return dtrespuesta;
            }
            catch (Exception ex)
            {
                return new DataTable("dtError");
            }
        }



        #endregion

    }

    #region DataContract
    [DataContract]
    public class DCUSUARIOS
    {
        #region Variables

        private System.Decimal dtcID_USUARIO;
        private System.Decimal dtcID_PERSONA;
        private System.String dtcLOGIN;
        private System.String dtcCONTRASENIA;
        private System.String dtcACTIVO;
        private System.Decimal dtcIDUSUARIOCREO;
        private System.DateTime dtcFECHACREO;
        private System.Decimal dtcIDUSUARIOMODIFICO;
        private System.DateTime dtcFECHAMODIFICO;

        #endregion

        #region Propiedades
        [DataMember]
        public System.Decimal ID_USUARIO
        {
            get { return dtcID_USUARIO; }
            set { dtcID_USUARIO = value; }
        }
        [DataMember]
        public System.Decimal ID_PERSONA
        {
            get { return dtcID_PERSONA; }
            set { dtcID_PERSONA = value; }
        }
        [DataMember]
        public System.String LOGIN
        {
            get { return dtcLOGIN; }
            set { dtcLOGIN = value; }
        }
        [DataMember]
        public System.String CONTRASENIA
        {
            get { return dtcCONTRASENIA; }
            set { dtcCONTRASENIA = value; }
        }
        [DataMember]
        public System.String ACTIVO
        {
            get { return dtcACTIVO; }
            set { dtcACTIVO = value; }
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
        public DCUSUARIOS(System.Decimal cID_USUARIO, System.Decimal cID_PERSONA, System.String cLOGIN, 
            System.String cCONTRASENIA, System.String cACTIVO, System.Decimal cIDUSUARIOCREO,
            System.DateTime cFECHACREO, System.Decimal cIDUSUARIOMODIFICO, System.DateTime cFECHAMODIFICO)
        {
            dtcID_USUARIO = cID_USUARIO;
            dtcID_PERSONA = cID_PERSONA;
            dtcLOGIN = cLOGIN;
            dtcCONTRASENIA = cCONTRASENIA;
            dtcACTIVO = cACTIVO;
            dtcIDUSUARIOCREO = cIDUSUARIOCREO;
            dtcFECHACREO = cFECHACREO;
            dtcIDUSUARIOMODIFICO = cIDUSUARIOMODIFICO;
            dtcFECHAMODIFICO = cFECHAMODIFICO;
        }

        #endregion

    }
    #endregion
}
