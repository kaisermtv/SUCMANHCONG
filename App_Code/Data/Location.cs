using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Location
/// </summary>
public class Location
{

    #region method getLocation
    public DataTable getLocation()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT *  FROM tblLocation";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            return ds.Tables[0];
        }
        catch 
        {
            return new DataTable();
        }

    }
    #endregion

    #region method getIdAndUpperName
    public DataTable getIdAndUpperName()
    {
        DataTable objTable = new DataTable();

        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id, UPPER(Name) AS Name FROM tblLocation";
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

    #region method getLocationName
    public String getLocationName(int id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT *  FROM tblLocation WHERE Id = @ Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }
        catch { }

        return "";

    }
    #endregion
}