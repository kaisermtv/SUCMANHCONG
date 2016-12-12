using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Partner
{
    #region method Partner
    public Partner()
    {
    } 
    #endregion

    #region method setPartner
    public int addPartner(string Name, string Address, string Phone, string Manager, string TaxCode, int Business, int LocationId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "INSERT INTO tblPartner(Name,Address,Phone,Manager,Business,TaxCode,BestSale,VIP,State.LocationId) VALUES(@Name,@Address,@Phone,@Manager,@Business,@TaxCode,@BestSale,@VIP,@State,@LocationId) SELECT CAST(scope_identity() AS int)";
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("Manager", SqlDbType.NVarChar).Value = Manager;
            Cmd.Parameters.Add("TaxCode", SqlDbType.NVarChar).Value = TaxCode;
            Cmd.Parameters.Add("Business", SqlDbType.Int).Value = Business;
            Cmd.Parameters.Add("BestSale", SqlDbType.Bit).Value = false;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = false;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = false;
            Cmd.Parameters.Add("LocationId", SqlDbType.Int).Value = LocationId;
            
            //int ret = Cmd.ExecuteNonQuery();
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

    #region method setPartnerCustomer
    public int setPartnerCustomer(int PartnerId, string CardNumberId, int ProductId, double Number, double Price)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "INSERT INTO tblPartnerCustomer(PartnerId,CardNumberId,ProductId,Number,Price,DayUse) VALUES(@PartnerId,@CardNumberId,@ProductId,@Number,@Price,@DayUse)";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            Cmd.Parameters.Add("CardNumberId", SqlDbType.NVarChar).Value = CardNumberId;
            Cmd.Parameters.Add("ProductId", SqlDbType.Int).Value = ProductId;
            Cmd.Parameters.Add("Number", SqlDbType.Float).Value = Number;
            Cmd.Parameters.Add("Price", SqlDbType.Float).Value = Price;
            Cmd.Parameters.Add("DayUse", SqlDbType.DateTime).Value = DateTime.Now;
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

    #region method setCustomersPaymentByCard
    public int setCustomersPaymentByCard(string BillId, float TotalMoney, string CustomerAccount)
    {
        try
        {
            SqlConnection sqlCon1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon1.Open();
            SqlCommand Cmd1 = sqlCon1.CreateCommand();
            string sqlQuery1 = "";
            sqlQuery1 = "IF NOT EXISTS (SELECT * FROM tblCustomersPaymentByCard WHERE BillId = @BillId AND TotalMoney = @TotalMoney AND datepart(day,DayCreate) = datepart(day,getdate()) AND datepart(month,DayCreate) = datepart(month,getdate()) AND datepart(year,DayCreate) = datepart(year,getdate()) AND datepart(hour,DayCreate) = datepart(hour,getdate()) AND datepart(minute,DayCreate) = datepart(minute,getdate()) )";
            sqlQuery1 += "BEGIN INSERT INTO tblCustomersPaymentByCard(BillId,TotalMoney,DayCreate,CustomerAccount) VALUES(@BillId,@TotalMoney,getdate(),@CustomerAccount) END";
            Cmd1.CommandText = sqlQuery1;
            Cmd1.Parameters.Add("BillId", SqlDbType.NVarChar).Value = BillId;
            Cmd1.Parameters.Add("TotalMoney", SqlDbType.Float).Value = TotalMoney;
            Cmd1.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            int ret = Cmd1.ExecuteNonQuery();
            sqlCon1.Close();
            sqlCon1.Dispose();

            return ret;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    
    #region Method UpdateOrInsertPartner
    //*
    public int UpdateOrInsertPartner(int Id, string Name, string Address, string Phone, string Manager, string TaxCode, int Business, bool BestSale, bool VIP, bool State, float Discount, string Content, string Image)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "IF NOT EXISTS (SELECT * FROM tblPartner WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblPartner(Name,Address,Phone,Manager,Business,TaxCode,Content,Image,BestSale,VIP,State,Discount) VALUES(@Name,@Address,@Phone,@Manager,@Business,@TaxCode,@Content,@Image,@BestSale,@VIP,@State,@Discount) END ";
            sqlQuery += "UPDATE tblPartner SET Name = @Name, Address = @Address, Phone = @Phone, Manager = @Manager, Business = @Business, TaxCode = @TaxCode, Content = @Content, Image = @Image, State = @State, BestSale = @BestSale, VIP = @VIP, Discount = @Discount WHERE Id = @Id";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("Manager", SqlDbType.NVarChar).Value = Manager;
            Cmd.Parameters.Add("TaxCode", SqlDbType.NVarChar).Value = TaxCode;
            Cmd.Parameters.Add("Business", SqlDbType.Int).Value = Business;
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = Content;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = Image;
            Cmd.Parameters.Add("BestSale", SqlDbType.Bit).Value = BestSale;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = VIP;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.Parameters.Add("Discount", SqlDbType.Float).Value = Discount;
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
    // */
    #endregion
    

    #region PartnerBillDetail

    #region method getPartnerBillById
    public DataTable getPartnerBillById(string billId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblPartnerBill WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = billId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            objTable = ds.Tables[0];
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getHistoryBill
    public DataTable getHistoryBillByPartnerAccount(string PartnerAccount)
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT 0 AS TT, * FROM tblPartnerBill WHERE PartnerAccount = @PartnerAccount ORDER BY DayCreate DESC";
        Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccount;
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

    #region method setPartnerBill
    public int setPartnerBill(string CustomerAccount, string PartnerAccount, float TotalMoney, float TotalMoneyDiscount, float Discount, float DiscountCard, float DiscountAdv, float TotalPeyment)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblPartnerBill WHERE CustomerAccount = @CustomerAccount AND PartnerAccount = @PartnerAccount AND TotalMoney = @TotalMoney AND TotalMoneyDiscount = @TotalMoneyDiscount AND Discount = @Discount AND TotalPeyment = @TotalPeyment AND datepart(day,DayCreate) = datepart(day,getdate()) AND datepart(month,DayCreate) = datepart(month,getdate()) AND datepart(year,DayCreate) = datepart(year,getdate()) AND datepart(hour,DayCreate) = datepart(hour,getdate()) AND datepart(minute,DayCreate) = datepart(minute,getdate()) )";
            sqlQuery += "BEGIN INSERT INTO tblPartnerBill(CustomerAccount,PartnerAccount,TotalMoney,TotalMoneyDiscount,Discount,DiscountCard,DiscountAdv,TotalPeyment,DayCreate) VALUES(@CustomerAccount,@PartnerAccount,@TotalMoney,@TotalMoneyDiscount,@Discount,@DiscountCard,@DiscountAdv,@TotalPeyment,getdate()) SELECT TOP 1 CAST(SCOPE_IDENTITY () as int)  END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccount;
            Cmd.Parameters.Add("TotalMoney", SqlDbType.Float).Value = TotalMoney;
            Cmd.Parameters.Add("TotalMoneyDiscount", SqlDbType.Float).Value = TotalMoneyDiscount;
            Cmd.Parameters.Add("Discount", SqlDbType.Float).Value = Discount;
            Cmd.Parameters.Add("DiscountCard", SqlDbType.Float).Value = DiscountCard;
            Cmd.Parameters.Add("DiscountAdv", SqlDbType.Float).Value = DiscountAdv;
            Cmd.Parameters.Add("TotalPeyment", SqlDbType.Float).Value = TotalPeyment;
            //int ret = Cmd.ExecuteNonQuery();
            int ret = (int)Cmd.ExecuteScalar(); //SELECT TOP 1 CAST(SCOPE_IDENTITY () as int) 

            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
            //Response.Redirect("ProductCustomer.aspx");
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region method getPartnerBillDetail
    public DataTable getPartnerBillDetail(string BillId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblPartnerBillDetail WHERE BillId = @BillId";
            Cmd.Parameters.Add("BillId", SqlDbType.NVarChar).Value = BillId;
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

    #region method setPartnerBillDetail
    public int setPartnerBillDetail(string BillId, string ProductId, string ProductName, string ProductPrice, string ProductNumber)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblPartnerBillDetail WHERE BillId = @BillId AND ProductId = @ProductId)";
            sqlQuery += "BEGIN INSERT INTO tblPartnerBillDetail(BillId,ProductId,ProductName,ProductPrice,ProductNumber) VALUES(@BillId,@ProductId,@ProductName,@ProductPrice,@ProductNumber) END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("BillId", SqlDbType.NVarChar).Value = BillId;
            Cmd.Parameters.Add("ProductId", SqlDbType.Int).Value = ProductId;
            Cmd.Parameters.Add("ProductName", SqlDbType.NVarChar).Value = ProductName;
            Cmd.Parameters.Add("ProductPrice", SqlDbType.Float).Value = ProductPrice;
            Cmd.Parameters.Add("ProductNumber", SqlDbType.Float).Value = ProductNumber;
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

    #region method setPartnerBillDetailOther
    public int setPartnerBillDetailOther(string BillId, string ProductId, string ProductName, string ProductPrice, string ProductNumber)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblPartnerBillDetailOrther WHERE BillId = @BillId AND ProductId = @ProductId)";
            sqlQuery += "BEGIN INSERT INTO tblPartnerBillDetailOrther(BillId,ProductId,ProductName,ProductPrice,ProductNumber) VALUES(@BillId,@ProductId,@ProductName,@ProductPrice,@ProductNumber) END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("BillId", SqlDbType.NVarChar).Value = BillId;
            Cmd.Parameters.Add("ProductId", SqlDbType.Int).Value = ProductId;
            Cmd.Parameters.Add("ProductName", SqlDbType.NVarChar).Value = ProductName;
            Cmd.Parameters.Add("ProductPrice", SqlDbType.Float).Value = ProductPrice;
            Cmd.Parameters.Add("ProductNumber", SqlDbType.Float).Value = ProductNumber;
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

    #region method getPartnerBillDetailOtherById
    public DataTable getPartnerBillDetailOtherById(int BillId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblPartnerBillDetailOrther WHERE BillId = @BillId AND ISNULL(ProductNumber,0) > 0";
            Cmd.Parameters.Add("BillId", SqlDbType.NVarChar).Value = BillId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            objTable = ds.Tables[0];
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
        return objTable;
    }
    #endregion

    #region method getPartnerBillDetailById
    public DataTable getPartnerBillDetailById(int BillId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblPartnerBillDetail WHERE BillId = @BillId AND ISNULL(ProductNumber,0) > 0";
            Cmd.Parameters.Add("BillId", SqlDbType.NVarChar).Value = BillId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            objTable = ds.Tables[0];
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
        return objTable;
    }
    #endregion

    #region method getProductBillCount
    public int getProductBillCount(string Account)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblPartnerCustomer WHERE PartnerId = (SELECT TOP 1 Id FROM tblPartner WHERE Account = @Account)";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
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

    #region getPartnerBillProductNumberByProductId
    public string getPartnerBillProductNumber(string BillId, string ProductId)
    {
        string tmpValue = "";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(ProductNumber,0) AS ProductNumber FROM tblPartnerBillDetail WHERE BillId = @BillId AND ProductId = @ProductId";
            Cmd.Parameters.Add("BillId", SqlDbType.NVarChar).Value = BillId;
            Cmd.Parameters.Add("ProductId", SqlDbType.Int).Value = ProductId;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = Rd["ProductNumber"].ToString();
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
        if (tmpValue == "0")
        {
            tmpValue = "";
        }
        return tmpValue;
    }
    #endregion

    #region getPartnerBillInDayByAccount
    public double getPartnerBillInDayByAccount(string Account)
    {
        double tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM(TotalMoneyDiscount),0) AS TotalMoneyDiscount FROM tblPartnerBill WHERE PartnerAccount = @PartnerAccount AND datepart(day,DayCreate) = datepart(day,getdate()) AND datepart(month,DayCreate) = datepart(month,getdate()) AND datepart(year,DayCreate) = datepart(year,getdate())";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = Account;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["TotalMoneyDiscount"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getPartnerBillInWeekByAccount
    public double getPartnerBillInWeekByAccount(string Account)
    {
        double tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM(TotalMoneyDiscount),0) AS TotalMoneyDiscount FROM tblPartnerBill WHERE PartnerAccount = @PartnerAccount AND datepart(week,DayCreate) = datepart(week,getdate()) AND datepart(month,DayCreate) = datepart(month,getdate()) AND datepart(year,DayCreate) = datepart(year,getdate())";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = Account;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["TotalMoneyDiscount"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getPartnerBillInMonthByAccount
    public double getPartnerBillInMonthByAccount(string Account)
    {
        double tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM(TotalMoneyDiscount),0) AS TotalMoneyDiscount FROM tblPartnerBill WHERE PartnerAccount = @PartnerAccount AND datepart(month,DayCreate) = datepart(month,getdate()) AND datepart(year,DayCreate) = datepart(year,getdate())";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = Account;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["TotalMoneyDiscount"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion


    #region method getPartnerBillTotalDiscountByAccount
    public double getPartnerBillTotalDiscountByAccount(string Account)
    {
        double tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM((TotalMoneyDiscount*Discount)/100),0) AS Discount FROM tblPartnerBill WHERE PartnerAccount = @PartnerAccount";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = Account;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["Discount"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getPartnerBillTotalDiscountCardByAccount
    public double getPartnerBillTotalDiscountCardByAccount(string Account)
    {
        double tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM((TotalMoneyDiscount*DiscountCard)/100),0) AS Discount FROM tblPartnerBill WHERE PartnerAccount = @PartnerAccount";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = Account;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["Discount"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getPartnerBillTotalDiscountAdvByAccount
    public double getPartnerBillTotalDiscountAdvByAccount(string Account)
    {
        double tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM((TotalMoneyDiscount*DiscountAdv)/100),0) AS Discount FROM tblPartnerBill WHERE PartnerAccount = @PartnerAccount";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = Account;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["Discount"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region Method getNameAndAccountTypeCustomerByPartnerBillId
    public DataTable getNameAndAccountTypeCustomerByPartnerBillId(int BillId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT *, ISNULL((SELECT Name FROM tblCustomers WHERE Account = tblPartnerBill.CustomerAccount),'') AS CustomerName, ISNULL((SELECT AccountType FROM tblCustomers WHERE Account = tblPartnerBill.CustomerAccount),'') AS AccountType FROM tblPartnerBill WHERE Id = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = BillId;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = Cmd;
            da.Fill(ds);
            objTable = ds.Tables[0];
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {
        }
        return objTable;
    }
    #endregion

    #endregion

    #region Method getPartner
    public DataTable getPartner()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT 0 AS TT, '' AS State1, * FROM tblPartner";

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

    #region Method getPartnerById
    public DataTable getPartnerById(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT * FROM tblPartner WHERE Id = @Id";
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

    #region Method getPartnerIdUpperName
    public DataTable getPartnerIdUpperName()
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT Id, UPPER(Name) AS Name FROM tblPartner";

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

    #region method getPartnerIdByAccount
    public int getPartnerIdByAccount(string Account)
    {
        int PartnerId = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT Id FROM tblPartner WHERE Account = @Account";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                PartnerId = int.Parse(Rd["Id"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return PartnerId;
    }
    #endregion

    #region method getPartnerInforById
    public DataTable getPartnerInforById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT TOP 4 0 AS TT, * FROM tblPartner WHERE Id = @Id";
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

    #region method getPartnerInforByAccount
    public DataTable getPartnerInforByAccount(string Account)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblPartner WHERE Account = @Account";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
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

    #region method getPartnerIdNameByAccount
    public DataTable getPartnerIdNameByAccount(string Account)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT Id, UPPER(Name) AS Name FROM tblPartner WHERE Account = @Account";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;

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

    #region method setPartnerInforByAccount
    public int setPartnerInforByAccount(string Account, string Name, string Address, string Phone, string Manager, string TaxCode, int Business, string Content, string Image, bool BestSale, bool VIP, bool State, string BankAccount, string BankAccountName)
    {
        int ret = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "UPDATE tblPartner SET Name = @Name, Address = @Address, Phone = @Phone, Manager = @Manager, Business = @Business, TaxCode = @TaxCode, Content = @Content, Image = @Image, State = @State, BestSale = @BestSale, VIP = @VIP, BankAccount = @BankAccount, BankAccountName = @BankAccountName WHERE Account = @Account";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("Manager", SqlDbType.NVarChar).Value = Manager;
            Cmd.Parameters.Add("TaxCode", SqlDbType.NVarChar).Value = TaxCode;
            Cmd.Parameters.Add("Business", SqlDbType.Int).Value = Business;
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = Content;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = Image;
            Cmd.Parameters.Add("BestSale", SqlDbType.Bit).Value = BestSale;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = VIP;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
            Cmd.Parameters.Add("BankAccount", SqlDbType.NVarChar).Value = BankAccount;
            Cmd.Parameters.Add("BankAccountName", SqlDbType.NVarChar).Value = BankAccountName;
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

    #region method getDiscountPartnerBillByCustomerAccount
    public double getDiscountPartnerBillByCustomerAccount(string CustomerAccount)
    {
        double tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM((TotalMoneyDiscount*DiscountCard)/100),0) AS Discount FROM tblPartnerBill WHERE CustomerAccount = @CustomerAccount";
            Cmd.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["Discount"].ToString());
            }
            Rd.Close();
        }
        catch
        {

        }

        return tmpValue;
    }
    #endregion

    #region Table Product

    #region method getProductCount
    public int getProductCount(string Account)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblProduct WHERE PartnerId = (SELECT TOP 1 Id FROM tblPartner WHERE Account = @Account)";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
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

    #region method getProductVIPCount
    public int getProductVIPCount(string Account)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblProduct WHERE PartnerId = (SELECT TOP 1 Id FROM tblPartner WHERE Account = @Account) AND VIP = 1";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
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

    #region method getProductBestSaleCount
    public int getProductBestSaleCount(string Account)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblProduct WHERE PartnerId = (SELECT TOP 1 Id FROM tblPartner WHERE Account = @Account) AND BestSale = 1";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
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


    #region method getProductDoanhSo
    public double getProductDoanhSo(string Account)
    {
        double TotalMoney = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT SUM(Price*Number) AS TotalMoney FROM tblPartnerCustomer WHERE PartnerId = (SELECT TOP 1 Id FROM tblPartner WHERE Account = @Account)";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            if (ds.Tables[0].Rows.Count > 0)
            {
                TotalMoney = double.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
        }
        catch
        {

        }
        return TotalMoney;
    }
    #endregion

    #endregion

}