using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_Del_DelContact : System.Web.UI.Page
{

    private Contact objDataContact = new Contact();
    private int itemId = 0;
    public string name = "";

    #region method getid
    protected void getid()
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());

        }
        catch
        {
        }


    }
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.getid();

        DataTable objTable = this.objDataContact.getContact(this.itemId);
        if (objTable.Rows.Count > 0)
        {
            this.name = objTable.Rows[0]["Name"].ToString();
        }
        else
        {
            Response.Redirect("~/System/");
        }

    }
    #endregion

    #region method btnSave_Click
    protected void btnOk_Click(object sender, EventArgs e)
    {
        //this.getid();

        objDataContact.DelContact(this.itemId);

        Response.Redirect("~/System/");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/System/");
    }
    #endregion
}