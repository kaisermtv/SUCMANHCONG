using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Abouts
/// </summary>
public class tblAbouts
{
    public string ErrorMessage = "";
    public int ErrorCode = 0;
    public tblAbouts()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region method getAbouts
    public DataTable getAbouts()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM tblAbouts WHERE Id = 1";

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

    #region method setAbouts
    public int setAbouts(string Name, string Address, string Phone, string Email, string Intro)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery += "IF NOT EXISTS (SELECT * FROM tblAbouts WHERE Id = 1)";
            sqlQuery += "BEGIN INSERT INTO tblAbouts(Id,Name,Address,Phone,Email,Intro) VALUES(1,@Name,@Address,@Phone,@Email,@Intro) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblAbouts SET Name = @Name, Address = @Address, Phone = @Phone, Email = @Email, Intro = @Intro WHERE Id = 1 END";
            
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("Intro", SqlDbType.NText).Value = Intro;
            int ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        }
        catch(Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }
    }
    #endregion
}