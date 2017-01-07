using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_History : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    private Partner objPartner = new Partner();
    public DataTable objTable = new DataTable();
    public string strName = "", strAddress = "", strPhone = "", strManager = "", strEmail = "", strTaxcode = "", strAccount = "", strBestSale = "", strVIP = "", strMsg = "", strHtml = "";

    public string FromDate = "";
    public string ToDate = "";
    public string Message = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            string rurl = "?";
            string str = this.txtFromDate.Value;

            if(str != "")
            {
                rurl += "FromDate=" + str;
            }

            str = this.txtToDate.Value;

            if (str != "")
            {
                if (rurl != "?") rurl += "&";
                rurl += "ToDate=" + str;
            }


            Response.Redirect("/Store/History" + rurl);
        } else
        {
            try
            {
                this.FromDate = Request["FromDate"].ToString();
                this.txtFromDate.Value = this.FromDate;
            }
            catch { }

            try
            {
                this.ToDate = Request["ToDate"].ToString();
                this.txtToDate.Value = this.ToDate;
            }
            catch { }



            this.getPartner();

            this.objTable = this.objPartner.getHistoryBillByPartnerAccount(Session["ACCOUNT"].ToString(), this.FromDate, this.ToDate);
            //this.Message = this.objPartner.ErrorMessage;
            if (this.objTable.Rows.Count > 0)
            {
                for (int i = 0; i < this.objTable.Rows.Count; i++)
                {
                    strHtml += "<div style =\"width:100%; margin-top:1px;\">";

                    strHtml += "<div style=\"width: 5%; float: left; border:solid 1px #f3f1f1; border-right:none; border-top:none;text-align:center;height:26px; line-height:26px; color:#000;\">";
                    strHtml += i.ToString();
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 18%; float: left; border:solid 1px #f3f1f1;border-top:none;text-align:center;height:26px; line-height:26px; color:#000;\">";
                    strHtml += this.objTable.Rows[i]["DayCreate"].ToString();
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 10%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;\">";
                    strHtml += string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["TotalMoney"].ToString()));
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 10%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;\">";
                    strHtml += string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["TotalMoneyDiscount"].ToString()));
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;\">";
                    strHtml += string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["Discount"].ToString()));
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;\">";
                    strHtml += string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["DiscountCard"].ToString()));
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;\">";
                    strHtml += string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["DiscountAdv"].ToString()));
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 10%; float: left; border:solid 1px #f3f1f1; border-left:none; text-align:right;border-top:none;padding-right:5px;height:26px; line-height:26px; color:#000; padding-right:5px;\">";
                    strHtml += string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["TotalPeyment"].ToString()));
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 27%; float: left; border:solid 1px #f3f1f1; border-left:none; text-align:justify;border-top:none;height:26px; line-height:26px; color:#000;\">";
                    strHtml += this.objTable.Rows[i]["Note"].ToString();
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 5%; float: left; border:solid 1px #f3f1f1; border-left:none; border-top:none;text-align:center;height:26px; line-height:26px; color:#000;\">";
                    strHtml += "<a href = \"ViewBill.aspx?id=" + this.objTable.Rows[i]["Id"].ToString() + "\"><img src = \"../img/Edit.png\" alt = \"Chi tiết\" title = \"Chi tiết hoá đơn\">";
                    strHtml += "</div>";

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

}