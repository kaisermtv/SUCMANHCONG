using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataBusiness
/// </summary>
public class DataBusiness
{
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

    #region method getBusiness
    public DataTable getBusiness()
    {
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

            return ds.Tables[0];
        }
        catch
        {
            return new DataTable();
        }
        
    }
    #endregion

    #region method getBusinessById
    public DataTable getBusinessById(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblBusiness WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
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

    #region method setBusiness
    public int setBusiness(int Id, string Descriptionm, string Name)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblBusiness WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblBusiness(Name,Description) VALUES(@Name,@Description) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblBusiness SET Name = @Name, Description = @Description WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = Descriptionm;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            int ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region method DelBusiness
    public int DelBusiness(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "DELETE FROM [dbo].[tblBusiness] WHERE Id = @ID";
            Cmd.Parameters.Add("ID", SqlDbType.Int).Value = Id;

            int ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        }
        catch
        {
            return 0;
        }
        
    }
    #endregion
    
}