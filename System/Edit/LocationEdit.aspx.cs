using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Edit_LocationEdit : System.Web.UI.Page
{

    #region  declare objects
    private Location objLocation = new Location();

    private int itemId = 0;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch{}

        if (!Page.IsPostBack)
        {
            DataTable objData = this.objLocation.getLocationById(this.itemId);
            if (objData.Rows.Count > 0)
            {
                this.txtName.Value = objData.Rows[0]["Name"].ToString();
                this.txtBkColor.Value = objData.Rows[0]["color"].ToString();
            }
            else
            {
                Response.Redirect("/System/ListLocation.aspx");
            }

        }
    }

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Name = this.txtName.Value;
        int Color = 0;
        try
        {
            Color = Int32.Parse(this.txtBkColor.Value);
        }
        catch { }


        int ret = objLocation.AddLocation(Name, Color);

        if (ret > 0)
        {
            Response.Redirect("/System/ListLocation.aspx");
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/System/ListLocation.aspx");
    }
    #endregion
}