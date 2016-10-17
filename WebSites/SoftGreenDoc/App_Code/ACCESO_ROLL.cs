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
    public class ACCESO_ROLL
    {
        #region Variables

        private System.Decimal _ID_ACCESO_ROLL;
        private System.Decimal _ID_ACCESO;
        private System.Decimal _ID_ROLL;
        private System.String _ACTIVO;
        private System.Decimal _IDUSUARIOCREO;
        private System.DateTime _FECHACREO;
        private System.Decimal _IDUSUARIOMODIFICO;
        private System.DateTime _FECHAMODIFICO;

        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal ID_ACCESO_ROLL
        {
            get { return _ID_ACCESO_ROLL; }
            set { _ID_ACCESO_ROLL = value; }
        }
        public System.Decimal ID_ACCESO
        {
            get { return _ID_ACCESO; }
            set { _ID_ACCESO = value; }
        }

        public System.Decimal ID_ROLL
        {
            get { return _ID_ROLL; }
            set { _ID_ROLL = value; }
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

        public ACCESO_ROLL(System.Decimal ID_ACCESO_ROLL, System.Decimal ID_ACCESO, 
            System.Decimal ID_ROLL, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_ACCESO_ROLL = ID_ACCESO_ROLL;
            _ID_ACCESO = ID_ACCESO;
            _ID_ROLL = ID_ROLL;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }

        public ACCESO_ROLL(System.Decimal ID_ACCESO, System.Decimal ID_ROLL, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_ACCESO = ID_ACCESO;
            _ID_ROLL = ID_ROLL;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }
        #endregion

        #region Métodos

        public static decimal ACCESO_ROLLRegistrar(System.Decimal ID_ACCESO_ROLL, System.Decimal ID_ACCESO,
            System.Decimal ID_ROLL, System.String ACTIVO, System.Decimal IDUSUARIOCREO, 
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                if (ID_ACCESO_ROLL == 0)
                {
                    object Id;
                    //inserta en la tabla sin retornar valor.
                    string TableName = "ACCESO_ROLL";
                    string SqlText = @"Insert into " + TableName + @" (ID_ACCESO, ID_ROLL, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values ("+ ID_ACCESO + ", " + ID_ROLL + ", '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120))";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    string SqlText2 = "select max(ID_ACCESO_ROLL) ID_ACCESO_ROLL FROM ACCESO_ROLL where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_ACCESO_ROLL"]);
                    return IDSELECCIONADO;
                }
                else
                {
                    return ID_ACCESO_ROLL;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool ACCESO_ROLLActualizarbyID_ACCESO_ROLL(System.Decimal ID_ACCESO_ROLL, System.Decimal ID_ACCESO,
            System.Decimal ID_ROLL, System.String ACTIVO, System.Decimal IDUSUARIOCREO,
            System.DateTime FECHACREO, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "ACCESO_ROLL";
                string SqlText = @"Update " + TableName + @" set 
                     ID_ACCESO = "+ ID_ACCESO + @"
                     ID_ROLL = " + ID_ROLL +@"
                     ACTIVO = '" + ACTIVO + @"',
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
					where ID_ACCESO_ROLL = " + ID_ACCESO_ROLL + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ACCESO_ROLLEliminarbyID_ACCESO_ROLL(System.Decimal ID_ACCESO_ROLL, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "ACCESO_ROLL";
                string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     ACTIVO = 'NO'
					where ID_ACCESO_ROLL = " + ID_ACCESO_ROLL + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<DCACCESO_ROLL> ACCESO_ROLLObtenerbyID_ACCESO_ROLL(System.Decimal ID_ACCESO_ROLL, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "ACCESO_ROLL";
                string SqlText = @"select ID_ACCESO_ROLL, ID_ACCESO, ID_ROLL, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESO_ROLL where ACTIVO = 'SI' AND ID_ACCESO_ROLL = " + ID_ACCESO_ROLL;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCACCESO_ROLL> lst = new List<DCACCESO_ROLL>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCACCESO_ROLL
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<DCACCESO_ROLL>();
            }
        }

        public static List<DCACCESO_ROLL> ACCESO_ROLLObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "ACCESO_ROLL";
                string SqlText = @"select ID_ACCESO_ROLL, ID_ACCESO, ID_ROLL, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESO_ROLL WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCACCESO_ROLL> lst = new List<DCACCESO_ROLL>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCACCESO_ROLL
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<DCACCESO_ROLL>();
            }
        }
        
        public static List<DCACCESO_ROLL> ACCESO_ROLLObtenerbyCriterio(System.Decimal ID_ROLL, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "ACCESO_ROLL";
                string SqlText = @"select ID_ACCESO_ROLL, ID_ACCESO, ID_ROLL, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESO_ROLL WHERE ACTIVO = 'SI' AND ID_ROLL = " + ID_ROLL ;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCACCESO_ROLL> lst = new List<DCACCESO_ROLL>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCACCESO_ROLL
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<DCACCESO_ROLL>();
            }
        }

        #endregion

        #region metodos juan
        public static List<ACCESO_ROLL> ACCESO_ROLLObtenerbyID_ROLL( System.Decimal ID_ROLL)
        {
            try
            {
                string TableName = "ACCESO_ROLL";
                string SqlText = @"select ID_ACCESO_ROLL, ID_ACCESO, ID_ROLL, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ACCESO_ROLL WHERE ACTIVO = 'SI' AND ID_ROLL = " + ID_ROLL;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<ACCESO_ROLL> lst = new List<ACCESO_ROLL>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new ACCESO_ROLL
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO_ROLL"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ACCESO"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ACCESO"]),
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<ACCESO_ROLL>();
            }
        }

        #endregion
    }

    #region DataContract
    [DataContract]
    public class DCACCESO_ROLL
    {
        #region Variables

        private System.Decimal dtcID_ACCESO_ROLL;
        private System.Decimal dtcID_ACCESO;
        private System.Decimal dtcID_ROLL;
        private System.String dtcACTIVO;
        private System.Decimal dtcIDUSUARIOCREO;
        private System.DateTime dtcFECHACREO;
        private System.Decimal dtcIDUSUARIOMODIFICO;
        private System.DateTime dtcFECHAMODIFICO;

        #endregion

        #region Propiedades
        [DataMember]
        public System.Decimal ID_ACCESO_ROLL
        {
            get { return dtcID_ACCESO_ROLL; }
            set { dtcID_ACCESO_ROLL = value; }
        }
        [DataMember]
        public System.Decimal ID_ACCESO
        {
            get { return dtcID_ACCESO; }
            set { dtcID_ACCESO = value; }
        }
        [DataMember]
        public System.Decimal ID_ROLL
        {
            get { return dtcID_ROLL; }
            set { dtcID_ROLL = value; }
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
        public DCACCESO_ROLL(System.Decimal cID_ACCESO_ROLL, System.Decimal cID_ACCESO, 
            System.Decimal cID_ROLL, System.String cACTIVO, System.Decimal cIDUSUARIOCREO,
            System.DateTime cFECHACREO, System.Decimal cIDUSUARIOMODIFICO, System.DateTime cFECHAMODIFICO)
        {
            dtcID_ACCESO_ROLL = cID_ACCESO_ROLL;
            dtcID_ACCESO = cID_ACCESO;
            dtcID_ROLL = cID_ROLL;
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
