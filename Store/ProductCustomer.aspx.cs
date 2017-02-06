using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_ProductCustomer : System.Web.UI.Page
{
    #region declare objects
    public DataTable objTableProduct = new DataTable();
    private Partner objPartner = new Partner();
    private Partner objPartner2 = new Partner();
    private Customers objCustomers = new Customers();
    private DataProduct objProduct = new DataProduct();
    //temp table
    private DataTable TemptblPartnerBill = new DataTable();
    private DataTable TemptblPartnerBillDetailOrther = new DataTable();
    private DataTable TemptblPartnerBillDetail = new DataTable();
    private DataTable TemptblCustomersPaymentByCard = new DataTable();

    public string strHtml = "", strValue = "", strCurrBillId = "", strhtmlbill = "", strhtmlbillNoDiscount = "";
    public string strName = "", strAddress = "", strPhone = "", strManager = "", strEmail = "", strTaxcode = "", strAccount = "", strBestSale = "", strVIP = "", strMsg = "", strDiscount = "-", strDiscountCard = "-", strDiscountAdv = "-", strCustomerTotalDiscountCard = "0";
    public string strCusAccount = "", strCusName = "", strCusAddress = "", strCusPhone = "", strIdCard = "", strCusEmail = "";
    public static int count = 0; public static int postback = 0; public static string strCusAccountType = "";
    public static string otpCode = "";
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("/");
        }
        if (!Page.IsPostBack)
        {
            this.getPartner();
           this.getProduct(Session["ACCOUNT"].ToString());
        }
        this.strDiscount = "-";
        this.strDiscountCard = "-";
        this.strDiscountAdv = "-";
    }
    #endregion

    #region method setPartnerBill
    public int setPartnerBill(bool PaymentByCard, int tempTable = 0)
    {
        this.lblMsg1.Text = "";

        #region Test input
        if (this.txtAccount.Value.ToString() == "")
        {
            this.lblMsg1.Text = "Chưa xác định thông tin khách hàng";
            return 0;
        }
        string CustomerAccount = txtAccount.Value.ToString();

        string PartnerAccount = Session["ACCOUNT"].ToString();
        this.getPartnerInforByAccount(PartnerAccount);


        if (this.txtTotalMoney.Value.ToString().Trim() == "")
        {
            this.lblMsg1.Text = "Chưa xác định tổng tiền đơn hàng";
            return 0;
        }
        float TotalMoney = 0;
        try
        {
            TotalMoney = float.Parse(this.txtTotalMoney.Value.ToString().Trim());
        }
        catch
        {
            this.lblMsg1.Text = "Tổng tiền đơn hàng sai định dạng";
            return 0;
        }

        if (this.txtTotalMoneyDiscount.Text == "")
        {
            this.lblMsg1.Text = "Chưa xác định tổng tiền được hưởng giảm giá của đơn hàng";
            return 0;
        }
        float TotalMoneyDiscount = 0;
        try
        {
            TotalMoneyDiscount = float.Parse(this.txtTotalMoneyDiscount.Text.Trim());
        }
        catch
        {
            this.lblMsg1.Text = "Tổng tiền được hưởng giảm giá sai định dạng";
            return 0;
        }

        if (this.strDiscount == "")
        {
            this.lblMsg1.Text = "Chưa xác định mức giảm giá trực tiếp cho khách hàng";
            return 0;
        }

        float Discount = 0;
        try
        {
            Discount = float.Parse(this.strDiscount);
        }
        catch
        {
            this.lblMsg1.Text = "Mức giảm giá trực tiếp cho khách hàng sai định dạng";
            return 0;
        }

        if (this.strDiscountCard == "")
        {
            this.lblMsg1.Text = "Chưa xác định mức giảm giá tích luỹ thẻ cho khách hàng";
            return 0;
        }
        float DiscountCard = 0;
        try
        {
            DiscountCard = float.Parse(this.strDiscountCard);
        }
        catch
        {
            this.lblMsg1.Text = "Mức giảm giá cho tích luỹ thẻ sai định dạng";
            return 0;
        }


        if (this.strDiscountAdv == "")
        {
            this.lblMsg1.Text = "Chưa xác định mức giảm giá cho quảng cáo";
            return 0;
        }
        float DiscountAdv = 0;
        try
        {
            DiscountAdv = float.Parse(this.strDiscountAdv);
        }
        catch
        {
            this.lblMsg1.Text = "Mức giảm giá cho quảng cáo sai định dạng";
            return 0;
        }

        if (this.txtTotalMoneyPayment.Text == "")
        {
            this.lblMsg1.Text = "Chưa xác định số tiền cần thanh toán";
            return 0;
        }
        float TotalPeyment = 0;
        try
        {
            TotalPeyment = float.Parse(this.txtTotalMoneyPayment.Text.Trim());
        }
        catch
        {
            this.lblMsg1.Text = " Số tiền cần thanh toán sai định dạng";
            return 0;
        }
        #endregion

        string BillId = "";
        int ret = 0;
        //
        try
        {
            if (tempTable == 1) { ret = updateTempTable(CustomerAccount, PartnerAccount, TotalMoney, TotalMoneyDiscount, Discount, DiscountCard, DiscountAdv, TotalPeyment); }
            else
            {
                ret = objPartner.setPartnerBill(CustomerAccount, PartnerAccount, TotalMoney, TotalMoneyDiscount, Discount, DiscountCard, DiscountAdv, TotalPeyment);
            }
        }
        catch { return 0; }
        //
        if (ret != 0)
        {
            BillId = ret.ToString();

            #region Luu chi tiet hoa don chinh thuc
            try
            {
                NameValueCollection nvc = Request.Form;
                if (nvc.Count > 0)
                {
                    foreach (string s in nvc)
                        foreach (string v in nvc.GetValues(s))
                        {
                            if (s.Contains("txt#"))
                            {
                                if (v.Trim() != "")
                                {
                                    string[] arr = s.Split('#');
                                    //
                                    try
                                    {
                                        if (tempTable == 1) { setTempBillDetail(BillId, arr[1], "", arr[2], v); }
                                        else { objPartner.setPartnerBillDetail(BillId, arr[1], "", arr[2], v); }
                                    }
                                    catch { return 0; }
                                    //
                                }
                            }
                        }
                }
            }
            catch { return 0; }
            #endregion

            #region Luu chi tiet hoa don phu
            if (this.txtProductName1.Text.Trim() != "" && this.txtProductNumber1.Text.Trim() != "" && this.txtProductPrice1.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder1.Text, this.txtProductName1.Text, this.txtProductPrice1.Text, this.txtProductNumber1.Text); }
                    else { objPartner.setPartnerBillDetailOther(BillId, this.txtOrder1.Text, this.txtProductName1.Text, this.txtProductPrice1.Text, this.txtProductNumber1.Text); }
                }
                catch
                {

                }
            }

            if (this.txtProductName2.Text.Trim() != "" && this.txtProductNumber2.Text.Trim() != "" && this.txtProductPrice2.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder2.Text, this.txtProductName2.Text, this.txtProductPrice2.Text, this.txtProductNumber2.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder2.Text, this.txtProductName2.Text, this.txtProductPrice2.Text, this.txtProductNumber2.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName3.Text.Trim() != "" && this.txtProductNumber3.Text.Trim() != "" && this.txtProductPrice3.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder3.Text, this.txtProductName3.Text, this.txtProductPrice3.Text, this.txtProductNumber3.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder3.Text, this.txtProductName3.Text, this.txtProductPrice3.Text, this.txtProductNumber3.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName4.Text.Trim() != "" && this.txtProductNumber4.Text.Trim() != "" && this.txtProductPrice4.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder4.Text, this.txtProductName4.Text, this.txtProductPrice4.Text, this.txtProductNumber4.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder4.Text, this.txtProductName4.Text, this.txtProductPrice4.Text, this.txtProductNumber4.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName5.Text.Trim() != "" && this.txtProductNumber5.Text.Trim() != "" && this.txtProductPrice5.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder5.Text, this.txtProductName5.Text, this.txtProductPrice5.Text, this.txtProductNumber5.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder5.Text, this.txtProductName5.Text, this.txtProductPrice5.Text, this.txtProductNumber5.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName6.Text.Trim() != "" && this.txtProductNumber6.Text.Trim() != "" && this.txtProductPrice6.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder6.Text, this.txtProductName6.Text, this.txtProductPrice6.Text, this.txtProductNumber6.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder6.Text, this.txtProductName6.Text, this.txtProductPrice6.Text, this.txtProductNumber6.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName7.Text.Trim() != "" && this.txtProductNumber7.Text.Trim() != "" && this.txtProductPrice7.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder7.Text, this.txtProductName7.Text, this.txtProductPrice7.Text, this.txtProductNumber7.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder7.Text, this.txtProductName7.Text, this.txtProductPrice7.Text, this.txtProductNumber7.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName8.Text.Trim() != "" && this.txtProductNumber8.Text.Trim() != "" && this.txtProductPrice8.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder8.Text, this.txtProductName8.Text, this.txtProductPrice8.Text, this.txtProductNumber8.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder8.Text, this.txtProductName8.Text, this.txtProductPrice8.Text, this.txtProductNumber8.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName9.Text.Trim() != "" && this.txtProductNumber9.Text.Trim() != "" && this.txtProductPrice9.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder9.Text, this.txtProductName9.Text, this.txtProductPrice9.Text, this.txtProductNumber9.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder9.Text, this.txtProductName9.Text, this.txtProductPrice9.Text, this.txtProductNumber9.Text);
                    }
                }
                catch
                {

                }
            }

            if (this.txtProductName10.Text.Trim() != "" && this.txtProductNumber10.Text.Trim() != "" && this.txtProductPrice10.Text.Trim() != "")
            {
                try
                {
                    if (tempTable == 1) { setTempPartnerBillDetailOther(BillId, this.txtOrder10.Text, this.txtProductName10.Text, this.txtProductPrice10.Text, this.txtProductNumber10.Text); }
                    else
                    {
                        objPartner.setPartnerBillDetailOther(BillId, this.txtOrder10.Text, this.txtProductName10.Text, this.txtProductPrice10.Text, this.txtProductNumber10.Text);
                    }
                }
                catch
                {

                }
            }

            #endregion

            if (PaymentByCard)
            {
                try
                {
                    switch (tempTable)
                    {
                        case 0: { ret = objPartner.setCustomersPaymentByCard(BillId, TotalMoney, CustomerAccount); break; }
                        case 1: { ret = setTempCustomersPaymentByCard(BillId, TotalMoney, CustomerAccount); break; }
                        default: break;
                    }
                }
                catch { return 0; }
            }


            this.strCurrBillId = BillId;
            this.lblMsg1.Text = "Thanh toán thành công đơn hàng!";
            this.btnSave.Disabled = true;
            this.btnSaveByCard.Disabled = true;
            this.getPartnerBillById(this.strCurrBillId);
            this.getProduct(Session["ACCOUNT"].ToString());
            this.btnCalTotalMoney.Disabled = true;
            this.PrintBill(BillId);
            return 1;
        }
        else
        {
            this.lblMsg1.Text = "Có lỗi xãy ra . Mời thử lại!";
            return 0;
        }

    }
    #endregion

    #region method PrintBill
    protected void PrintBill(string BillId)
    {
        try
        {
            this.getPartner();
            this.getCustomerInfo();
            this.btnPrint.Disabled = false;

            this.tongtienhang.InnerText = this.txtTotalMoney.Value.ToString().Trim();
            this.tonggiamgia.InnerText = this.txtTotalMoneyDiscount.Text;
            this.tienphaitra.InnerText = this.txtTotalMoneyPayment.Text;

            // bảng  khuyến mãi

            DataTable data = objPartner.getPartnerBillDetail(BillId);

            string str = "";
            int stt = 0;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                str += "<tr>";
                str += "<td>" + (++stt).ToString() + "</td>";
                str += "<td>" + data.Rows[i]["Name"] + "</td>";

                double intnum = double.Parse(data.Rows[i]["ProductNumber"].ToString());
                double intPrice = double.Parse(data.Rows[i]["ProductPrice"].ToString());

                str += "<td>" + intnum.ToString() + "</td>";
                str += "<td>" + intPrice.ToString() + "</td>";
                str += "<td>" + (intnum * intPrice).ToString() + "</td>";
                str += "</tr>";
            }
            strhtmlbill = str;

            // bảng ko khuyến mãi

            string strNoDiscount = "";
            int intBillId = Int32.Parse(BillId);
            DataTable data2 = objPartner2.getPartnerBillDetailOtherById(intBillId);

            for (int i = 0; i < data2.Rows.Count; i++)
            {
                strNoDiscount += "<tr>";
                strNoDiscount += "<td>" + (++stt).ToString() + "</td>";
                strNoDiscount += "<td>" + data2.Rows[i]["ProductName"] + "</td>";

                double intnum = double.Parse(data2.Rows[i]["ProductNumber"].ToString());
                double intPrice = double.Parse(data2.Rows[i]["ProductPrice"].ToString());

                strNoDiscount += "<td>" + intnum.ToString() + "</td>";
                strNoDiscount += "<td>" + intPrice.ToString() + "</td>";
                strNoDiscount += "<td>" + (intnum * intPrice).ToString() + "</td>";
                strNoDiscount += "</tr>";
            }
            strhtmlbillNoDiscount = strNoDiscount;
            btnAdd.Enabled = true;
        }
        catch
        {

        }
    }
    #endregion

    #region method getPartnerInforByAccount
    public void getPartnerInforByAccount(string Account)
    {

        DataTable ret = objPartner.getPartnerInforByAccount(Account);

        if (ret.Rows.Count > 0)
        {
            this.strDiscount = ret.Rows[0]["Discount"].ToString();
            this.strDiscountCard = ret.Rows[0]["DiscountCard"].ToString();
            this.strDiscountAdv = ret.Rows[0]["DiscountAdv"].ToString();
        }

    }
    #endregion

    #region method getCustomerInfo
    public void getCustomerInfo()
    {
        this.lblMsg1.Text = "-:-";
        if (this.txtAccount.Value.Trim() == "")
        {
            this.lblMsg1.Text = "Nhập số thẻ khách hàng";
        }
        bool AccountValid = false;

        DataTable objCusomerInfo = new DataTable();
        objCusomerInfo = this.objCustomers.getCustomer(this.txtAccount.Value.ToString());

        if (objCusomerInfo.Rows.Count > 0)
        {

            this.strCusAccount = this.txtAccount.Value.ToString().ToUpper();
            this.strCusName = objCusomerInfo.Rows[0]["Name"].ToString();
            this.strCusAddress = objCusomerInfo.Rows[0]["Address"].ToString();
            this.strCusPhone = objCusomerInfo.Rows[0]["Phone"].ToString();
            this.strIdCard = objCusomerInfo.Rows[0]["IdCard"].ToString();
            this.strCusEmail = objCusomerInfo.Rows[0]["Email"].ToString();
            strCusAccountType = objCusomerInfo.Rows[0]["AccountType"].ToString();
            this.lblName.Text = "<a href=\"#\" rel=\"balloon1\">" + objCusomerInfo.Rows[0]["Name"].ToString() + "&nbsp;&nbsp;|&nbsp;&nbsp;" + this.strCusAccount + "</a>";
            if (objCusomerInfo.Rows[0]["AccountType"].ToString() == "CustomerAccount")
            {
                this.ckbD.Checked = true;
                this.ckbB.Checked = false;
                this.ckbV.Checked = false;

                this.ckbD1.Checked = true;
                this.ckbB1.Checked = false;
                this.ckbV1.Checked = false;

            }
            else if (objCusomerInfo.Rows[0]["AccountType"].ToString() == "CustomerAccount1")
            {
                this.ckbD.Checked = false;
                this.ckbB.Checked = true;
                this.ckbV.Checked = false;

                this.ckbD1.Checked = false;
                this.ckbB1.Checked = true;
                this.ckbV1.Checked = false;

            }
            else if (objCusomerInfo.Rows[0]["AccountType"].ToString() == "CustomerAccount2")
            {
                this.ckbD.Checked = false;
                this.ckbB.Checked = false;
                this.ckbV.Checked = true;

                this.ckbD1.Checked = false;
                this.ckbB1.Checked = false;
                this.ckbV1.Checked = true;

            }
            this.lblCusAvatar.Text = "<img width = \"85px\" height = \"113px\" src = \"http://khachhang.sucmanhcong.com/Images/Customer/" + objCusomerInfo.Rows[0]["Avatar"].ToString() + "\">";
            AccountValid = true;
        }

        if (AccountValid)
        {
            this.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
            this.getProduct(Session["ACCOUNT"].ToString());
            this.strCustomerTotalDiscountCard = String.Format("{0:0,0}", this.getCustomerTotalDiscountCard(this.txtAccount.Value.ToString().Trim()));
            if (this.strCustomerTotalDiscountCard.Trim() == "00")
            {
                this.strCustomerTotalDiscountCard = "0";
            }
            this.txtAccount.Disabled = true;
            this.btnViewCustomer.Enabled = false;
            //this.btnCaculatorMoney.Enabled = true;
            this.txtTotalMoney.Disabled = false;
            this.txtTotalMoneyDiscount.ReadOnly = false;
        }
        else
        {
            this.lblMsg1.Text = "Số thẻ khách hàng không hợp lệ!";
        }
    }
    #endregion

    #region method getPartnerBillById
    public void getPartnerBillById(string billId)
    {
        if (billId == "")
        {
            billId = "0";
        }
        DataTable objTable = this.objPartner.getPartnerBillById(billId);

        if (objTable.Rows.Count > 0)
        {
            this.txtTotalMoney.Value = String.Format("{0:0,0}", double.Parse(objTable.Rows[0]["TotalMoney"].ToString()));
            this.txtTotalMoneyDiscount.Text = String.Format("{0:0,0}", double.Parse(objTable.Rows[0]["TotalMoneyDiscount"].ToString()));
            this.txtTotalMoneyPayment.Text = String.Format("{0:0,0}", double.Parse(objTable.Rows[0]["TotalPeyment"].ToString()));
        }
    }
    #endregion

    #region method getProduct
    public void getProduct(string Account)
    {

        this.objTableProduct = this.objProduct.getDataByPartner(Account);


        if (this.objTableProduct.Rows.Count > 0)
        {
            strHtml = "<form>";
            for (int i = 0; i < this.objTableProduct.Rows.Count; i++)
            {
                if (i == 0)
                {
                    strHtml += "<div style =\"width:100%; margin-top:1px;\">";

                    strHtml += "<div style=\"width: 8%; float: left; border:solid 1px #f3f1f1; border-right:none; text-align:center;height:30px;line-height:30px;\">";
                    strHtml += this.objTableProduct.Rows[i]["TT"].ToString();
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 74%; float: left; border:solid 1px #f3f1f1;padding-left:6px; overflow:hidden; height:30px;line-height:30px;\" id=\"txtName" + i.ToString() + "\" >";
                    strHtml += this.objTableProduct.Rows[i]["Name"].ToString();
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 8%; float: left; border:solid 1px #f3f1f1;overflow:hidden; height:30px;line-height:30px; text-align:right;\">";
                    strHtml += "<input class = \"tvsInput\" type =\"text\" id = \"txtNumber" + i.ToString() + "\" name = \"txt#" + this.objTableProduct.Rows[i]["Id"].ToString() + "#" + this.objTableProduct.Rows[i]["Price"].ToString() + "\" value =\"" + this.objPartner.getPartnerBillProductNumber(this.strCurrBillId, this.objTableProduct.Rows[i]["Id"].ToString()) + "\" style =\"color:#000; text-align:right; padding-right:5px;\"/>";
                    strHtml += "</div>";

                    strHtml += "<div id=\"txtInput\" style=\"width: 10%; float: right; border:solid 1px #f3f1f1; overflow:hidden; height:30px;line-height:30px; text-align:right;\">";
                    strHtml += "<input class = \"tvsInput\" type =\"text\" id = \"txtPrice" + i.ToString() + "\" value = \"" + String.Format("{0:0,0}", double.Parse(this.objTableProduct.Rows[i]["Price"].ToString())) + "\" style = \"text-align:right; padding-right:5px;\" readonly = \"readonly\">";
                    strHtml += "</div>";

                    strHtml += "</div>";
                }
                else
                {
                    strHtml += "<div style =\"width:100%; margin-top:1px;\">";

                    strHtml += "<div style=\"width: 8%; float: left; border:solid 1px #f3f1f1; border-right:none; border-top:none;text-align:center;height:30px;line-height:30px;\">";
                    strHtml += this.objTableProduct.Rows[i]["TT"].ToString();
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 74%; float: left; border:solid 1px #f3f1f1;padding-left:6px; overflow:hidden; height:30px;line-height:30px;\" id=\"txtName" + i.ToString() + "\" >";
                    strHtml += this.objTableProduct.Rows[i]["Name"].ToString();
                    strHtml += "</div>";

                    strHtml += "<div style=\"width: 8%; float: left; border:solid 1px #f3f1f1;overflow:hidden; height:30px;line-height:30px; text-align:right;\">";
                    strHtml += "<input class = \"tvsInput\" type =\"text\" id = \"txtNumber" + i.ToString() + "\" name = \"txt#" + this.objTableProduct.Rows[i]["Id"].ToString() + "#" + this.objTableProduct.Rows[i]["Price"].ToString() + "\" value =\"" + this.objPartner.getPartnerBillProductNumber(this.strCurrBillId, this.objTableProduct.Rows[i]["Id"].ToString()) + "\" style =\"color:#000; text-align:right; padding-right:5px;\"/>";
                    strHtml += "</div>";

                    strHtml += "<div id=\"txtInput\" style=\"width: 10%; float: right; border:solid 1px #f3f1f1;overflow:hidden; height:30px;line-height:30px; text-align:right;\">";
                    strHtml += "<input class = \"tvsInput\" type =\"text\" id = \"txtPrice" + i.ToString() + "\" value = \"" + String.Format("{0:0,0}", double.Parse(this.objTableProduct.Rows[i]["Price"].ToString())) + "\" style = \"text-align:right; padding-right:5px;\" readonly = \"readonly\">";
                    strHtml += "</div>";

                    strHtml += "</div>";
                }
            }
            strHtml += "</form>";

            this.txtTotalItem.Value = this.objTableProduct.Rows.Count.ToString();
        }

      
    }
    #endregion

    #region method btnViewCustomer_Click
    protected void btnViewCustomer_Click(object sender, EventArgs e)
    {
        this.getCustomerInfo();
            if(strCusAccountType == "CustomerAccount")
            {
                btnSaveByCard.Disabled = true;
                Page.ClientScript.RegisterStartupScript(GetType(),"warn","confirm('Lưu ý : Khách hàng hạng Đồng không thể giao dịch bằng thẻ SMC.')",true);
            }
    }
    #endregion

    #region method btnCaculatorMoney_Click
    protected void btnCaculatorMoney_Click(object sender, EventArgs e)
    {
        this.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
        this.lblMsg1.Text = "";
        if (this.txtTotalMoney.Value.ToString().Trim() == "")
        {
            this.lblMsg1.Text = "Chưa xác định tổng tiền đơn hàng";
            return;
        }
        if (this.txtTotalMoneyDiscount.Text == "")
        {
            this.lblMsg1.Text = "Chưa xác định tổng tiền được hưởng giảm giá của đơn hàng";
            return;
        }
        if (this.strDiscount == "")
        {
            this.lblMsg1.Text = "Chưa xác định mức giảm giá của cửa hàng";
            return;
        }
        try
        {
            if (double.Parse(this.txtTotalMoneyDiscount.Text) > double.Parse(this.txtTotalMoney.Value.ToString().Trim()))
            {
                this.lblMsg1.Text = "Tổng tiền chiết khấu lớn hơn tổng tiền hoá đơn";
                return;
            }

            double tmpTodalMoneyDiscount = 0;
            tmpTodalMoneyDiscount = double.Parse(this.txtTotalMoneyDiscount.Text) * double.Parse(this.strDiscount) / 100;
            this.txtTotalMoneyPayment.Text = (double.Parse(this.txtTotalMoney.Value.ToString().Trim()) - tmpTodalMoneyDiscount).ToString();
            this.btnSave.Disabled = false;

        }
        catch
        {

        }

        if (this.strDiscountCard.Trim() != "")
        {
            try
            {
                this.strCustomerTotalDiscountCard = String.Format("{0:0,0}", this.getCustomerTotalDiscountCard(this.txtAccount.Value.ToString().Trim()));
                if (this.strCustomerTotalDiscountCard.Trim() == "00")
                {
                    this.strCustomerTotalDiscountCard = "0";
                }
                if (double.Parse(this.strCustomerTotalDiscountCard) >= double.Parse(this.txtTotalMoneyPayment.Text))
                {
                    this.btnSaveByCard.Disabled = false;
                }
            }
            catch
            {
                this.btnSaveByCard.Disabled = true;
            }
        }
        this.getProduct(Session["ACCOUNT"].ToString());

     

    }
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objTable = this.objPartner.getPartnerInforByAccount(Session["ACCOUNT"].ToString());

        if (objTable.Rows.Count > 0)
        {
            this.strName = objTable.Rows[0]["Name"].ToString();
            this.strAddress = objTable.Rows[0]["Address"].ToString();
            this.strManager = objTable.Rows[0]["Manager"].ToString();
            this.strPhone = objTable.Rows[0]["Phone"].ToString();
            this.strEmail = objTable.Rows[0]["Email"].ToString();
            this.strTaxcode = objTable.Rows[0]["TaxCode"].ToString();
            this.strAccount = objTable.Rows[0]["Account"].ToString();

            this.strDiscount = objTable.Rows[0]["Discount"].ToString();
            this.strDiscountCard = objTable.Rows[0]["DiscountCard"].ToString();
            this.strDiscountAdv = objTable.Rows[0]["DiscountAdv"].ToString();

            if (objTable.Rows[0]["BestSale"].ToString() == "True")
            {
                this.strBestSale = "X";
            }
            else
            {
                this.strBestSale = "";
            }
            if (objTable.Rows[0]["VIP"].ToString() == "True")
            {
                this.strVIP = "X";
            }
            else
            {
                this.strVIP = "";
            }
        }

    }
    #endregion

    #region method getCustomerTotalDiscountCard
    public double getCustomerTotalDiscountCard(string CustomerAccount)
    {
        double tmpValue = 0, tmpValue1 = 0;
        tmpValue = this.objPartner.getDiscountPartnerBillByCustomerAccount(CustomerAccount);
        tmpValue1 = this.objCustomers.getCustomerPaymentCallByCustomerAccount(CustomerAccount);

        tmpValue = tmpValue - tmpValue1;
        return tmpValue;
    }
    #endregion

    #region RandomString
    private string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }
    #endregion

    #region method btnSaveBill_Click
    protected void btnSaveBill_Click(object sender, EventArgs e)
    {
        if(postback!=1)
        { 
        int exec = this.setPartnerBill(false); // 0/1
        }
        else
        {
           saveToTrust();
           btnAdd.Enabled = true;
        }
    }
    #endregion

    #region AcceptUseOTP()
    protected void senddingOTP()
    {
        this.txtOTPCode.Disabled = false;
        this.txtOTPCode.Value = "";
        otpCode = RandomString(5, false);
        DataTable objCusomerInfo = new DataTable();
        int x = setPartnerBill(true, 1);
        if (this.objCustomers.setCustomers_SMS_OTP(txtAccount.Value.ToString(), Session["ACCOUNT"].ToString(), otpCode) == 1)
        {
            string ret = this.SendSMS(this.objCustomers.getCustomer(this.txtAccount.Value.ToString()).Rows[0]["Phone"].ToString(), "Mã xác nhận từ SMC : " + otpCode);
            this.btnSave.Disabled = true;
            this.btnSaveByCard.Disabled = false;
            this.txtOTPCode.Disabled = false;
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msg", "confirm('Mã OTP đã được gửi <TEST : " + otpCode + "> ');", true);
            this.lblMsg1.Text = "Mã OTP đã được gửi";
        }
        else
        {
            this.btnSave.Disabled = false;
            this.btnSaveByCard.Disabled = false;
            this.txtOTPCode.Disabled = false;
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "msg", "confirm('Tin nhắn OTP chưa được gửi đi ,Xin vui lòng thực hiện lại thao tác .');", true);
            this.lblMsg1.Text = "Mời thử lại";
            return;
        }
    }


    #endregion

    #region method btnSaveByCard_Click
    protected void btnSaveByCard_Click(object sender, EventArgs e)
    {
        
        senddingOTP();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalsms').modal('show');</script>", false);
    }
    #endregion

    #region clear_both()
    public void clear()
    {
        this.lblMsg1.Text = "-:-";
        this.btnViewCustomer.Enabled = true;
        this.txtAccount.Disabled = false;
        this.lblName.Text = "-:-";
        this.txtAccount.Value = "";
        this.txtTotalMoney.Value = "";
        this.txtTotalMoneyDiscount.Text = "";
        this.strDiscount = "";
        this.strDiscountCard = "";
        this.strDiscountAdv = "";

        this.ckbD.Checked = false;
        this.ckbD1.Checked = false;
        this.ckbB.Checked = false;
        this.ckbB1.Checked = false;
        this.ckbV.Checked = false;
        this.ckbV1.Checked = false;

        this.txtTotalMoneyPayment.Text = "";

        #region Thong tin cho hang hoa thong thuong

        this.txtProductName1.Text = "";
        this.txtProductName2.Text = "";
        this.txtProductName3.Text = "";
        this.txtProductName4.Text = "";
        this.txtProductName5.Text = "";
        this.txtProductName6.Text = "";
        this.txtProductName7.Text = "";
        this.txtProductName8.Text = "";
        this.txtProductName9.Text = "";
        this.txtProductName10.Text = "";

        this.txtProductPrice1.Text = "";
        this.txtProductPrice2.Text = "";
        this.txtProductPrice3.Text = "";
        this.txtProductPrice4.Text = "";
        this.txtProductPrice5.Text = "";
        this.txtProductPrice6.Text = "";
        this.txtProductPrice7.Text = "";
        this.txtProductPrice8.Text = "";
        this.txtProductPrice9.Text = "";
        this.txtProductPrice10.Text = "";

        #endregion

        this.btnSave.Disabled = true;
        this.btnSaveByCard.Disabled = true;
        this.getPartnerInforByAccount(Session["ACCOUNT"].ToString());
        this.getProduct(Session["ACCOUNT"].ToString());
        this.btnCalTotalMoney.Disabled = false;
    }
    #endregion

    #region method btnAdd_Click || Xóa trắng
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clear();
    }
    #endregion

    #region Code for SMS Send

    const string APIKey = "dd42853687E0826254B37E23102810B0"; //Dang ky tai khoan tai esms.vn de lay key//Register account at esms.vn to get key
    const string SecretKey = "đdF37072E46541B48EA32B7723F6019B";

    #region method SendSMS
    public string SendSMS(string phone, string message)
    {

        string url = "http://api.esms.vn/MainService.svc/xml/SendMultipleMessage_V2/";
        // declare ascii encoding
        UTF8Encoding encoding = new UTF8Encoding();

        string strResult = string.Empty;



        string customers = "";

        string[] lstPhone = phone.Split(',');

        for (int i = 0; i < lstPhone.Count(); i++)
        {
            customers = customers + @"<CUSTOMER>"
                            + "<PHONE>" + lstPhone[i] + "</PHONE>"
                            + "</CUSTOMER>";
        }

        try
        {

            string SampleXml = @"<RQST>"
                               + "<APIKEY>" + APIKey + "</APIKEY>"
                               + "<SECRETKEY>" + SecretKey + "</SECRETKEY>"
                               + "<ISFLASH>0</ISFLASH>"
                               + "<SMSTYPE>7</SMSTYPE>"//SMSTYPE 3: đầu số ngẫu nhiên tốc độ chậm, SMSTYPE=7: đầu số ngẫu nhiên tốc độ cao, SMSTYPE=4: Đầu số 19001534; SMSTYpe=6: đàu số 8755                               
                               + "<CONTENT>" + message + "</CONTENT>"
                               + "<CONTACTS>" + customers + "</CONTACTS>"


           + "</RQST>";
            //Tham khao them ve SMSTYPE tai day: http://esms.vn/SMSApi/ApiSendSMSNormal


            string postData = SampleXml.Trim().ToString();
            // convert xmlstring to byte using ascii encoding
            byte[] data = encoding.GetBytes(postData);
            // declare httpwebrequet wrt url defined above
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            // set method as post
            webrequest.Method = "POST";
            webrequest.Timeout = 500000;
            // set content type
            webrequest.ContentType = "application/x-www-form-urlencoded";
            // set content length
            webrequest.ContentLength = data.Length;
            // get stream data out of webrequest object
            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            // declare & read response from service
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            // set utf8 encoding
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            // read response stream from response object
            StreamReader loResponseStream =
                new StreamReader(webresponse.GetResponseStream(), enc);
            // read string from stream data
            strResult = loResponseStream.ReadToEnd();
            // close the stream object
            loResponseStream.Close();
            // close the response object
            webresponse.Close();
            // below steps remove unwanted data from response string
            strResult = strResult.Replace("</string>", "");

            return strResult;
        }
        catch
        {
            return "";
        }
    }

    #endregion

    #endregion

    #region btnSubmitClick
    protected void btnSubmitOTP_Click(object sender, EventArgs e)
    {
        DataTable ret = this.objCustomers.getCustomers_SMS_OTP(txtAccount.Value.ToString(), Session["ACCOUNT"].ToString(), this.txtOTPCode.Value.ToString(), "00:01:00.000");

        if (ret.Rows.Count > 0)
        {
             DataTable TemptblPartnerBill2 = ViewState["TemptblPartnerBill"] as DataTable;
             double money = this.objCustomers.getCustomerTotalDiscountCard(txtAccount.Value.ToString());  // -- this.objCustomers.getSalesCardByCustomerAccout(txtAccount.Value.ToString()) ??
             float TotalPeyment = float.Parse(TemptblPartnerBill2.Rows[0]["TotalPeyment"].ToString());
             if (money <= TotalPeyment)
               {
                lblMsg.Text = "SÔ DƯ TÀI KHOẢN KHÔNG ĐỦ ĐỂ GIAO DỊCH     .   (Nhấp vào mục phía dưới xem thông tin để hiện số dư).";
              //  clear();
            postback = 1;
            this.btnSave.Disabled = false;
            this.btnPrint.Disabled = true;
            btnSaveByCard.Disabled = true;
            btnAdd.Enabled = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#Message').modal('show');</script>", false);
            return;
            }
            else
            {
                // matched OTP    -> insert data form viewstate to server
                saveToTrust();
                this.btnSaveByCard.Disabled = true;
                count = 0;
                lblMsg.Text = " GIAO DỊCH THÀNH CÔNG , CẢM ƠN QUÝ KHÁCH ";
                getCustomerInfo();
                this.btnSave.Disabled = true;
               
            }
            this.btnSave.Disabled = true;
            btnAdd.Enabled = true;
            this.btnPrint.Disabled = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#Message').modal('show');</script>", false);
            return;
        }
        else
        {
            count ++;
            this.btnSave.Disabled = true;
            this.txtOTPCode.Disabled = false;
            if (count >= 3) { this.btnPrint.Disabled = true; this.btnSaveByCard.Disabled = true; clear(); Response.Redirect("/Default.aspx"); return; }
            lblwarning.InnerText = "  OTP không hợp lệ , Số lần còn lại : " + (3 - count) + ".  ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalsms').modal('show');</script>", false);
            return;
        }
    }

    #endregion

    // BẢNG TẠM
    #region menthod create temp table for wait OTP suport || create -> INSERT -> DELETE

    #region method createTempTable
    public int updateTempTable(string CustomerAccount, string PartnerAccount, float TotalMoney, float TotalMoneyDiscount, float Discount, float DiscountCard, float DiscountAdv, float TotalPeyment)
    {
        try
        {

            TemptblPartnerBill.Columns.AddRange(new DataColumn[8]{ new DataColumn("CustomerAccount"),
                new DataColumn("PartnerAccount"),new DataColumn("TotalMoney"),new DataColumn("TotalMoneyDiscount"),new DataColumn("Discount"),
                new DataColumn("DiscountCard"), new DataColumn("DiscountAdv"), new DataColumn("TotalPeyment"), 
                    });
            TemptblPartnerBill.Rows.Add(CustomerAccount, PartnerAccount, TotalMoney, TotalMoneyDiscount, Discount, DiscountCard, DiscountAdv, TotalPeyment);
            ViewState["TemptblPartnerBill"] = TemptblPartnerBill;

            return 1;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region method setTempBillDetail ||
    public int setTempBillDetail(string BillId, string ProductId, string ProductName, string ProductPrice, string ProductNumber)
    {
        try
        {
            TemptblPartnerBillDetail.Columns.AddRange(new DataColumn[5]{ new DataColumn("BillId"),
                new DataColumn("ProductId"),new DataColumn("ProductName"),new DataColumn("ProductPrice"),new DataColumn("ProductNumber")
                    });

            TemptblPartnerBillDetail.Rows.Add(BillId, ProductId, ProductName, ProductPrice, ProductNumber);
            ViewState["TemptblPartnerBillDetail"] = TemptblPartnerBillDetail;
            return 1;

        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region method setTempPartnerBillDetailOther
    public int setTempPartnerBillDetailOther(string BillId, string ProductId, string ProductName, string ProductPrice, string ProductNumber)
    {
        try
        {
            TemptblPartnerBillDetailOrther.Columns.AddRange(new DataColumn[5]{ new DataColumn("BillId"),
                new DataColumn("ProductId"),new DataColumn("ProductName"),new DataColumn("ProductPrice"),new DataColumn("ProductNumber") });
            TemptblPartnerBillDetailOrther.Rows.Add(BillId, ProductId, ProductName, ProductPrice, ProductNumber);
            ViewState["TemptblPartnerBillDetailOrther"] = TemptblPartnerBillDetailOrther;
            return 1;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region method setTempCustomersPaymentByCard
    public int setTempCustomersPaymentByCard(string BillId, float TotalMoney, string CustomerAccount)
    {
        try
        {
            TemptblCustomersPaymentByCard.Columns.AddRange(new DataColumn[3]{ new DataColumn("BillId"),
                new DataColumn("TotalMoney"),new DataColumn("CustomerAccount") });
            TemptblCustomersPaymentByCard.Rows.Add(BillId, TotalMoney, CustomerAccount);
            ViewState["TemptblCustomersPaymentByCard"] = TemptblCustomersPaymentByCard;
            return 1;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region saveTemptoTrust
    public void saveToTrust()
    {
        int billId = -1;
        DataTable rowPartnerBill = ViewState["TemptblPartnerBill"] as DataTable;
        try
        {
            string CustomerAccount = rowPartnerBill.Rows[0]["CustomerAccount"].ToString();
            string PartnerAccount = rowPartnerBill.Rows[0]["PartnerAccount"].ToString();
            float TotalMoney = float.Parse(rowPartnerBill.Rows[0]["TotalMoney"].ToString());
            float TotalMoneyDiscount = float.Parse(rowPartnerBill.Rows[0]["TotalMoneyDiscount"].ToString());
            float Discount = float.Parse(rowPartnerBill.Rows[0]["Discount"].ToString());
            float DiscountCard = float.Parse(rowPartnerBill.Rows[0]["DiscountCard"].ToString());
            float DiscountAdv = float.Parse(rowPartnerBill.Rows[0]["DiscountAdv"].ToString());
            float TotalPeyment = float.Parse(rowPartnerBill.Rows[0]["TotalPeyment"].ToString());
          billId =  objPartner.setPartnerBill(CustomerAccount, PartnerAccount, TotalMoney, TotalMoneyDiscount, Discount, DiscountCard, DiscountAdv, TotalPeyment);
        }
        catch
        {
            lblMsg.Text = " ERROR 404 ";
        }
        DataTable TemptblPartnerBillDetailOrther2 = ViewState["TemptblPartnerBillDetailOrther"] as DataTable;
        try
        {
            for (int i = 0; i < TemptblPartnerBillDetailOrther2.Rows.Count; i++)
            {
                objPartner.setPartnerBillDetailOther(billId.ToString(), TemptblPartnerBillDetailOrther2.Rows[i]["ProductId"].ToString()
                                                    , TemptblPartnerBillDetailOrther2.Rows[i]["ProductName"].ToString(), TemptblPartnerBillDetailOrther2.Rows[i]["ProductPrice"].ToString(),
                                                    TemptblPartnerBillDetailOrther2.Rows[i]["ProductNumber"].ToString());
            }
        }
        catch
        {
         //   lblMsg.Text = " ERROR 404 ";
        }
        DataTable TemptblPartnerBillDetail2 = ViewState["TemptblPartnerBillDetail"] as DataTable;
        try
        {

            for (int i = 0; i < TemptblPartnerBillDetail2.Rows.Count; i++)
            {
                string x = TemptblPartnerBillDetail2.Rows[i]["ProductId"].ToString();
                objPartner.setPartnerBillDetail(billId.ToString(), TemptblPartnerBillDetail2.Rows[i]["ProductId"].ToString(),
                    "", TemptblPartnerBillDetail2.Rows[i]["ProductPrice"].ToString(), TemptblPartnerBillDetail2.Rows[i]["ProductNumber"].ToString());
            }
        }
        catch
        {
           // lblMsg.Text = " ERROR 404 ";
        }
        DataTable TemptblCustomersPaymentByCard2 = ViewState["TemptblCustomersPaymentByCard"] as DataTable;
        try
        {
            objPartner.setCustomersPaymentByCard(billId.ToString(), float.Parse(TemptblCustomersPaymentByCard2.Rows[0]["TotalMoney"].ToString()), TemptblCustomersPaymentByCard2.Rows[0]["CustomerAccount"].ToString());
        }
        catch
        {
           lblMsg.Text = " ERROR 404 ";
        }

        this.PrintBill(billId.ToString());         //IN hoa don san sang 
        btnAdd.Enabled = false;
        lblMsg.Text = " Hóa đơn đả sẵn sàng ";
    }

    #endregion


    #endregion



}