using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;

public class ImageZoomData
{
    public ImageZoomData() { }

    public static DataSet GetImageZoomData()
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/ImageZoom1.mdb"));
        var myComm = new OleDbCommand("SELECT [id], [imageUrl], [imageDescription] FROM [tbl_ImageZoom]", myConn);
        var da = new OleDbDataAdapter(myComm);
        var ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            myComm.Dispose();
            myConn.Close();
        }

        return ds;
    }

    public string DataImageUrl{
        get;
        set;
    }
    public string DataImageDescription
    {
        get;
        set;
    }
   /* 
    public static DataSet GetImageZoomData()
    {
        var myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageZoomConnectionString1"].ConnectionString);
        var myComm = new SqlCommand("SELECT [id], [imageUrl], [imageDescription] FROM [tbl_ImageZoom]", myConn);
        var da = new SqlDataAdapter(myComm);
        var ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            myComm.Dispose();
            myConn.Close();
        }

        return ds;
    }
     */ 
}
