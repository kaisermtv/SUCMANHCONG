using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_ProductEdit : System.Web.UI.Page
{
    #region declare objects
    private DataProduct objProduct = new DataProduct();
    private Partner objPartner = new Partner();
    private Brand objBrand = new Brand();

    private int itemId = 0;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("/");
        }
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

        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "../ckfinder";
        _FileBrowser.SetupCKEditor(this.txtContent);
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
            this.getPartner();
            this.getBrand();
            this.getProduct();
        }
    }
    #endregion

    #region method getProduct
    public void getProduct()
    {
        DataTable objDataProduct = this.objProduct.getProductById(this.itemId);
        if(objDataProduct.Rows.Count > 0 )
        {
            this.txtName.Text = objDataProduct.Rows[0]["Name"].ToString();
            this.txtPrice.Text = objDataProduct.Rows[0]["Price"].ToString();
            this.txtDiscount.Text = objDataProduct.Rows[0]["Discount"].ToString();
            this.txtContent.Text = objDataProduct.Rows[0]["Content"].ToString();
            this.txtImage.Text = objDataProduct.Rows[0]["Image"].ToString();
            this.ddlProductGroup.SelectedValue = objDataProduct.Rows[0]["GroupId"].ToString();
            this.ddlPartner.SelectedValue = objDataProduct.Rows[0]["PartnerId"].ToString();
            this.ddlBrand.SelectedValue = objDataProduct.Rows[0]["BrandId"].ToString();
            if (objDataProduct.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
            if (objDataProduct.Rows[0]["BestSale"].ToString() == "True")
            {
                this.ckbBestSale.Checked = true;
            }
            else
            {
                this.ckbBestSale.Checked = false;
            }
            if (objDataProduct.Rows[0]["VIP"].ToString() == "True")
            {
                this.ckbVIP.Checked = true;
            }
            else
            {
                this.ckbVIP.Checked = false;
            }
            lblImg1.Text = "<img width = \"125px\" height = \"100px\" src = \"/Images/Products/" + objDataProduct.Rows[0]["Image"].ToString() + "\">";
        }
    }
    #endregion

    #region method getProductGroup
    public void getProductGroup()
    {
        DataTable objDataProductGroup = this.objProduct.getProductGroupIdUpperName();
        if(objDataProductGroup.Rows.Count > 0)
        {
            this.ddlProductGroup.DataSource = objDataProductGroup;
            this.ddlProductGroup.DataTextField = "Name";
            this.ddlProductGroup.DataValueField = "Id";
            this.ddlProductGroup.DataBind();
        }
    }
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objDataPartner = this.objPartner.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
        if(objDataPartner.Rows.Count > 0)
        {
            this.ddlPartner.DataSource = objDataPartner;
            this.ddlPartner.DataTextField = "Name";
            this.ddlPartner.DataValueField = "Id";
            this.ddlPartner.DataBind();
        }
    }
    #endregion

    #region method getBrand
    public void getBrand()
    {
        DataTable objDataBrand = this.objBrand.getBrandIdName();
        if(objDataBrand.Rows.Count > 0)
        {
            this.ddlBrand.DataSource = objDataBrand;
            this.ddlBrand.DataTextField = "Name";
            this.ddlBrand.DataValueField = "Id";
            this.ddlBrand.DataBind();
        }

    }
    #endregion

    #region method setProduct
    public void setProduct()
    {
        if (upImage1.PostedFile.FileName != "")
            if (!saveImage1())
            {
                return;
            }

        float Price = 0;
        try{
            Price = float.Parse(this.txtPrice.Text);
        }catch{}

        float Discount = 0;
        try{
            Discount = float.Parse(this.txtDiscount.Text);
        }catch{}

        int GroupId = 0;
        try{
            GroupId = Int32.Parse(this.ddlProductGroup.SelectedValue.ToString());
        }catch{}

        int BrandId = 0;
        try{
            BrandId = Int32.Parse(this.ddlBrand.SelectedValue.ToString());
        }catch{}



        int ret = this.objProduct.UpdateOrInsertProductByAccount(Session["ACCOUNT"].ToString(), this.itemId, this.txtName.Text, Price, Discount, this.txtContent.Text, this.txtImage.Text, this.ckbBestSale.Checked, this.ckbVIP.Checked, GroupId, BrandId);
        if(ret > 0)
        {
            Response.Redirect("Product.aspx");
        } else
        {
            this.outtext.InnerText = "Có lỗi xảy ra. Xin thử lại!";
        }

    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.setProduct();
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Product.aspx");
    }
    #endregion

    #region method saveImage1
    private bool saveImage1()
    {
        string strBaseLoactionImg = "";
        try
        {
            strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["PRODUCTIMAGE"].ToString());
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
                this.lblImg1.Text = "<img width = \"125px\" height = \"100px\"  src = \"../Images/Products/" + sFileName + strEx + "\">";
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