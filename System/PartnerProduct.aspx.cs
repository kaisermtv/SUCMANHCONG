using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_PartnerProduct : System.Web.UI.Page
{
    #region declare objects
    private DataProduct objProduct = new DataProduct();
    private Partner objPartner = new Partner();
    private TVSFunc objFunc = new TVSFunc();

    public int itemId = 0;
    public int SoSanPham = 0, SoSanPhamVIP = 0, SoSanPhamBanChay = 0, SoGiaoDich = 0;
    public double TongDoanhSo = 0;
    public string strName = "";
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
            this.getPartner();
            this.SoSanPham = this.objProduct.getCountProductByPartnerId(this.itemId);
            this.SoSanPhamVIP = this.objProduct.getProductVIPCountByPartnerId(this.itemId);
            this.SoSanPhamBanChay = this.objProduct.getProductBestSaleCountByPartnerId(this.itemId);
            this.SoGiaoDich = this.objPartner.getProductBillCountByPartnerId(this.itemId);
            this.TongDoanhSo = this.objPartner.getProductDoanhSoByPartnerId(this.itemId);

            CollectionPager2.MaxPages = 1000;
            CollectionPager2.PageSize = 120;
            CollectionPager2.DataSource = getProduct().DefaultView;
            CollectionPager2.BindToControl = DataList2;
            DataList2.DataSource = CollectionPager2.DataSourcePaged;
            DataList2.DataBind();

        }
    } 
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objData = this.objPartner.getPartnerById(this.itemId);
        if(objData.Rows.Count > 0)
        {
            this.strName = objData.Rows[0]["Name"].ToString();
        }
    }
    #endregion


    #region method getProduct
    public DataTable getProduct()
    {
        DataTable objData = this.objProduct.getProductByPartnerId(this.itemId);
        if(objData.Rows.Count < 120)
        {
            this.tblABC.Visible = false;
        }
        return objData;
    }
    #endregion
}