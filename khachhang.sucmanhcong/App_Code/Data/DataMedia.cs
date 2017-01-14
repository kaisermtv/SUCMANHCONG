using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataMedia
/// </summary>
public class DataMedia
{
	public DataMedia()
	{
	}
    #region method getMediaImage
    public DataTable getMediaImage()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblMedia";
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

    #region method getMediaImageById
    public DataTable getMediaImageById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM tblMedia WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;

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

    #region method setMediaImage
    public int setMediaImage(int Id, string name, string Url, string Image, bool State)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblMedia WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblMedia(Name,Image,Url,State) VALUES(@Name,@Image,@Url,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblMedia SET Name=@Name,Image = @Image, Url = @Url, State = @State WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = name;
            Cmd.Parameters.Add("Url", SqlDbType.NVarChar).Value = Url;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = Image;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
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

    #region method removeMediaImage
    public int removeMediaImage(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF  EXISTS (SELECT * FROM tblMedia WHERE Id = @Id)";
            sqlQuery += "BEGIN DELETE FROM tblMedia  WHERE Id = @Id END ";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            int ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();

            return 1;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

}