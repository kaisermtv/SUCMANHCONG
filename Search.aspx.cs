using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    #region declare
    public Location objLocation = new Location();
    public Partner objPartner = new Partner();
    public DataProduct objProduct = new DataProduct();
    private DataBusiness objBusiness = new DataBusiness();

    public DataTable objTableProduct = new DataTable();
    public DataTable objTableStore = new DataTable();
    public DataRowCollection objTableBusiness;
    public DataRowCollection objTableLocation;

    public int LTFind = 0;
    public string sSearch = "";
    public string Message = "";
    public int StoreType = 0;
    public int VBType = 0;
    public int Location = 0;

    public int nPage = 1;
    public int MaxPage = 1;
    public int ncount = 0;

    public int ProductGroup = 0;
    public int pPage = 1;
    public int pMaxPage = 1;
    public int pcount = 0;

    public string urlget = "";

    // tối đa một trang hiển thị bao nhiêu item
    public int PageItem = 16;
    #endregion

    #region Method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.objTableBusiness = this.objBusiness.getBusiness().Rows;
        this.objTableLocation = this.objLocation.getLocation().Rows;

        #region get option
        try
        {
            this.nPage = int.Parse(Request["StorePage"].ToString());
        }
        catch { }
        if (this.nPage < 1) this.nPage = 1;
        try
        {
            this.pPage = int.Parse(Request["ProductPage"].ToString());
        }
        catch { }
        if (this.pPage < 1) this.pPage = 1;

        try
        {
            this.sSearch = Request["Search"].ToString();
        }
        catch { }

        try
        {
            this.LTFind = int.Parse(Request["lt"].ToString());
        }
        catch { }

        try
        {
            this.nPage = int.Parse(Request["StorePage"].ToString());
        }
        catch { }
        if (this.nPage < 1) this.nPage = 1;

        try
        {
            this.Location = int.Parse(Request["Location"].ToString());
        }
        catch { }

        try
        {
            this.StoreType = int.Parse(Request["StoreType"].ToString());
        }
        catch { }

        try
        {
            this.VBType = int.Parse(Request["Type"].ToString());
        }
        catch { }
        if (this.VBType > 2) this.VBType = 0;
        #endregion

        #region Tính số trang
        this.ncount = objPartner.getCountPartnerOption(this.VBType, this.StoreType, this.Location, this.sSearch);
        this.MaxPage = this.ncount / this.PageItem;
        if (this.ncount % this.PageItem != 0)
        {
            this.MaxPage++;
        }
        if (this.MaxPage == 0) this.MaxPage = 1;
        if (this.nPage > this.MaxPage) this.nPage = this.MaxPage;
        #endregion

        this.objTableStore = objPartner.getPartnerOption(this.VBType, this.StoreType, this.Location, this.PageItem, (this.nPage - 1) * this.PageItem, true, this.sSearch);

        this.Message = objPartner.ErrorMessage;

        #region Tính số trang
        this.pcount = objProduct.getCountProductOption(this.VBType, this.ProductGroup, this.sSearch , this.Location );
        this.pMaxPage = this.pcount / this.PageItem;
        if (this.pcount % this.PageItem != 0)
        {
            this.pMaxPage++;
        }
        if (this.pMaxPage == 0) this.pMaxPage = 1;
        if (this.pPage > this.pMaxPage) this.pPage = this.pMaxPage;
        #endregion
        this.objTableProduct = objProduct.getProductOption(this.VBType, this.ProductGroup, this.PageItem, (this.nPage - 1) * this.PageItem, true, this.sSearch , this.Location );

    }
    #endregion

    #region Method GetUrlPage
    public string GetUrlPage(int page = 0,int ppage = 0)
    {
        if (this.urlget == "")
        {
            this.urlget = "?";

            if (this.VBType != 0)
            {
                this.urlget += "Type=" + this.VBType;
            }

            if (this.LTFind != 0)
            {
                if (this.urlget != "?") this.urlget += "&";
                this.urlget += "lt=" + this.LTFind;
            }

            if (this.StoreType != 0)
            {
                if (this.urlget != "?") this.urlget += "&";
                this.urlget += "StoreType=" + this.StoreType;
            }

            if (this.Location != 0)
            {
                if (this.urlget != "?") this.urlget += "&";
                this.urlget += "Location=" + this.Location;
            }

            if (this.sSearch != "")
            {
                if (this.urlget != "?") this.urlget += "&";
                this.urlget += "Search=" + this.sSearch;
            }
        }

        string str = this.urlget;

        if (page > 1)
        {
            if (str != "?") str += "&";
            str += "StorePage=" + page;
        }

        if (ppage > 1)
        {
            if (str != "?") str += "&";
            str += "ProductPage=" + ppage;
        }

        return str;
    }
    #endregion
}