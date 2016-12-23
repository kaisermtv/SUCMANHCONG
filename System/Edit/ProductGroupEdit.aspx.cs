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

            lblImg1.Text = "<img width = \"50px\" height = \"50px\" src = \"/Images/" + objData.Rows[0]["icon"].ToString() + "\">";

            this.txtImage.Text = objData.Rows[0]["icon"].ToString();
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

        if (this.txtName.Text.Trim() == "")
        {
            this.txtName.Focus();
            return;
        }

        int ret = this.objProduct.setProductGroup(this.itemId, this.txtDescription.Text, this.txtName.Text, this.ckbState.Checked, this.txtImage.Text);
        if(ret > 0)
        {
            Response.Redirect("~/System/ProductGroup.aspx");
        }
    } 
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/ProductGroup.aspx");
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