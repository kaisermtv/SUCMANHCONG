using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReceiveNews : System.Web.UI.Page
{
    public string email = "";
    private TVSFunc func = new TVSFunc();

    protected void Page_Load(object sender, EventArgs e)
    {

        this.email = Request["email"].ToString();
       
        if (this.email == null || this.email.Trim() == "")
        {
            Response.Redirect("/");
        }

        DataReceiveNews mail = new DataReceiveNews();
        mail.addEmail(this.email);

    }
}