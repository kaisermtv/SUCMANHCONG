using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Edit_LocationAdd : System.Web.UI.Page
{
    #region  declare objects
    private Location objLocation = new Location();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

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
        
        if(ret > 0)
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