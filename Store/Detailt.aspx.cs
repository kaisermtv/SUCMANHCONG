using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Detailt : System.Web.UI.Page
{
    #region declare objects
    private Partner objPartner = new Partner();
    private DataProduct objProduct = new DataProduct();

    public DataTable objTablePartner = new DataTable();
    public DataTable objTable = new DataTable();
    public DataTable objTableSelect = new DataTable();
    private int itemId = 0, itemProductId = 0;

    public string htmtStr = "", htmlCard = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        contentRight2.Visible = false;

        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            Response.Redirect("/");
            this.itemId = 0;
        }
        if (!Page.IsPostBack)
        {
            this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
            this.objTable = this.objProduct.getProductByIdJoin(this.itemId);
            this.ddlLeft.DataSource = this.objProduct.getProductByIdWithJoinAndSortByDiscount(this.itemId);
            this.ddlLeft.DataBind();
        }
    }
    #endregion

  

    protected void btnMoicapnhat_Click(object sender, EventArgs e)
    {
        contentText.Visible = false;
        contentRight2.Visible = true;
        this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
        ddlRight.Visible = true;
        ddlRight.DataSource = this.objProduct.getProductByIdWithJoinAndRecentlyUpdate(25);
        ddlRight.DataBind();
     
    }
    protected void btnHotnhat_Click(object sender, EventArgs e)
    {
        contentText.Visible = false;
        contentRight2.Visible = true;
        this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
        ddlRight.Visible = true;
        ddlRight.DataSource = this.objProduct.getProductByIdWithJoinAndSortByPrice(25);
        ddlRight.DataBind();
    }
    protected void btnGiaTot_Click(object sender, EventArgs e)
    {
        contentText.Visible = false;
        contentRight2.Visible = true;
        this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
        ddlRight.Visible = true;
        ddlRight.DataSource = this.objProduct.getProductByIdWithJoinAndSortByPriceAsc(25);
        ddlRight.DataBind();
    }
  
    protected void btnGiamGia_Click(object sender, EventArgs e)
    {
        contentText.Visible = false;
        contentRight2.Visible = true;
        this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
        ddlRight.Visible = true;
        ddlRight.DataSource = this.objProduct.getProductByIdWithJoinAndSortByDiscount(25);
        ddlRight.DataBind();

    }
}