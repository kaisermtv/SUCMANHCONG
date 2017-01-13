using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemConfig : System.Web.UI.Page
{
    #region declare objects
    private DataSystemCongif objSystemCongif = new DataSystemCongif();

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
        this.lblMsg.Text = "";
        /*
        if (this.txtPartnerAccount.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ký hiệu thẻ đối tác";
            return;
        }
        if (this.txtCustomerAccount.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ký hiệu thẻ khách hàng hạng đồng";
            return;
        }
        if (this.txtCustomerAccount1.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ký hiệu thẻ khách hàng hạng bạc";
            return;
        }
        if (this.txtCustomerAccount2.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ký hiệu thẻ khách hàng hạng vàng";
            return;
        }
        if (this.txtMemberAccount.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập ký hiệu thẻ thành viên";
            return;
        }
        if (this.txtPartnerDiscount.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mức giảm giá của đối tác";
            return;
        }
        if (this.txtCustomerDiscount.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mức giảm giá thành viên";
            return;
        }
         /**/

        float PartnerDiscount = 0;
        try{
            PartnerDiscount = float.Parse(this.txtPartnerDiscount.Text);
        }catch{
            this.lblMsg.Text = "Bạn nhập sai định dạng mức giảm giá của đối tác";
            return;
        }

        float CustomerDiscount = 0;
        try{
            CustomerDiscount = float.Parse(this.txtPartnerDiscount.Text);
        }catch{
            this.lblMsg.Text = "Bạn nhập sai định dạng mức giảm giá thành viên";
            return;
        }

        int ret = this.objSystemCongif.setSystemCongif(1, this.txtPartnerAccount.Text, this.txtCustomerAccount.Text, this.txtCustomerAccount1.Text, this.txtCustomerAccount2.Text, this.txtMemberAccount.Text, PartnerDiscount, CustomerDiscount);
        if(ret > 0)
        {
            this.lblMsg.Text = "Lưu dữ thiệu thành công !";
        }
    }
    #endregion

    #region method getCustomer
    public void getCustomer()
    {
        DataTable objData = this.objSystemCongif.getCustomerById(1);
        if(objData.Rows.Count > 0)
        {
            this.txtPartnerAccount.Text = objData.Rows[0]["PartnerAccount"].ToString();
            this.txtCustomerAccount.Text = objData.Rows[0]["CustomerAccount"].ToString();
            this.txtCustomerAccount1.Text = objData.Rows[0]["CustomerAccount1"].ToString();
            this.txtCustomerAccount2.Text = objData.Rows[0]["CustomerAccount2"].ToString();
            this.txtMemberAccount.Text = objData.Rows[0]["MemberAccount"].ToString();
            this.txtPartnerDiscount.Text = objData.Rows[0]["PartnerDiscount"].ToString();
            this.txtCustomerDiscount.Text = objData.Rows[0]["CustomerDiscount"].ToString();
        }
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.setCustomer();
    } 
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/Customer.aspx");
    } 
    #endregion
}