using System;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for EmData
/// </summary>
public class EmData
{
    public EmData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataSet GetMenuData()
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/EasyMenuDB.mdb"));
        OleDbCommand myComm = new OleDbCommand("SELECT ID, InnerHtml, Url, ParentId FROM emSample", myConn);
        OleDbDataAdapter da = new OleDbDataAdapter(myComm);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch
        {
            throw;
        }
        finally
        {
            myComm.Dispose();
            myConn.Close();
        }

        return ds;
    }

}
