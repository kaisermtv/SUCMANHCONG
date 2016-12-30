using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{
    private tblAbouts objAbouts = new tblAbouts();
    public string Name = "";
    public string Address = "";
    public string Phone = "";
    public string Email = "";
    public string Intro = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable objDataAbout = this.objAbouts.getAbouts();
        if (objDataAbout.Rows.Count > 0)
        {
            this.Name = objDataAbout.Rows[0]["Name"].ToString();
            this.Address = objDataAbout.Rows[0]["Address"].ToString();
            this.Phone = objDataAbout.Rows[0]["Phone"].ToString();
            this.Email = objDataAbout.Rows[0]["Email"].ToString();
            this.Intro = objDataAbout.Rows[0]["Intro"].ToString();
        }
    }
}