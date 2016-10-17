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
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for OrdersGenericData
/// </summary>
public class OrdersGenericData
{
	public OrdersGenericData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Order> GetGenericOrders()
    {
        List<Order> orders = new List<Order>();

        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();
        OleDbCommand myComm = new OleDbCommand("SELECT OrderID, ShipName, ShipCity, ShipCountry FROM Orders", myConn);
        OleDbDataReader myReader = myComm.ExecuteReader(CommandBehavior.Default);
       
        while (myReader.Read())
        {
            Order oOrder = new Order();
            oOrder.OrderID = myReader.GetInt32(0);
            oOrder.ShipName = myReader.GetString(1);
            oOrder.ShipCity = myReader.GetString(2);
            oOrder.ShipCountry = myReader["ShipCountry"].ToString();            
            
            orders.Add(oOrder);
        }
        myReader.Close();
        myConn.Close();

        return orders;
    }

    public static List<Order> GetGenericOrdersWithInfo()
    {
        List<Order> orders = new List<Order>();

        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();
        OleDbCommand myComm = new OleDbCommand("SELECT OrderID, ShipName, ShipCity, ShipCountry FROM Orders", myConn);
        OleDbDataReader myReader = myComm.ExecuteReader(CommandBehavior.Default);

        while (myReader.Read())
        {
            Order oOrder = new Order();
            oOrder.OrderID = myReader.GetInt32(0);
            oOrder.ShipName = myReader.GetString(1);
            oOrder.ShipCity = myReader.GetString(2);
            oOrder.ShipCountry = myReader["ShipCountry"].ToString();
           
            Random oRandom = new Random();            

            AdditionalInformation oAdditionalInfo1 = new AdditionalInformation();
            oAdditionalInfo1.Text = "info1_" + oOrder.OrderID.ToString() + "_" + oRandom.Next(100).ToString();

            AdditionalInformation oAdditionalInfo2 = new AdditionalInformation();
            oAdditionalInfo2.Text = "info2_" + oOrder.OrderID.ToString() + "_" + oRandom.Next(100).ToString();

            oOrder.AdditionalInfo = new ArrayList();
            oOrder.AdditionalInfo.Add(oAdditionalInfo1);
            oOrder.AdditionalInfo.Add(oAdditionalInfo2);

            orders.Add(oOrder);
        }
        myReader.Close();
        myConn.Close();

        return orders;
    }



    public static List<Customer> GetGenericCustomers()
    {
        List<Customer> customers = new List<Customer>();

        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();
        OleDbCommand myComm = new OleDbCommand("SELECT TOP 3 CustomerID, CompanyName, ContactName, Country FROM [Customers]", myConn);
        OleDbDataReader myReader = myComm.ExecuteReader(CommandBehavior.Default);

        while (myReader.Read())
        {
            Customer customer = new Customer();

            customer.CustomerID = myReader.GetString(0);
            customer.CompanyName = myReader.GetString(1);
            customer.ContactName = myReader.GetString(2);
            customer.Country = myReader.GetString(3);

            customers.Add(customer);
        }
        myReader.Close();
        myConn.Close();

        return customers;
    }



    public static List<Order> GetGenericOrdersByCustomer(string CustomerID)
    {
        List<Order> orders = new List<Order>();

        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();
        
        OleDbCommand myComm = new OleDbCommand("SELECT CustomerID, OrderID, OrderDate, ShippedDate, Freight FROM [Orders] WHERE CustomerID = @CustomerID", myConn);
        myComm.Parameters.Add("@CustomerID", OleDbType.VarChar).Value = CustomerID;
        
        OleDbDataReader myReader = myComm.ExecuteReader(CommandBehavior.Default);

        while (myReader.Read())
        {
            Order oOrder = new Order();

            oOrder.CustomerID = myReader.GetString(0);
            oOrder.OrderID = myReader.GetInt32(1);
            oOrder.OrderDate = myReader.GetDateTime(2);
            oOrder.ShippedDate = myReader.GetDateTime(3);
            double freight = 0;

            if(myReader["Freight"] != null)
            {
                double.TryParse(myReader["Freight"].ToString(), out freight);
            }

            oOrder.Freight = freight;

            orders.Add(oOrder);
        }
        myReader.Close();
        myConn.Close();

        return orders;
    }

