using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataTopic
/// </summary>
public class DataTopic
{
    #region method setTopic
    public int setTopic(int Id, string Title, string ShortContent, string Content, string Image, bool State, int GroupId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblTopic WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblTopic(Title,ShortContent,Content,Image,GroupId,DayCreate) VALUES(@Title,@ShortContent,@Content,@Image,@GroupId,getdate()) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblTopic SET Title = @Title, ShortContent = @ShortContent, Content = @Content, Image = @Image, State = @State, GroupId = @GroupId WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = Title;
            Cmd.Parameters.Add("ShortContent", SqlDbType.NVarChar).Value = ShortContent;
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = Content;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = Image;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
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

    #region method getTopicById
    public DataTable getTopicById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM tblTopic WHERE Id = @Id";
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

    #region method getTopic
    public DataTable getTopic(int groupid = 0)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT,'' AS DayCreate1, * FROM tblTopic";
            if(groupid != 0)
            {
                Cmd.CommandText += " WHERE [GroupId] = @GroupId";
                Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = groupid;
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            objTable = ds.Tables[0];
            return objTable;
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getTopicGroup
    public DataTable getTopicGroup()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT Id, UPPER(Name) AS Name FROM tblTopicGroup";

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

    #region method getTopTopic  || return 3 best topic
    public DataTable getTopTopic()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 3 0 AS TT, *,'' AS DayCreate1 FROM tblTopic WHERE GroupId = 1  ORDER BY DayCreate DESC";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            return ds.Tables[0];
        }
        catch
        {
            return new DataTable();
        }
        
    }
    #endregion

    #region method removeTopicImage
    public int removeTopicImage(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF  EXISTS (SELECT * FROM tblTopic WHERE Id = @Id)";
            sqlQuery += "BEGIN DELETE FROM tblTopic  WHERE Id = @Id END ";
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

    #region method Group Topic

    #region method getGroupTopicById
    public DataTable getGroupTopicById(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM [tblTopicGroup] WHERE Id = @Id";
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

    #endregion
}