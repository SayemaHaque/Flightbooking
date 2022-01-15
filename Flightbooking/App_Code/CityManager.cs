using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ArticleManager
/// </summary>
public class CityManager
{
	public CityManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void Insert(string name)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO Cities(CityName) VALUES (@CityName)");
        cmd.Parameters.AddWithValue("@CityName",name);
        Database.ExecuteCommand(cmd);
    }


    public void Update(string name,int id)
    {
        SqlCommand cmd = new SqlCommand("UPDATE Cities SET CityName=@CityName WHERE CityID=@CityID");
        cmd.Parameters.AddWithValue("@CityName", name);
        cmd.Parameters.AddWithValue("@CityID", id);
        Database.ExecuteCommand(cmd);
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand("DELETE  FROM Cities WHERE CityID=@CityID");
        cmd.Parameters.AddWithValue("@CityID", id);
        Database.ExecuteCommand(cmd);
    }

    public DataTable Select()
    {
        return Database.Execute("SELECT * FROM Cities ");
    }
 

    public DataRow Select(int id)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM Cities WHERE CityID=@CityID");
        cmd.Parameters.AddWithValue("@CityID", id);
        DataTable dt = Database.Execute(cmd);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0];
        }
        else
        {
            return null;
        }
    }

}