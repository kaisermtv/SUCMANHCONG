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

    #region getContact
    public DataTable getContact()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "  SELECT 0 AS TT, Id,Name,Email,Phone,[Subject],[Message]  FROM   tblContact ;";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            objTable = ds.Tables[0];
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                ds.Tables[0].Rows[i]["TT"] = i + 1;
            }

                return objTable;
        }
        catch
        { return objTable; }
    }

    #endregion

    #region method getContact
    public DataTable getContact(int id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblContact WHERE Id = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = id;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method DelContact
    public int DelContact(int id)
    {
        int ret = 0;
        if (id == 0) return ret;
        try
        {
            SqlConnection sqlCon1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon1.Open();
            SqlCommand Cmd1 = sqlCon1.CreateCommand();
            string sqlQuery1 = "";
            sqlQuery1 += "DELETE FROM tblContact  WHERE Id=@id";
            Cmd1.CommandText = sqlQuery1;
            Cmd1.Parameters.Add("id", SqlDbType.Int).Value = id;
            ret = Cmd1.ExecuteNonQuery();
            //ret = (int)Cmd1.ExecuteScalar();
            sqlCon1.Close();
            sqlCon1.Dispose();
        }
        catch
        {

        }
        return ret;
    }
    #endregion
}