using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ACCOUNT"] = null;

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

            DataTable accout = this.GetAccount(this.txtAccount.Value.ToString());
            if(accout.Rows.Count == 0)
            {
                this.lblMsg.Text = "Tài khoản không tồn tại";
                return;
            }

            if (accout.Rows[0]["Acct_Pass"].ToString() != this.objFunc.CryptographyMD5(this.txtPassWord.Value.ToString()))
            {
                this.lblMsg.Text = "Mật khẩu không chính xác";
                return;
            }

            Session["ACCOUNT"] = accout.Rows[0]["Acct_Name"].ToString();
            
            int type = (int)accout.Rows[0]["Acct_Type"];
            if (type  == 0)
            {
                Response.Redirect("/Store");
            }
            else if (type == 1)
            {
                Response.Redirect("/Customer");
            }
        }
        
    } 
    #endregion

    #region method GetAccount
    protected DataTable GetAccount(string account)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE Acct_Name = @account";
            Cmd.Parameters.Add("account", SqlDbType.NVarChar).Value = account;
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


}