using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Brand
/// </summary>
public class Brand
{

    #region method getBrandIdName
    public DataTable getBrandIdName()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT *, UPPER(Name) AS Name FROM tblBrand";

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

    #region method getBrand
    public DataTable getBrand()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = " SELECT * FROM tblBrand";

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


    #region method getTopBrand
    public DataTable getTopBrand()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = " SELECT * FROM tblBrand WHERE VIP  = 1 ";

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


    #region Method getBrandById
    public DataTable getBrandById(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM tblBrand WHERE Id = @Id";
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


    #region method setBrand
    public int setBrand(int Id, string Descriptionm, string Name,bool VIP,string logo)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblBrand WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblBrand(Name,Description,VIP,Logo) VALUES(@Name,@Description,@VIP,@Logo) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblBrand SET Name = @Name, Description = @Description, VIP=@VIP, Logo=@Logo WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = Descriptionm;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = VIP;
            Cmd.Parameters.Add("Logo", SqlDbType.NVarChar).Value = logo;
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

    #region method DelBrand
    public int DelBrand(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "DELETE FROM [dbo].[tblBrand] WHERE Id = @ID";
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