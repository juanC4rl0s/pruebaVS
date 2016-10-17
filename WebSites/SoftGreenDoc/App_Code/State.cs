using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for State
/// </summary>
public class State
{
	public State()
	{
	}

    public static DataSet GetStates()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add("States");
        ds.Tables[0].Columns.Add("State");
        
        String[] arrStates = {"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", 			
								"Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa",			
								"Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan",			
								"Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire",			
								"New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma",			
								"Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas",			
								"Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"};
        
        for (int i = 0; i < arrStates.Length; i++)
        {
            DataRow state = ds.Tables[0].NewRow();
            state["State"] = arrStates[i];
            ds.Tables[0].Rows.Add(state);
        }

        return ds;
    }
}