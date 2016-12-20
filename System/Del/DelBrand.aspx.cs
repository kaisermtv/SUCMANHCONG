using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Del_DelBrand : System.Web.UI.Page
{
    protected Brand objBrand = new Brand();
    private int itemId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            Response.Redirect("/System/ListBrand.aspx");
        }
    }


    #region method btnSave_Click
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //this.getid();

        objBrand.DelBrand(this.itemId);

        Response.Redirect("/System/ListBrand.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/System/ListBrand.aspx");
    }
    #endregion
}