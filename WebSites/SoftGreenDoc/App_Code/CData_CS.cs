using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;


/// <summary>
/// Simple class to load the data from the database
/// this class will be used by an ObjectDataSource object
/// </summary>
public partial class CData
{
	// method that loads the options from the database
	public DataTable GetOptions()
	{
		OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("~/App_Data/combobox.mdb"));
		OleDbCommand myComm = new OleDbCommand("SELECT * FROM combobox", myConn);
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
		return ds.Tables[0];
	}

    public static List<ComboboxItem> GetGenericItems()
    {
        List<ComboboxItem> items = new List<ComboboxItem>();

        OleDbConnection myConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath("../App_Data/combobox.mdb"));
        myConn.Open();
        OleDbCommand myComm = new OleDbCommand("SELECT * FROM combobox", myConn);
        OleDbDataReader myReader = myComm.ExecuteReader(CommandBehavior.Default);

        while (myReader.Read())
        {
            ComboboxItem item = new ComboboxItem();

            item.Text = myReader.GetString(myReader.GetOrdinal("text"));
            item.Value = myReader.GetInt32(myReader.GetOrdinal("value")).ToString();

            items.Add(item);
        }
        myReader.Close();
        myConn.Close();

        return items;
    }

}

public class ComboboxItem
{
    private string _text;
    private string _value;

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

    public string Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }
}
