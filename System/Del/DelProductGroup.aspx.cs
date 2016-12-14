using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Del_DelSlide : System.Web.UI.Page
{
    private DataProduct objProduct = new DataProduct();
    int itemId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }

    }

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.objProduct.removeGroupProduct(itemId);

        Response.Redirect("~/System/ProductGroup.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/ProductGroup.aspx");
    }
    #endregion
}