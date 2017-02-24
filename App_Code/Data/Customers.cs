using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

public class Customers
{
    public string ErrorMessage = "";
    public int ErrorCode = 0;

    #region method setCustomer
    //*
    public int setCustomer(int Id, string Name, string Address, string Birthday,string Phone,string Email,string Account,string IdCard,String Avatar,bool State)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblCustomers WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblCustomers(Name,Address,Birthday,IdCard,Phone,Email,Account,Avatar,State) VALUES(@Name,@Address,@Birthday,@IdCard,@Phone,@Email,@Account,@Avatar,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblCustomers SET Name = @Name,Address = @Address,Birthday = @Birthday,IdCard = @IdCard,Phone = @Phone,Email = @Email,Account = @Account,Avatar = @Avatar,State = @State WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            try
            {
                DateTime datee = DateTime.ParseExact(Birthday, "dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                datee = new DateTime(2010, 12, 21);
                Cmd.Parameters.Add("Birthday", SqlDbType.DateTime).Value = datee;
            }
            catch
            {
                Cmd.Parameters.Add("Birthday", SqlDbType.DateTime).Value = DateTime.Now;
            }
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            Cmd.Parameters.Add("IdCard", SqlDbType.NVarChar).Value = IdCard;
            Cmd.Parameters.Add("Avatar", SqlDbType.NVarChar).Value = Avatar;
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
    //*/
    #endregion

    #region method getDataCustomer
    public DataTable getDataCustomer()
    {
        DataTable objTable = new DataTable();
        try
        {

            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS TT, '' AS State1, *, '' AS NgayTao FROM tblCustomers ORDER BY DayRegister DESC";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
                ds.Tables[0].Rows[i]["NgayTao"] = DateTime.Parse(ds.Tables[0].Rows[i]["DayRegister"].ToString()).ToString("dd/MM/yyyy");
                if (ds.Tables[0].Rows[i]["State"].ToString().ToUpper() == "TRUE")
                {
                    ds.Tables[0].Rows[i]["State1"] = "<B>x</B>";
                }
                else
                {
                    ds.Tables[0].Rows[i]["State1"] = "-:-";
                }
            }
            objTable = ds.Tables[0];

        }
        catch
        {

        }

        return objTable;
    }
    #endregion

    #region method getCustomer
    public DataTable getCustomer(string Account = "")
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCustomers";
            if (Account != "")
            {
                Cmd.CommandText += " WHERE Account = @Account";
                Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            }
            
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

    #region method getCustomerById
    public DataTable getCustomerById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCustomers WHERE Id = @Id";
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

    #region method getCustomerByAccount
    public DataTable getCustomerByAccount(string Acct)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCustomers WHERE [Account] = @Acct";
            Cmd.Parameters.Add("Acct", SqlDbType.NVarChar).Value = Acct;
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

    #region method UpdateCustomerById
    public int UpdateCustomerById(int Id, string Account, string AccountType)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "UPDATE tblCustomers SET Account = @Account, AccountType = @AccountType, DayCreateAccount = getdate() WHERE Id = @Id";

            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
            Cmd.Parameters.Add("AccountType", SqlDbType.NVarChar).Value = AccountType;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;

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

    #region method getCustomerPaymentCallByCustomerAccount
    public double getCustomerPaymentCallByCustomerAccount(string CustomerAccount)
    {
        double tmpValue1 = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd1 = sqlCon.CreateCommand();
            Cmd1.CommandText = "SELECT ISNULL(SUM(TotalMoney),0) AS TotalMoney FROM tblCustomersPaymentByCard WHERE CustomerAccount = @CustomerAccount";
            Cmd1.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            SqlDataReader Rd1 = Cmd1.ExecuteReader();
            while (Rd1.Read())
            {
                tmpValue1 = double.Parse(Rd1["TotalMoney"].ToString());
            }
            Rd1.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }

        return tmpValue1;
    }
    #endregion

    #region SMS OTP

    #region method setCustomers_SMS_OTP
    public int setCustomers_SMS_OTP(string CustomerAccount, string PartnerAccount, string KeyOTP)
    {
        int rowsAffected = 0;
        try
        {
            SqlConnection sqlCon1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon1.Open();
            SqlCommand Cmd1 = sqlCon1.CreateCommand();
            string sqlQuery1 = "";
            sqlQuery1 = "INSERT INTO tblCustomers_SMS_OTP (CustomerAccount,PartnerAccount,DayCreate,KeyOTP) VALUES(@CustomerAccount,@PartnerAccount,getdate(),@KeyOTP)";
            Cmd1.CommandText = sqlQuery1;
            Cmd1.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            Cmd1.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccount;
            Cmd1.Parameters.Add("KeyOTP", SqlDbType.NVarChar).Value = KeyOTP;
            rowsAffected = Cmd1.ExecuteNonQuery();
            sqlCon1.Close();
            sqlCon1.Dispose();
        }
        catch
        {

        }

        return rowsAffected;
    }
    #endregion

