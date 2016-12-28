using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StoreBestSale : System.Web.UI.Page
{
    #region declare 
    public Partner objStoreBestSale = new Partner();
    public DataTable objTableStoreBestSale = new DataTable();
    private DataBusiness objBusiness = new DataBusiness();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        this.objTableStoreBestSale = objStoreBestSale.getTopPartnerBestSale(24);    // get 24 object    
        
        if(!IsPostBack)
        {
            setStoreType();
        }
        
    }

    #region Set Store Type
    private void setStoreType()
    {
        this.ddlStoreType.DataSource = objBusiness.getBusiness();
        this.ddlStoreType.DataTextField = "Name";
        this.ddlStoreType.DataValueField = "Id";
        this.ddlStoreType.DataBind();
        this.ddlStoreType.Items.Insert(0, new ListItem("Nhóm sản phẩm kinh doanh", "0"));
    }
    #endregion

    protected void ddlStoreType_SelectedIndexChanged(object sender, EventArgs e)
    {

        int id = int.Parse( ddlStoreType.SelectedValue);
        if (id == 0) { return; }
        // get Id index
        this.objTableStoreBestSale = objStoreBestSale.getBestSalePartnerFilterByGroup(id);
        ddlStoreType.SelectedValue = ddlStoreType.SelectedValue;
    }
}