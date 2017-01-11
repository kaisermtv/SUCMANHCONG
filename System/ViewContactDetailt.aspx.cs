using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ViewContactDetailt : System.Web.UI.Page
{
    
    #region declare objects
    private Contact objContactViewDetail = new Contact();

    private int itemId = 0;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());

        }
        catch
        {
            this.itemId = 0;
        }

        if (!Page.IsPostBack)
        {
            this.getContact();
        }
    }
    #endregion

    #region method getContact
    protected void getContact()
    {
        if (this.itemId != 0)
        {
            DataTable objTable = this.objContactViewDetail.getContact(this.itemId);

            if (objTable.Rows.Count > 0)
            {
                this.txtName.Value = objTable.Rows[0]["Name"].ToString();
                this.txtEmail.Value = objTable.Rows[0]["Email"].ToString();
            
                this.txtPhone.Value = objTable.Rows[0]["Phone"].ToString();
                this.txtSubject.Value = objTable.Rows[0]["Subject"].ToString();
                this.txtMessage.Value = objTable.Rows[0]["Message"].ToString();
                // */
            }
        }
        else
        {
            Response.Redirect("/");
        }
    }
    #endregion

}