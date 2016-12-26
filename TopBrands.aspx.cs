using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TopBrands : System.Web.UI.Page
{
    #region declare
    public DataTable objTableBrandVip = new DataTable();
    private Brand objBrand = new Brand();

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        this.objTableBrandVip = objBrand.getTopBrand();
    }
}