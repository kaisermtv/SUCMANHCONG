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

public partial class CustomerMaster : MasterPage
{
    #region declare objects
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    public string strHeader = "", currPartnerId = "", strFullName = "";
    private TVSFunc objFunc = new TVSFunc();
    public string[] ProductGroup = new string[7] { "", "", "", "", "", "", "" };
    private DataTable objTableProductGroup = new DataTable();
    public String tichluythang = "" , tongsodu = "";
    public Customers objCustomers = new Customers();
    public DataRow objCustomer;
    #endregion

    #region method Page_Init
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null || Session["ACCOUNT"].ToString() == "")
        {
            Response.Redirect("/");
        }
        DataTable objData = objCustomers.getCustomerByAccount(Session["ACCOUNT"].ToString());
        if (objData.Rows.Count > 0)
        {
            this.objCustomer = objData.Rows[0];
        }
        else
        {
            Response.Redirect("/");
        }


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
        this.tichluythang = String.Format("{0:0,0}",getCustomerTotalDiscountCard(Session["ACCOUNT"].ToString()));
        this.tongsodu =  String.Format("{0:0,0}",this.getCustomerTotalDiscountCard(Session["ACCOUNT"].ToString()) - objCustomers.getSalesCardByCustomerAccout(Session["ACCOUNT"].ToString()));



        //this.strFullName = "<B>Xin chào " + Session["ACCOUNT"].ToString() + " | <a href = \"../Logout.aspx\">Thoát</a></B>";
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

    #region method getCustomerTotalDiscountCard
    public double getCustomerTotalDiscountCard(string CustomerAccount)
    {
        double tmpValue = 0, tmpValue1 = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT ISNULL(SUM((TotalMoneyDiscount*DiscountCard)/100),0) AS Discount FROM tblPartnerBill WHERE CustomerAccount = @CustomerAccount";
            Cmd.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = double.Parse(Rd["Discount"].ToString());
            }
            Rd.Close();

            SqlCommand Cmd1 = sqlCon.CreateCommand();
            Cmd1.CommandText = "SELECT ISNULL(SUM(TotalMoney),0) AS TotalMoney FROM tblCustomersPaymentByCard WHERE CustomerAccount = @CustomerAccount";
            Cmd1.Parameters.Add("CustomerAccount", SqlDbType.NVarChar).Value = CustomerAccount;
            SqlDataReader Rd1 = Cmd1.ExecuteReader();
            while (Rd1.Read())
            {
                tmpValue1 = double.Parse(Rd1["TotalMoney"].ToString());
            }
            Rd1.Close();

            tmpValue = tmpValue - tmpValue1;

            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method Unnamed_LoggingOut
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
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