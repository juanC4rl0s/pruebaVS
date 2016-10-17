using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for OrdersData
/// </summary>
public class OrdersData
{
	public OrdersData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet GetOrders()
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        OleDbCommand myComm = new OleDbCommand("SELECT TOP 25 * FROM Orders ORDER BY OrderID DESC", myConn);
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

    public int InsertOrder(object OrderID, string ShipName, string ShipCity, string ShipPostalCode, string ShipCountry)
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();

        OleDbCommand myComm = new OleDbCommand("INSERT INTO Orders (ShipName, ShipCity, ShipPostalCode, ShipCountry) VALUES(@ShipName, @ShipCity, @ShipPostalCode, @ShipCountry)", myConn);

        myComm.Parameters.Add("@ShipName", OleDbType.VarChar).Value = ShipName;
        myComm.Parameters.Add("@ShipCity", OleDbType.VarChar).Value = ShipCity;
        myComm.Parameters.Add("@ShipPostalCode", OleDbType.VarChar).Value = ShipPostalCode;
        myComm.Parameters.Add("@ShipCountry", OleDbType.VarChar).Value = ShipCountry;

        myComm.ExecuteNonQuery();
        myConn.Close();

        return 1;
    }

    public int UpdateOrder(int OrderID, string ShipName, string ShipCity, string ShipPostalCode, string ShipCountry)
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();

        OleDbCommand myComm = new OleDbCommand("UPDATE Orders SET ShipName = @ShipName, ShipCity = @ShipCity, ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry WHERE OrderID = @OrderID", myConn);

        myComm.Parameters.Add("@ShipName", OleDbType.VarChar).Value = ShipName;
        myComm.Parameters.Add("@ShipCity", OleDbType.VarChar).Value = ShipCity;
        myComm.Parameters.Add("@ShipPostalCode", OleDbType.VarChar).Value = ShipPostalCode;
        myComm.Parameters.Add("@ShipCountry", OleDbType.VarChar).Value = ShipCountry;
        myComm.Parameters.Add("@OrderID", OleDbType.Integer).Value = OrderID;

        myComm.ExecuteNonQuery();
        myConn.Close();

        return 1;
    }

    public int DeleteOrder(int OrderID, string ShipName, string ShipCity, string ShipPostalCode, string ShipCountry)
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();

        OleDbCommand myComm = new OleDbCommand("DELETE FROM Orders WHERE OrderID = @OrderID", myConn);

        myComm.Parameters.Add("@OrderID", OleDbType.Integer).Value = OrderID;

        myComm.ExecuteNonQuery();
        myConn.Close();

        return 1;
    }

    public static DataSet GetCustomers()
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        
        OleDbCommand myComm = new OleDbCommand("SELECT TOP 3 * FROM [Customers]", myConn);
        
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

    public static DataSet GetOrdersByCustomer(string CustomerID)
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        
        OleDbCommand myComm = new OleDbCommand("SELECT * FROM [Orders] WHERE CustomerID = @CustomerID", myConn);
        myComm.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = CustomerID;

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

    public static DataSet GetOrderDetailsByOrder(int OrderID)
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        
        OleDbCommand myComm = new OleDbCommand("SELECT * FROM [Order Details] WHERE OrderID = @OrderID", myConn);
        myComm.Parameters.Add("@OrderID", OleDbType.Integer).Value = OrderID;
        
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