    #region method getCustomers_SMS_OTP
    public DataTable getCustomers_SMS_OTP(string CustomerAccount, string PartnerAccount, string KeyOTP,string TimeOut)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCustomers_SMS_OTP WHERE KeyOTP = @KeyOTP and CustomerAccount = @CustomerAccount and PartnerAccount = @PartnerAccount and (getdate() - [DayCreate]) < @TimeOut";
            Cmd.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            Cmd.Parameters.Add("PartnerAccount", SqlDbType.NVarChar).Value = PartnerAccount;
            Cmd.Parameters.Add("KeyOTP", SqlDbType.NVarChar).Value = KeyOTP;
            Cmd.Parameters.Add("TimeOut", SqlDbType.DateTime).Value = TimeOut; //"00:05:00.000"; // Thời gian mà mã OTP còn hiệu lực
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];

            if (objTable.Rows.Count > 0 ) {
                SqlCommand Cmd2 = sqlCon.CreateCommand();
                Cmd2.CommandText = "DELETE  FROM tblCustomers_SMS_OTP WHERE KeyOTP = @KeyOTP and CustomerAccount = @CustomerAccount and PartnerAccount = @PartnerAccount ";
                Cmd2.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
                Cmd2.Parameters.Add("KeyOTP", SqlDbType.NVarChar).Value = KeyOTP;
                Cmd2.ExecuteNonQuery();
            }
        }
        catch
        {

        }

        return objTable;
    }
    #endregion

    #endregion

    #region method removeCustomer  || delelte customer with id
    public int removeCustomer(int id)
    {
        if (id == 0) return 1;
        try
        {
            SqlConnection sqlCon1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon1.Open();
            SqlCommand Cmd1 = sqlCon1.CreateCommand();
            string sqlQuery1 = "";
            sqlQuery1 += "DELETE FROM tblCustomers   WHERE ID=@id";
            Cmd1.CommandText = sqlQuery1;
            Cmd1.Parameters.Add("id", SqlDbType.Int).Value = id;
            Cmd1.ExecuteNonQuery();

            Cmd1 = sqlCon1.CreateCommand();
            Cmd1.CommandText = "DELETE FROM [tblAccount] WHERE [Acct_Type] = 1 AND Acct_PGKEY = @Id";
            Cmd1.Parameters.Add("Id", SqlDbType.Int).Value = id;
            Cmd1.ExecuteNonQuery();

            sqlCon1.Close();
            sqlCon1.Dispose();
        }
        catch
        {
            return -1;
        }
        return 1;
    }
    #endregion

    #region Method getSalesBalance
    public double getSalesCardByCustomerAccout(string CustomerAccout)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM(PB.TotalMoneyDiscount),0) FROM [tblCustomersPaymentByCard] AS CPC LEFT JOIN [tblPartnerBill] AS PB ON PB.[Id] = CPC.[BillId]";
            Cmd.CommandText += " WHERE PB.[CustomerAccount] = @CustomerAccout";
            Cmd.Parameters.Add("CustomerAccout", SqlDbType.NVarChar).Value = CustomerAccout.ToUpper().Trim();
            double ret = (double)Cmd.ExecuteScalar();

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

    #region method getCustomerTotalDiscountCard
    public double getCustomerTotalDiscountCard(string CustomerAccount)
    {
        double tmpValue = 0, tmpValue1 = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = " SELECT ISNULL(SUM((TotalMoneyDiscount*DiscountCard)/100),0) AS Discount FROM tblPartnerBill WHERE CustomerAccount = @CustomerAccount";
            Cmd.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["Discount"].ToString());
            }
            Rd.Close();

            SqlCommand Cmd1 = sqlCon.CreateCommand();
            Cmd1.CommandText = "SELECT ISNULL(SUM(TotalMoney),0) AS TotalMoney FROM tblCustomersPaymentByCard WHERE CustomerAccount = @CustomerAccount";
            Cmd1.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            SqlDataReader Rd1 = Cmd1.ExecuteReader();
            while (Rd1.Read())
            {
                tmpValue1 = double.Parse(Rd1["TotalMoney"].ToString());
            }
            Rd1.Close();

            tmpValue = tmpValue - tmpValue1;

            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

}