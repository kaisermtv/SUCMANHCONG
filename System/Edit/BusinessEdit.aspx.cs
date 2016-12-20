using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Edit_BusinessEdit : System.Web.UI.Page
{
    #region declare objects
    protected DataBusiness objBusiness = new DataBusiness();
    private int itemId = 0;
    #endregion

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
        if (!Page.IsPostBack)
        {
            this.getBusiness();
        }
    }

    #region method getProductGroup
    public void getBusiness()
    {
        DataTable objData = this.objBusiness.getBusinessById(this.itemId);
        if (objData.Rows.Count > 0)
        {
            this.txtDescription.Text = objData.Rows[0]["Description"].ToString();
            this.txtName.Text = objData.Rows[0]["Name"].ToString();
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text.Trim() == "")
        {
            this.txtName.Focus();
            return;
        }

        int ret = this.objBusiness.setBusiness(this.itemId, this.txtDescription.Text, this.txtName.Text);
        if (ret > 0)
        {
            Response.Redirect("/System/ListBusiness.aspx");
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/System/ListBusiness.aspx");
    }
    #endregion
}