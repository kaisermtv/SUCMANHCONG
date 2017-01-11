using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : System.Web.UI.Page
{
    #region declare
    private Contact contact = new Contact();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { }
    }


    protected void submit_Click(object sender, EventArgs e)
    {
        if (contact.sendContact(txtName.Text, txtEmail.Text, txtPhone.Text, txtSubject.Text, txtMessage.InnerText) ==1)
        {

            Page.ClientScript.RegisterStartupScript(GetType(), "msg", "confirm('Yêu cầu được gửi đi thành công , Cảm ơn bạn đả kết nối cùng chúng tôi') ; window.close();", true);
           
          
            
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('Có lổi xãy ra , Xin hãy thực hiện lại  thao tác ')", true);
        }

    }
}