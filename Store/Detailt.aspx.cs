using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Detailt : System.Web.UI.Page
{
    #region declare objects
    private Partner objPartner = new Partner();
    private DataProduct objProduct = new DataProduct();

    public DataTable objTablePartner = new DataTable();
    public DataTable objTable = new DataTable();
    private int itemId = 0, itemProductId = 0;
   

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
            Response.Redirect("/");
            this.itemId = 0;
        }
        if (!Page.IsPostBack)
        {
            this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
            this.objTable = this.objProduct.getProductById(this.itemId);
        }
    }
    
    #endregion

}