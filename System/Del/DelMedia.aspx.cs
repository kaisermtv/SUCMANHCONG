using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Del_DelMedia : System.Web.UI.Page
{
    private DataMedia objMedia = new DataMedia();
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
        this.objMedia.removeMediaImage(itemId);

        Response.Redirect("~/System/ListMedia.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/ListMedia.aspx");
    }
    #endregion
}