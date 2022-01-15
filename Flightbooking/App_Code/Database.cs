using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
    
    public static  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
    Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True

    public Database()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void OpenConnection()
    {
        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }
    }

    public static void CloseConnection()
    {
        con.Close();
    }

    public static void ExecuteCommand(SqlCommand cmd)
    {
        cmd.Connection = Database.con;
        Database.OpenConnection();
        cmd.ExecuteNonQuery();
        Database.CloseConnection();
    }


    public static DataTable Execute(SqlCommand cmd)
    {
        cmd.Connection = con;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter (cmd);
        da.Fill (dt);
        return dt;
    }

    public static DataTable Execute(string sql)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql,con);
        da.Fill(dt);
        return dt;
    }

}