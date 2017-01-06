using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string Acct = ""; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ADMINLOGIN"] == null || (int)Session["ADMINLOGIN"] == 0)
        {
          Response.Redirect("/system/login");
        }

        int buf = (int)Session["ADMINLOGIN"];

        Session["ADMINLOGIN"] = buf;
    }
}
