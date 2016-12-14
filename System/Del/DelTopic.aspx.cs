using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Del_DelTopic : System.Web.UI.Page
{
    private DataTopic objTopic = new DataTopic();
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
        this.objTopic.removeTopicImage(itemId);

        Response.Redirect("~/System/Topic.aspx");
    }
    #endregion
            
    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/Topic.aspx");
    }
    #endregion
}