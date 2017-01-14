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

public partial class SiteMaster : MasterPage
{
    #region declare objects
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    public string strHeader = "", currPartnerId = "";
    private TVSFunc objFunc = new TVSFunc();
    public string[] ProductGroup = new string[8] { "", "", "", "", "", "", "","" };
    public int[] ProductGroupId = new int[8] { 0, 0, 0, 0, 0, 0, 0,0 };
    private DataTable objTableProductGroup = new DataTable();
    public Location objLocation = new Location();
    public string footer = "";
    private tblAbouts objAbout = new tblAbouts();
    public int Location = 0;
    private DataTable objTableAboutUs = new DataTable();
    public DataRowCollection objTableLocation;
    #endregion

    #region method Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
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
        this.objTableLocation = this.objLocation.getLocation().Rows;
        try
        {
            this.Location = int.Parse(Request["Location"].ToString());
        }
        catch { }


        DataTable objdata;
         if (Session["ACCOUNT"] == null || Session["ACCOUNT"].ToString() == "")
         {
             objdata = new DataTable();
         } else
         {
             objdata = objFunc.getAccount(Session["ACCOUNT"].ToString());
         }


         if (objdata.Rows.Count == 0)
        {
            strHeader = "&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"#\" id=\"searchlink1\" rel=\"subcontent1\">Đăng kí &nbsp;|&nbsp; </a><a href=\"/login.aspx\">&nbsp;Đăng nhập</a>";
            currPartnerId = "#";
        }
        else
        {
            if ((int)objdata.Rows[0]["Acct_Type"] == 0)
            {
                strHeader = "<i class=\"fa fa-user\">&nbsp;<a href=\"../Store/\">" + Session["ACCOUNT"].ToString() + "</a></i>";
                currPartnerId = "../Store/PartnerInfo.aspx?id=" + Session["ACCOUNT"].ToString();
            }
            else
            {
                strHeader = "<i class=\"fa fa-user\">&nbsp;<a href=\"../Customer/\">" + Session["ACCOUNT"].ToString() + "</a></i>";
                currPartnerId = "../Customer/CustomerInfo.aspx?id=" + Session["ACCOUNT"].ToString();
            }
        }
        this.objTableProductGroup = this.getProductGroup();
        if (this.objTableProductGroup.Rows.Count > 0)
        {
            for (int i = 0; i < this.objTableProductGroup.Rows.Count && i < 8; i++)
            {

                this.ProductGroup[i] = this.objTableProductGroup.Rows[i]["Name"].ToString();
                this.ProductGroupId[i] = int.Parse(this.objTableProductGroup.Rows[i]["Id"].ToString());
            }
        }
        // footer 
        this.objTableAboutUs=  this.objAbout.getAbouts();
        if (this.objTableAboutUs.Rows.Count > 0)
        {
            footer = " <h6 style='font-family: Arial; font-size: 15px; font-weight: bold; color: #4e4e57;'>";
            footer += objTableAboutUs.Rows[0]["Name"].ToString().ToUpper() + "</h6>";
            footer += " <p style='font-family: Arial; font-size: 13px; margin-top: -5px; color: #4e4e57;'>";
            footer += objTableAboutUs.Rows[0]["Address"].ToString();
            footer += " </p>"+
                    "<p style='font-family: Arial; font-size: 13px; margin-top: -5px; color: #4e4e57;'>";
            footer += "Điện thoại :" + objTableAboutUs.Rows[0]["Phone"].ToString() + "  Email  :" + objTableAboutUs.Rows[0]["Email"];
            footer += " </p>";
             
        }

    } 
    #endregion

    #region method getProductGroup
    public DataTable getProductGroup()
    {
        try {         SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = " SELECT 0 AS TT , * FROM tblProductGroup ";
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
        catch
        {
            return new DataTable();

        }
    }

    #endregion

    #region method Unnamed_LoggingOut
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    } 
    #endregion

}