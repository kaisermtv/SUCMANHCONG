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

    #region method getPartProduct
    public DataTable getPartProduct()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = " SELECT 0 AS TT,Name,Price,Id,CountLike,CountBuy, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct ORDER BY id desc";
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

    #region Method getProductByIdJoin   
    public DataTable getProductByIdJoin(int Id)                  
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT tblProduct.* , tblLocation.Name AS Location  FROM tblPartner LEFT JOIN tblLocation  ON tblPartner.LocationId = tblLocation.Id  LEFT JOIN  tblProduct ON tblProduct.PartnerId =  tblPartner.Id WHERE  tblPartner.Id = @Id ;";
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

    #region Method getProductByIdWithJoinAndRecentlyUpdate      || hạn chế lấy cột content
    public DataTable getProductByIdWithJoinAndRecentlyUpdate(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = " SELECT TOP 15 tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId], tblLocation.Name AS Location ";
            Cmd.CommandText += "  FROM tblPartner  LEFT JOIN tblLocation  ON tblPartner.LocationId = tblLocation.Id  LEFT JOIN  tblProduct ON tblProduct.PartnerId =  tblPartner.Id   WHERE tblPartner.Id = @PartnerId ;";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = Id;
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

    #region Method getProductByIdWithJoinAndSortByPrice  ||  ! Không lấy cột content
    public DataTable getProductByIdWithJoinAndSortByPrice(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText += " SELECT TOP 15 tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId], tblLocation.Name AS Location ";
            Cmd.CommandText += " FROM tblPartner LEFT JOIN tblLocation  ON tblPartner.LocationId = tblLocation.Id  LEFT JOIN  tblProduct ON tblProduct.PartnerId =  tblPartner.Id WHERE tblPartner.Id = @PartnerId  ORDER BY tblProduct.Price   DESC ;";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = Id;
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

    // sap xem 

    #region Method getAllProductSortByPrice ||  ! Không lấy cột content
    public DataTable getAllProductSortByPrice()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText += " SELECT 0 AS TT,Name,Price,Id,CountLike,CountBuy , REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1   from tblProduct  ORDER BY tblProduct.Price   DESC ;";
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

    #region Method getAllProductSortByVIP       ||  ! Không lấy cột content
    public DataTable getAllProductSortByVIP()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText += " SELECT 0 AS TT,Name,Price,Id,CountLike,CountBuy , REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1    from tblProduct  ORDER BY tblProduct.VIP   DESC ;";
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

    #region Method getAllProductSortBySALE ||  ! Không lấy cột content
    public DataTable getAllProductSortBySALE()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText += " SELECT 0 AS TT,Name,Price,Id,CountLike,CountBuy , REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1   from tblProduct  ORDER BY tblProduct.BestSale   DESC ;";
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

    #region Method getAllProductSortByBuy  ||  ! Không lấy cột content
    public DataTable getAllProductSortByBuy()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText += " SELECT 0 AS TT,Name,Price,Id,CountLike,CountBuy , REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1   from tblProduct  ORDER BY tblProduct.CountBuy   DESC ;";
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

    #region Method getAllProductSortByLike
    public DataTable getAllProductSortByLike()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText += " SELECT 0 AS TT,Name,Price,Id,CountLike,CountBuy , REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1   from tblProduct  ORDER BY tblProduct.CountLike   DESC ;";
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

    #region Method getAllProductSortBySALE
    public DataTable getAllProductSortByName()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText += " SELECT 0 AS TT,Name,Price,Id,CountLike,CountBuy , REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1  from tblProduct  ORDER BY tblProduct.Name   DESC ;";
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

    // tim kiem 
    #region Method getAllProductSearchByName
    public DataTable getAllProductSearchByName(string name)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

          //  Cmd.CommandText = "SELECT * FROM tblProduct WHERE UPPER(RTRIM(LTRIM(Name))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' ORDER BY Id DESC";

            Cmd.CommandText = " SELECT TOP 150 0 AS TT, tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId], REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1  from tblProduct ";
            Cmd.CommandText += " WHERE UPPER(RTRIM(LTRIM(Name))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Name)))+'%'   OR    UPPER(RTRIM(LTRIM(Price))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@Name)))+'%'  ORDER BY tblProduct.Name   DESC ;";
              Cmd.Parameters.Add("@Name",SqlDbType.NVarChar).Value = name;
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
    #region Method getAllProductSearchByLocation
    public DataTable getAllProductSearchByLocation(string location)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            //  Cmd.CommandText = "SELECT * FROM tblProduct WHERE UPPER(RTRIM(LTRIM(Name))) LIKE  N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' ORDER BY Id DESC";

            Cmd.CommandText = " SELECT TOP  36 0 AS TT, tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId], REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1  from tblProduct ";
            Cmd.CommandText += " WHERE   tblProduct.PartnerId  IN (SELECT tblPartner.Id FROM tblPartner LEFT JOIN tblLocation ON tblLocation.Id = tblPartner.LocationId WHERE UPPER(RTRIM(LTRIM(tblLocation.Name)))   LIKE  N'%'+UPPER(RTRIM(LTRIM(@Location)))+'%'  ) ORDER BY tblProduct.Id   DESC ;";
            Cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
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

    // jon to show 
    #region Method getProductByIdWithJoinAndSortByPriceAsc  ||  ! Không lấy cột content
    public DataTable getProductByIdWithJoinAndSortByPriceAsc(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT TOP 15  tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId] , tblLocation.Name AS Location  FROM tblPartner  LEFT JOIN tblLocation  ON tblPartner.LocationId = tblLocation.Id  LEFT JOIN  tblProduct ON tblProduct.PartnerId =  tblPartner.Id WHERE tblProduct.Id IS NOT NULL  AND tblPartner.Id = @PartnerId  ORDER BY tblProduct.Price  , tblProduct.Id  ;";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = Id;
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

    #region Method getProductByIdWithJoinAndSortByDiscount      ||  ! Không lấy cột content
    public DataTable getProductByIdWithJoinAndSortByDiscount(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT TOP 15  tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId] , tblLocation.Name AS Location  FROM tblPartner  LEFT JOIN tblLocation  ON tblPartner.LocationId = tblLocation.Id  LEFT JOIN  tblProduct ON tblProduct.PartnerId =  tblPartner.Id WHERE tblProduct.Id IS NOT NULL  AND tblPartner.Id = @PartnerId  ORDER BY tblProduct.Discount  DESC , tblProduct.Id    ;";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = Id;
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

    #region Method getProductByIdWithJoinAndSortByLike      ||  ! Không lấy cột content
    public DataTable getProductByIdWithJoinAndSortByLike(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT TOP 4  tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId] , tblLocation.Name AS Location  FROM tblPartner  LEFT JOIN tblLocation  ON tblPartner.LocationId = tblLocation.Id  LEFT JOIN  tblProduct ON tblProduct.PartnerId =  tblPartner.Id WHERE tblProduct.Id IS NOT NULL  AND tblPartner.Id = @PartnerId  AND tblProduct.State =1  ORDER BY tblProduct.CountLike  ;";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = Id;
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

    #region method getTopProductVIP || return 4 product
    public DataTable getTopProductVIP(int limit = 4)
   {
       SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
      sqlCon.Open();
       SqlCommand Cmd = sqlCon.CreateCommand();
       Cmd.CommandText = "SELECT TOP " + limit.ToString() + " 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct WHERE tblProduct.VIP=1  AND tblProduct.State =1  ";
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
    
    #region Method getProductById
    public DataTable getProductById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * from tblProduct Where Id = @Id ;";
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

    #region method removeProduct
    public int removeProduct(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF  EXISTS (SELECT * FROM tblProduct WHERE Id = @Id)";
            sqlQuery += "BEGIN DELETE FROM tblProduct  WHERE Id = @Id END ";
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





    // Different Table

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
    public int setProductGroup(int Id, string Descriptionm, string Name, bool State,string icon)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblProductGroup WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblProductGroup(Name,Description,State,icon) VALUES(@Name,@Description,@State,@icon) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblProductGroup SET Name = @Name, Description = @Description, State = @State,icon=@icon WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = Descriptionm;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.Parameters.Add("icon", SqlDbType.NVarChar).Value = icon;
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

    #region method getProductVIP        || Return  all Products
    public DataTable getProductVIP()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 24 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct WHERE tblProduct.VIP =1 AND tblProduct.State = 1 ";
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

    #region method getFilterProductVIPByGroupId || return 15 Products Data Table 
    public DataTable getFilterTopProductVIP(int groupId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = " IF  EXISTS (SELECT tblProductGroup.Id FROM tblProductGroup WHERE Id = @groupId ) ";
            Cmd.CommandText += " BEGIN  SELECT TOP 16 0 AS TT, tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId], REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 ";
            Cmd.CommandText+= " FROM tblProduct   ";
            Cmd.CommandText += " WHERE GroupId = @groupId AND tblProduct.State =1  ORDER BY tblProduct.VIP END ";
            Cmd.CommandText += " ELSE BEGIN  SELECT TOP 16 0 AS TT, tblProduct.[Id],tblProduct.[Name],tblProduct.[Price],tblProduct.[Discount],tblProduct.[Image],tblProduct.[GroupId],tblProduct.[CountLike],tblProduct.[CountBuy],tblProduct.[BestSale],tblProduct.[VIP],tblProduct.[State],tblProduct.[PartnerId],tblProduct.[BrandId], REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1  FROM tblProduct WHERE  tblProduct.State =1  ORDER BY tblProduct.VIP   END  ";
            Cmd.Parameters.Add("@groupid", SqlDbType.Int).Value = groupId;
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

    #region method getProductBestSale  || return 4 product with best Sale
    public DataTable getProductBestSale(int limit = 4)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP " + limit.ToString() + " * FROM tblProduct WHERE BestSale = 1";
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

    #region method getTopProductVIPShowHome || return 15 Products Data Table
    public DataTable getTopProductVIPShowHome(int limit = 4, int offset = 0)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT  [Id],[Name],[Image],[Discount],[CountLike],[CountBuy],[Price] FROM tblProduct WHERE VIP = 1 AND [State] = 1 ORDER BY [Id] DESC OFFSET " + offset.ToString() + " ROWS FETCH NEXT " + limit.ToString() + " ROWS ONLY";
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

    #region Method getCountProductBestSaleShowHome
    public int getCountProductBestSaleShowHome()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT COUNT(*) FROM tblProduct WHERE BestSale = 1  AND [State] = 1";

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

    #region method getProductBestSaleShowHome
    public DataTable getProductBestSaleShowHome(int limit = 4,int offset=0)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT [Id],[Name],[Image],[Discount],[CountLike],[CountBuy],[Price] FROM tblProduct WHERE BestSale = 1  AND [State] = 1 ORDER BY [Id] DESC OFFSET "+ offset.ToString() +" ROWS FETCH NEXT "+ limit.ToString() +" ROWS ONLY";
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

    #region method getProductBestSaleWithNum  || return number product with best Sale
    public DataTable getProductBestSaleWithNum(int filter)
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT TOP  " + filter +" 0 AS TT, *, REPLACE(REPLACE(CAST(BestSale AS nvarchar),'1',N'Bán chạy'),'0','') AS BESTSALE1, REPLACE(REPLACE(CAST(VIP AS nvarchar),'1',N'VIP'),'0','') AS VIP1 FROM tblProduct WHERE BestSale = 1 AND tblProduct.State = 1 ";
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

    #region method removeGroupProduct
    public int removeGroupProduct(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF  EXISTS (SELECT * FROM tblProductGroup WHERE Id = @Id)";
            sqlQuery += "BEGIN DELETE FROM tblProductGroup  WHERE Id = @Id END ";
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