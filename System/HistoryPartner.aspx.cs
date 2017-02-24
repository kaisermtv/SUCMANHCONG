using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_HistoryPartner : System.Web.UI.Page
{

    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    private Partner objPartner = new Partner();
    public DataTable objTable = new DataTable();

    public string FromDate = "";
    public string ToDate = "";
    public string Message = "";

    private int itemId = 0;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            Response.Redirect("/System/Partner");
            return;
        }

        if (Page.IsPostBack)
        {
            string rurl = "?id=" + this.itemId;
            string str = this.txtFromDate.Value;

            if (str != "")
            {
                rurl += "&FromDate=" + str;
            }

            str = this.txtToDate.Value;

            if (str != "")
            {
                rurl += "&ToDate=" + str;
            }


            Response.Redirect("/System/HistoryPartner" + rurl);
        }
        else
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

            DataTable partnerinfo = this.objPartner.getPartnerById(this.itemId);

            if (partnerinfo.Rows.Count == 0 )
            {
                Response.Redirect("/System/Partner");
                return;
            }


            this.objTable = this.objPartner.getHistoryBill(partnerinfo.Rows[0]["Account"].ToString(), this.FromDate, this.ToDate);
            //this.Message = this.objPartner.ErrorMessage;
        }
    }
    #endregion
}