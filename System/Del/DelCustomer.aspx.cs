using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_AccountDel : System.Web.UI.Page
{

    private Customers objCustomer = new Customers();
    private int itemId = 0;
    public string name = "";

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
            name += objCustomer.getCustomerById(this.itemId).Rows[0]["Name"].ToString();
        }
        catch
        {
            return;
        }
        if (this.itemId == 0)
        {
            Response.Redirect("~/System/Customer.aspx");
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnOk_Click(object sender, EventArgs e)
    {
      
        objCustomer.removeCustomer(this.itemId);

        Response.Redirect("~/System/Customer.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/Customer.aspx");
    }
    #endregion
}