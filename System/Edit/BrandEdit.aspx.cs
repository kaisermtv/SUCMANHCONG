using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Edit_BrandEdit : System.Web.UI.Page
{
    protected Brand objBrand = new Brand();
    public int itemId;

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
            this.getBrand();
        }
    }

    #region method getBrand
    public void getBrand()
    {
        DataTable objData = this.objBrand.getBrandById(this.itemId);
        if (objData.Rows.Count > 0)
        {
            this.txtDescription.Text = objData.Rows[0]["Description"].ToString();
            this.txtName.Text = objData.Rows[0]["Name"].ToString();
            this.txtUrl.Text = objData.Rows[0]["Url"].ToString();

            if (objData.Rows[0]["VIP"].ToString() == "True")
            {
                this.CheckVip.Checked = true;
            }
            else
            {
                this.CheckVip.Checked = false;
            }

            lblImg1.Text = "<img width = \"125px\" height = \"100px\" src = \"/Images/" + objData.Rows[0]["Logo"].ToString() + "\">";

            this.txtImage.Text = objData.Rows[0]["Logo"].ToString();
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

        if (upImage1.PostedFile.FileName != "")
            if (!saveImage1())
            {
                return;
            }

        int ret = this.objBrand.setBrand(this.itemId,this.txtUrl.Text, this.txtDescription.Text, this.txtName.Text, this.CheckVip.Checked, this.txtImage.Text);
        if (ret > 0)
        {
            Response.Redirect("/System/ListBrand.aspx");
        }
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/System/ListBrand.aspx");
    }
    #endregion

    #region method saveImage1
    private bool saveImage1()
    {
        string strBaseLoactionImg = "";
        try
        {
            strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["NEWSIMAGE"].ToString());
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
                this.lblImg1.Text = "<img width = \"125px\" height = \"100px\"  src = \"/Images/" + sFileName + strEx + "\">";
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