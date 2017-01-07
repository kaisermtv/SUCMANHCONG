using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Summary : System.Web.UI.Page
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
            this.lblDSInDay.Text = String.Format("{0:0,0}", this.objPartner.getPartnerBillInDayByAccount(Session["ACCOUNT"].ToString()));
            this.lblDSInWeek.Text = String.Format("{0:0,0}", this.objPartner.getPartnerBillInWeekByAccount(Session["ACCOUNT"].ToString()));
            this.lblDSInMonth.Text = String.Format("{0:0,0}", this.objPartner.getPartnerBillInMonthByAccount(Session["ACCOUNT"].ToString()));
            this.lblTotalDiscount.Text = String.Format("{0:0,0}", this.objPartner.getPartnerBillTotalDiscountByAccount(Session["ACCOUNT"].ToString()));
            this.lblTotalDiscountCard.Text = String.Format("{0:0,0}", this.objPartner.getPartnerBillTotalDiscountCardByAccount(Session["ACCOUNT"].ToString()));
            this.lblTotalDiscountAdv.Text = String.Format("{0:0,0}", this.objPartner.getPartnerBillTotalDiscountAdvByAccount(Session["ACCOUNT"].ToString()));
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

    #region date
    public DateTime MondayOfWeek(DateTime date)
    {
        var dayOfWeek = date.DayOfWeek;

        /*
        if (dayOfWeek == DayOfWeek.Sunday)
        {
            //xét chủ nhật là đầu tuần thì thứ 2 là ngày kế tiếp nên sẽ tăng 1 ngày  
            //return date.AddDays(1);  

            // nếu xét chủ nhật là ngày cuối tuần  
            return date.AddDays(-6);
        }
         /* */
        // nếu không phải thứ 2 thì lùi ngày lại cho đến thứ 2  
        int offset = dayOfWeek - DayOfWeek.Monday;
        return date.AddDays(-offset);
    }

    public DateTime SundayOfWeek(DateTime date)
    {
        return this.MondayOfWeek(date).AddDays(6);
    }  

    #endregion
}