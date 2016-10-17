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
    public class PERSONAS
    {
        #region Variables

        private System.Decimal _IDPERSONA;
        private System.String _IDENTIFICACION;
        private System.String _TIPOIDENTIFICACION;
        private System.DateTime _FECHAEXPEDICION;
        private System.DateTime _FECHANACIMIENTO;
        private System.String _NOMBRE;
        private System.String _APELLIDOS;
        private System.String _DIRECCION;
        private System.String _PAIS;
        private System.String _DEPTO;
        private System.String _CIUDAD;
        private System.String _CORREO;
        private System.String _GENERO;
        private System.String _TELEFONO;
        private System.String _MOVIL;
        private System.String _TIPO;
        private System.String _ACTIVO;
        private System.Decimal _IDUSUARIOCREO;
        private System.DateTime _FECHACREO;
        private System.Decimal _IDUSUARIOMODIFICO;
        private System.DateTime _FECHAMODIFICO;

        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal IDPERSONA
        {
            get { return _IDPERSONA; }
            set { _IDPERSONA = value; }
        }

        public System.String IDENTIFICACION
        {
            get { return _IDENTIFICACION; }
            set { _IDENTIFICACION = value; }
        }

        public System.String TIPOIDENTIFICACION
        {
            get { return _TIPOIDENTIFICACION; }
            set { _TIPOIDENTIFICACION = value; }
        }

        public System.DateTime FECHAEXPEDICION
        {
            get { return _FECHAEXPEDICION; }
            set { _FECHAEXPEDICION = value; }
        }

        public System.DateTime FECHANACIMIENTO
        {
            get { return _FECHANACIMIENTO; }
            set { _FECHANACIMIENTO = value; }
        }

        public System.String NOMBRE
        {
            get { return _NOMBRE; }
            set { _NOMBRE = value; }
        }

        public System.String APELLIDOS
        {
            get { return _APELLIDOS; }
            set { _APELLIDOS = value; }
        }

        public System.String DIRECCION
        {
            get { return _DIRECCION; }
            set { _DIRECCION = value; }
        }

        public System.String PAIS
        {
            get { return _PAIS; }
            set { _PAIS = value; }
        }

        public System.String DEPTO
        {
            get { return _DEPTO; }
            set { _DEPTO = value; }
        }

        public System.String CIUDAD
        {
            get { return _CIUDAD; }
            set { _CIUDAD = value; }
        }

        public System.String CORREO
        {
            get { return _CORREO; }
            set { _CORREO = value; }
        }

        public System.String GENERO
        {
            get { return _GENERO; }
            set { _GENERO = value; }
        }

        public System.String TELEFONO
        {
            get { return _TELEFONO; }
            set { _TELEFONO = value; }
        }

        public System.String MOVIL
        {
            get { return _MOVIL; }
            set { _MOVIL = value; }
        }

        public System.String TIPO
        {
            get { return _TIPO; }
            set { _TIPO = value; }
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

        public PERSONAS(System.Decimal IDPERSONA, System.String IDENTIFICACION, System.String TIPOIDENTIFICACION,
            System.DateTime FECHAEXPEDICION, System.DateTime FECHANACIMIENTO, System.String NOMBRE,
            System.String APELLIDOS, System.String DIRECCION, System.String PAIS, System.String DEPTO,
            System.String CIUDAD, System.String CORREO, System.String GENERO, System.String TELEFONO,
            System.String MOVIL, System.String TIPO, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _IDPERSONA = IDPERSONA;
            _IDENTIFICACION = IDENTIFICACION;
            _TIPOIDENTIFICACION = TIPOIDENTIFICACION;
            _FECHAEXPEDICION = FECHAEXPEDICION;
            _FECHANACIMIENTO = FECHANACIMIENTO;
            _NOMBRE = NOMBRE;
            _APELLIDOS = APELLIDOS;
            _DIRECCION = DIRECCION;
            _PAIS = PAIS;
            _DEPTO = DEPTO;
            _CIUDAD = CIUDAD;
            _CORREO = CORREO;
            _GENERO = GENERO;
            _TELEFONO = TELEFONO;
            _MOVIL = MOVIL;
            _TIPO = TIPO;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
    }

        public PERSONAS( System.String IDENTIFICACION, System.String TIPOIDENTIFICACION,
            System.DateTime FECHAEXPEDICION, System.DateTime FECHANACIMIENTO, System.String NOMBRE,
            System.String APELLIDOS, System.String DIRECCION, System.String PAIS, System.String DEPTO,
            System.String CIUDAD, System.String CORREO, System.String GENERO, System.String TELEFONO,
            System.String MOVIL, System.String TIPO, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _IDENTIFICACION = IDENTIFICACION;
            _TIPOIDENTIFICACION = TIPOIDENTIFICACION;
            _FECHAEXPEDICION = FECHAEXPEDICION;
            _FECHANACIMIENTO = FECHANACIMIENTO;
            _NOMBRE = NOMBRE;
            _APELLIDOS = APELLIDOS;
            _DIRECCION = DIRECCION;
            _PAIS = PAIS;
            _DEPTO = DEPTO;
            _CIUDAD = CIUDAD;
            _CORREO = CORREO;
            _GENERO = GENERO;
            _TELEFONO = TELEFONO;
            _MOVIL = MOVIL;
            _TIPO = TIPO;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }
        #endregion

        #region Métodos

        public static decimal PERSONASRegistrar(System.Decimal IDPERSONA, System.String IDENTIFICACION, System.String TIPOIDENTIFICACION,
            System.DateTime FECHAEXPEDICION, System.DateTime FECHANACIMIENTO, System.String NOMBRE,
            System.String APELLIDOS, System.String DIRECCION, System.String PAIS, System.String DEPTO,
            System.String CIUDAD, System.String CORREO, System.String GENERO, System.String TELEFONO,
            System.String MOVIL, System.String TIPO, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                if (IDPERSONA == 0)
                {
                    object Id;
                    //inserta en la tabla sin retornar valor.
                    string TableName = "PERSONAS";
                    string SqlText = @"Insert into " + TableName + @" ( IDENTIFICACION, 
TIPOIDENTIFICACION, FECHAEXPEDICION, FECHANACIMIENTO, NOMBRE, APELLIDOS, DIRECCION, PAIS, DEPTO,
CIUDAD, CORREO, GENERO, TELEFONO, MOVIL, TIPO, ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values ('" + IDENTIFICACION + "', '"+ TIPOIDENTIFICACION + "', convert(datetime, '" + FECHAEXPEDICION.Year + "-" + FECHAEXPEDICION.Month + "-" + FECHAEXPEDICION.Day + " " + FECHAEXPEDICION.Hour
+ ":" + FECHAEXPEDICION.Minute + ":" + FECHAEXPEDICION.Second + "', 120), convert(datetime, '" + FECHANACIMIENTO.Year + "-" + FECHANACIMIENTO.Month + "-" + FECHANACIMIENTO.Day + " " + FECHANACIMIENTO.Hour
+ ":" + FECHANACIMIENTO.Minute + ":" + FECHANACIMIENTO.Second + "', 120), '" + NOMBRE + "', '" 
+ APELLIDOS + "', '" + DIRECCION + @"','" + PAIS + @"','" + DEPTO + @"','" + CIUDAD + @"','" + CORREO + @"','"
+ GENERO + "', '" + TELEFONO + "', '" + MOVIL + "', '" + TIPO + "', '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120))";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);
                    
                    string SqlText2 = "select max(IDPERSONA) IDPERSONA FROM PERSONAS where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                    decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["IDPERSONA"]);
                    
                    #region Registro ususarios Default

                    //inserta en la tabla sin retornar valor.
                    TableName = "USUARIOS";
                    SqlText = @"Insert into " + TableName + @" (ID_PERSONA, LOGIN, CONTRASENIA,
ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values (" + IDSELECCIONADO + ", '" + NOMBRE.Substring(0,1)+ "." + APELLIDOS.Substring(0,4) + "', '" + "123BUF" + "', '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120))";

                    DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    SqlText2 = "select max(ID_USUARIO) ID_USUARIO FROM USUARIOS where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                    decimal IDUSUARIOCREADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_USUARIO"]);

                    #endregion

                    #region Registro ususarios_ROLL Default

                    SqlText2 = @"select ID_ROLL, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ROLES WHERE ACTIVO = 'SI' AND NOMBRE LIKE 'PUBLICO'";

                    DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                    decimal ID_ROLL = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_ROLL"]);

                    //inserta en la tabla sin retornar valor.
                    TableName = "USUARIOS_ROLL";
                     SqlText = @"Insert into " + TableName + @" (ID_USUARIO, ID_ROLL, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values (" + IDUSUARIOCREADO + ", " + ID_ROLL + ", '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120))";

                     DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                     SqlText2 = "select max(ID_USUARIO_ROLL) ID_USUARIO_ROLL FROM USUARIOS_ROLL where IDUSUARIOCREO = " + IDUSUARIOCREO;

                     DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                    decimal IDUSUARIO_ROLL = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_USUARIO_ROLL"]);

                    #endregion

                    return IDSELECCIONADO;
                }
                else
                {
                    return IDPERSONA;
                }
            }
            catch (Exception ex)
            {
                String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\" + "PERSONASRegistrarERROR" + ".txt";
                string texto = ex.Message + " " + ex.Source + " " + ex.StackTrace + " " + ex.InnerException + " ";
                System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
                sw.WriteLine(texto);
                sw.Close();
                return 0;
            }
        }

        public static bool PERSONASActualizarbyIDPERSONA(System.Decimal IDPERSONA, System.String IDENTIFICACION, System.String TIPOIDENTIFICACION,
            System.DateTime FECHAEXPEDICION, System.DateTime FECHANACIMIENTO, System.String NOMBRE,
            System.String APELLIDOS, System.String DIRECCION, System.String PAIS, System.String DEPTO,
            System.String CIUDAD, System.String CORREO, System.String GENERO, System.String TELEFONO,
            System.String MOVIL, System.String TIPO, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "PERSONAS";
                string SqlText = @"Update " + TableName + @" set 
                     IDENTIFICACION = '" + IDENTIFICACION + @"',
TIPOIDENTIFICACION = '" + TIPOIDENTIFICACION + @"',
FECHAEXPEDICION = convert(datetime, '" + FECHAEXPEDICION.Year + "-" + FECHAEXPEDICION.Month + "-" +
FECHAEXPEDICION.Day + " " + FECHAEXPEDICION.Hour+ ":" + FECHAEXPEDICION.Minute + ":" + FECHAEXPEDICION.Second + @"', 120),
FECHANACIMIENTO = convert(datetime, '" + FECHANACIMIENTO.Year + "-" + FECHANACIMIENTO.Month + "-" +
FECHANACIMIENTO.Day + " " + FECHANACIMIENTO.Hour + ":" + FECHANACIMIENTO.Minute + ":" + FECHANACIMIENTO.Second + @"', 120),
NOMBRE = '" + NOMBRE + @"',
APELLIDOS = '" + APELLIDOS + @"',
DIRECCION = '" + DIRECCION + @"',
PAIS = '" + PAIS + @"',
DEPTO = '" + DEPTO + @"',
CIUDAD = '" + CIUDAD + @"',
CORREO = '" + CORREO + @"',
GENERO = '" + GENERO + @"',
TELEFONO = '" + TELEFONO + @"',
MOVIL = '" + MOVIL + @"',
TIPO = '" + TIPO + @"',
ACTIVO = '" + ACTIVO + @"',
IDUSUARIOCREO = " + IDUSUARIOCREO + @",
FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" +
FECHACREO.Day + " " + FECHACREO.Hour + ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" +
FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour + ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
					where IDPERSONA = " + IDPERSONA + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool PERSONASEliminarbyIDPERSONA(System.Decimal IDPERSONA, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "PERSONAS";
                string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     ACTIVO = 'NO'
					where IDPERSONA = " + IDPERSONA + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<DCPERSONAS> PERSONASObtenerbyIDPERSONA(System.Decimal IDPERSONA, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "PERSONAS";
                string SqlText = @"select IDPERSONA, IDENTIFICACION, TIPOIDENTIFICACION,
FECHAEXPEDICION, FECHANACIMIENTO, NOMBRE, APELLIDOS, DIRECCION, PAIS, DEPTO, CIUDAD, CORREO, GENERO, TELEFONO,
MOVIL, TIPO, ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from PERSONAS where ACTIVO = 'SI' AND IDPERSONA = " + IDPERSONA;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCPERSONAS> lst = new List<DCPERSONAS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCPERSONAS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDPERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDPERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["IDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IDENTIFICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPOIDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPOIDENTIFICACION"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAEXPEDICION"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHANACIMIENTO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["APELLIDOS"]),
                            (System.String)(dtrespuesta.Rows[i]["DIRECCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DIRECCION"]),
                            (System.String)(dtrespuesta.Rows[i]["PAIS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["PAIS"]),
                            (System.String)(dtrespuesta.Rows[i]["DEPTO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DEPTO"]),
                            (System.String)(dtrespuesta.Rows[i]["CIUDAD"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CIUDAD"]),
                            (System.String)(dtrespuesta.Rows[i]["CORREO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CORREO"]),
                            (System.String)(dtrespuesta.Rows[i]["GENERO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["GENERO"]),
                            (System.String)(dtrespuesta.Rows[i]["TELEFONO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TELEFONO"]),
                            (System.String)(dtrespuesta.Rows[i]["MOVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["MOVIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPO"]),
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
                return new List<DCPERSONAS>();
            }
        }

        public static List<DCPERSONAS> PERSONASObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "PERSONAS";
                string SqlText = @"select IDPERSONA, IDENTIFICACION, TIPOIDENTIFICACION,
FECHAEXPEDICION, FECHANACIMIENTO, NOMBRE, APELLIDOS, DIRECCION, PAIS, DEPTO, CIUDAD, CORREO, GENERO, TELEFONO,
MOVIL, TIPO, ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from PERSONAS WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCPERSONAS> lst = new List<DCPERSONAS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCPERSONAS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDPERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDPERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["IDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IDENTIFICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPOIDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPOIDENTIFICACION"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAEXPEDICION"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHANACIMIENTO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["APELLIDOS"]),
                            (System.String)(dtrespuesta.Rows[i]["DIRECCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DIRECCION"]),
                            (System.String)(dtrespuesta.Rows[i]["PAIS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["PAIS"]),
                            (System.String)(dtrespuesta.Rows[i]["DEPTO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DEPTO"]),
                            (System.String)(dtrespuesta.Rows[i]["CIUDAD"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CIUDAD"]),
                            (System.String)(dtrespuesta.Rows[i]["CORREO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CORREO"]),
                            (System.String)(dtrespuesta.Rows[i]["GENERO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["GENERO"]),
                            (System.String)(dtrespuesta.Rows[i]["TELEFONO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TELEFONO"]),
                            (System.String)(dtrespuesta.Rows[i]["MOVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["MOVIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPO"]),
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
                return new List<DCPERSONAS>();
            }
        }

        public static List<DCPERSONAS> PERSONASObtenerbyCriterio(System.String IDENTIFICACION, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "PERSONAS";
                string SqlText = @"select IDENTIFICACION, TIPOIDENTIFICACION,
FECHAEXPEDICION, FECHANACIMIENTO, NOMBRE, APELLIDOS, DIRECCION, PAIS, DEPTO, CIUDAD, CORREO, GENERO, TELEFONO,
MOVIL, TIPO, ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from PERSONAS WHERE ACTIVO = 'SI' AND IDENTIFICACION LIKE '" + IDENTIFICACION + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCPERSONAS> lst = new List<DCPERSONAS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCPERSONAS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDPERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDPERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["IDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IDENTIFICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPOIDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPOIDENTIFICACION"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAEXPEDICION"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHANACIMIENTO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["APELLIDOS"]),
                            (System.String)(dtrespuesta.Rows[i]["DIRECCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DIRECCION"]),
                            (System.String)(dtrespuesta.Rows[i]["PAIS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["PAIS"]),
                            (System.String)(dtrespuesta.Rows[i]["DEPTO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DEPTO"]),
                            (System.String)(dtrespuesta.Rows[i]["CIUDAD"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CIUDAD"]),
                            (System.String)(dtrespuesta.Rows[i]["CORREO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CORREO"]),
                            (System.String)(dtrespuesta.Rows[i]["GENERO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["GENERO"]),
                            (System.String)(dtrespuesta.Rows[i]["TELEFONO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TELEFONO"]),
                            (System.String)(dtrespuesta.Rows[i]["MOVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["MOVIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPO"]),
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
                return new List<DCPERSONAS>();
            }
        }

        #endregion

    }

    #region DataContract
    [DataContract]
    public class DCPERSONAS
    {
        #region Variables

        private System.Decimal dcIDPERSONA;
        private System.String dcIDENTIFICACION;
        private System.String dcTIPOIDENTIFICACION;
        private System.DateTime dcFECHAEXPEDICION;
        private System.DateTime dcFECHANACIMIENTO;
        private System.String dcNOMBRE;
        private System.String dcAPELLIDOS;
        private System.String dcDIRECCION;
        private System.String dcPAIS;
        private System.String dcDEPTO;
        private System.String dcCIUDAD;
        private System.String dcCORREO;
        private System.String dcGENERO;
        private System.String dcTELEFONO;
        private System.String dcMOVIL;
        private System.String dcTIPO;
        private System.String dcACTIVO;
        private System.Decimal dcIDUSUARIOCREO;
        private System.DateTime dcFECHACREO;
        private System.Decimal dcIDUSUARIOMODIFICO;
        private System.DateTime dcFECHAMODIFICO;

        #endregion

        #region Propiedades

        [DataMember]
        public System.Decimal IDPERSONA
        {
            get { return dcIDPERSONA; }
            set { dcIDPERSONA = value; }
        }
        [DataMember]
        public System.String IDENTIFICACION
        {
            get { return dcIDENTIFICACION; }
            set { dcIDENTIFICACION = value; }
        }
        [DataMember]
        public System.String TIPOIDENTIFICACION
        {
            get { return dcTIPOIDENTIFICACION; }
            set { dcTIPOIDENTIFICACION = value; }
        }
        [DataMember]
        public System.DateTime FECHAEXPEDICION
        {
            get { return dcFECHAEXPEDICION; }
            set { dcFECHAEXPEDICION = value; }
        }
        [DataMember]
        public System.DateTime FECHANACIMIENTO
        {
            get { return dcFECHANACIMIENTO; }
            set { dcFECHANACIMIENTO = value; }
        }
        [DataMember]
        public System.String NOMBRE
        {
            get { return dcNOMBRE; }
            set { dcNOMBRE = value; }
        }
        [DataMember]
        public System.String APELLIDOS
        {
            get { return dcAPELLIDOS; }
            set { dcAPELLIDOS = value; }
        }
        [DataMember]
        public System.String DIRECCION
        {
            get { return dcDIRECCION; }
            set { dcDIRECCION = value; }
        }
        [DataMember]
        public System.String PAIS
        {
            get { return dcPAIS; }
            set { dcPAIS = value; }
        }
        [DataMember]
        public System.String DEPTO
        {
            get { return dcDEPTO; }
            set { dcDEPTO = value; }
        }
        [DataMember]
        public System.String CIUDAD
        {
            get { return dcCIUDAD; }
            set { dcCIUDAD = value; }
        }
        [DataMember]
        public System.String CORREO
        {
            get { return dcCORREO; }
            set { dcCORREO = value; }
        }
        [DataMember]
        public System.String GENERO
        {
            get { return dcGENERO; }
            set { dcGENERO = value; }
        }
        [DataMember]
        public System.String TELEFONO
        {
            get { return dcTELEFONO; }
            set { dcTELEFONO = value; }
        }
        [DataMember]
        public System.String MOVIL
        {
            get { return dcMOVIL; }
            set { dcMOVIL = value; }
        }
        [DataMember]
        public System.String TIPO
        {
            get { return dcTIPO; }
            set { dcTIPO = value; }
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

        public DCPERSONAS(System.Decimal nIDPERSONA, System.String nIDENTIFICACION, 
            System.String nTIPOIDENTIFICACION, System.DateTime nFECHAEXPEDICION, 
            System.DateTime nFECHANACIMIENTO, System.String nNOMBRE,
            System.String nAPELLIDOS, System.String nDIRECCION, System.String nPAIS, 
            System.String nDEPTO, System.String nCIUDAD, System.String nCORREO, 
            System.String nGENERO, System.String nTELEFONO, System.String nMOVIL, 
            System.String nTIPO, System.String nACTIVO, System.Decimal nIDUSUARIOCREO,
            System.DateTime nFECHACREO, System.Decimal nIDUSUARIOMODIFICO, System.DateTime nFECHAMODIFICO)
        {
            dcIDPERSONA = nIDPERSONA;
            dcIDENTIFICACION = nIDENTIFICACION;
            dcTIPOIDENTIFICACION = nTIPOIDENTIFICACION;
            dcFECHAEXPEDICION = nFECHAEXPEDICION;
            dcFECHANACIMIENTO = nFECHANACIMIENTO;
            dcNOMBRE = nNOMBRE;
            dcAPELLIDOS = nAPELLIDOS;
            dcDIRECCION = nDIRECCION;
            dcPAIS = nPAIS;
            dcDEPTO = nDEPTO;
            dcCIUDAD = nCIUDAD;
            dcCORREO = nCORREO;
            dcGENERO = nGENERO;
            dcTELEFONO = nTELEFONO;
            dcMOVIL = nMOVIL;
            dcTIPO = nTIPO;
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
