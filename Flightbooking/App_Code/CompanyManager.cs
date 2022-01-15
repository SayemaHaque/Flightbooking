using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CompanyManager
/// </summary>
public class CompanyManager
{
	public CompanyManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void Insert(string name)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO Companies(CompanyName) VALUES (@CompanyName)");
        cmd.Parameters.AddWithValue("@CompanyName", name);
        Database.ExecuteCommand(cmd);
    }


    public void Update(string name, int id)
    {
        SqlCommand cmd = new SqlCommand("UPDATE Companies SET CompanyName=@CompanyName WHERE CompanyID=@CompanyID");
        cmd.Parameters.AddWithValue("@CompanyName", name);
        cmd.Parameters.AddWithValue("@CompanyID", id);
        Database.ExecuteCommand(cmd);
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand("DELETE  FROM * Companies WHERE CompanyID=@CompanyID");
        cmd.Parameters.AddWithValue("@CompanyID", id);
        Database.ExecuteCommand(cmd);
    }

    public DataTable Select()
    {
        return Database.Execute("SELECT * FROM Companies ");
    }


    public DataRow Select(int id)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM Companies WHERE CompanyID=@CompanyID");
        cmd.Parameters.AddWithValue("@CompanyID", id);
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