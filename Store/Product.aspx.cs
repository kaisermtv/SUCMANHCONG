using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Product : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private TVSFunc objFunc = new TVSFunc();
    private Partner objPartner = new Partner();
    private Product objProduct = new Product();

    public string strHtml = "";
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
            this.objTable = this.objProduct.getDataByPartnerAllAccount(Session["ACCOUNT"].ToString());
            if (this.objTable.Rows.Count > 0)
            {
                for (int i = 0; i < this.objTable.Rows.Count; i++)
                {
                    strHtml += "<div class=\"row tvsRow\">";
                    strHtml += "<div class=\"col-md-1 TVSRowCenter\">" + (i + 1).ToString() + "</div>";
                    strHtml += "<div class=\"col-md-10 TVSRowLeft\">" + this.objTable.Rows[i]["Name"].ToString() + "</div>";
                    strHtml += "<div class=\"col-md-1 TVSRowRight\">&nbsp;<a href = \"ProductEdit.aspx?id=" + this.objTable.Rows[i]["Id"].ToString() + "\"><img src = \"/img/edit.png\" alt = \"Sửa\" title = \"Sửa thông tin\"></a>&nbsp;&nbsp;&nbsp;<a href = \"#\"><img src = \"/img/delete.png\" alt = \"Xoá\" title = \"Xoá thông tin\"></a></div>";
                    strHtml += "</div>";
                }
            }
        }
    }
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objDataPartner = this.objPartner.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
        if (objDataPartner.Rows.Count > 0)
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
}