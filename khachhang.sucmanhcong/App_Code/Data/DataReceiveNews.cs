using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DataReceiveNews
{
   
	public int addEmail(string email)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            
            Cmd.CommandText = "IF NOT EXISTS (SELECT * FROM [tblReceiveNews] WHERE UPPER([Email]) = UPPER(@email))";
            Cmd.CommandText += "BEGIN INSERT INTO [tblReceiveNews]([Email]) VALUES(@email) END";
            Cmd.Parameters.Add("email", SqlDbType.NVarChar).Value = email.Trim();

            int ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        } catch
        {
            return 0;
        }
    }

    public DataTable getEmail( )
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0  AS TT, * FROM tblReceiveNews";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
         
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                ds.Tables[0].Rows[i]["TT"] = i + 1;
            }
                sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            return objTable;
        }
        catch
        {
            return new DataTable();
        }
    }
}