using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_PartnerInfo : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    private Partner objPartner = new Partner();
    public int SoSanPham = 0, SoSanPhamVIP = 0, SoSanPhamBanChay = 0, SoGiaoDich = 0;
    public double TongDoanhSo = 0;
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
            this.SoSanPham = this.objPartner.getProductCount(Session["ACCOUNT"].ToString());
            this.SoSanPhamVIP = this.objPartner.getProductVIPCount(Session["ACCOUNT"].ToString());
            this.SoSanPhamBanChay = this.objPartner.getProductBestSaleCount(Session["ACCOUNT"].ToString());
            this.SoGiaoDich = this.objPartner.getProductBillCount(Session["ACCOUNT"].ToString());
            this.TongDoanhSo = this.objPartner.getProductDoanhSo(Session["ACCOUNT"].ToString());
        }
    } 
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objDataPartner = this.objPartner.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
        if (objDataPartner.Rows.Count > 0)
        {
            this.lblName.Text = objDataPartner.Rows[0]["Name"].ToString();
            this.lblAddress.Text = "Địa chỉ: " + objDataPartner.Rows[0]["Address"].ToString();
            this.lblManager.Text = "Người quản lý: " + objDataPartner.Rows[0]["Manager"].ToString();
            this.lblPhone.Text = "Điện thoại: " + objDataPartner.Rows[0]["Phone"].ToString();
            this.lblTaxCode.Text = "Mã số thuế: " + objDataPartner.Rows[0]["TaxCode"].ToString();
            this.lblAccount.Text = objDataPartner.Rows[0]["Account"].ToString();
            if (objDataPartner.Rows[0]["BestSale"].ToString() == "True")
            {
                this.ckbBestSale.Checked = true;
            }
            else
            {
                this.ckbBestSale.Checked = false;
            }
            if (objDataPartner.Rows[0]["VIP"].ToString() == "True")
            {
                this.ckbVIP.Checked = true;
            }
            else
            {
                this.ckbVIP.Checked = false;
            }
            if (objDataPartner.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
            lblImg1.Text = "<img width = \"263px\" height = \"123px\" src = \"/Images/Partner/" + objDataPartner.Rows[0]["Image"].ToString() + "\">";
        }
    }
    #endregion

    #region method btnOK_Click
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.txtOldPass.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mật khẩu hiện tại!";
            return;
        }
        if (this.txtNewPass.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mật khẩu mới!";
            return;
        }
        this.lblMsg.Text = this.objFunc.changePass(Session["ACCOUNT"].ToString(), this.txtOldPass.Text, this.txtNewPass.Text);
    } 
    #endregion
}