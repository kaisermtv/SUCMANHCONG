using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Contact
/// </summary>
public class Contact
{
    // ContactUs ..
	public Contact()
	{
    }
    #region sendContact
    public int sendContact(string name, string email ,string phone,string title,string message)
    {
        try {       
                SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
                sqlCon.Open();
                SqlCommand Cmd = sqlCon.CreateCommand();
                Cmd.CommandText = "INSERT INTO tblContact(Name,Email,Phone,Subject,Message) VALUES (@Name,@Email,@Phone,@Tittle,@Message);";
                Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value=name;
                Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = email;
                Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = phone;
                Cmd.Parameters.Add("Tittle", SqlDbType.NVarChar).Value = title;
                Cmd.Parameters.Add("Message", SqlDbType.NVarChar).Value = message;
                Cmd.ExecuteNonQuery();
                return 1;
        }
        catch
        { return 0;  }
    }

    #endregion

}