using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Brands : System.Web.UI.Page
{
    #region declare 
    public DataTable objTableBrand = new DataTable();
    private Brand objBrand =  new Brand();

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.objTableBrand = objBrand.getBrand();
    }
 
}