    public static List<OrderDetail> GetGenericOrderDetailsByOrder(int OrderID)
    {
        List<OrderDetail> orderDetails = new List<OrderDetail>();

        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/Northwind.mdb"));
        myConn.Open();

        OleDbCommand myComm = new OleDbCommand("SELECT OrderID, UnitPrice, Quantity, Discount FROM [Order Details] WHERE OrderID = @OrderID", myConn);
        myComm.Parameters.Add("@OrderID", OleDbType.Integer).Value = OrderID;

        OleDbDataReader myReader = myComm.ExecuteReader(CommandBehavior.Default);

        while (myReader.Read())
        {
            OrderDetail orderDetail = new OrderDetail();

            orderDetail.OrderID = myReader.GetInt32(0);

            double unitPrice = 0;
            if (myReader["UnitPrice"] != null)
            {
                double.TryParse(myReader["UnitPrice"].ToString(), out unitPrice);
            }
            orderDetail.UnitPrice = unitPrice;

            int quantity = 0;
            if (myReader["Quantity"] != null)
            {
                int.TryParse(myReader["Quantity"].ToString(), out quantity);
            }
            orderDetail.Quantity = quantity;

            double discount = 0;
            if (myReader["Discount"] != null)
            {
                double.TryParse(myReader["Discount"].ToString(), out discount);
            }
            orderDetail.Discount = discount;

            orderDetails.Add(orderDetail);
        }
        myReader.Close();
        myConn.Close();

        return orderDetails;
    }
}

#region Order Class
public class Order
{
    public Order()
    {
    }

    private string customer_id;
    public string CustomerID
    {
        get
        {
            return customer_id;
        }
        set
        {
            customer_id = value;
        }
    }

    private int order_id;
    public int OrderID
    {
        get
        {
            return order_id;
        }
        set
        {
            order_id = value;
        }
    }

    private string ship_name;
    public string ShipName
    {
        get
        {
            return ship_name;
        }
        set
        {
            ship_name = value;
        }
    }

    private string ship_city;
    public string ShipCity
    {
        get
        {
            return ship_city;
        }
        set
        {
            ship_city = value;
        }
    }
   
    private string ship_country;
    public string ShipCountry
    {
        get
        {
            return ship_country;
        }
        set
        {
            ship_country = value;
        }
    }

    private string ship_postalcode;
    public string ShipPostalCode
    {
        get
        {
            return ship_postalcode;
        }
        set
        {
            ship_postalcode = value;
        }
    }
    private string ship_via;
    public string ShipVia
    {
        get
        {
            return ship_via;
        }
        set
        {
            ship_via = value;
        }
    }

    private string sent;
    public string Sent
    {
        get
        {
            return sent;
        }
        set
        {
            sent = value;
        }
    }


    private string ship_address;
    public string ShipAddress
    {
        get
        {
            return ship_address;
        }
        set
        {
            ship_address = value;
        }
    }

    private string ship_region;
    public string ShipRegion
    {
        get
        {
            return ship_region;
        }
        set
        {
            ship_region = value;
        }
    }

    private DateTime order_date;
    public DateTime OrderDate
    {
        get
        {
            return order_date;
        }
        set
        {
            order_date = value;
        }
    }

    private DateTime required_date;
    public DateTime RequiredDate
    {
        get
        {
            return required_date;
        }
        set
        {
            required_date = value;
        }
    }

    private DateTime shipped_date;
    public DateTime ShippedDate
    {
        get
        {
            return shipped_date;
        }
        set
        {
            shipped_date = value;
        }
    }

    private double _freight;
    public double Freight
    {
        get
        {
            return _freight;
        }
        set
        {
            _freight = value;
        }
    }

    private ArrayList _AdditionalInfo;
    public ArrayList AdditionalInfo
    {
        get
        {
            return _AdditionalInfo;
        }
        set
        {
            _AdditionalInfo = value;
        }
    }
}
#endregion

#region AdditionalInformation Class
[Serializable]
public class AdditionalInformation
{
    string _text;
    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
        }
    }
}
#endregion

#region Customer Class
public class Customer
{
    public Customer()
    {
    }

    private string customer_id;
    public string CustomerID
    {
        get
        {
            return customer_id;
        }
        set
        {
            customer_id = value;
        }
    }

    private string company_name;
    public string CompanyName
    {
        get
        {
            return company_name;
        }
        set
        {
            company_name = value;
        }
    }

    private string contact_name;
    public string ContactName
    {
        get
        {
            return contact_name;
        }
        set
        {
            contact_name = value;
        }
    }

    private string _country;
    public string Country
    {
        get
        {
            return _country;
        }
        set
        {
            _country = value;
        }
    }
}
#endregion

#region OrderDetail Class
public class OrderDetail
{
    public OrderDetail()
    {
    }

    private int order_id;
    public int OrderID
    {
        get
        {
            return order_id;
        }
        set
        {
            order_id = value;
        }
    }

    private double unit_price;
    public double UnitPrice
    {
        get
        {
            return unit_price;
        }
        set
        {
            unit_price = value;
        }
    }

    private int _quantity;
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            _quantity = value;
        }
    }

    private double _discount;
    public double Discount
    {
        get
        {
            return _discount;
        }
        set
        {
            _discount = value;
        }
    }
}
#endregion
