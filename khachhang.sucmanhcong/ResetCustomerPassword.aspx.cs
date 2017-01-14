using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_ResetCustomerPassword : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    private Customers objCustomer = new Customers();
    public string strName = "", strAddress = "", strPhone = "", strCard = "", strEmail = "", strAccount = "",  strMsg = "";
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
            this.getCustomer();
        }
    }
    #endregion

    #region method getCustomer
    public void getCustomer()
    {
        DataTable objDataCutomer = this.objCustomer.getCustomerByAccount(Session["ACCOUNT"].ToString());
        if (objDataCutomer.Rows.Count > 0)
        {
            this.strName = objDataCutomer.Rows[0]["Name"].ToString();
            this.strAddress = objDataCutomer.Rows[0]["Address"].ToString();
        
            this.strPhone = objDataCutomer.Rows[0]["Phone"].ToString();
            this.strEmail = objDataCutomer.Rows[0]["Email"].ToString();
      
            this.strAccount = objDataCutomer.Rows[0]["Account"].ToString();
            switch(objDataCutomer.Rows[0]["AccountType"].ToString())
            {
                case "CustomerAccount": this.strCard = "Thẻ Đồng"; break;
                case "CustomerAccount1": this.strCard = "Thẻ Bạc"; break;
                case "CustomerAccount2": this.strCard = "Thẻ Vàng"; break;
                default: this.strCard = "Không xác định"; break;
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