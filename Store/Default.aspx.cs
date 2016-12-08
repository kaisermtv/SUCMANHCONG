using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Default : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    private Partner objPartner = new Partner();
    public int SoSanPham = 0, SoSanPhamVIP = 0, SoSanPhamBanChay = 0, SoGiaoDich = 0;
    public double TongDoanhSo = 0;
    public string strName = "", strAddress = "", strPhone = "", strManager = "", strEmail = "", strTaxcode = "", strAccount = "", strBestSale = "", strVIP = "", strBankAccount = "", strBankAccountName = "";
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
        if(objDataPartner.Rows.Count > 0)
        {
            this.strName = objDataPartner.Rows[0]["Name"].ToString();
            Session["STORENAME"] = this.strName.ToUpper();
            this.strAddress = objDataPartner.Rows[0]["Address"].ToString();
            this.strManager = objDataPartner.Rows[0]["Manager"].ToString();
            this.strPhone = objDataPartner.Rows[0]["Phone"].ToString();
            this.strEmail = objDataPartner.Rows[0]["Email"].ToString();
            this.strTaxcode = objDataPartner.Rows[0]["TaxCode"].ToString();
            this.strAccount = objDataPartner.Rows[0]["Account"].ToString();
            this.strBankAccount = objDataPartner.Rows[0]["BankAccount"].ToString();
            this.strBankAccountName = objDataPartner.Rows[0]["BankAccountName"].ToString();
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
}