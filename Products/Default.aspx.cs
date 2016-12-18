using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products_Default : System.Web.UI.Page
{
    #region declare objects
    public DataTable objTableProductVIP = new DataTable();
    public DataProduct objProduct = new DataProduct();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int itemId = int.Parse(Request.QueryString["filter"]);
            this.objTableProductVIP = objProduct.getFilterTopProductVIP(itemId);
        }
        catch
        {
            this.objTableProductVIP = objProduct.getTopProductVIP();
        }
        if (!Page.IsPostBack)
        {
           
        }
    } 
    #endregion

   
}