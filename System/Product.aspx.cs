using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Product : System.Web.UI.Page
{
    #region declare objects
    private DataProduct objProduct = new DataProduct();
    DataTable objData = new DataTable();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CollectionPager2.MaxPages = 1000;
            CollectionPager2.PageSize = 120;
            CollectionPager2.DataSource = getProduct().DefaultView;
            CollectionPager2.BindToControl = DataList2;
            DataList2.DataSource = CollectionPager2.DataSourcePaged;
            DataList2.DataBind();
        }
    }
    #endregion

    #region method getProduct
    public DataTable getProduct()
    {
        DataTable objData = this.objProduct.getPartProduct();       //  vì bảng sản phầm nhiều cột , nên chỉ lấy những cột cần thiết , tránh bị die 
        if (objData.Rows.Count < 120)
        {
            this.tblABC.Visible = false;
        }
        return objData;
    }
    #endregion


    protected void btnShortByTen_Click(object sender, EventArgs e)
    {
         objData = this.objProduct.getAllProductSortByName();

        CollectionPager2.MaxPages = 1000;
        CollectionPager2.PageSize = 120;
        CollectionPager2.DataSource = objData.DefaultView;
        CollectionPager2.BindToControl = DataList2;
        DataList2.DataSource = CollectionPager2.DataSourcePaged;
        DataList2.DataBind();
    }
    protected void btnShortByGia_Click(object sender, EventArgs e)
    {
         objData = this.objProduct.getAllProductSortByPrice();

        CollectionPager2.MaxPages = 1000;
        CollectionPager2.PageSize = 120;
        CollectionPager2.DataSource = objData.DefaultView;
        CollectionPager2.BindToControl = DataList2;
        DataList2.DataSource = CollectionPager2.DataSourcePaged;
        DataList2.DataBind();

    }
    protected void btnShortByVip_Click(object sender, EventArgs e)
    {
        objData = this.objProduct.getAllProductSortByVIP();

        CollectionPager2.MaxPages = 1000;
        CollectionPager2.PageSize = 120;
        CollectionPager2.DataSource = objData.DefaultView;
        CollectionPager2.BindToControl = DataList2;
        DataList2.DataSource = CollectionPager2.DataSourcePaged;
        DataList2.DataBind();
    }
    protected void btnShortByBestSale_Click(object sender, EventArgs e)
    {
        objData = this.objProduct.getAllProductSortBySALE();

        CollectionPager2.MaxPages = 1000;
        CollectionPager2.PageSize = 120;
        CollectionPager2.DataSource = objData.DefaultView;
        CollectionPager2.BindToControl = DataList2;
        DataList2.DataSource = CollectionPager2.DataSourcePaged;
        DataList2.DataBind();
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        string str = this.txtSearch.Text.Trim();
        objData = this.objProduct.getAllProductSearchByName(str);

        CollectionPager2.MaxPages = 1000;
        CollectionPager2.PageSize = 120;
        CollectionPager2.DataSource = objData.DefaultView;
        CollectionPager2.BindToControl = DataList2;
        DataList2.DataSource = CollectionPager2.DataSourcePaged;
        DataList2.DataBind();
    }
}