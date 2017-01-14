using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Partner
{
    #region method bien
    public string ErrorMessage = "";
    public int ErrorCode = 0;

    #endregion

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
            Cmd.CommandText = "INSERT INTO tblPartner(Name,Address,Phone,Manager,Business,TaxCode,BestSale,VIP,State,LocationId) VALUES(@Name,@Address,@Phone,@Manager,@Business,@TaxCode,@BestSale,@VIP,@State,@LocationId) SELECT CAST(scope_identity() AS int)";
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
        catch (Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.ErrorCode = ex.HResult;
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
    public int UpdateOrInsertPartner(int Id, string Name, string Address, string Phone, string Manager, string TaxCode, int Business, bool BestSale, bool VIP, bool State, float Discount, string Content, string Image, int locationId,string datetime = "")
    {
        #region when user setup dateTime()
        if (datetime.Trim() != null) {
            try
            {
                SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
                sqlCon.Open();
                SqlCommand Cmd = sqlCon.CreateCommand();
                string sqlQuery = "IF NOT EXISTS (SELECT * FROM tblPartner WHERE Id = @Id)";
                sqlQuery += "BEGIN INSERT INTO tblPartner(Name,Address,Phone,Manager,Business,TaxCode,Content,Image,BestSale,VIP,State,Discount,LocationId,DayCreate) VALUES(@Name,@Address,@Phone,@Manager,@Business,@TaxCode,@Content,@Image,@BestSale,@VIP,@State,@Discount,@LocationId,@DayCreate) END ";
                sqlQuery += "ELSE BEGIN UPDATE tblPartner SET Name = @Name, Address = @Address, Phone = @Phone, Manager = @Manager, Business = @Business, TaxCode = @TaxCode, Content = @Content, Image = @Image, State = @State, BestSale = @BestSale, VIP = @VIP, Discount = @Discount,LocationId = @LocationId ,DayCreate= @DayCreate WHERE Id = @Id END";
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
                Cmd.Parameters.Add("LocationId", SqlDbType.Int).Value = locationId;
                Cmd.Parameters.Add("DayCreate", SqlDbType.DateTime).Value = datetime;
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

        #region update normal
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "IF NOT EXISTS (SELECT * FROM tblPartner WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblPartner(Name,Address,Phone,Manager,Business,TaxCode,Content,Image,BestSale,VIP,State,Discount,LocationId) VALUES(@Name,@Address,@Phone,@Manager,@Business,@TaxCode,@Content,@Image,@BestSale,@VIP,@State,@Discount,@LocationId) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblPartner SET Name = @Name, Address = @Address, Phone = @Phone, Manager = @Manager, Business = @Business, TaxCode = @TaxCode, Content = @Content, Image = @Image, State = @State, BestSale = @BestSale, VIP = @VIP, Discount = @Discount,LocationId = @LocationId WHERE Id = @Id END";
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
            Cmd.Parameters.Add("LocationId", SqlDbType.Int).Value = locationId;
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
    public DataTable getHistoryBill(string PartnerAccount = "",string fromdate = "",string todate = "",string customerAccount = "",int type = 0)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, PB.* FROM tblPartnerBill AS PB";
            if (type == 2)
            {
                Cmd.CommandText += " RIGHT JOIN [tblCustomersPaymentByCard] AS CPC ON PB.[Id] = CPC.[BillId] WHERE 1=1";
            }
            else if (type == 1)
            {
                Cmd.CommandText += " WHERE PB.[Id] NOT IN(SELECT [BillId] FROM [tblCustomersPaymentByCard])";
            }
            else
            {
                Cmd.CommandText += " WHERE 1=1";
            }
            
            if (PartnerAccount != "")
            {
                Cmd.CommandText += " AND UPPER(PB.PartnerAccount) = @PartnerAccount";
                Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccount.ToUpper();
            }

            if (customerAccount != "")
            {
                Cmd.CommandText += " AND UPPER(PB.[CustomerAccount]) = @CustomerAccount";
                Cmd.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = customerAccount.ToUpper();
            }

            if (fromdate != "")
            {
                Cmd.CommandText += " AND PB.DayCreate >= @FromDate";
                Cmd.Parameters.Add("FromDate", SqlDbType.DateTime).Value = fromdate;
            }

            if (todate != "")
            {
                Cmd.CommandText += " AND PB.DayCreate < DATEADD(day,1,@ToDate)";
                Cmd.Parameters.Add("ToDate", SqlDbType.DateTime).Value = todate;
            }

            Cmd.CommandText += " ORDER BY PB.DayCreate DESC";
            this.ErrorMessage = Cmd.CommandText;
           
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
                
            return ds.Tables[0];
        }
        catch { 
            return new DataTable();
        }
        
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

            Cmd.CommandText = "SELECT 0 AS TT, '' AS State1, * FROM tblPartner ORDER BY [DayCreate] DESC";

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

            Cmd.CommandText = "SELECT tblPartner.*,tblLocation.Name As Location FROM tblPartner LEFT JOIN tblLocation ON tblPartner.LocationId=tblLocation.Id WHERE tblPartner.Id = @Id ";
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
            Cmd.CommandText = "SELECT [Id],[Name],[Price],[Discount],[Image],[GroupId],[CountLike],[CountBuy],[BestSale],[VIP],[State],[PartnerId],[BrandId] FROM tblProduct WHERE PartnerId = (SELECT TOP 1 Id FROM tblPartner WHERE Account = @Account)";
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

    #region menthod getTVSFunc
    public int  updatePartner(int id, string partnerAcc)
    {
        try
        { 
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "UPDATE tblPartner SET Account = @Account, DayCreate = getdate(), AccountPass = @AccountPass WHERE Id = @Id";
        Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = partnerAcc + id.ToString("0000");
        Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;

        TVSFunc objFunc = new TVSFunc();
        Cmd.Parameters.Add("AccountPass", SqlDbType.NVarChar).Value = objFunc.CryptographyMD5("123");
        Cmd.ExecuteNonQuery();
            }
        catch
        {
            return -1;
        }
        return 1;
    }
    #endregion

    #region Method getProductBillCountByPartnerId
    public int getProductBillCountByPartnerId(int PartnerId)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();

            Cmd.CommandText = "SELECT COUNT(*) FROM tblPartnerCustomer WHERE PartnerId = @PartnerId";
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

    #region method getTopPartner        || return top 4 partner
    public DataTable getTopPartner()
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 6 0 AS TT, * FROM tblPartner";
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

    #region method getTopPartner        || return top number partner input
    public DataTable getTopPartner(int filter)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP  " + filter + " 0 AS TT , tblLocation.Name AS [Local],  tblPartner.* FROM tblPartner LEFT JOIN tblLocation ON tblLocation.Id = tblPartner.LocationId ";
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

    #region method getTopPartner        || return top number partner fromto 
    public DataTable getTopPartner(int from, int to)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP   0 AS TT, * FROM tblPartner LIMIT " + from + " OFFSET " + to + " ";
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

    #region method getTopPartnerBestSale        || return top number partner input
    public DataTable getTopPartnerBestSale(int filter)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP " + filter + " 0 AS TT, tblPartner.* , tblLocation.Name AS Location,tblLocation.color as Color FROM tblPartner  LEFT JOIN  tblLocation ON tblPartner.LocationId = tblLocation.Id  WHERE [BestSale] = 1 AND tblPartner.State = 1  ";
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

  
    #region method getTopPartnerVIP        || return top number partner input
    public DataTable getTopPartnerVIP(int filter = 4)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP " + filter + " tblPartner.* , tblLocation.Name AS Location,tblLocation.color as Color ,  tblPartner.* FROM tblPartner   JOIN tblLocation ON tblLocation.Id = tblPartner.LocationId WHERE [VIP] = 1 AND tblPartner.State = 1  ORDER BY tblPartner.Id DESC";
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


    #region method getBestSalePartnerFilterByGroup        || return top number partner input
    public DataTable getBestSalePartnerFilterByGroup(int business)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP " + 24 + " tblPartner.* , tblLocation.Name AS Location  FROM tblPartner   JOIN tblLocation ON tblLocation.Id = tblPartner.LocationId WHERE tblPartner.Business = @Business AND [BestSale] = 1 AND tblPartner.State = 1    ORDER BY tblPartner.Id DESC"; //
            Cmd.Parameters.Add("Business", SqlDbType.Int).Value = business;
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

    #region method getVIPTopPartnerFilterByGroup        || return top number partner input
    public DataTable getVIPPartnerFilterByGroup(int business)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP " + 24 + " 0 AS TT, tblPartner.* , tblLocation.Name AS Location FROM tblPartner  LEFT JOIN  tblLocation ON tblPartner.LocationId = tblLocation.Id  WHERE [VIP] = 1 AND tblPartner.Business = @Business AND  tblPartner.State = 1  "; //
            Cmd.Parameters.Add("Business", SqlDbType.Int).Value = business;
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


    #region method getProductDoanhSoByPartnerId
    public double getProductDoanhSoByPartnerId(int PartnerId)
    {
        double TotalMoney = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT SUM(Price*Number) AS TotalMoney FROM tblPartnerCustomer WHERE PartnerId = @PartnerId";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
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

    #region method updatePartner
    public int updatePartner(int Id, double discountTotal, double discount, double discountAdv, double discountCard,double minSales,double maxSales)
    {
        
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "UPDATE tblPartner SET DiscountTotal = @DiscountTotal, Discount = @Discount, DiscountAdv = @DiscountAdv, DiscountCard = @DiscountCard,[MinSales] = @MinSales , [MaxSales] = @MaxSales WHERE Id = @Id";
            Cmd.Parameters.Add("DiscountTotal", SqlDbType.Float).Value = discountTotal;
            Cmd.Parameters.Add("Discount", SqlDbType.Float).Value = discount;
            Cmd.Parameters.Add("DiscountAdv", SqlDbType.Float).Value = discountAdv;
            Cmd.Parameters.Add("DiscountCard", SqlDbType.Float).Value = discountCard;
            Cmd.Parameters.Add("MinSales", SqlDbType.Float).Value = minSales;
            Cmd.Parameters.Add("MaxSales", SqlDbType.Float).Value = maxSales;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();    
  
        }
        catch
        {
            throw new Exception("Cannot Update " + "Error");
        }
        return 1;
    }
    #endregion

    #region method removePartner
    public int removePartner(int Id)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF  EXISTS (SELECT * FROM tblPartner WHERE Id = @Id)";
            sqlQuery += "BEGIN DELETE FROM tblPartner  WHERE Id = @Id END ";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            int ret = Cmd.ExecuteNonQuery();


            Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "DELETE FROM [tblAccount] WHERE [Acct_Type] = 0 AND Acct_PGKEY = @Id";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            ret = Cmd.ExecuteNonQuery();

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


    #region Method getPartnerOption
    public DataTable getPartnerOption(int vipandsale = 0,int Business = 0, int Location = 0, int limit = 0, int offset = 0,bool DESC = true,string search ="")
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "";
            Cmd.CommandText += "SELECT [tblPartner].[Id],[tblPartner].[Name],[tblPartner].[Address],[tblPartner].[Phone],[tblPartner].[Image],[tblPartner].[Discount]";
            Cmd.CommandText += ",tblLocation.Name as Location, tblLocation.color as Color";
            Cmd.CommandText += "  FROM tblPartner LEFT JOIN tblLocation ON tblPartner.LocationId = tblLocation.Id WHERE [tblPartner].[State] = 1 ";
            if(vipandsale == 1) 
            {
                Cmd.CommandText += " AND [tblPartner].[VIP] = 1";
            }
            else if (vipandsale == 2)
            {
                Cmd.CommandText += " AND [tblPartner].[BestSale] = 1";
            }
            if (Location != 0)
            {
                Cmd.CommandText += " AND [tblLocation].[Id] = " + Location.ToString();
            }
            if (Business != 0)
            {
                Cmd.CommandText += " AND [tblPartner].[Business] = " + Business.ToString();
            }
            if (search != "")
            {
                Cmd.CommandText += " AND (UPPER([tblPartner].[Name]) LIKE N'%'+ @Search +'%' OR UPPER([tblPartner].[Address]) LIKE N'%'+ @Search +'%')";
                Cmd.Parameters.Add("Search", SqlDbType.NVarChar).Value = search.ToUpper().Trim();
            }
            if(DESC)
            {
                Cmd.CommandText += " ORDER BY [DayCreate] DESC" ;
            }
            Cmd.CommandText += " OFFSET " + offset.ToString() + " ROWS";
            if (limit != 0)
            {
                Cmd.CommandText += " FETCH NEXT " + limit.ToString() + " ROWS ONLY";
            }
            //this.ErrorMessage = Cmd.CommandText;
            //return new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();

            return ds.Tables[0];
        }
        catch(Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.ErrorCode = ex.HResult;

            return new DataTable();
        }
    }
    #endregion

    #region Method getCountPartnerOption
    public int getCountPartnerOption(int vipandsale = 0, int Business = 0, int Location = 0,string search = "")
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "";
            Cmd.CommandText += "SELECT COUNT(*)  FROM tblPartner WHERE [tblPartner].[State] = 1 ";
            if (vipandsale == 1)
            {
                Cmd.CommandText += " AND [tblPartner].[VIP] = 1";
            }
            else if (vipandsale == 2)
            {
                Cmd.CommandText += " AND [tblPartner].[BestSale] = 1";
            }
            if (Location != 0)
            {
                Cmd.CommandText += " AND [tblPartner].[LocationId] = " + Location.ToString();
            }
            if (Business != 0)
            {
                Cmd.CommandText += " AND [tblPartner].[Business] = " + Business.ToString();
            }
            if (search != "")
            {
                Cmd.CommandText += " AND (UPPER([tblPartner].[Name]) LIKE N'%'+ @Search +'%' OR UPPER([tblPartner].[Address]) LIKE N'%'+ @Search +'%')";
                Cmd.Parameters.Add("Search", SqlDbType.NVarChar).Value = search.ToUpper().Trim();
            }
            //this.ErrorMessage = Cmd.CommandText;

            int ret = (int)Cmd.ExecuteScalar();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        }
        catch (Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }
    }
    #endregion



    #region Method getSalesBalance
    public double getSalesCardByPartnerAccout(string PartnerAccout)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM(PB.TotalMoneyDiscount),0) FROM [tblCustomersPaymentByCard] AS CPC LEFT JOIN [tblPartnerBill] AS PB ON PB.[Id] = CPC.[BillId]";
            Cmd.CommandText += " WHERE PB.[PartnerAccount] = @PartnerAccount";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccout.ToUpper().Trim();
            double ret = (double)Cmd.ExecuteScalar();

            Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM([TotalPayment]),0) FROM [tblPartnerPayments]";
            Cmd.CommandText += " WHERE [PartnerId] = (SELECT [Id] FROM [tblPartner] WHERE [Account] = @PartnerAccount) ";
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccout.ToUpper().Trim();
            ret += (double)Cmd.ExecuteScalar();


            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        }
        catch(Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.ErrorCode = ex.HResult;

            return 0;
        }
    }
    #endregion

    #region Method getSalesBalance
    public int addPartnerPayment(int AccountId,int PartnerId,double Payment)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "INSERT INTO [tblPartnerPayments]([PartnerId],[TotalPayment],[AccountId]) VALUES(@PartnerId,@Payment,@AccountId) SELECT CAST(scope_identity() AS int)";
            Cmd.Parameters.Add("AccountId", SqlDbType.Int).Value = AccountId;
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            Cmd.Parameters.Add("Payment", SqlDbType.Float).Value = Payment;

            //int ret = Cmd.ExecuteNonQuery();
            int ret = (int)Cmd.ExecuteScalar();
            sqlCon.Close();
            sqlCon.Dispose();

            return ret;
        }
        catch (Exception ex)
        {
            this.ErrorMessage = ex.Message;
            this.ErrorCode = ex.HResult;
            return 0;
        }
    }
    #endregion
}