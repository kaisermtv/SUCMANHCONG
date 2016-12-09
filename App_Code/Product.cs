using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataProduct
/// </summary>
public class Product
{
    public Product()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Method UpdateOrInsertProductByAccount
    public int UpdateOrInsertProductByAccount(string Account, int Id, string Name, float Price, float Discount, string Content, string Image, bool BestSale, bool VIP, int GroupId, int BrandId)
    {
        int ret = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";

            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblProduct WHERE Id = @Id AND  PartnerId = (SELECT id FROM tblPartner WHERE Account = @Account))";
            sqlQuery += "BEGIN INSERT INTO tblProduct(Name,Price,Discount,Content,Image,GroupId,BestSale,VIP,PartnerId,BrandId) VALUES(@Name,@Price,@Discount,@Content,@Image,@GroupId,@BestSale,@VIP,(SELECT id FROM tblPartner WHERE Account = @Account),@BrandId) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblProduct SET Name = @Name, Price = @Price, Discount = @Discount, Content = @Content, Image = @Image, BestSale = @BestSale, VIP = @VIP, GroupId = @GroupId, PartnerId = (SELECT id FROM tblPartner WHERE Account = @Account), BrandId = @BrandId WHERE Id = @Id END ";
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Price", SqlDbType.Float).Value = Price;
            Cmd.Parameters.Add("Discount", SqlDbType.Float).Value = Discount;
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = Content;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = Image;
            Cmd.Parameters.Add("BestSale", SqlDbType.Bit).Value = BestSale;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = VIP;
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            Cmd.Parameters.Add("BrandId", SqlDbType.Int).Value = BrandId;

            ret = Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return ret;
    }
    #endregion

    #region Method getProductById
    public DataTable getProductById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM tblProduct WHERE Id = @Id";
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

    #region method getProductCountById
    public int getProductCountById(int PartnerId)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblProduct WHERE PartnerId = @PartnerId";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            CountItem = ds.Tables[0].Rows.Count;
        }
        catch
        {

        }
        return CountItem;
    }
    #endregion

    #region method getProductVIPCountById
    public int getProductVIPCountById(int PartnerId)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblProduct WHERE PartnerId = @PartnerId AND VIP = 1";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            CountItem = ds.Tables[0].Rows.Count;
        }
        catch
        {
            return 0;
        }
        return CountItem;
    }
    #endregion

    #region method getProductBestSaleCountById
    public int getProductBestSaleCountById(int PartnerId)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblProduct WHERE PartnerId = @PartnerId AND BestSale = 1";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            CountItem = ds.Tables[0].Rows.Count;
            return CountItem;
        }
        catch
        {
            return 0;
        }
       
    }
    #endregion

    #region Method getDataByPartner
    public DataTable getDataByPartner(string Account)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct WHERE [State] = 1 AND PartnerId = (SELECT id FROM tblPartner WHERE Account = @Account)";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            objTable = ds.Tables[0];
            sqlCon.Close();
            sqlCon.Dispose();

            for (int i = 0; i < objTable.Rows.Count; i++)
            {
                objTable.Rows[i]["TT"] = (i + 1);
            }
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region Method getDataByPartnerAllAccount
    public DataTable getDataByPartnerAllAccount(string Account)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct WHERE PartnerId = (SELECT id FROM tblPartner WHERE Account = @Account)";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            objTable = ds.Tables[0];
            sqlCon.Close();
            sqlCon.Dispose();

            for (int i = 0; i < objTable.Rows.Count; i++)
            {
                objTable.Rows[i]["TT"] = (i + 1);
            }
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region Table Product Group

    #region Method getProductGroup
    public DataTable getProductGroupIdUpperName()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT Id, UPPER(Name) AS Name FROM tblProductGroup";

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

    #endregion
}