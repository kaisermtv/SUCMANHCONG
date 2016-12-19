using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StoreBestSale : System.Web.UI.Page
{
    #region declare 
    public Partner objStoreBestSale = new Partner();
    public DataTable objTableStoreBestSale = new DataTable();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        this.objTableStoreBestSale = objStoreBestSale.getTopPartnerBestSale(24);    // get 24 object    
    }
}