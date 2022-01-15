using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MemeberManager
{
	public MemeberManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void Insert(string name, string email,string phone, string password, int id)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO Members(MemberName,MemberEmail,MemberPhone,MemeberPassword,CityID) VALUES (@MemberName,@MemberEmail,@MemberPhone,@MemeberPassword,@CityID)");
        cmd.Parameters.AddWithValue("@MemberName", name);
        cmd.Parameters.AddWithValue("@MemberEmail", email);
        cmd.Parameters.AddWithValue("@MemberPhone", phone);
        cmd.Parameters.AddWithValue("@MemeberPassword", password );
        cmd.Parameters.AddWithValue("@CityID", id );

        
        Database.ExecuteCommand(cmd);
    }


    public void Update(string name, string email, string phone, string password, int cityid, int memid)
    {
        SqlCommand cmd = new SqlCommand("UPDATE Member SET MemberName=@MemberName,MemberEmail=@MemberEmail,MemberPhone=@MemberPhone,MemeberPassword=@MemeberPassword,CityID=@CityID WHERE MemberID=@MemberID");
        cmd.Parameters.AddWithValue("@MemberName", name);
        cmd.Parameters.AddWithValue("@MemberEmail", email );
        cmd.Parameters.AddWithValue("@MemberPhone", phone);
        cmd.Parameters.AddWithValue("@MemeberPassword", password);
        cmd.Parameters.AddWithValue("@CityID", cityid);
        cmd.Parameters.AddWithValue("@MemberID", memid);
        Database.ExecuteCommand(cmd);
    }

    public void Delete(int id)
    {
        SqlCommand cmd = new SqlCommand("DELETE  FROM Member WHERE MemberID=@MemberID");
        cmd.Parameters.AddWithValue("@MemberID", id);
        Database.ExecuteCommand(cmd);
    }

    public DataTable Select()
    {
        return Database.Execute("SELECT * FROM Member ");
    }


    public DataRow Select(int id)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM Member WHERE MemberID=@MemberID");
        cmd.Parameters.AddWithValue("@MemberID", id);

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