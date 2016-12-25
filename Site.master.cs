﻿using System;
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
    public string[] ProductGroup = new string[7] { "", "", "", "", "", "", "" };
    public int[] ProductGroupId = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
    private DataTable objTableProductGroup = new DataTable();
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
        if (Session["ACCOUNT"] == null || Session["ACCOUNT"].ToString() == "")
        {
            strHeader = "&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"#\" id=\"searchlink1\" rel=\"subcontent1\">Đăng kí &nbsp;|&nbsp; </a><a href=\"../LogIn/login.aspx\">&nbsp;Đăng nhập</a>";
            currPartnerId = "#";
        }
        else
        {
            if (Session["ACCOUNT"].ToString().Substring(0, 3).ToUpper() == this.objFunc.getPartnerAccount().Trim().ToUpper())
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
            for (int i = 0; i < this.objTableProductGroup.Rows.Count && i<7; i++)
            {

                this.ProductGroup[i] = this.objTableProductGroup.Rows[i]["Name"].ToString();
                this.ProductGroupId[i] =int.Parse(this.objTableProductGroup.Rows[i]["Id"].ToString());
            }
        }
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


}