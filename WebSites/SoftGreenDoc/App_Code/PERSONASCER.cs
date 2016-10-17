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
	public class PERSONASCER
		{
            #region Variables

            private System.Decimal _IDPERSONA;
            private System.String _IDENTIFICACION;
            private System.String _NOMBRE;
            private System.String _APELLIDOS;
            private System.DateTime _FECHANACIMIENTO;
            private System.String _EMAIL;
            private System.String _TELEFONO;
            private System.String _MOVIL;
            private System.String _TIPO;
            private System.String _ESTADOCIVIL;
            private System.Decimal _IDUSUARIOCREO;
            private System.DateTime _FECHACREO;
            private System.Decimal _IDUSUARIOMODIFICO;
            private System.DateTime _FECHAMODIFICO;
            private System.String _CARGO;
            private System.String _DEPENDENCIA;
            private System.String _FUNCIONES;
            private System.String _SUELDO;
            private System.String _ACTIVO;

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

            public System.DateTime FECHANACIMIENTO
            {
                get { return _FECHANACIMIENTO; }
                set { _FECHANACIMIENTO = value; }
            }

            public System.String EMAIL
            {
                get { return _EMAIL; }
                set { _EMAIL = value; }
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

            public System.String ESTADOCIVIL
            {
                get { return _ESTADOCIVIL; }
                set { _ESTADOCIVIL = value; }
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

            public System.String CARGO
            {
                get { return _CARGO; }
                set { _CARGO = value; }
            }

            public System.String DEPENDENCIA
            {
                get { return _DEPENDENCIA; }
                set { _DEPENDENCIA = value; }
            }

            public System.String FUNCIONES
            {
                get { return _FUNCIONES; }
                set { _FUNCIONES = value; }
            }

            public System.String SUELDO
            {
                get { return _SUELDO; }
                set { _SUELDO = value; }
            }

            public System.String ACTIVO
            {
                get { return _ACTIVO; }
                set { _ACTIVO = value; }
            }

            #endregion

            #region Constructores
        
        public PERSONASCER(System.Decimal IDPERSONA, System.String IDENTIFICACION, System.String NOMBRE,
                System.String APELLIDOS, System.DateTime FECHANACIMIENTO, System.String EMAIL, System.String TELEFONO,
                System.String MOVIL, System.String TIPO, System.String ESTADOCIVIL, System.Decimal IDUSUARIOCREO,
                System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO, System.String CARGO, 
            System.String DEPENDENCIA, System.String FUNCIONES, System.String SUELDO, System.String ACTIVO)
            {
                _IDPERSONA = IDPERSONA;
                _IDENTIFICACION = IDENTIFICACION;
                _NOMBRE = NOMBRE;
                _APELLIDOS = APELLIDOS;
                _FECHANACIMIENTO = FECHANACIMIENTO;
                _EMAIL = EMAIL;
                _TELEFONO = TELEFONO;
                _MOVIL = MOVIL; 
                _TIPO = TIPO; 
                _ESTADOCIVIL = ESTADOCIVIL;
                _IDUSUARIOCREO = IDUSUARIOCREO;
                _FECHACREO = FECHACREO;
                _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
                _FECHAMODIFICO = FECHAMODIFICO;
            _CARGO =  CARGO;
            _DEPENDENCIA = DEPENDENCIA;
            _FUNCIONES = FUNCIONES;
            _SUELDO = SUELDO;
            _ACTIVO = ACTIVO;
            }
       
        public PERSONASCER(System.String IDENTIFICACION, System.String NOMBRE,
                System.String APELLIDOS, System.DateTime FECHANACIMIENTO, System.String EMAIL, System.String TELEFONO,
                System.String MOVIL, System.String TIPO, System.String ESTADOCIVIL, System.Decimal IDUSUARIOCREO,
                System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO,
            System.String CARGO, System.String DEPENDENCIA, System.String FUNCIONES, System.String SUELDO, System.String ACTIVO)
            {
                _IDENTIFICACION = IDENTIFICACION;
                _NOMBRE = NOMBRE;
                _APELLIDOS = APELLIDOS;
                _FECHANACIMIENTO = FECHANACIMIENTO;
                _EMAIL = EMAIL;
                _TELEFONO = TELEFONO;
                _MOVIL = MOVIL;
                _TIPO = TIPO;
                _ESTADOCIVIL = ESTADOCIVIL;
                _IDUSUARIOCREO = IDUSUARIOCREO;
                _FECHACREO = FECHACREO;
                _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
                _FECHAMODIFICO = FECHAMODIFICO;
                _CARGO = CARGO;
                _DEPENDENCIA = DEPENDENCIA;
                _FUNCIONES = FUNCIONES;
                _SUELDO = SUELDO;
                _ACTIVO = ACTIVO;
            }
            #endregion

            #region Métodos

            public static decimal PERSONASCERRegistrar(System.Decimal IDPERSONA, System.String IDENTIFICACION, System.String NOMBRE,
                System.String APELLIDOS, System.DateTime FECHANACIMIENTO, System.String EMAIL, System.String TELEFONO,
                System.String MOVIL, System.String TIPO, System.String ESTADOCIVIL, System.Decimal IDUSUARIOCREO,
                System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO,
            System.String CARGO, System.String DEPENDENCIA, System.String FUNCIONES, System.String SUELDO, System.String ACTIVO)
            {
                try
                {
                    if (IDPERSONA == 0)
                    {
                        object Id;
                        //inserta en la tabla sin retornar valor.
                        string TableName = "PERSONASCER";
                        string SqlText = @"Insert into " + TableName + @" ( IDENTIFICACION, NOMBRE, APELLIDOS,
FECHANACIMIENTO, EMAIL, TELEFONO, MOVIL, TIPO, ESTADOCIVIL, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO,
CARGO, DEPENDENCIA, FUNCIONES, SUELDO, ACTIVO) 
values ('" + IDENTIFICACION + "', '" + NOMBRE + "', '" + APELLIDOS +
"', convert(datetime, '" + FECHANACIMIENTO.Year + "-" + FECHANACIMIENTO.Month + "-" + FECHANACIMIENTO.Day + " " + FECHANACIMIENTO.Hour
+ ":" + FECHANACIMIENTO.Minute + ":" + FECHANACIMIENTO.Second + "', 120), '" + EMAIL + @"','" 
+ TELEFONO + "', '" + MOVIL + "', '" + TIPO + "', '" + ESTADOCIVIL + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), '" + CARGO + "', '" + DEPENDENCIA + "', '" + FUNCIONES + "', '" + SUELDO + "', '"+ ACTIVO +"')";

                        conexionSQL DBAdmin = new conexionSQL();
                        DBAdmin.executeComando(SqlText);

                        string SqlText2 = "select max(IDPERSONA) IDPERSONA FROM PERSONASCER where IDUSUARIOCREO = " + IDUSUARIOCREO;

                        conexionSQL DBAdmin2 = new conexionSQL();
                        DBAdmin2.obtenerDataTable(SqlText2);
                        decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["IDPERSONA"]);
                        return IDSELECCIONADO;
                    }
                    else
                    {
                        return IDPERSONA;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

            public static bool PERSONASCERActualizarbyIDPERSONA(System.Decimal IDPERSONA, System.String IDENTIFICACION, System.String NOMBRE,
                System.String APELLIDOS, System.DateTime FECHANACIMIENTO, System.String EMAIL, System.String TELEFONO,
                System.String MOVIL, System.String TIPO, System.String ESTADOCIVIL, System.Decimal IDUSUARIOCREO,
                System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO,
            System.String CARGO, System.String DEPENDENCIA, System.String FUNCIONES, System.String SUELDO, System.String ACTIVO)
            {
                try
                {
                    string TableName = "PERSONASCER";
                    string SqlText = @"Update " + TableName + @" set 
					 IDENTIFICACION = '" + IDENTIFICACION + @"',
                     NOMBRE = '" + NOMBRE + @"',
                     APELLIDOS = '" + APELLIDOS + @"',
                     FECHANACIMIENTO = convert(datetime,'" + FECHANACIMIENTO.Year + "-" + FECHANACIMIENTO.Month + "-" + 
                     FECHANACIMIENTO.Day + " " + FECHANACIMIENTO.Hour + ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     EMAIL = '" + EMAIL + @"',
                     TELEFONO = '" + TELEFONO + @"',
                     MOVIL = '" + MOVIL + @"',
                     TIPO = '" + TIPO + @"',
                     ESTADOCIVIL = '" + ESTADOCIVIL + @"',
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     CARGO = '" + CARGO + @"',
                     DEPENDENCIA = '" + DEPENDENCIA + @"', 
                     FUNCIONES = '" + FUNCIONES + @"',
                     SUELDO = '" + SUELDO + @"',
                     ACTIVO = '"+ ACTIVO +@"'
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

            public static bool PERSONASCEREliminarbyIDPERSONA(System.Decimal IDPERSONA, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
            {
                try
                {
                    string TableName = "PERSONASCER";
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

            public static List<DCPERSONASCER> PERSONASCERObtenerbyIDPERSONA(System.Decimal IDPERSONA, System.Decimal IDUSUARIO)
            {
                try
                {
                    string TableName = "PERSONASCER";
                    string SqlText = @"select IDPERSONA, IDENTIFICACION, NOMBRE, APELLIDOS, FECHANACIMIENTO, 
EMAIL, TELEFONO, MOVIL, TIPO, ESTADOCIVIL, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO,
CARGO, DEPENDENCIA, FUNCIONES, SUELDO, ACTIVO from PERSONASCER where ACTIVO = 'SI' AND IDPERSONA = " + IDPERSONA;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                
                List<DCPERSONASCER> lst = new List<DCPERSONASCER>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCPERSONASCER
                        (

                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDPERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDPERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["IDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IDENTIFICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["APELLIDOS"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHANACIMIENTO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHANACIMIENTO"]),
                            (System.String)(dtrespuesta.Rows[i]["EMAIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["EMAIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TELEFONO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TELEFONO"]),
                            (System.String)(dtrespuesta.Rows[i]["MOVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["MOVIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPO"]),
                            (System.String)(dtrespuesta.Rows[i]["ESTADOCIVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ESTADOCIVIL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"]),
                            (System.String)(dtrespuesta.Rows[i]["CARGO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CARGO"]),
                            (System.String)(dtrespuesta.Rows[i]["DEPENDENCIA"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DEPENDENCIA"]),
                            (System.String)(dtrespuesta.Rows[i]["FUNCIONES"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["FUNCIONES"]),
                            (System.String)(dtrespuesta.Rows[i]["SUELDO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["SUELDO"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"])
                        )
                    );
                }

                return lst;
                
                }
                catch (Exception ex)
                {
                    return new List<DCPERSONASCER>();
                }
            }

            public static List<DCPERSONASCER> PERSONASCERObtener(System.Decimal IDUSUARIO)
            {
                try
                {
                    string TableName = "PERSONASCER";
                    string SqlText = @"select IDPERSONA, IDENTIFICACION, NOMBRE, APELLIDOS, FECHANACIMIENTO,
EMAIL, TELEFONO, MOVIL, TIPO, ESTADOCIVIL, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO,
CARGO, DEPENDENCIA, FUNCIONES, SUELDO, ACTIVO from PERSONASCER WHERE ACTIVO = 'SI'";

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCPERSONASCER> lst = new List<DCPERSONASCER>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCPERSONASCER
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDPERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDPERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["IDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IDENTIFICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["APELLIDOS"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHANACIMIENTO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHANACIMIENTO"]),
                            (System.String)(dtrespuesta.Rows[i]["EMAIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["EMAIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TELEFONO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TELEFONO"]),
                            (System.String)(dtrespuesta.Rows[i]["MOVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["MOVIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPO"]),
                            (System.String)(dtrespuesta.Rows[i]["ESTADOCIVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ESTADOCIVIL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"]),
                            (System.String)(dtrespuesta.Rows[i]["CARGO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CARGO"]),
                            (System.String)(dtrespuesta.Rows[i]["DEPENDENCIA"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DEPENDENCIA"]),
                            (System.String)(dtrespuesta.Rows[i]["FUNCIONES"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["FUNCIONES"]),
                            (System.String)(dtrespuesta.Rows[i]["SUELDO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["SUELDO"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"])
                        )
                    );
                }

                return lst;

            }
            catch (Exception ex)
            {
                return new List<DCPERSONASCER>();
            }
        }

            public static List<DCPERSONASCER> PERSONASCERObtenerbyCriterio(System.String IDENTIFICACION, System.Decimal IDUSUARIO)
            {
                try
                {
                    string TableName = "PERSONASCER";
                    string SqlText = @"select IDPERSONA, IDENTIFICACION, NOMBRE, APELLIDOS, FECHANACIMIENTO,
EMAIL, TELEFONO, MOVIL, TIPO, ESTADOCIVIL, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO,
CARGO, DEPENDENCIA, FUNCIONES, SUELDO, ACTIVO from PERSONASCER WHERE ACTIVO = 'SI' AND IDENTIFICACION LIKE '" + IDENTIFICACION + "'";

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCPERSONASCER> lst = new List<DCPERSONASCER>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCPERSONASCER
                        (

                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDPERSONA"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDPERSONA"]),
                            (System.String)(dtrespuesta.Rows[i]["IDENTIFICACION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["IDENTIFICACION"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["APELLIDOS"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHANACIMIENTO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHANACIMIENTO"]),
                            (System.String)(dtrespuesta.Rows[i]["EMAIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["EMAIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TELEFONO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TELEFONO"]),
                            (System.String)(dtrespuesta.Rows[i]["MOVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["MOVIL"]),
                            (System.String)(dtrespuesta.Rows[i]["TIPO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["TIPO"]),
                            (System.String)(dtrespuesta.Rows[i]["ESTADOCIVIL"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ESTADOCIVIL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHACREO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["IDUSUARIOCREO"]),
                            Convert.ToDateTime(dtrespuesta.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : dtrespuesta.Rows[i]["FECHAMODIFICO"]),
                            (System.String)(dtrespuesta.Rows[i]["CARGO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CARGO"]),
                            (System.String)(dtrespuesta.Rows[i]["DEPENDENCIA"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DEPENDENCIA"]),
                            (System.String)(dtrespuesta.Rows[i]["FUNCIONES"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["FUNCIONES"]),
                            (System.String)(dtrespuesta.Rows[i]["SUELDO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["SUELDO"]),
                            (System.String)(dtrespuesta.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["ACTIVO"])
                        )
                    );
                }

                return lst;

            }
            catch (Exception ex)
            {
                return new List<DCPERSONASCER>();
            }
        }

            #endregion

		}

	#region DataContract
	[DataContract]
	public class DCPERSONASCER
	{
		#region Variables

        private System.Decimal dcIDPERSONA;
        private System.String dcIDENTIFICACION;
        private System.String dcNOMBRE;
        private System.String dcAPELLIDOS;
        private System.DateTime dcFECHANACIMIENTO;
        private System.String dcEMAIL;
        private System.String dcTELEFONO;
        private System.String dcMOVIL;
        private System.String dcTIPO;
        private System.String dcESTADOCIVIL;
        private System.Decimal dcIDUSUARIOCREO;
        private System.DateTime dcFECHACREO;
        private System.Decimal dcIDUSUARIOMODIFICO;
        private System.DateTime dcFECHAMODIFICO;
        private System.String dcCARGO;
        private System.String dcDEPENDENCIA;
        private System.String dcFUNCIONES;
        private System.String dcSUELDO;
        private System.String dcACTIVO;

		#endregion

		#region Propiedades
		[DataMember]
		public System.Decimal IDPERSONA
		{
			get { return dcIDPERSONA; }
			set { dcIDPERSONA =  value; }
		}
        [DataMember]
        public System.String IDENTIFICACION
        {
            get { return dcIDENTIFICACION; }
            set { dcIDENTIFICACION = value; }
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
        public System.DateTime FECHANACIMIENTO
        {
            get { return dcFECHANACIMIENTO; }
            set { dcFECHANACIMIENTO = value; }
        }
        [DataMember]
        public System.String EMAIL
        {
            get { return dcEMAIL; }
            set { dcEMAIL = value; }
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
        public System.String ESTADOCIVIL
        {
            get { return dcESTADOCIVIL; }
            set { dcESTADOCIVIL = value; }
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
        [DataMember]
        public System.String CARGO
        {
            get { return dcCARGO; }
            set { dcCARGO = value; }
        }
        [DataMember]
        public System.String DEPENDENCIA
        {
            get { return dcDEPENDENCIA; }
            set { dcDEPENDENCIA = value; }
        }
        [DataMember]
        public System.String FUNCIONES
        {
            get { return dcFUNCIONES; }
            set { dcFUNCIONES = value; }
        }
        [DataMember]
        public System.String SUELDO
        {
            get { return dcSUELDO; }
            set { dcSUELDO = value; }
        }
        [DataMember]
        public System.String ACTIVO
        {
            get { return dcACTIVO; }
            set { dcACTIVO = value; }
        }
		#endregion

		#region Constructores
        public DCPERSONASCER(System.Decimal nIDPERSONA, System.String nIDENTIFICACION, System.String nNOMBRE,
                System.String nAPELLIDOS, System.DateTime nFECHANACIMIENTO, System.String nEMAIL, System.String nTELEFONO,
                System.String nMOVIL, System.String nTIPO, System.String nESTADOCIVIL, System.Decimal nIDUSUARIOCREO,
                System.DateTime nFECHACREO, System.Decimal nIDUSUARIOMODIFICO, System.DateTime nFECHAMODIFICO,
            System.String nCARGO, System.String nDEPENDENCIA, System.String nFUNCIONES, System.String nSUELDO, System.String nACTIVO)
		{
            dcIDPERSONA = nIDPERSONA;
            dcIDENTIFICACION = nIDENTIFICACION;
            dcNOMBRE = nNOMBRE;
            dcAPELLIDOS = nAPELLIDOS;
            dcFECHANACIMIENTO = nFECHANACIMIENTO;
            dcEMAIL = nEMAIL;
            dcTELEFONO = nTELEFONO;
            dcMOVIL = nMOVIL;
            dcTIPO = nTIPO;
            dcESTADOCIVIL = nESTADOCIVIL;
            dcIDUSUARIOCREO = nIDUSUARIOCREO;
            dcFECHACREO = nFECHACREO;
            dcIDUSUARIOMODIFICO = nIDUSUARIOMODIFICO;
            dcFECHAMODIFICO = nFECHAMODIFICO;
            dcCARGO = nCARGO;
            dcDEPENDENCIA = nDEPENDENCIA;
            dcFUNCIONES = nFUNCIONES;
            dcSUELDO = nSUELDO;
            dcACTIVO = nACTIVO;
		}

		#endregion

	}
	#endregion
}
