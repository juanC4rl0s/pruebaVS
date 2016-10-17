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
    public class GENERALES
    {
        #region Variables

        private System.Decimal _ID;
        private System.String _NOMBRE;
        private System.Decimal _ID_DEPTO;

        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public System.String NOMBRE
        {
            get { return _NOMBRE; }
            set { _NOMBRE = value; }
        }

        public System.Decimal ID_DEPTO
        {
            get { return _ID_DEPTO; }
            set { _ID_DEPTO = value; }
        }

        #endregion

        #region Constructores

        public GENERALES(System.Decimal ID, System.String NOMBRE, System.Decimal ID_DEPTO)
        {
            _ID = ID;
            _NOMBRE = NOMBRE;
            _ID_DEPTO = ID_DEPTO;
        }

        #endregion

        #region Métodos

        #region DEPARTAMENTOS
        public static DataTable DEPARTAMENTOSObtenerbyID(System.Decimal ID, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "DEPARTAMENTOS";
                string SqlText = @"select ID, NOMBRE from DEPARTAMENTOS where ID = " + ID;

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

        public static DataTable DEPARTAMENTOSObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "DEPARTAMENTOS";
                string SqlText = @"select ID, NOMBRE from DEPARTAMENTOS ";

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

        public static DataTable DEPARTAMENTOSObtenerbyCriterio(System.String NOMBRE, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "GENERALES";
                string SqlText = @"select ID, NOMBRE from MUNICIPIOS WHERE NOMBRE LIKE '" + NOMBRE + "'";

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

        #region MUNICIPIOS
        public static DataTable MUNICIPIOSObtenerbyID(System.Decimal ID, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "MUNICIPIOS";
                string SqlText = @"select ID, NOMBRE, ID_DEPTO from MUNICIPIOS where ID = " + ID;

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

        public static DataTable MUNICIPIOSObtenerbyID_DEPTO(System.Decimal ID_DEPTO, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "MUNICIPIOS";
                string SqlText = @"select ID, NOMBRE, ID_DEPTO from MUNICIPIOS where ID_DEPTO = " + ID_DEPTO;

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

        public static DataTable MUNICIPIOSObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "MUNICIPIOS";
                string SqlText = @"select ID, NOMBRE, ID_DEPTO from MUNICIPIOS ";

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

        public static DataTable MUNICIPIOSObtenerbyCriterio(System.String NOMBRE, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "GENERALES";
                string SqlText = @"select ID, NOMBRE, ID_DEPTO from MUNICIPIOS WHERE NOMBRE LIKE '" + NOMBRE + "'";

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

        #endregion

    }

    #region DataContract
    [DataContract]
    public class DCGENERALES
    {
        #region Variables

        private System.Decimal dcID;
        private System.String dcNOMBRE;
        private System.Decimal dcID_DEPTO;

        #endregion

        #region Propiedades
        [DataMember]
        public System.Decimal ID
        {
            get { return dcID; }
            set { dcID = value; }
        }
        [DataMember]
        public System.String NOMBRE
        {
            get { return dcNOMBRE; }
            set { dcNOMBRE = value; }
        }
        [DataMember]
        public System.Decimal ID_DEPTO
        {
            get { return dcID_DEPTO; }
            set { dcID_DEPTO = value; }
        }

        #endregion

        #region Constructores
        public DCGENERALES(System.Decimal nID, System.String nNOMBRE, System.Decimal nID_DEPTO)
        {
            dcID = nID;
            dcNOMBRE = nNOMBRE;
            dcID_DEPTO = nID_DEPTO;
        }

        #endregion

    }
    #endregion
}