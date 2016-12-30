using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Register : System.Web.UI.Page
{
    #region declare objects
    private DataBusiness objBusiness = new DataBusiness();
    private Location objLocation = new Location();
    private Partner objPartner = new Partner();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.getLocation();
            this.getBusiness();
        }
    }    
    #endregion

    #region method getBusiness
    public void getBusiness()
    {
        DataTable objDataBusiness = this.objBusiness.getIdAndUpperName();
        if(objDataBusiness.Rows.Count > 0)
        {
            this.ddlBusiness.DataSource = objDataBusiness;
            this.ddlBusiness.DataTextField = "Name";
            this.ddlBusiness.DataValueField = "Id";
            this.ddlBusiness.DataBind();
        }
    }
    #endregion

    #region method getLocation
    public void getLocation()
    {
        DataTable objDataLocation = this.objLocation.getIdAndUpperName();

        this.ddlLocation.DataSource = objDataLocation;
        this.ddlLocation.DataTextField = "Name";
        this.ddlLocation.DataValueField = "Id";
        this.ddlLocation.DataBind();

    }
    #endregion

    #region method setPartner
    public void setPartner()
    {
        int Business = 0;
        try{
            Business = Int32.Parse(this.ddlBusiness.SelectedValue.ToString());
        }
        catch { }

        int LocationId = 0;
        try{
            LocationId = Int32.Parse(this.ddlLocation.SelectedValue.ToString());
        }
        catch { }

        int PartnerId = this.objPartner.addPartner(this.txtName.Value.ToString(), this.txtAddress.Value.ToString(), this.txtPhone.Value.ToString(), this.txtManager.Value.ToString(), this.txtTaxCode.Value.ToString(), Business, LocationId);

        this.lblMsg.Text = this.objPartner.ErrorMessage;
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";
        if (this.txtName.Value.ToString().Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên cửa hàng, vui lòng kiểm tra lại";
            this.txtName.Focus();
            return;
        }
        if (this.txtAddress.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập địa chỉ cửa hàng, vui lòng kiểm tra lại";
            this.txtAddress.Focus();
            return;
        }
        if (this.txtPhone.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập số điện thoại cửa hàng, vui lòng kiểm tra lại";
            this.txtPhone.Focus();
            return;
        }
        this.setPartner();
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("/");
    }
    #endregion
}