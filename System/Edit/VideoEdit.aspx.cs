using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VideoEdit : System.Web.UI.Page
{
    #region declare objects
    private DataVideo objVideo = new DataVideo();
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
            this.getVideo();
        }
    }
    #endregion

    #region method getVideo
    public void getVideo()
    {
        DataTable objData = this.objVideo.getVideoInfoById(this.itemId);
        if(objData.Rows.Count > 0)
        {
            this.txtUrl.Text = objData.Rows[0]["Url"].ToString();
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
        int ret = this.objVideo.setVideo(this.itemId, this.txtUrl.Text, this.txtName.Text, this.ckbState.Checked);
        if(ret > 0)
        {
            Response.Redirect("~/System/Video.aspx");
        }
    } 
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/Video.aspx");
    } 
    #endregion
}