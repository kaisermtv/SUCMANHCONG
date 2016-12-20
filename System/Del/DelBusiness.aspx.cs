using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Del_DelBusiness : System.Web.UI.Page
{
    #region declare objects
    protected DataBusiness objBusiness = new DataBusiness();
    private int itemId = 0;
    public string name = "";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            Response.Redirect("/System/ListBusiness.aspx");
        }
        if (!Page.IsPostBack)
        {
            DataTable objData = this.objBusiness.getBusinessById(this.itemId);
            if (objData.Rows.Count > 0)
            {
                this.name = objData.Rows[0]["Name"].ToString();
            }
        }
    }


    #region method btnSave_Click
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //this.getid();

        objBusiness.DelBusiness(this.itemId);

        Response.Redirect("/System/ListBusiness.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/System/ListBusiness.aspx");
    }
    #endregion
}