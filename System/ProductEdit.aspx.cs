using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductEdit : System.Web.UI.Page
{
    #region declare objects
    private DataProduct objProduct = new DataProduct();
    private Partner objPartner = new Partner();

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
            this.getProduct();
        }
    }
    #endregion

    #region method getProduct
    public void getProduct()
    {
        DataTable objData = this.objProduct.getProductById(this.itemId);
        if(objData.Rows.Count > 0)
        {
            this.txtName.Text = objData.Rows[0]["Name"].ToString();
            this.txtPrice.Text = objData.Rows[0]["Price"].ToString();
            this.txtDiscount.Text = objData.Rows[0]["Discount"].ToString();
            this.txtContent.Text = objData.Rows[0]["Content"].ToString();
            this.txtImage.Text = objData.Rows[0]["Image"].ToString();
            this.ddlProductGroup.SelectedValue = objData.Rows[0]["GroupId"].ToString();
            this.ddlPartner.SelectedValue = objData.Rows[0]["PartnerId"].ToString();
            if (objData.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
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
            lblImg1.Text = "<img width = \"125px\" height = \"100px\" src = \"/Images/Products/" + objData.Rows[0]["Image"].ToString() + "\">";
        }
    }
    #endregion

    #region method getProductGroup
    public void getProductGroup()
    {
        DataTable objData = this.objProduct.getProductGroupIdUpperName();
        if(objData.Rows.Count > 0)
        {
            this.ddlProductGroup.DataSource = objData;
            this.ddlProductGroup.DataTextField = "Name";
            this.ddlProductGroup.DataValueField = "Id";
            this.ddlProductGroup.DataBind();
        }
    }
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objData = this.objPartner.getPartnerIdUpperName();
        this.ddlPartner.DataSource = objData;
        this.ddlPartner.DataTextField = "Name";
        this.ddlPartner.DataValueField = "Id";
        this.ddlPartner.DataBind();
    }
    #endregion

    #region method setProduct
    public void setProduct()
    {
        try
        {
            if (upImage1.PostedFile.FileName != "")
                if (!saveImage1())
                {
                    return;
                }
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblProduct WHERE Id = @Id)";
            sqlQuery += "BEGIN INSERT INTO tblProduct(Name,Price,Discount,Content,Image,GroupId,BestSale,VIP,State,PartnerId) VALUES(@Name,@Price,@Discount,@Content,@Image,@GroupId,@BestSale,@VIP,@State,@PartnerId) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblProduct SET Name = @Name, Price = @Price, Discount = @Discount, Content = @Content, Image = @Image, BestSale = @BestSale, VIP = @VIP, State = @State, GroupId = @GroupId, PartnerId = @PartnerId WHERE Id = @Id END";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = this.itemId;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = this.txtName.Text;
            Cmd.Parameters.Add("Price", SqlDbType.Float).Value = this.txtPrice.Text;
            Cmd.Parameters.Add("Discount", SqlDbType.Float).Value = this.txtDiscount.Text;
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = this.txtContent.Text;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = this.txtImage.Text;
            Cmd.Parameters.Add("BestSale", SqlDbType.Bit).Value = this.ckbBestSale.Checked;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = this.ckbVIP.Checked;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = this.ckbState.Checked;
            Cmd.Parameters.Add("GroupId", SqlDbType.Int).Value = this.ddlProductGroup.SelectedValue.ToString();
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = this.ddlPartner.SelectedValue.ToString();
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            Response.Redirect("Product.aspx");
        }
        catch
        {

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