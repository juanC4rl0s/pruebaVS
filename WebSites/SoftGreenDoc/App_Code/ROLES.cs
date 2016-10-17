
using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;

using SQLCLASS;

namespace BLL
{
    public class ROLES
    {
        #region Variables

        private System.Decimal _ID_ROLL;
        private System.String _NOMBRE;
        private System.String _DESCRIPCION;
        private System.String _ACTIVO;
        private System.Decimal _IDUSUARIOCREO;
        private System.DateTime _FECHACREO;
        private System.Decimal _IDUSUARIOMODIFICO;
        private System.DateTime _FECHAMODIFICO;

        public static DataTable dtrespuesta = new DataTable();

        #endregion

        #region Propiedades

        public System.Decimal ID_ROLL
        {
            get { return _ID_ROLL; }
            set { _ID_ROLL = value; }
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

        #endregion

        #region Constructores
        public ROLES()
        {
            _ID_ROLL = -1;
            _ACTIVO = "SI";

        }

        public ROLES(System.Decimal ID_ROLL)
        {
            _ID_ROLL = ID_ROLL;
            ROLES ROL = ROLESObtenerbyID_ROL(ID_ROLL);
            _NOMBRE = ROL.NOMBRE;
            _DESCRIPCION = ROL.DESCRIPCION;
            _ACTIVO = ROL.ACTIVO;
            _IDUSUARIOCREO = ROL.IDUSUARIOCREO;
            _FECHACREO = ROL.FECHACREO;
            _IDUSUARIOMODIFICO = ROL.IDUSUARIOMODIFICO;
            _FECHAMODIFICO = ROL.FECHAMODIFICO;
        }

        //fin de juan


        public ROLES(System.Decimal ID_ROLL, System.String NOMBRE, System.String DESCRIPCION,
                System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
                System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            _ID_ROLL = ID_ROLL;
            _NOMBRE = NOMBRE;
            _DESCRIPCION = DESCRIPCION;
            _ACTIVO = ACTIVO;
            _IDUSUARIOCREO = IDUSUARIOCREO;
            _FECHACREO = FECHACREO;
            _IDUSUARIOMODIFICO = IDUSUARIOMODIFICO;
            _FECHAMODIFICO = FECHAMODIFICO;
        }

        public ROLES(System.String NOMBRE, System.String DESCRIPCION,
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

        public static decimal ROLESRegistrar(System.Decimal ID_ROLL, System.String NOMBRE, System.String DESCRIPCION,
            System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
            System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                if (ID_ROLL == 0)
                {
                    object Id;
                    //inserta en la tabla sin retornar valor.
                    string TableName = "ROLES";
                    string SqlText = @"Insert into " + TableName + @" (NOMBRE, DESCRIPCION,
ACTIVO, IDUSUARIOCREO, FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO) 
values ('" + NOMBRE + "', '" + DESCRIPCION + "', '" + ACTIVO + "', " + IDUSUARIOCREO +
", convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + "', 120), " + IDUSUARIOMODIFICO +
", convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + "', 120))";

                    conexionSQL DBAdmin = new conexionSQL();
                    DBAdmin.executeComando(SqlText);

                    string SqlText2 = "select max(ID_ROLL) ID_ROLL FROM ROLES where IDUSUARIOCREO = " + IDUSUARIOCREO;

                    conexionSQL DBAdmin2 = new conexionSQL();
                    DBAdmin2.obtenerDataTable(SqlText2);
                    decimal IDSELECCIONADO = Convert.ToDecimal(dtrespuesta.Rows[0]["ID_ROLL"]);
                    return IDSELECCIONADO;
                }
                else
                {
                    return ID_ROLL;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool ROLESActualizarbyID_ROLL(System.Decimal ID_ROLL, System.String NOMBRE, System.String DESCRIPCION,
            System.String ACTIVO, System.Decimal IDUSUARIOCREO, System.DateTime FECHACREO,
            System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "ROLES";
                string SqlText = @"Update " + TableName + @" set 
                     ID_ROLL = " + ID_ROLL + @"
					 NOMBRE = '" + NOMBRE + @"',
                     DESCRIPCION = '" + DESCRIPCION + @"',
                     ACTIVO = '" + ACTIVO + @"',
                     IDUSUARIOCREO = " + IDUSUARIOCREO + @",
                     FECHACREO = convert(datetime, '" + FECHACREO.Year + "-" + FECHACREO.Month + "-" + FECHACREO.Day + " " + FECHACREO.Hour
+ ":" + FECHACREO.Minute + ":" + FECHACREO.Second + @"', 120),
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120)
					where ID_ROLL = " + ID_ROLL + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ROLESEliminarbyID_ROLL(System.Decimal ID_ROLL, System.Decimal IDUSUARIOMODIFICO, System.DateTime FECHAMODIFICO)
        {
            try
            {
                string TableName = "ROLES";
                string SqlText = @"Update " + TableName + @" set 
                     IDUSUARIOMODIFICO = " + IDUSUARIOMODIFICO + @",
                     FECHAMODIFICO = convert(datetime, '" + FECHAMODIFICO.Year + "-" + FECHAMODIFICO.Month + "-" + FECHAMODIFICO.Day + " " + FECHAMODIFICO.Hour
+ ":" + FECHAMODIFICO.Minute + ":" + FECHAMODIFICO.Second + @"', 120),
                     ACTIVO = 'NO'
					where ID_ROLL = " + ID_ROLL + "";

                conexionSQL DBAdmin = new conexionSQL();
                DBAdmin.executeComando(SqlText);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<DCROLES> ROLESObtenerbyID_ROLL(System.Decimal ID_ROLL, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "ROLES";
                string SqlText = @"select ID_ROLL, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ROLES where ACTIVO = 'SI' AND ID_ROLL = " + ID_ROLL;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCROLES> lst = new List<DCROLES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCROLES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<DCROLES>();
            }
        }

        public static List<DCROLES> ROLESObtener(System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "ROLES";
                string SqlText = @"select ID_ROLL, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ROLES WHERE ACTIVO = 'SI'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCROLES> lst = new List<DCROLES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCROLES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<DCROLES>();
            }
        }

        public static List<DCROLES> ROLESObtenerbyCriterio(System.String NOMBRE, System.Decimal IDUSUARIO)
        {
            try
            {
                string TableName = "ROLES";
                string SqlText = @"select ID_ROLL, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ROLES WHERE ACTIVO = 'SI' AND NOMBRE LIKE '" + NOMBRE + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<DCROLES> lst = new List<DCROLES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new DCROLES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<DCROLES>();
            }
        }

        #endregion

        #region Metodos Juan
        public static List<ROLES> ROLESObtenerTodos(String ACTIVO)
        {
            try
            {
                string TableName = "ROLES";
                string SqlText = @"select ID_ROLL, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO,
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ROLES WHERE ACTIVO LIKE '" + ACTIVO + "'";

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<ROLES> lst = new List<ROLES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new ROLES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return new List<ROLES>();
            }
        }

        public static ROLES ROLESObtenerbyID_ROL(System.Decimal ID_ROLL)
        {
            try
            {
                string TableName = "ROLES";
                string SqlText = @"select ID_ROLL, NOMBRE, DESCRIPCION, ACTIVO, IDUSUARIOCREO, 
FECHACREO, IDUSUARIOMODIFICO, FECHAMODIFICO from ROLES where ID_ROLL = " + ID_ROLL;

                conexionSQL DBAdmin2 = new conexionSQL();
                DBAdmin2.obtenerDataTable(SqlText);
                dtrespuesta = conexionSQL.DTGLOBAL;
                List<ROLES> lst = new List<ROLES>();

                for (int i = 0; i < dtrespuesta.Rows.Count; i++)
                {
                    lst.Add
                    (
                        new ROLES
                        (
                            Convert.ToDecimal(dtrespuesta.Rows[i]["ID_ROLL"].Equals(System.DBNull.Value) ? 0 : dtrespuesta.Rows[i]["ID_ROLL"]),
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
                return lst[0];
            }
            catch (Exception ex)
            {
                return new ROLES();
            }
        }

        #endregion

    }

    #region DataContract
    [DataContract]
    public class DCROLES
    {
        #region Variables

        private System.Decimal dcID_ROLL;
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
        public System.Decimal ID_ROLL
        {
            get { return dcID_ROLL; }
            set { dcID_ROLL = value; }
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
        public DCROLES(System.Decimal nID_ROLL, System.String nNOMBRE, System.String nDESCRIPCION,
                System.String nACTIVO, System.Decimal nIDUSUARIOCREO, System.DateTime nFECHACREO,
                System.Decimal nIDUSUARIOMODIFICO, System.DateTime nFECHAMODIFICO)
        {
            dcID_ROLL = nID_ROLL;
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
