using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListStore : System.Web.UI.Page
{
    #region declare
    public Location objLocation = new Location();
    public Partner objPartner = new Partner();
    private DataBusiness objBusiness = new DataBusiness();

    public DataTable objTableStore = new DataTable();
    public DataRowCollection objTableBusiness;
    public DataRowCollection objTableLocation;

    public string Message = "";
    public int StoreType = 0;
    public int VBType = 0;
    public int Location = 0;
    public int nPage = 1;
    public int MaxPage = 1;
    public int ncount = 0;

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
            this.nPage = int.Parse(Request["Page"].ToString());
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
        this.ncount = objPartner.getCountPartnerOption(this.VBType, this.StoreType, this.Location);
        this.MaxPage = this.ncount / this.PageItem;
        if (this.ncount % this.PageItem != 0)
        {
            this.MaxPage++;
        }
        if (this.MaxPage == 0) this.MaxPage = 1;
        if (this.nPage > this.MaxPage) this.nPage = this.MaxPage;
        #endregion

        this.objTableStore = objPartner.getPartnerOption(this.VBType, this.StoreType, this.Location, this.PageItem, (this.nPage - 1) * this.PageItem);

        this.Message = objPartner.ErrorMessage;

    }
    #endregion

    #region Method GetUrlPage
    public string GetUrlPage(int page =0 )
    {
        if (this.urlget == "")
        {
            this.urlget = "?";

            if (this.VBType != 0)
            {
                this.urlget += "Type=" + this.VBType;
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
        }

        string str = this.urlget;

        if (page > 1)
        {
            if (str != "?") str += "&";
            str += "Page=" + page;
        }

        return str;
    }
    #endregion
}