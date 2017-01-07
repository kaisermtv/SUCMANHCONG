using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TVSFunc
{
    public string ErrorMessage = "";

    #region Method CryptographyMD5
    public string CryptographyMD5(string source)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider objMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(source);
        byte[] bytHash = objMD5.ComputeHash(buffer);
        string result = "";
        foreach (byte a in bytHash)
        {
            result += int.Parse(a.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
        }
        return result;
    }
    #endregion

    #region method changePass
    public string changePass(string Account, string Old, string New)
    {
        bool foundAccount = false;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT * FROM [tblAccount] WHERE [Acct_Name] = @Account AND [Acct_Pass] = @OldAccountPass";
        Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Account;
        Cmd.Parameters.Add("OldAccountPass", SqlDbType.NVarChar).Value = this.CryptographyMD5(Old);
        Cmd.Parameters.Add("AccountPass", SqlDbType.NVarChar).Value = this.CryptographyMD5(New);
        SqlDataReader Rd = Cmd.ExecuteReader();
        while (Rd.Read())
        {
            foundAccount = true;
        }
        Rd.Close();
        if (!foundAccount)
        {
            return "Thông tin không hợp lệ, vui lòng xem lại!";
        }
        else
        {
            Cmd.CommandText = "UPDATE [tblAccount] SET [Acct_Pass] = @AccountPass WHERE [Acct_Name] = @Account";
            Cmd.ExecuteNonQuery();
        }
        sqlCon.Close();
        sqlCon.Dispose();
        return "Thay đổi mật khẩu thành công !";
    }
    #endregion

    #region method getPartnerAccount
    public string getPartnerAccount()
    {
        string tmpValue = "";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(PartnerAccount,'') AS PartnerAccount FROM tblSystemCongif WHERE Id = 1";
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = Rd["PartnerAccount"].ToString().Trim();
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

    #region method getCustomerAccount
    public string getCustomerAccount(string TypeCard)
    {
        string tmpValue = "";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(" + TypeCard + ",'') AS CustomerAccount FROM tblSystemCongif WHERE Id = 1";
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = Rd["CustomerAccount"].ToString().Trim();
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

    #region menthod updatePartnerAccount
    public int updatePartnerAccount(int id, string partnerAcc)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [tblAccount] WHERE [Acct_Name] = @Account";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = partnerAcc;
            int ret = Cmd.ExecuteNonQuery();
            if (ret > 0)
            {
                return 1;
            }

            Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "IF EXISTS (SELECT * FROM [tblAccount] WHERE [Acct_Type] = 0 AND Acct_PGKEY = @Id)";
            Cmd.CommandText += " BEGIN UPDATE [tblAccount] SET [Acct_Name] = @Account WHERE [Acct_Type] = 0 AND Acct_PGKEY = @Id END";
            Cmd.CommandText += " ELSE BEGIN INSERT INTO [tblAccount]([Acct_Name],[Acct_Pass],[Acct_Type],Acct_PGKEY) VALUES(@Account,@Password,0,@Id)  END";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = partnerAcc;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = this.CryptographyMD5("123");
            ret = Cmd.ExecuteNonQuery();
            if (ret == 0)
            {
                return 2;
            }

            Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "UPDATE tblPartner SET Account = @Account, DayCreate = getdate() WHERE Id = @Id";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = partnerAcc;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
            ret = Cmd.ExecuteNonQuery();
            if (ret == 0)
            {
                return 2;
            }

            sqlCon.Close();
            sqlCon.Dispose();

            return 0;
        }
        catch(Exception ex)
        {
            this.ErrorMessage = ex.Message;
            return -1;
        }
    }
    #endregion

    #region menthod updateCustomerAccount
    public int updateCustomerAccount(int id, string customerAcc, string customertype)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [tblAccount] WHERE [Acct_Name] = @Account";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = customerAcc;
            int ret = Cmd.ExecuteNonQuery();
            if (ret > 0)
            {
                return 1;
            }

            Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "IF EXISTS (SELECT * FROM [tblAccount] WHERE [Acct_Type] = 1 AND Acct_PGKEY = @Id)";
            Cmd.CommandText += " BEGIN UPDATE [tblAccount] SET [Acct_Name] = @Account WHERE [Acct_Type] = 1 AND Acct_PGKEY = @Id END";
            Cmd.CommandText += " ELSE BEGIN INSERT INTO [tblAccount]([Acct_Name],[Acct_Pass],[Acct_Type],Acct_PGKEY) VALUES(@Account,@Password,1,@Id)  END";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = customerAcc;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
            Cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = this.CryptographyMD5("123");
            ret = Cmd.ExecuteNonQuery();
            if (ret == 0)
            {
                return 2;
            }

            Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "UPDATE [tblCustomers] SET Account = @Account, [AccountType] = @AccountType, DayCreateAccount = getdate() WHERE Id = @Id";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = customerAcc;
            Cmd.Parameters.Add("AccountType", SqlDbType.NVarChar).Value = customertype;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
            ret = Cmd.ExecuteNonQuery();
            if (ret == 0)
            {
                return 2;
            }

            sqlCon.Close();
            sqlCon.Dispose();

            return 0;
        }
        catch (Exception ex)
        {
            this.ErrorMessage = ex.Message;
            return -1;
        }
    }
    #endregion

    //IF NOT EXISTS (SELECT [column_name] FROM information_schema.columns WHERE [table_name] = 'tblBillDetail' and column_name = 'StockId')
    //BEGIN ALTER TABLE tblBillDetail ADD StockId nvarchar(50) DEFAULT('') END
    #region formatprice(String price)
    public String formatPrice(String price)
    {

        if (price.Length <= 3) { return price + " <sup><u>đ</u></sup>"; }
        else
        {
            char[] priceTmp = price.ToCharArray();
            if (priceTmp.Length <= 6 && priceTmp[priceTmp.Length - 1] == '0' && priceTmp[priceTmp.Length - 2] == '0' && priceTmp[priceTmp.Length - 3] == '0')
            {
                String price2 = new String(priceTmp);
                price2 = price2.Substring(0, price.Length - 3);
                return price2 + " k<sup><u>đ</u></sup>";
            }
            else if (priceTmp.Length <= 9 && priceTmp[priceTmp.Length - 1] == '0' && priceTmp[priceTmp.Length - 2] == '0' && priceTmp[priceTmp.Length - 3] == '0')
            {
                String price2 = new String(priceTmp);
                price2 = price2.Substring(0, price.Length - 3);
                price2 = String.Format("{0:n0}", Int32.Parse(price2));
                while (price2.EndsWith("0")) { price2 = price2.Substring(0, price2.Length - 1); }

                return (price2 + " tr <sup><u>đ</u></sup>");

            }

            else
            {
                return (" <span class='' style='fontsize:4px;'>" + price + "</span>");
            }
        }
    }

    #endregion
}