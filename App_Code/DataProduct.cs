using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataProduct
/// </summary>
public class DataProduct
{

    #region method getProduct
    public DataTable getProduct()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct ORDER BY id desc";
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

    #region Method UpdateOrInsertProductById
    public int UpdateOrInsertProductById(int Id, string Name, float Price, float Discount, string Content, string Image, bool BestSale, bool VIP, bool State, int GroupId, int PartnerId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblProduct WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblProduct(Name,Price,Discount,Content,Image,GroupId,BestSale,VIP,State,PartnerId) VALUES(@Name,@Price,@Discount,@Content,@Image,@GroupId,@BestSale,@VIP,@State,@PartnerId) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblProduct SET Name = @Name, Price = @Price, Discount = @Discount, Content = @Content, Image = @Image, BestSale = @BestSale, VIP = @VIP, State = @State, GroupId = @GroupId, PartnerId = @PartnerId WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Price", SqlDbType.Float).Value = Price;
            Cmd.Parameters.Add("Discount", SqlDbType.Float).Value = Discount;
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = Content;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = Image;
            Cmd.Parameters.Add("BestSale", SqlDbType.Bit).Value = BestSale;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = VIP;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = GroupId;
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
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

    #region Method getProductByPartnerId
    public DataTable getProductByPartnerId(int PartnerId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct WHERE PartnerId = @PartnerId";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;

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

    #region Method getCountProductByPartnerId
    public int getCountProductByPartnerId(int PartnerId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT COUNT(*) FROM tblProduct WHERE PartnerId = @PartnerId";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;

            int ret = (int)Cmd.ExecuteScalar();
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

    #region Method getProductVIPCountByPartnerId
    public int getProductVIPCountByPartnerId(int PartnerId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT COUNT(*) FROM tblProduct WHERE PartnerId = @PartnerId AND VIP = 1";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = PartnerId;

            int ret = (int)Cmd.ExecuteScalar();
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

    #region Method getProductBestSaleCountByPartnerId
    public int getProductBestSaleCountByPartnerId(int PartnerId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT COUNT(*) FROM tblProduct WHERE PartnerId = @PartnerId AND BestSale = 1";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = PartnerId;

            int ret = (int)Cmd.ExecuteScalar();
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

    #region method getProductGroup
    public DataTable getProductGroup()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, * FROM tblProductGroup";
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

    #region Method getProductGroupIdUpperName
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

    #region method getProductGroupById
    public DataTable getProductGroupById(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblProductGroup WHERE Id = @Id";
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

    #region method setProductGroup
    public int setProductGroup(int Id, string Descriptionm, string Name, bool State)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblProductGroup WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblProductGroup(Name,Description,State) VALUES(@Name,@Description,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblProductGroup SET Name = @Name, Description = @Description, State = @State WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = Descriptionm;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
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

    #endregion

    #region method getProductVIP || return 4 product
    public DataTable getTopProductVIP()
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT TOP 4 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct";
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
    #endregion

    #region method getProductBestSale  || return 4 product with best Sale
    public DataTable getProductBestSale()
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT TOP 4 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct WHERE BestSale = 1";
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
    #endregion

}