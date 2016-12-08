using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Business
/// </summary>
public class Business
{
	public Business()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region method getIdAndUpperName
    public DataTable getIdAndUpperName()
    {
        DataTable objTable = new DataTable();

        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, UPPER(Name) AS Name FROM tblBusiness";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();

            objTable = ds.Tables[0];

        }
        catch { }

        return objTable;
        
    }
    #endregion
}