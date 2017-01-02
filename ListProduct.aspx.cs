using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListProduct : System.Web.UI.Page
{
    #region declare
    public DataProduct objProduct = new DataProduct();

    public DataTable objTableProduct = new DataTable();
    public DataRowCollection objRowProductGroup;

    public string Message = "";
    public int ProductGroup = 0;
    public int VBType = 0;
    public int nPage = 1;
    public int MaxPage = 1;
    public int ncount = 0;

    public string urlget = "";

    // tối đa một trang hiển thị bao nhiêu item
    public int PageItem = 16;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.objRowProductGroup = this.objProduct.getProductGroup().Rows;

        #region get option
        try
        {
            this.nPage = int.Parse(Request["Page"].ToString());
        }
        catch { }
        if (this.nPage < 1) this.nPage = 1;

        try
        {
            this.ProductGroup = int.Parse(Request["Group"].ToString());
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
        this.ncount = objProduct.getCountProductOption(this.VBType, this.ProductGroup);
        this.MaxPage = this.ncount / this.PageItem;
        if (this.ncount % this.PageItem != 0)
        {
            this.MaxPage++;
        }
        if (this.MaxPage == 0) this.MaxPage = 1;
        if (this.nPage > this.MaxPage) this.nPage = this.MaxPage;
        #endregion

        this.objTableProduct = objProduct.getProductOption(this.VBType, this.ProductGroup, this.PageItem, (this.nPage - 1) * this.PageItem);

        this.Message = objProduct.ErrorMessage;
    }

    #region Method GetUrlPage
    public string GetUrlPage(int page = 0)
    {
        if (this.urlget == "")
        {
            this.urlget = "?";

            if (this.VBType != 0)
            {
                this.urlget += "Type=" + this.VBType;
            }

            if (this.ProductGroup != 0)
            {
                if (this.urlget != "?") this.urlget += "&";
                this.urlget += "Group=" + this.ProductGroup;
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