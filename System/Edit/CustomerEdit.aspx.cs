using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerEdit : System.Web.UI.Page
{
    #region declare objects
    private Customers objCustomers = new Customers();

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
            this.getCustomer();
        }
    }
    #endregion

    #region method setCustomer
    public void setCustomer()
    {
        try
        {
            this.lblMsg.Text = "";
            if (this.txtName.Text.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập tên thành viên";
                return;
            }
            if (this.txtIdCard.Text.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập số CMND của thành viên";
                return;
            }
            if (this.txtBirthday.Text.Trim() == "")
            {
                this.lblMsg.Text = "Bạn chưa nhập ngày sinh của thành viên";
                return;
            }
            if (upImage1.PostedFile.FileName != "")
                if (!saveImage1())
                {
                    return;
                }
            int ret = this.objCustomers.setCustomer(this.itemId, this.txtName.Text, this.txtAddress.Text, this.txtBirthday.Text, this.txtPhone.Text, this.txtEmail.Text, this.txtAccount.Text, this.txtIdCard.Text, this.txtAvatar.Text, this.ckbState.Checked);

            if(ret > 0)
            {
                Response.Redirect("~/System/Customer.aspx");
            }
            else
            {
                this.lblMsg.Text = "Có lỗi xảy ra. Xin thử lại";
            }
        }
        catch
        {

        }
    }
    #endregion

    #region method getCustomer
    public void getCustomer()
    {
        DataTable objData = this.objCustomers.getCustomerById(this.itemId);
        if(objData.Rows.Count > 0)
        {
            this.txtName.Text = objData.Rows[0]["Name"].ToString();
            this.txtAddress.Text = objData.Rows[0]["Address"].ToString();
            this.txtPhone.Text = objData.Rows[0]["Phone"].ToString();
            try {
                this.txtBirthday.Text = DateTime.Parse(objData.Rows[0]["Birthday"].ToString()).ToString("dd/MM/yyyy");
                }
            catch
            {
                this.txtBirthday.Text = "";
            }
            this.txtEmail.Text = objData.Rows[0]["Email"].ToString();
            this.txtAccount.Text = objData.Rows[0]["Account"].ToString();
            this.txtIdCard.Text = objData.Rows[0]["IdCard"].ToString();
            this.txtAvatar.Text = objData.Rows[0]["Avatar"].ToString();
            if (objData.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
            lblImg1.Text = "<img width = \"125px\" height = \"100px\" src = \"http://khachhang.sucmanhcong.com/Images/Customer/" + objData.Rows[0]["Avatar"].ToString() + "\">";

            this.txtAvatar.Text = objData.Rows[0]["Avatar"].ToString();
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.setCustomer();
        Response.Redirect("~/System/Customer.aspx");
    } 
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/Customer.aspx");
    } 
    #endregion

    #region method saveImage1
    private bool saveImage1()
    {
        string strBaseLoactionImg = "";
        try
        {
            strBaseLoactionImg = Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings["CUSTOMERS"].ToString());
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
                this.txtAvatar.Text = sFileName + strEx;
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