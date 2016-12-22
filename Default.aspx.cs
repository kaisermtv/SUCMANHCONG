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
    public string[] ProductGroup = new string[20] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    private DataTable objTableProductGroup = new DataTable();
    public DataTable objTableProductVIP = new DataTable();
    public DataTable objTableNews = new DataTable();
    private DataProduct objProduct = new DataProduct();
    private DataTopic objTopic = new DataTopic();
    public DataTable objTablePartner = new DataTable();
    public Partner objPartner = new Partner();
    private Brand objBrand = new Brand();
    private DataSlideImage objSlide = new DataSlideImage();
    public DataTable objTableBestSale = new DataTable();
    public DataTable objTableBrand = new DataTable();
    public DataTable objTableSlide = new DataTable();

    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.objTableNews = objTopic.getTopTopic();     
        this.objTableProductVIP = objProduct.getTopProductVIP();
        objTableBestSale = objProduct.getProductBestSale();
        this.objTablePartner = objPartner.getTopPartner();
        this.objTableBrand = objBrand.getBrand();
        this.objTableSlide = objSlide.getSlideImage();
    }
    #endregion
}