using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Customers
{
	public Customers()
	{
	}

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
    public DataTable getCustomer(string Account)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblCustomers WHERE Account = @Account";
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
        }
        catch
        {

        }

        return objTable;
    }
    #endregion

    
}