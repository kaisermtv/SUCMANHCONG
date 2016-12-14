using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Abouts : System.Web.UI.Page
{
    #region declare objects
    private tblAbouts objAbouts = new tblAbouts();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtIntro.config.toolbar = new object[]
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
        _FileBrowser.SetupCKEditor(this.txtIntro);
        if (!Page.IsPostBack)
        {
            this.getAbouts();
        }
    }
    #endregion

    #region method getAbouts
    public void getAbouts()
    {
        DataTable objDataAbout = this.objAbouts.getAbouts();
        if(objDataAbout.Rows.Count > 0)
        {
            this.txtName.Text = objDataAbout.Rows[0]["Name"].ToString();
            this.txtAddress.Text = objDataAbout.Rows[0]["Address"].ToString();
            this.txtPhone.Text = objDataAbout.Rows[0]["Phone"].ToString();
            this.txtEmail.Text = objDataAbout.Rows[0]["Email"].ToString();
            this.txtIntro.Text = objDataAbout.Rows[0]["Intro"].ToString();
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int ret = this.objAbouts.setTopic(this.txtName.Text, this.txtAddress.Text, this.txtPhone.Text, this.txtEmail.Text, this.txtIntro.Text);
    } 
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/Topic.aspx");
    } 
    #endregion
}