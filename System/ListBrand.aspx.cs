using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ListBrand : System.Web.UI.Page
{
    protected Brand objBusiness = new Brand();
    public DataTable objTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.objTable = this.objBusiness.getBrand();
            cpGroupAcc.MaxPages = 1000;
            cpGroupAcc.PageSize = 15;
            cpGroupAcc.DataSource = this.objTable.DefaultView;
            cpGroupAcc.BindToControl = dtlBrand;
            dtlBrand.DataSource = cpGroupAcc.DataSourcePaged;
            dtlBrand.DataBind();
            if (this.objTable.Rows.Count < 15)
            {
                this.tblABC.Visible = false;
            }
        }
    }
}