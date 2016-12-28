using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StoreVIP : System.Web.UI.Page
{
    #region declare 
    public DataTable objTableStoreVip = new DataTable();
    private Partner objStoreVip = new Partner();
    private DataProduct objGroup = new DataProduct();
    #endregion  

    protected void Page_Load(object sender, EventArgs e)
    {

        this.objTableStoreVip = objStoreVip.getTopPartnerVIP(24);
        if (!IsPostBack)
        { 
        setStoreType();
        }
    }

    #region Set Store Type
    private void setStoreType()
    {
        this.ddlStoreType.DataSource = objGroup.getProductGroup();
        this.ddlStoreType.DataTextField = "Name";
        this.ddlStoreType.DataValueField = "Id";
        this.ddlStoreType.DataBind();
       this.ddlStoreType.Items.Insert(0, new ListItem("Nhóm sản phẩm kinh doanh", "0"));
    }
    #endregion

    protected void ddlStoreType_SelectedIndexChanged(object sender, EventArgs e)
    {

        int id = int.Parse( ddlStoreType.SelectedValue);
        // get Id index
        if (id == 0) { return; }
        this.objTableStoreVip = objStoreVip.getTopPartnerVIPFilterByGroup(id);
        ddlStoreType.SelectedValue = ddlStoreType.SelectedValue;
    }
}