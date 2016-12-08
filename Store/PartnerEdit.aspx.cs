using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_PartnerEdit : System.Web.UI.Page
{    
    #region declare objects
    private Partner objPartner = new Partner();
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
        if (!Page.IsPostBack)
        {
            this.getBusiness();
            this.getPartner();
        }
    }
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objDataPartner = this.objPartner.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
        if (objDataPartner.Rows.Count > 0)
        {
            this.txtName.Text = objDataPartner.Rows[0]["Name"].ToString();
            this.txtAddress.Text = objDataPartner.Rows[0]["Address"].ToString();
            this.txtManager.Text = objDataPartner.Rows[0]["Manager"].ToString();
            this.txtPhone.Text = objDataPartner.Rows[0]["Phone"].ToString();
            this.txtTaxCode.Text = objDataPartner.Rows[0]["TaxCode"].ToString();
            this.ddlBusiness.SelectedValue = objDataPartner.Rows[0]["Business"].ToString();
            this.txtContent.Text = objDataPartner.Rows[0]["Content"].ToString();
            this.txtImage.Text = objDataPartner.Rows[0]["Image"].ToString();
            this.txtBankAccount.Text = objDataPartner.Rows[0]["BankAccount"].ToString();
            this.txtBankAccountName.Text = objDataPartner.Rows[0]["BankAccountName"].ToString();
            if (objDataPartner.Rows[0]["BestSale"].ToString() == "True")
            {
                this.ckbBestSale.Checked = true;
            }
            else
            {
                this.ckbBestSale.Checked = false;
            }
            if (objDataPartner.Rows[0]["VIP"].ToString() == "True")
            {
                this.ckbVIP.Checked = true;
            }
            else
            {
                this.ckbVIP.Checked = false;
            }
            if (objDataPartner.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
            lblImg1.Text = "<img width = \"125px\" height = \"100px\" src = \"/Images/Partner/" + objDataPartner.Rows[0]["Image"].ToString() + "\">";
        }
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
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            string sqlQuery = "UPDATE tblPartner SET Name = @Name, Address = @Address, Phone = @Phone, Manager = @Manager, Business = @Business, TaxCode = @TaxCode, Content = @Content, Image = @Image, State = @State, BestSale = @BestSale, VIP = @VIP, BankAccount = @BankAccount, BankAccountName = @BankAccountName WHERE Account = @Account";
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = Session["ACCOUNT"].ToString();
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = this.txtName.Text;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = this.txtAddress.Text;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = this.txtPhone.Text;
            Cmd.Parameters.Add("Manager", SqlDbType.NVarChar).Value = this.txtManager.Text;
            Cmd.Parameters.Add("TaxCode", SqlDbType.NVarChar).Value = this.txtTaxCode.Text;
            Cmd.Parameters.Add("Business", SqlDbType.Int).Value = this.ddlBusiness.SelectedValue.ToString();
            Cmd.Parameters.Add("Content", SqlDbType.NText).Value = this.txtContent.Text;
            Cmd.Parameters.Add("Image", SqlDbType.NVarChar).Value = this.txtImage.Text;
            Cmd.Parameters.Add("BestSale", SqlDbType.Bit).Value = this.ckbBestSale.Checked;
            Cmd.Parameters.Add("VIP", SqlDbType.Bit).Value = this.ckbVIP.Checked;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = this.ckbState.Checked;
            Cmd.Parameters.Add("BankAccount", SqlDbType.NVarChar).Value = this.txtBankAccount.Text;
            Cmd.Parameters.Add("BankAccountName", SqlDbType.NVarChar).Value = this.txtBankAccountName.Text;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            Response.Redirect("default.aspx");
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
        Response.Redirect("default.aspx");
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
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT Id, UPPER(Name) AS Name FROM tblBusiness";
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        this.ddlBusiness.DataSource = ds.Tables[0];
        this.ddlBusiness.DataTextField = "Name";
        this.ddlBusiness.DataValueField = "Id";
        this.ddlBusiness.DataBind();
        sqlCon.Close();
        sqlCon.Dispose();
    }
    #endregion
}