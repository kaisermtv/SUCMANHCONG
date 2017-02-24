using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_ViewBill : System.Web.UI.Page
{
    #region declare objects
    public string strCusAccount = "", strCusName = "", strCusAddress = "", strCusPhone = "", strIdCard = "", strCusEmail = "", strCusAccountType = "", strCustomerTotalDiscountCard = "0", strDiscount = "-", strDiscountCard = "-", strDiscountAdv = "-", strHtml = "", strHtml1 = "";
    private int billId = 0;

    private DataTable objTable = new DataTable();
    private DataTable objTableDetailt = new DataTable();
    private DataTable objTableDetailtOrther = new DataTable();

    private Partner objPartner = new Partner();
    private Customers objCustomers = new Customers();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.billId = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.billId = 0;
        }
        if (!Page.IsPostBack)
        {
            this.objTable = this.objPartner.getNameAndAccountTypeCustomerByPartnerBillId(this.billId);
            if (this.objTable.Rows.Count > 0)
            {
                this.lblAccount.Text = "Số thẻ: <a data-toggle=\"modal\" data-target=\"#myModal\" href = \"#\">" + this.objTable.Rows[0]["CustomerAccount"].ToString() + "</a>";
                this.lblName.Text = "Tên khách hàng: " + this.objTable.Rows[0]["CustomerName"].ToString();
                this.getCustomer(this.objTable.Rows[0]["CustomerAccount"].ToString());
                this.txtTotalMoney.Value = this.objTable.Rows[0]["TotalMoney"].ToString();
                this.strDiscount = this.objTable.Rows[0]["Discount"].ToString();
                this.strDiscountCard = this.objTable.Rows[0]["DiscountCard"].ToString();
                this.strDiscountAdv = this.objTable.Rows[0]["DiscountAdv"].ToString();
                this.txtTotalMoneyDiscount.Text = this.objTable.Rows[0]["TotalMoneyDiscount"].ToString();
                this.txtTotalMoneyPayment.Text = this.objTable.Rows[0]["TotalPeyment"].ToString();
                this.lblMsg1.Text = "Ngày tạo: " + DateTime.Parse(this.objTable.Rows[0]["DayCreate"].ToString()).ToString("dd/MM/yyyy HH:mm");
            }

            this.objTableDetailt = this.objPartner.getPartnerBillDetailById(this.billId);
            if (this.objTableDetailt.Rows.Count > 0)
            {
                this.strHtml = "";
                for (int i = 0; i < this.objTableDetailt.Rows.Count; i++)
                {
                    this.strHtml += "<div style=\"width: 100%;\">";
                    this.strHtml += "<div style=\"width: 5%; float: left; text-align:center; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml += (i + 1).ToString();
                    this.strHtml += "</div>";
                    this.strHtml += "<div style=\"width: 65%; float: left; text-align:justify; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml += this.objTableDetailt.Rows[i]["Name"].ToString();
                    this.strHtml += "</div>";
                    this.strHtml += "<div style=\"width: 15%; float: left; text-align:right; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml += this.objTableDetailt.Rows[i]["ProductNumber"].ToString();
                    this.strHtml += "</div>";
                    this.strHtml += "<div style=\"width: 15%; float: left; text-align:right; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml += this.objTableDetailt.Rows[i]["ProductPrice"].ToString();
                    this.strHtml += "</div>";
                    this.strHtml += "</div>";
                }
            }

            this.objTableDetailtOrther = this.objPartner.getPartnerBillDetailOtherById(this.billId);
            if (this.objTableDetailtOrther.Rows.Count > 0)
            {
                this.strHtml1 = "";
                for (int i = 0; i < this.objTableDetailtOrther.Rows.Count; i++)
                {
                    this.strHtml1 += "<div style=\"width: 100%;\">";
                    this.strHtml1 += "<div style=\"width: 5%; float: left; text-align:center; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml1 += (i + 1).ToString();
                    this.strHtml1 += "</div>";
                    this.strHtml1 += "<div style=\"width: 65%; float: left; text-align:justify; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml1 += this.objTableDetailtOrther.Rows[i]["ProductName"].ToString();
                    this.strHtml1 += "</div>";
                    this.strHtml1 += "<div style=\"width: 15%; float: left; text-align:right; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml1 += this.objTableDetailtOrther.Rows[i]["ProductNumber"].ToString();
                    this.strHtml1 += "</div>";
                    this.strHtml1 += "<div style=\"width: 15%; float: left; text-align:right; padding:3px; color:#000; font-size:13px;\">";
                    this.strHtml1 += this.objTableDetailtOrther.Rows[i]["ProductPrice"].ToString();
                    this.strHtml1 += "</div>";
                    this.strHtml1 += "</div>";
                }
            }
        }
    }
    #endregion

    #region method getCustomer
    public void getCustomer(string Account)
    {

        this.lblMsg1.Text = "-:-";
        DataTable objDataCustomer = this.objCustomers.getCustomer(Account);
        if (objDataCustomer.Rows.Count > 0)
        {
            this.strCusAccount = Account.ToUpper();
            this.strCusName = objDataCustomer.Rows[0]["Name"].ToString();
            this.strCusAddress = objDataCustomer.Rows[0]["Address"].ToString();
            this.strCusPhone = objDataCustomer.Rows[0]["Phone"].ToString();
            this.strIdCard = objDataCustomer.Rows[0]["IdCard"].ToString();
            this.strCusEmail = objDataCustomer.Rows[0]["Email"].ToString();

            this.lblName.Text = "Họ tên: " + objDataCustomer.Rows[0]["Name"].ToString();
            if (objDataCustomer.Rows[0]["AccountType"].ToString() == "CustomerAccount")
            {
                this.ckbD.Checked = true;
                this.ckbB.Checked = false;
                this.ckbV.Checked = false;

                this.ckbD1.Checked = true;
                this.ckbB1.Checked = false;
                this.ckbV1.Checked = false;
            }
            else if (objDataCustomer.Rows[0]["AccountType"].ToString() == "CustomerAccount1")
            {
                this.ckbD.Checked = false;
                this.ckbB.Checked = true;
                this.ckbV.Checked = false;

                this.ckbD1.Checked = false;
                this.ckbB1.Checked = true;
                this.ckbV1.Checked = false;
            }
            else if (objDataCustomer.Rows[0]["AccountType"].ToString() == "CustomerAccount2")
            {
                this.ckbD.Checked = false;
                this.ckbB.Checked = false;
                this.ckbV.Checked = true;

                this.ckbD1.Checked = false;
                this.ckbB1.Checked = false;
                this.ckbV1.Checked = true;
            }
            this.lblCusAvatar.Text = "<img width = \"150px\" height = \"100px\" src = \"/Images/Customer/" + objDataCustomer.Rows[0]["Avatar"].ToString() + "\">";
        }
    }
    #endregion
}