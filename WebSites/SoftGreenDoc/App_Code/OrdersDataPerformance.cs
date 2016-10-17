using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections;

public class OrdersDataPerformance
{
    private static string FilterExpression;
    
    public OrdersDataPerformance()
	{		
	}

    public IEnumerable GetOrders(string sortExpression, int maximumRows, int startRowIndex)
    {        
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));

        string filterExpression = "";

        if (!string.IsNullOrEmpty(sortExpression))
        {
            if (sortExpression.IndexOf("__ob_sep__") != -1)
            {
                string tempExpression = sortExpression;
                sortExpression = tempExpression.Substring(0, tempExpression.IndexOf("__ob_sep__"));
                filterExpression = tempExpression.Substring(tempExpression.IndexOf("__ob_sep__") + 10);
            }

            if (!string.IsNullOrEmpty(sortExpression))
                sortExpression = " ORDER BY " + sortExpression;
        }
        
        OrdersDataPerformance.FilterExpression = filterExpression;

        // the command text needs to look like this:
        // SELECT TOP 10 FROM Orders WHERE OrderID NOT IN (SELECT TOP 20 FROM Orders)
        // (to retrieve 10 records from page 3)

        string commandText = "SELECT TOP " + maximumRows.ToString() + " * FROM Orders";
        if (!string.IsNullOrEmpty(filterExpression) || startRowIndex > 0)
        {
            commandText += " WHERE ";
            if (!string.IsNullOrEmpty(filterExpression))
            {
                commandText += filterExpression;
                if (startRowIndex > 0)
                    commandText += " AND ";
            }
            if (startRowIndex > 0)
                commandText += "OrderID NOT IN (SELECT TOP " + startRowIndex.ToString() + " OrderID FROM Orders " + (filterExpression != string.Empty ? " WHERE " + filterExpression : "") + sortExpression + ")";
        }
        commandText += sortExpression;

        OleDbCommand myComm = new OleDbCommand(commandText, myConn);        

        myConn.Open();        
        
        DataSet ds = new DataSet();
        
        
        OleDbDataAdapter da = new OleDbDataAdapter();
        
        da.SelectCommand = myComm;
        da.Fill(ds, "Orders");
        
        myConn.Close();        
        
        return ds.Tables[0].DefaultView;
    }

    public int GetOrdersCount()
    {
        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));        
        OleDbCommand myComm = new OleDbCommand("SELECT COUNT(*) FROM Orders" + (OrdersDataPerformance.FilterExpression != String.Empty ? " WHERE " + OrdersDataPerformance.FilterExpression : ""), myConn);

        myConn.Open();

        int count = (int)(myComm.ExecuteScalar());        

        myConn.Close();
        return count;
    }
}
