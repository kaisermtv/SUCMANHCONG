using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        DataRowCollection objPartnerInfo = new Partner().getPartnerById(id).Rows;
        if (objPartnerInfo.Count == 0)
        {
            return 4;
        }


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

            if (objPartnerInfo[0]["Account"] != null && objPartnerInfo[0]["Account"] != "")
            {
                Cmd = sqlCon.CreateCommand();
                Cmd.CommandText = "UPDATE [tblPartnerBill] SET [PartnerAccount] = @Account WHERE [PartnerAccount] = @oldPartnerAccount";
                Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = partnerAcc;
                Cmd.Parameters.Add("oldPartnerAccount", SqlDbType.NVarChar).Value = objPartnerInfo[0]["Account"];
                Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
                ret = Cmd.ExecuteNonQuery();
                if (ret == 0)
                {
                    return 3;
                }

                Cmd = sqlCon.CreateCommand();
                Cmd.CommandText = "UPDATE [tblCustomers_SMS_OTP] SET [PartnerAccount] = @Account WHERE [PartnerAccount] = @oldPartnerAccount";
                Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = partnerAcc;
                Cmd.Parameters.Add("oldPartnerAccount", SqlDbType.NVarChar).Value = objPartnerInfo[0]["Account"];
                Cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
                ret = Cmd.ExecuteNonQuery();
                if (ret == 0)
                {
                    return 3;
                }
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
        //DataRowCollection objProduct = new DataProduct().getProductById(id).Rows;
        //if (objProduct.Count == 0)
        //{
        //    return 4;
        //}

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

    #region menthod getAccount
    public DataTable getAccount(string account)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();

            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM [tblAccount] WHERE [Acct_Name] = @Account";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = account;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();

            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            this.ErrorMessage = ex.Message;
            return new DataTable();
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

    #region sendEmailforUser
    public int sendEmail(String fromMail ,String fromName, String toMail,String toName,String password,String contentmail)
    {
        var fromAddress = new MailAddress(fromMail, fromName);
        var toAddress = new MailAddress(toMail , toName);
      
        String title = "Test mail";
        String content = "Noi dung";
        content = contentmail;
        var stmp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, password),
            Timeout=20000
        };
        try { 
        using (var message = new MailMessage(fromAddress, toAddress) { Subject = title, Body = content }) { stmp.Send(message); }
       
            }
        catch(Exception e)
        {
            if (e.ToString().Contains("authenticated")) { return -1; }
            return 0;
        }
        
        return 1;
    }
    #endregion




}