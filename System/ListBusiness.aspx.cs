using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ListBusiness : System.Web.UI.Page
{
    protected DataBusiness objBusiness = new DataBusiness();
    public DataTable objTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.objTable = this.objBusiness.getIdAndUpperName();
            cpGroupAcc.MaxPages = 1000;
            cpGroupAcc.PageSize = 15;
            cpGroupAcc.DataSource = this.objTable.DefaultView;
            cpGroupAcc.BindToControl = dtlBusiness;
            dtlBusiness.DataSource = cpGroupAcc.DataSourcePaged;
            dtlBusiness.DataBind();
            if (this.objTable.Rows.Count < 15)
            {
                this.tblABC.Visible = false;
            }
        }
    }
}