using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store : MasterPage
{
    #region declare objects
    private Partner objPartner = new Partner();
    private TVSFunc objFunc = new TVSFunc();

    private DataTable objTableProductGroup = new DataTable();

    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    public string strHeader = "", currPartnerId = "", strFullName = "";
    public string[] ProductGroup = new string[7] { "", "", "", "", "", "", "" };
    public string strStoreName = "";
    public string strName = "", strAddress = "", strPhone = "", strManager = "", strEmail = "", strTaxcode = "", strAccount = "", strBestSale = "", strVIP = "", strMsg = "", strHtml = "";
    public bool ngoisao = true;
    #endregion

    #region method Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null || Session["ACCOUNT"].ToString() == "")
        {
            Response.Redirect("/");
        }
        Session["ACCOUNT"] = Session["ACCOUNT"];
        

        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    } 
    #endregion

    #region method master_Page_PreLoad
    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    } 
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.getPartner();
        this.strFullName = "Xin chào " + Session["ACCOUNT"].ToString() + " &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href = \"../Logout.aspx\">Thoát</a>";
    } 
    #endregion

    #region method getProductGroup
    public DataTable getProductGroup()
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT 0 AS TT, * FROM tblProductGroup";
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ds.Tables[0].Rows[i]["TT"] = (i + 1);
        }
        return ds.Tables[0];
    }
    #endregion

    #region method Unnamed_LoggingOut
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    } 
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataRowCollection objTable = this.objPartner.getPartnerInforByAccount(Session["ACCOUNT"].ToString()).Rows;
        if(objTable.Count > 0 )
        {
            this.strStoreName = objTable[0]["Name"].ToString();
            this.strName = objTable[0]["Name"].ToString();
            this.strAddress = objTable[0]["Address"].ToString();
            this.strManager = objTable[0]["Manager"].ToString();
            this.strPhone = objTable[0]["Phone"].ToString();
            this.strEmail = objTable[0]["Email"].ToString();
            this.strTaxcode = objTable[0]["TaxCode"].ToString();
            this.strAccount = objTable[0]["Account"].ToString();
            
            double min = 0,max =0;
            try
            {
                min = (double)objTable[0]["MinSales"];
                max = (double)objTable[0]["MaxSales"];
            }
            catch { }
            // Lấy số tiền được thanh toán bằng thẻ trừ đi tổng chi phí quảng cáo
            double a = this.objPartner.getSalesCardByPartnerAccout(Session["ACCOUNT"].ToString()) - this.objPartner.getPartnerBillTotalDiscountAdvByAccount(Session["ACCOUNT"].ToString());
            if (a < min || a > max) { this.ngoisao = false; }
            
            if (objTable[0]["BestSale"].ToString() == "True")
            {
                this.strBestSale = "X";
            }
            else
            {
                this.strBestSale = "";
            }
            if (objTable[0]["VIP"].ToString() == "True")
            {
                this.strVIP = "X";
            }
            else
            {
                this.strVIP = "";
            }
            lblImg1.Text = "<img width = \"100%\" height = \"120px\" src = \"/Images/Partner/" + objTable[0]["Image"].ToString() + "\">";
        
        }

    }
    #endregion
}