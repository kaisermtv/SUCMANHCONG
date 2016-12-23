using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search_Default : System.Web.UI.Page
{
    #region declare objects
    public DataTable objTableProductVIP = new DataTable();
    public DataTable objTableStoreVip = new DataTable();
    private Partner objPartner = new Partner();
    private DataProduct objProduct = new DataProduct();
    public string strFind = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           strFind =  Request["search"].ToString();
        }
        catch
        {
            strFind = "0";
        }
        
        if (!Page.IsPostBack)
        {
            this.objTableStoreVip = objPartner.getAllPartnerSearchByName(strFind);
            this.objTableProductVIP = objProduct.getAllProductSearchByName(strFind);
        }
    } 
    #endregion

 
}