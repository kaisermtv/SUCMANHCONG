using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    #region declare objects
    public string[] ProductGroup = new string[7] { "", "", "", "", "", "", "" };
    private DataTable objTableProductGroup = new DataTable();
    public DataTable objTableProductVIP = new DataTable();
    public DataTable objTableNews = new DataTable();
    private DataProduct objProduct = new DataProduct();
    private DataTopic objTopic = new DataTopic();
    public DataTable objTablePartner = new DataTable();
    public Partner objPartner = new Partner();
    private Brand objBrand = new Brand();
    public DataTable objTableBestSale = new DataTable();
    public DataTable objTableBrand = new DataTable();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        this.objTableProductGroup = objProduct.getProductGroup();          // Lấy nội dung từng phần hiển thị .

        if (this.objTableProductGroup.Rows.Count > 0)
        {
            for (int i = 0; i < this.objTableProductGroup.Rows.Count; i++)      
            {
                this.ProductGroup[i] = this.objTableProductGroup.Rows[i]["Name"].ToString();        
            }   
        }
        this.objTableNews = objTopic.getTopTopic();     
        this.objTableProductVIP = objProduct.getTopProductVIP();
        objTableBestSale = objProduct.getProductBestSale();
        this.objTablePartner = objPartner.getTopPartner();
        this.objTableBrand = objBrand.getBrand();

        }
    }
    #endregion
}