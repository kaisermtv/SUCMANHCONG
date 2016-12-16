using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListStore : System.Web.UI.Page
{
    Partner objPartner = new Partner();
   public DataTable objTablePartner = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.objTablePartner = objPartner.getPartner();
    }
}