using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ListLocation : System.Web.UI.Page
{
    private DataTable objTable = new DataTable();
    private Location objDataLocation = new Location();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.objTable = this.objDataLocation.getLocation();
            cpGroupAcc.MaxPages = 1000;
            cpGroupAcc.PageSize = 15;
            cpGroupAcc.DataSource = this.objTable.DefaultView;
            cpGroupAcc.BindToControl = dtlLocation;
            dtlLocation.DataSource = cpGroupAcc.DataSourcePaged;
            dtlLocation.DataBind();
            if (this.objTable.Rows.Count < 15)
            {
                this.tblABC.Visible = false;
            }
        }
    }
}