using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ADMINLOGIN"] != null && (int)Session["ADMINLOGIN"] != 0)
        {
            Response.Redirect("/system");
        }


        if (Page.IsPostBack)
        {
            if (this.txtAccount.Value.ToString() == "")
            {
                this.lblMsg.Text = "Tên đăng nhập không hợp lệ";
                return;
            }
            if (this.txtPassWord.Value.ToString() == "")
            {
                this.lblMsg.Text = "Mật khẩu nhập không hợp lệ";
                return;
            }

            int ret = this.Login(this.txtAccount.Value.ToString(), this.txtPassWord.Value.ToString());
            //*
            if(ret == 1)
            {
                this.lblMsg.Text = "Tài khoản không tồn tại";
                return;
            }

            if (ret == 2)
            {
                this.lblMsg.Text = "Mật khẩu không chính xác";
                return;
            }

            Response.Redirect("/system");
            //*/
        }
    }

    public int Login(string Acct, string Pass)
    {
        DataAccount dtac = new DataAccount();

        DataTable acct = dtac.getAccountByAccount(Acct.Trim());
        if (acct.Rows.Count == 0)
        {
            return 1;
        }


        if (acct.Rows[0]["PassWord"].ToString() != this.CryptographyMD5(Pass.Trim()))
        {
            return 2;
        }

        Session["ADMINLOGIN"] = (int)acct.Rows[0]["Id"];

        return 0;
    }

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
}