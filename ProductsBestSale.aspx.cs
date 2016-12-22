using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductsBestSale : System.Web.UI.Page
{
    #region declare objects
    public DataTable objTableProductBestSale = new DataTable();
    public DataProduct objProduct = new DataProduct();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.objTableProductBestSale = objProduct.getProductBestSaleWithNum(24);
        }
    }

  
}