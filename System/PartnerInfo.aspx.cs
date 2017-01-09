using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_PartnerInfo : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    private Partner objPartner = new Partner();
    private DataProduct objProduct = new DataProduct();

    private int itemId = 0;
    public int SoSanPham = 0, SoSanPhamVIP = 0, SoSanPhamBanChay = 0, SoGiaoDich = 0;
    public double TongDoanhSo = 0;

    public string Message = "";
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
            this.btnCreate.Enabled = false;
            this.btnUpdate.Enabled = false;
        }
        if (this.itemId == 0)
        {
            Response.Redirect("/System/Partner");
        } else if (!Page.IsPostBack)
        {
            this.getPartner();
            this.SoSanPham = this.objProduct.getCountProductByPartnerId(this.itemId);
            this.SoSanPhamVIP = this.objProduct.getProductVIPCountByPartnerId(this.itemId);
            this.SoSanPhamBanChay = this.objProduct.getProductBestSaleCountByPartnerId(this.itemId);
            this.SoGiaoDich = this.objPartner.getProductBillCountByPartnerId(this.itemId);
            this.TongDoanhSo = this.objPartner.getProductDoanhSoByPartnerId(this.itemId);
            
            if (this.txtAccount.Text.Trim() == "")
            {
                this.btnCreate.Enabled = true;
            }
            else
            {
                this.btnCreate.Enabled = false;
            }
            /* */
        }
    } 
    #endregion

    #region method getPartner new 
    public void getPartner()
    {
        DataTable objData = this.objPartner.getPartnerById(this.itemId);
        if (objData.Rows.Count > 0)
        {
            this.lblName.Text = objData.Rows[0]["Name"].ToString();
            this.lblAddress.Text = objData.Rows[0]["Address"].ToString();
            this.lblManager.Text = objData.Rows[0]["Manager"].ToString();
            this.lblPhone.Text = objData.Rows[0]["Phone"].ToString();
            this.lblTaxCode.Text = objData.Rows[0]["TaxCode"].ToString();
            this.txtAccount.Text = objData.Rows[0]["Account"].ToString();
            if (objData.Rows[0]["BestSale"].ToString() == "True")
            {
                this.ckbBestSale.Checked = true;
            }
            else
            {
                this.ckbBestSale.Checked = false;
            }
            if (objData.Rows[0]["VIP"].ToString() == "True")
            {
                this.ckbVIP.Checked = true;
            }
            else
            {
                this.ckbVIP.Checked = false;
            }
            if (objData.Rows[0]["State"].ToString() == "True")
            {
                this.ckbState.Checked = true;
            }
            else
            {
                this.ckbState.Checked = false;
            }
            this.txtMinMaxSale.Text = objData.Rows[0]["MinMaxSales"].ToString();
            this.txtDiscountCard.Text = objData.Rows[0]["DiscountCard"].ToString();
            this.txtDiscountTotal.Text = objData.Rows[0]["DiscountTotal"].ToString();
            this.txtDiscount.Text = objData.Rows[0]["Discount"].ToString();
            this.txtDiscountAdv.Text = objData.Rows[0]["DiscountAdv"].ToString();
            lblImg1.Text = "<img width = \"263px\" height = \"123px\" src = \"/Images/Partner/" + objData.Rows[0]["Image"].ToString() + "\">";
        }
    }
    #endregion

    #region method btnCreate_Click
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        TVSFunc objFunc = new TVSFunc();
        string PartnerAccount = objFunc.getPartnerAccount();

        int ret = objFunc.updatePartnerAccount(this.itemId,PartnerAccount + this.txtAccount.Text);
        if(ret == 0)
        {
            this.txtAccount.Text = PartnerAccount + this.txtAccount.Text;
            this.btnCreate.Enabled = false;

            this.Message = "Cập nhật tài khoản thành công";
        } else if(ret == -1)
        {
            this.Message = objFunc.ErrorMessage;
        } else if(ret == 1)
        {
            this.Message = "Tài khoản đã tồn tại";
        }

        

        /*
        try
        {
            //TVSFunc objFunc = new TVSFunc();
            string PartnerAccount = "";
            PartnerAccount = objFunc.getPartnerAccount();

            Partner pn = new Partner();
            if (pn.updatePartner(itemId, PartnerAccount)<0) return;

            this.txtAccount.Text = PartnerAccount + this.itemId.ToString("0000");
            this.btnCreate.Enabled = false;
          
        }
        catch { }
        /* */
    } 
    #endregion

    #region method btnUpdate_Click
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            this.lblMsg.Text = "";

            if (this.itemId == 0)
            {
                return;
            }

            double tmp1 = 0;
            try
            {
                if (!double.TryParse(this.txtDiscountTotal.Text, out tmp1))
                {
                    this.lblMsg.Text = "Tổng mức chiết khấu, sai định dạng";
                    return;
                }
            }
            catch
            {
                this.lblMsg.Text = "Tổng mức chiết khấu, sai định dạng";
            }
            try
            {
                if (!double.TryParse(this.txtDiscount.Text, out tmp1))
                {
                    this.lblMsg.Text = "Chiết khấu trực tiếp, sai định dạng";
                    return;
                }
            }
            catch
            {
                this.lblMsg.Text = "Chiết khấu trực tiếp, sai định dạng";
            }
            try
            {
                if (!double.TryParse(this.txtDiscountCard.Text, out tmp1))
                {
                    this.lblMsg.Text = "Chiết khấu tích lũy, sai định dạng";
                    return;
                }
            }
            catch
            {
                this.lblMsg.Text = "Chiết khấu tích lũy, sai định dạng";
            }
            try
            {
                if (!double.TryParse(this.txtDiscountAdv.Text, out tmp1))
                {
                    this.lblMsg.Text = "Chiết khấu quảng cáo, sai định dạng";
                    return;
                }
            }
            catch
            {
                this.lblMsg.Text = "Chiết khấu quảng cáo, sai định dạng";
            }
            TVSFunc objFunc = new TVSFunc();
            string CustomerAccount = "";
            CustomerAccount = objFunc.getCustomerAccount("CustomerAccount");

            if  (objPartner.updatePartner(this.itemId,
                  double.Parse(this.txtDiscountTotal.Text),
                  double.Parse(this.txtDiscount.Text),
                  double.Parse(this.txtDiscountAdv.Text),
                  double.Parse(this.txtDiscountCard.Text),
                  double.Parse(this.txtMinMaxSale.Text)) > 0)
            this.lblMsg.Text = "Thông tin đã được cập nhật vào hệ thống.";
        }
        catch(Exception Ex)
        {
            this.lblMsg.Text = Ex.Message;
        }
    }
    #endregion
}