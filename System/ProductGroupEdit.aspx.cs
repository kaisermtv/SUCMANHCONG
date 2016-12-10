using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductGroupEdit : System.Web.UI.Page
{
    #region declare objects
    private DataProduct objProduct = new DataProduct();
    private int itemId = 0;
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
            this.itemId = 0;
        }
        if (!Page.IsPostBack)
        {
            this.getProductGroup();
        }
    }
    #endregion

    #region method getProductGroup
    public void getProductGroup()
    {
        DataTable objData = this.objProduct.getProductGroupById(this.itemId);
        if(objData.Rows.Count > 0)
        {
            this.txtDescription.Text = objData.Rows[0]["Description"].ToString();
            this.txtName.Text = objData.Rows[0]["Name"].ToString();
            if (objData.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
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

        int ret = this.objProduct.setProductGroup(this.itemId, this.txtDescription.Text, this.txtName.Text, this.ckbState.Checked);
        if(ret > 0)
        {
            Response.Redirect("ProductGroup.aspx");
        }
    } 
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductGroup.aspx");
    } 
    #endregion
}