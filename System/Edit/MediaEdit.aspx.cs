using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Media : System.Web.UI.Page
{
    #region declare objects
    private DataMedia objMediaImage = new DataMedia();
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
            this.getTopic();
        }
    }
    #endregion

    #region method getTopic
    public void getTopic()
    {
        DataTable objData = this.objMediaImage.getMediaImageById(this.itemId);
        if (objData.Rows.Count > 0)
        {
            this.Name.Text = objData.Rows[0]["Name"].ToString();
            this.txtUrl.Text = objData.Rows[0]["Url"].ToString();
            this.txtImage.Text = objData.Rows[0]["Image"].ToString();
            if (objData.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
            lblImg1.Text = "<img width = \"100%\" height = \"120px\" src = \"/Images/Media/" + objData.Rows[0]["Image"].ToString() + "\">";
            this.txtImage.Text = objData.Rows[0]["Image"].ToString();
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (upImage1.PostedFile.FileName != "")
            if (!saveImage1())
            {
                return;
            }

        int ret = this.objMediaImage.setMediaImage(this.itemId, this.Name.Text, this.txtUrl.Text, this.txtImage.Text, this.ckbState.Checked);
        if (ret > 0)
        {
            Response.Redirect("~/System/ListMedia.aspx");
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/ListMedia.aspx");
    }
    #endregion

    #region method saveImage1
    private bool saveImage1()
    {
        string strBaseLoactionImg = "";
        try
        {
            strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["MEDIAIMAGE"].ToString());
            if (upImage1.PostedFile.ContentLength > 5048576)
            {
                return false;
            }
            else
            {
                string sFileName = "A" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second + DateTime.Now.Millisecond.ToString();
                string strEx = System.IO.Path.GetFileName(upImage1.PostedFile.FileName);
                strEx = strEx.Substring(strEx.LastIndexOf("."), strEx.Length - strEx.LastIndexOf("."));
                strBaseLoactionImg += sFileName + strEx;
                strBaseLoactionImg = strBaseLoactionImg.Replace("/", "\\");
                upImage1.PostedFile.SaveAs(strBaseLoactionImg);
                this.txtImage.Text = sFileName + strEx;
                this.lblImg1.Text = "<img width = \"100%\" height = \"120px\" src = \"../Images/Media/" + sFileName + strEx + "\">";
                return true;
            }
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
        }
        return false;
    }
    #endregion
}