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
            CollectionPager2.DataSource = this.getProduct().DefaultView;
            CollectionPager2.BindToControl = DataList2;
            DataList2.DataSource = CollectionPager2.DataSourcePaged;
            DataList2.DataBind();
        }
    }
    #endregion

    #region method getProduct
    public DataTable getProduct()
    {
        objData = this.objProduct.getPartAdvertmentProduct();       //  vì bảng sản phầm nhiều cột , nên chỉ lấy những cột cần thiết , tránh bị die 
        if (objData.Rows.Count < 120)
        {
            this.tblABC.Visible = false;
        }
        return objData;
    }
    #endregion


   
}