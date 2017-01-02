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
    private DataProduct objProduct = new DataProduct();
    public Partner objPartner = new Partner();
    private Brand objBrand = new Brand();
    private DataTopic objTopic = new DataTopic();

    private DataTable objTableProductGroup = new DataTable();
    public DataTable objTableProductVIP = new DataTable();
    public DataTable objTableNews = new DataTable();
    public DataTable objTablePartner = new DataTable();
    public DataTable objTablePartnerBestSale = new DataTable();
    private DataSlideImage objSlide = new DataSlideImage();
    public DataTable objTableBestSale = new DataTable();
    public DataTable objTableBrand = new DataTable();
    public DataTable objTableSlide = new DataTable();


    public int CountPageProduct = 1;
    public int PageProduct = 1;

    public int CountPagePartner = 1;
    public int PagePartner = 1;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.PageProduct = int.Parse(Request["PageProduct"].ToString());
        }
        catch
        {
        }
        int ncount;
        ncount = objProduct.getCountProductOption(2);
        this.CountPageProduct = ncount / 8;
        if (ncount % 8 != 0)
        {
            this.CountPageProduct++;
        }
        if (this.CountPageProduct == 0) this.CountPageProduct = 1;
        if (this.PageProduct > this.CountPageProduct) this.PageProduct = this.CountPageProduct;


        try
        {
            this.PagePartner = int.Parse(Request["PagePartner"].ToString());
        }
        catch
        {
        }
        ncount = objPartner.getCountPartnerOption(2);
        this.CountPagePartner = ncount / 8;
        if (ncount % 8 != 0)
        {
            this.CountPagePartner++;
        }
        if (this.CountPagePartner == 0) this.CountPagePartner = 1;
        if (this.PagePartner > this.CountPagePartner) this.PagePartner = this.CountPagePartner;
        


        this.objTableNews = objTopic.getTopTopic();
        this.objTableProductVIP = objProduct.getProductOption(1,0,8);
        this.objTableBestSale = objProduct.getProductOption(2,0,8, (this.PageProduct - 1) * 8);
        this.objTablePartner = objPartner.getPartnerOption(1,0,0,8);
        this.objTablePartnerBestSale = objPartner.getPartnerOption(2,0,0,8, (this.PagePartner - 1) * 8);
        this.objTableBrand = objBrand.getBrand();
        this.objTableSlide = objSlide.getSlideImage();
    }
    #endregion
}