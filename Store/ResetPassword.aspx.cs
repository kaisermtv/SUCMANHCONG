using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_ResetPassword : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    private Partner objPartner = new Partner();
    public string strName = "", strAddress = "", strPhone = "", strManager = "", strEmail = "", strTaxcode = "", strAccount = "", strBestSale = "", strVIP = "", strMsg = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("/");
        }
        if (!Page.IsPostBack)
        {
            this.getPartner();
        }
    }
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objDataPartner = this.objPartner.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
        if(objDataPartner.Rows.Count > 0)
        {
            this.strName = objDataPartner.Rows[0]["Name"].ToString();
            this.strAddress = objDataPartner.Rows[0]["Address"].ToString();
            this.strManager = objDataPartner.Rows[0]["Manager"].ToString();
            this.strPhone = objDataPartner.Rows[0]["Phone"].ToString();
            this.strEmail = objDataPartner.Rows[0]["Email"].ToString();
            this.strTaxcode = objDataPartner.Rows[0]["TaxCode"].ToString();
            this.strAccount = objDataPartner.Rows[0]["Account"].ToString();
            if (objDataPartner.Rows[0]["BestSale"].ToString() == "True")
            {
                this.strBestSale = "X";
            }
            else
            {
                this.strBestSale = "";
            }
            if (objDataPartner.Rows[0]["VIP"].ToString() == "True")
            {
                this.strVIP = "X";
            }
            else
            {
                this.strVIP = "";
            }
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtOldPass.Text.Trim() == "")
        {
            this.strMsg = "Bạn chưa nhập mật khẩu hiện tại!";
            return;
        }
        if (this.txtNewPass.Text.Trim() == "")
        {
            this.strMsg = "Bạn chưa nhập mật khẩu mới!";
            return;
        }
        if (this.txtNewPass2.Text.Trim() != this.txtNewPass.Text.Trim())
        {
            this.strMsg = "Nhập lại mật khẩu không khớp!";
            return;
        }
        this.strMsg = this.objFunc.changePass(Session["ACCOUNT"].ToString(), this.txtOldPass.Text, this.txtNewPass.Text);
    } 
    #endregion
}