using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_MyProfile : System.Web.UI.Page
{
    public String html = "";
    #region declare objects
    public string strName = "", strAddress = "", strPhone = "", strBirthday = "", strIdCard = "", strEmail = "", strMsg = "",strDaycreate="",strCard = "";
    private string Id = "";
    private TVSFunc objFunc = new TVSFunc();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Id = Session["ACCOUNT"].ToString();
        }
        catch
        {
            this.Id = "";
        }
        if (!Page.IsPostBack)
        {
            this.getCustomer();
        }
    }
    #endregion

    #region method getCustomer
    public void getCustomer()
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT * FROM tblCustomers WHERE Account = @Account";
        Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = this.Id;
        SqlDataReader Rd = Cmd.ExecuteReader();
        while (Rd.Read())
        {
            this.strName = Rd["Name"].ToString();
            this.strAddress = Rd["Address"].ToString();
            this.strPhone = Rd["Phone"].ToString();
            try
            {
                this.strBirthday = DateTime.Parse(Rd["Birthday"].ToString()).ToString("dd/MM/yyyy");
            }
            catch { }
            this.strCard = Rd["IdCard"].ToString();
            this.strEmail = Rd["Email"].ToString();
            this.strIdCard = Rd["IdCard"].ToString();
            this.strDaycreate = Rd["DayCreateAccount"].ToString();
            lblImg1.Text = "<img width = \"100%\" height = \"120px\" src = \"/Images/Customer/" + Rd["Avatar"].ToString() + "\">";
        }
        Rd.Close();
        sqlCon.Close();
        sqlCon.Dispose();
    }
    #endregion

    #region method btnUpdate_Click
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerInfoUpdate.aspx");
    } 
    #endregion

    protected void can1_Click(object sender, EventArgs e)
    {
        panel.Visible = false;
        getCustomer();
    }
    protected void ClickMe_Click1(object sender, EventArgs e)
    {

        panel.Visible = true;
        getCustomer();
    }
    protected void btnDoiNhom_Click(object sender, EventArgs e)
    {
       
        panel.Visible = true;
        html += "<div class='container'> Đội Nhóm </div>";
       
    }
    protected void btnHoSoCuaToi_Click(object sender, EventArgs e)
    {
        html += "<div class='row' style='width:650px; margin-left:0%; color:red; text-algin:center; font-size:25px;'>Hồ Sơ Của Tôi </div>";
        getCustomer();
        html += " <div class='panel panel-default' style='text-algin:left;'> <ul class='list-group' style='text-algin:left;'>" +
                            "<li class='list-group-item'>Tên tài khoản:"+(strName)+"</li>"+
                            "<li class='list-group-item'>Địa chỉ: "+(strAddress)+"</li>"+
                            "<li class='list-group-item'>Điện thoại: "+(strPhone)+"</li>"+
                            "<li class='list-group-item'>Ngày sinh: "+(strBirthday)+"</li>"+
                            "<li class='list-group-item'>Số CMND: "+(strIdCard) +"</li>"+
                            "<li class='list-group-item'>Địa chỉ Email:"+(strEmail)+"</li>"+
                        "</ul></div>";

        panel.Visible = true;
    }
    protected void btnTichLuyThang_Click(object sender, EventArgs e)
    {
        html += "<div class='row' style='width:650px; margin-left:0%; color:red; text-algin:center; font-size:25px;'>Tích Lũy Tháng</div>";
        panel.Visible = true;
    }
    protected void btnTongSoDu_Click(object sender, EventArgs e)
    {
        panel.Visible = true;
        html += "<div class='row' style='width:650px; margin-left:0%; color:red; text-algin:center; font-size:25px;'>Tổng số dư</div>";
        
    }

}