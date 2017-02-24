using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Net.Mail;

public partial class System_SendEmailtoCustomer : System.Web.UI.Page
{
    #region  declare
    private TVSFunc func = new TVSFunc();
    private DataReceiveNews objNew = new DataReceiveNews();
    DataTable objData = new DataTable();
    public String strFromMail = "hieu.e.content@gmail.com";
    public String strPassword = "hieuxinhe94";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CollectionPager2.MaxPages = 1000;
            CollectionPager2.PageSize = 120;
            CollectionPager2.DataSource = getEmail().DefaultView;
            CollectionPager2.BindToControl = DataList2;
            DataList2.DataSource = CollectionPager2.DataSourcePaged;
            DataList2.DataBind();
        }
       

    }

    #region method getPartner
    public DataTable getEmail()
    {
      objData= objNew.getEmail();
        if (objData.Rows.Count < 120)
        {
            this.tblABC.Visible = false;
        }
    

        return objData;
    }
    #endregion

    #region checkMail
    public bool checkIsMail(String mail)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(mail);
            return addr.Address == mail;
        }
        catch
        {
            return false;
        }

    }
    #endregion

    protected void can1_Click(object sender, EventArgs e)
    {
        panel.Visible = false;
    }
    protected void ClickMe_Click1(object sender, EventArgs e)
    {
        panel.Visible = true;
    }

    #region save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // vertify input 
        if (checkIsMail(txtMailFrom.Text)) 
            { 
            strFromMail = txtMailFrom.Text;
            strPassword = txtPassword.Text;

            }
        else { Page.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('Địa chỉ ban nhập không hợp lệ, chúng tôi đả sử dụng email mặc định! ')", true); }
        getEmail();
        TVSFunc func = new TVSFunc();
       
        for (int i = 0; i < objData.Rows.Count;i++ ){
            // mail server or mail 
            if (func.sendEmail(strFromMail, this.txtEmailTitle.Text, objData.Rows[i]["Email"].ToString(),"SUCMANHCONG SUPPORT", strPassword,this.txtEmailContent.InnerText) != 1)
            {
            
                 Page.ClientScript.RegisterStartupScript(GetType(), "msga", "('Không thể gửi một số email do định dạng không đúng, ')", false);
                continue;
            }
             }
        Page.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('Good job ! ')", true);
    }
    #endregion
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }



   
}