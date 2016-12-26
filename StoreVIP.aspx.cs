using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StoreVIP : System.Web.UI.Page
{
    #region declare 
    public DataTable objTableStoreVip = new DataTable();
    private Partner objStoreVip = new Partner();
    #endregion  

    protected void Page_Load(object sender, EventArgs e)
    {

        this.objTableStoreVip = objStoreVip.getTopPartnerVIP(24);

    }


}