using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Default : System.Web.UI.Page
{
    #region declare
    private DataTopic objTopic = new DataTopic();
    public DataTable objtable = new DataTable();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objtable = objTopic.getTopTopic();
        }
    }


}