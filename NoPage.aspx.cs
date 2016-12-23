using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NoPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ADMINLOGIN"] != null)
            {
                int buf = (int)Session["ADMINLOGIN"];

                Session["ADMINLOGIN"] = buf;
            }

            if (Session["ACCOUNT"] != null)
            {
                string bufs = (string)Session["ACCOUNT"];

                Session["ACCOUNT"] = bufs;
            }
        }
        catch { }
        
    }
}