using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PartnerEdit : System.Web.UI.Page
{
    #region declare objects
    private Partner objPartner = new Partner();
    private DataBusiness objBusiness = new DataBusiness();
    private Location objLocation = new Location();
    private int itemId = 0;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        txtContent.config.toolbar = new object[]
        {
            new object[] { "Source", "-", "Save", "NewPage", "Preview", "-", "Templates" },
            new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print", "SpellChecker", "Scayt" },
            new object[] { "Undo", "Redo", "-", "Find", "Replace", "-", "SelectAll", "RemoveFormat" },
            new object[] { "Form", "Checkbox", "Radio", "TextField", "Textarea", "Select", "Button", "ImageButton", "HiddenField" },
            "/",
            new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
            new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent", "Blockquote", "CreateDiv" },
            new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
            new object[] { "BidiLtr", "BidiRtl" },
            new object[] { "Link", "Unlink", "Anchor" },
            new object[] { "Image", "Flash", "Table", "HorizontalRule", "Smiley", "SpecialChar", "PageBreak", "Iframe" },
            "/",
            new object[] { "Styles", "Format", "Font", "FontSize" },
            new object[] { "TextColor", "BGColor" },
            new object[] { "Maximize", "ShowBlocks", "-", "About" }
        };

        //CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        //_FileBrowser.BasePath = "/ckfinder";
        //_FileBrowser.SetupCKEditor(this.txtContent);

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
            this.getBusiness();
            this.getLocation();
            this.getPartner();

           
        }
    }
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objData = this.objPartner.getPartnerById(this.itemId);
        if (objData.Rows.Count > 0)
        {
            this.txtName.Text = objData.Rows[0]["Name"].ToString();
            this.txtAddress.Text = objData.Rows[0]["Address"].ToString();
            this.txtManager.Text = objData.Rows[0]["Manager"].ToString();
            this.txtPhone.Text = objData.Rows[0]["Phone"].ToString();
            this.txtTaxCode.Text = objData.Rows[0]["TaxCode"].ToString();
            this.ddlBusiness.SelectedValue = objData.Rows[0]["Business"].ToString();
            this.txtContent.Text = objData.Rows[0]["Content"].ToString();
            this.txtImage.Text = objData.Rows[0]["Image"].ToString();
            string x = objData.Rows[0]["DayCreate"].ToString();     //DateTime.ParseExact(objData.Rows[0]["DayCreate"].ToString(), "dd-MM-yyyy HH:mm:ss",CultureInfo.InvariantCulture);
            DateTime date = Convert.ToDateTime(objData.Rows[0]["DayCreate"].ToString());
            this.txtDateTime.Value = date.ToString("dd-M-yyyy HH:mm:ss");
             try
            {  
                this.ddlLocation.SelectedIndex = Int32.Parse(objData.Rows[0]["LocationId"].ToString()) -1;
            }
            catch
            { }
            if (objData.Rows[0]["BestSale"].ToString() == "True")
            {
                this.ckbBestSale.Checked = true;
            }
            else
            {
                this.ckbBestSale.Checked = false;
            }
            if (objData.Rows[0]["VIP"].ToString() == "True")
            {
                this.ckbVIP.Checked = true;
            }
            else
            {
                this.ckbVIP.Checked = false;
            }
            if (objData.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
            this.txtDiscount.Text = objData.Rows[0]["Discount"].ToString();
            lblImg1.Text = "<img width = \"125px\" height = \"100px\" src = \"/Images/Partner/" + objData.Rows[0]["Image"].ToString() + "\">";

            this.txtImage.Text = objData.Rows[0]["Image"].ToString();
        }
    }
    #endregion

    #region method getLocation
    public void getLocation()
    {
        DataTable objData = this.objLocation.getIdAndUpperName();
        this.ddlLocation.DataSource = objData;
        this.ddlLocation.DataTextField = "Name";
        this.ddlLocation.DataValueField = "Id";
     
        this.ddlLocation.DataBind();
       
    }
    #endregion

    #region method setPartner
    public void setPartner()
    {
        try
        {
            if (upImage1.PostedFile.FileName != "")
                if (!saveImage1())
                {
                    return;
                }
            int Business = 0;
            try{
                Business = Int32.Parse(this.ddlBusiness.SelectedValue.ToString());
            } catch{}
            int locationId = 0;
             try{
                 locationId = Int32.Parse(this.ddlLocation.SelectedValue.ToString());
            } catch{}

            float Discount = 0;
            try{
                Discount = Int32.Parse(this.txtDiscount.Text);
            } catch{}
            string dayCreate = "";
            try
            {
                DateTime date = DateTime.ParseExact(this.txtDateTime.Value,"dd-M-yyyy HH:mm:ss",null,DateTimeStyles.None);
                dayCreate = date.ToString();
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgDate2", "alert('" + date + "!');",true);
            }
            catch {
                dayCreate = "";
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "msgDate", "alert('Ngày hợp đồng có hiệu lực : dd-MM-yyyy HH:mm:ss , Hãy cẩn thận !');",true);
            }

            int ret = this.objPartner.UpdateOrInsertPartner(this.itemId, this.txtName.Text, this.txtAddress.Text, this.txtPhone.Text, this.txtManager.Text, this.txtTaxCode.Text, Business, this.ckbBestSale.Checked, this.ckbVIP.Checked, this.ckbState.Checked, Discount, this.txtContent.Text, this.txtImage.Text, locationId, dayCreate);
            if (ret > 0)
            {
                Response.Redirect("/System/Partner.aspx");
            }
        }
        catch
        {

        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.setPartner();
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/Partner.aspx");
    }
    #endregion

    #region method saveImage1
    private bool saveImage1()
    {
        string strBaseLoactionImg = "";
        try
        {
            strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["PARTNER"].ToString());
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
                this.lblImg1.Text = "<img width = \"125px\" height = \"100px\"  src = \"../Images/Partner/" + sFileName + strEx + "\">";
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

    #region method getBusiness
    public void getBusiness()
    {
        DataTable objData = this.objBusiness.getBusiness();

        this.ddlBusiness.DataSource = objData;
        this.ddlBusiness.DataTextField = "Name";
        this.ddlBusiness.DataValueField = "Id";
        this.ddlBusiness.DataBind();
    }
    #endregion
}