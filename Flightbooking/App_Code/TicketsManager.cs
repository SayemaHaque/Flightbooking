using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TicketsManager
/// </summary>
public class TicketsManager
{
	public TicketsManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public static void Insert(int companyid,int fromcityid,int tocityid,int price, string ticketclass )
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO Tickets(CompanyID,FromCityID,ToCityID,TicketPrice,TicketClass) VALUES (@CompanyID,@FromCityID,@ToCityID,@TicketPrice,@TicketClass)");
        cmd.Parameters.AddWithValue("@CompanyID", companyid);
        cmd.Parameters.AddWithValue("@FromCityID", fromcityid);
        cmd.Parameters.AddWithValue("@ToCityID", tocityid);
        cmd.Parameters.AddWithValue("@TicketPrice", price);
        cmd.Parameters.AddWithValue("@TicketClass", ticketclass);
        Database.ExecuteCommand(cmd);
    }


     public void Update(int companyid, int fromcityid, int tocityid, int price, string ticketclass, int ticketid)
    {
        SqlCommand cmd = new SqlCommand("UPDATE Tickets SET CompanyID=@CompanyID,FromCityID=@FromCityID,ToCityID=@ToCityID,TicketPrice=@TicketPrice,TicketClass=@TicketClass WHERE TicketID=@TicketID");
        cmd.Parameters.AddWithValue("@CompanyID", companyid);
        cmd.Parameters.AddWithValue("@FromCityID", fromcityid);
        cmd.Parameters.AddWithValue("@ToCityID", tocityid);
        cmd.Parameters.AddWithValue("@TicketPrice", price);
        cmd.Parameters.AddWithValue("@TicketClass", ticketclass);
        cmd.Parameters.AddWithValue("@TicketID", ticketid);
        Database.ExecuteCommand(cmd);
    }

     public void Delete(int ticketid)
    {
        SqlCommand cmd = new SqlCommand("DELETE  FROM Tickets WHERE TicketID=@TicketID");
        cmd.Parameters.AddWithValue("@TicketID", ticketid);
        Database.ExecuteCommand(cmd);
    }

    public DataTable Select()
    {
        return Database.Execute("SELECT * FROM Tickets");
    }


    public DataRow Select(int ticketid)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM Tickets WHERE TicketID=@TicketID");
        cmd.Parameters.AddWithValue("@TicketID", ticketid);
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