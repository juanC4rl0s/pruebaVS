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
	public class ACCESOS
		{
            #region Variables

            private System.Decimal _ID_ACCESO;
            private System.String _NOMBRE;
            private System.String _DESCRIPCION;
            private System.String _CLAVE;
        private System.Decimal _ID_MODULO;
        private System.Decimal _ID_SECCION;
            private System.Decimal _IDUSUARIOCREO;
            private System.DateTime _FECHACREO;
            private System.Decimal _IDUSUARIOMODIFICO;
            private System.DateTime _FECHAMODIFICO;
           
            public static DataTable dtrespuesta = new DataTable();

            #endregion

            #region Propiedades

            public System.Decimal ID_ACCESO
            {
                get { return _ID_ACCESO; }
                set { _ID_ACCESO = value; }
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

            public System.String CLAVE
            {
                get { return _CLAVE; }
                set { _CLAVE = value; }
        }
        public System.Decimal ID_MODULO
        {
            get { return _ID_MODULO; }
            set { _ID_MODULO = value; }
        }
        public System.Decimal ID_SECCION
        {
            get { return _ID_SECCION; }
            set { _ID_SECCION = value; }
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
        
        public ACCESOS(System.Decimal ID_ACCESO, System.String NOMBRE, System.String DESCRIPCION,
                System.String CLAVE, System.Decimal ID_MODULO, System.Decimal ID_SECCION, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
            {
                _ID_ACCESO = ID_ACCESO;
                _NOMBRE = NOMBRE;
                _DESCRIPCION = DESCRIPCION;
                _CLAVE = CLAVE;
            _ID_MODULO = ID_MODULO;
            _ID_SECCION = ID_SECCION;
                _IDUSUARIOCREO = IDUSUARIOCREO;
                _FECHACREO = FECHACREO;
                _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
                _FECHAMODIFICO = FECHAMODIFICO;
            }
       
        public ACCESOS(System.String NOMBRE, System.String DESCRIPCION,
                System.String CLAVE, System.Decimal ID_MODULO, System.Decimal ID_SECCION, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _NOMBRE = NOMBRE;
            _DESCRIPCION = DESCRIPCION;
            _CLAVE = CLAVE;
            _ID_MODULO = ID_MODULO;
            _ID_SECCION = ID_SECCION;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }
            #endregion

            #region Métodos

            public static decimal ACCESOSRegistrar(System.Decimal ID_ACCESO, System.String NOMBRE, System.String DESCRIPCION,
                System.String CLAVE, System.Decimal ID_MODULO, System.Decimal ID_SECCION, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
            {
                try
                {
                    if (ID_ACCESO == 0)
                    {
                        object Id;
                        //inserta en la tabla sin retornar valor.
                        string TableName = "ACCESOS";
                        string SqlText = @"Insert into " + TableName + @" (NOMBRE, DESCRIPCION,
CLAVE, ID_MODULO, ID_SECCION, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values ('" + NOMBRE + "', '" + DESCRIPCION + "', '" + CLAVE + "', " + ID_MODULO+ ", " + ID_SECCION+ ", " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + "', 120))";

                        conexionSQL DBAdmin = new conexionSQL();
                        DBAdmin.executeComando(SqlText);

                        string SqlText2 = "select max(ID_ACCESO) ID_ACCESO FROM ACCESOS where IDUSUARIOCREO = " + IDUSUARIOCREO;

                        conexionSQL DBAdmin2 = new conexionSQL();
                        DBAdmin2.obtenerDataTable(SqlText2);
                        decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_ACCESO"]);
                        return IDSELECCIONADO;
                    }
                    else
                    {
                        return ID_ACCESO;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

            public static bool ACCESOSActualizarbyID_ACCESO(System.Decimal ID_ACCESO, System.String NOMBRE, System.String DESCRIPCION,
                System.String CLAVE, System.Decimal ID_MODULO, System.Decimal ID_SECCION, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
            {
                try
                {
                    string TableName = "ACCESOS";
                    string SqlText = @"Update " + TableName + @" set 
                     ID_ACCESO = "+ ID_ACCESO + @"
					 NOMBRE = '" + NOMBRE + @"',
                     DESCRIPCION = '" + DESCRIPCION + @"',
                     CLAVE = '" + CLAVE + @"',
                     ID_MODULO = " + ID_MODULO + @",
                     ID_SECCION = " + ID_SECCION + @",
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
                    where ID_ACCESO = " + ID_ACCESO + "";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public static bool ACCESOSEliminarbyID_ACCESO(System.Decimal ID_ACCESO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
            {
                try
                {
                    string TableName = "ACCESOS";
                    string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
					where ID_ACCESO = " + ID_ACCESO + "";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public static List<DCACCESOS> ACCESOSObtenerbyID_ACCESO(System.Decimal ID_ACCESO, System.Decimal IDUSUARIO)
            {
                try
                {
                    string TableName = "ACCESOS";
                    string SqlText = @"select ID_ACCESO, NOMBRE, DESCRIPCION, CLAVE, ID_MODULO, ID_SECCION IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESOS where ID_ACCESO = " + ID_ACCESO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                    List<DCACCESOS> lst = new List<DCACCESOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCACCESOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["CLAVE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CLAVE"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
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
                return new List<DCACCESOS>();
            }
        }

            public static List<DCACCESOS> ACCESOSObtener(System.Decimal IDUSUARIO)
            {
                try
                {
                    string TableName = "ACCESOS";
                    string SqlText = @"select ID_ACCESO, NOMBRE, DESCRIPCION, CLAVE, ID_MODULO, ID_SECCION IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESOS ";

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCACCESOS> lst = new List<DCACCESOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCACCESOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["CLAVE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CLAVE"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
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
                return new List<DCACCESOS>();
            }
        }

        public static List<DCACCESOS> ACCESOSObtenerbyCriterio(System.String NOMBRE, System.Decimal IDUSUARIO)
            {
                try
                {
                    string TableName = "ACCESOS";
                    string SqlText = @"select ID_ACCESO, NOMBRE, DESCRIPCION, CLAVE, ID_MODULO, ID_SECCION IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESOS WHERE NOMBRE LIKE '" + NOMBRE + "'";

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText);
                    dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCACCESOS> lst = new List<DCACCESOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCACCESOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["CLAVE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CLAVE"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
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
                return new List<DCACCESOS>();
            }
        }

        public static List<DCACCESOS> ACCESOSObtenerbyModuloySeccion(System.String NOMBRE, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "ACCESOS";
                string SqlText = @"select ID_ACCESO, NOMBRE, DESCRIPCION, CLAVE, ID_MODULO, ID_SECCION IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESOS WHERE NOMBRE LIKE '" + NOMBRE + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCACCESOS> lst = new List<DCACCESOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCACCESOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["CLAVE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CLAVE"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
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
                return new List<DCACCESOS>();
            }
        }
        #endregion

        #region metodos Juan
        public static List<ACCESOS> ACCESOSObtenerTodos()
        {
            try
            {
                string TableName = "ACCESOS";
                string SqlText = @"select ID_ACCESO, NOMBRE, DESCRIPCION, CLAVE, ID_MODULO, ID_SECCION IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESOS ";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<ACCESOS> lst = new List<ACCESOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new ACCESOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["CLAVE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CLAVE"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
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
                return new List<ACCESOS>();
            }
        }

        public static List<ACCESOS> ACCESOSObtenerByIDSeccion(Decimal IDSECCION)
        {
            try
            {
                string TableName = "ACCESOS";
                string SqlText = @"select ID_ACCESO, NOMBRE, DESCRIPCION, CLAVE, ID_MODULO, ID_SECCION, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESOS  WHERE ID_SECCION= "+IDSECCION;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<ACCESOS> lst = new List<ACCESOS>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new ACCESOS
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO"]),
                            (System.String)(dtrespuesta.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["NOMBRE"]),
                            (System.String)(dtrespuesta.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["DESCRIPCION"]),
                            (System.String)(dtrespuesta.Rows[i]["CLAVE"].Equals(System.DBNull.Value) ? "" : dtrespuesta.Rows[i]["CLAVE"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_MODULO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_MODULO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_SECCION"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_SECCION"]),
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
                return new List<ACCESOS>();
            }
        }
        #endregion



    }

    #region DataContract
    [DataContract]
	public class DCACCESOS
	{
		#region Variables

        private System.Decimal dcID_ACCESO;
        private System.String dcNOMBRE;
        private System.String dcDESCRIPCION;
        private System.String dcCLAVE;
        private System.Decimal dcID_MODULO;
        private System.Decimal dcID_SECCION;
        private System.Decimal dcIDUSUARIOCREO;
        private System.DateTime dcFECHACREO;
        private System.Decimal dcIDUSUARIOMODIFICO;
        private System.DateTime dcFECHAMODIFICO;
       
		#endregion

		#region Propiedades
		[DataMember]
		public System.Decimal ID_ACCESO
		{
			get { return dcID_ACCESO; }
			set { dcID_ACCESO =  value; }
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
        public System.String CLAVE
        {
            get { return dcCLAVE; }
            set { dcCLAVE = value; }
        }
        [DataMember]
        public System.Decimal ID_MODULO
        {
            get { return dcID_MODULO; }
            set { dcID_MODULO = value; }
        }
        [DataMember]
        public System.Decimal ID_SECCION
        {
            get { return dcID_SECCION; }
            set { dcID_SECCION = value; }
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
        public DCACCESOS(System.Decimal nID_ACCESO, System.String nNOMBRE, System.String nDESCRIPCION,
                System.String nCLAVE, System.Decimal nID_MODULO, System.Decimal nID_SECCION, System.Decimal nIDUSUARIOCREO, System.DateTime nFECHACREO,
                System.Decimal nIDUSUARIOMODIFICO, System.DateTime nFECHAMODIFICO)
		{
            dcID_ACCESO = nID_ACCESO;
            dcNOMBRE = nNOMBRE;
            dcDESCRIPCION = nDESCRIPCION;
            dcCLAVE = nCLAVE;
            dcID_MODULO = nID_MODULO;
            dcID_SECCION = nID_SECCION;
            dcIDUSUARIOCREO = nIDUSUARIOCREO;
            dcFECHACREO = nFECHACREO;
            dcIDUSUARIOMODIFICO = nIDUSUARIOMODIFICO;
            dcFECHAMODIFICO = nFECHAMODIFICO;
		}

		#endregion

	}
	#endregion
}