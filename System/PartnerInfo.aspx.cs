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
        if (!Page.IsPostBack)
        {
            this.getPartner();
            this.SoSanPham = this.objProduct.getCountProductById(this.itemId);
            this.SoSanPhamVIP = this.objProduct.getProductVIPCountById(this.itemId);
            this.SoSanPhamBanChay = this.objProduct.getProductBestSaleCountById(this.itemId);
            this.SoGiaoDich = this.getProductBillCountById(this.itemId.ToString());
            this.TongDoanhSo = this.getProductDoanhSoById(this.itemId.ToString());
            if (this.txtAccount.Text.Trim() == "")
            {
                this.btnCreate.Enabled = true;
            }
            else
            {
                this.btnCreate.Enabled = false;
            }
        }
    } 
    #endregion

    #region method getPartner
    public void getPartner()
    {
        DataTable objData = this.objPartner.getPartnerById(this.itemId);
        if(objData.Rows.Count > 0)
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
        try
        {
            if (this.itemId == 0)
            {
                return;
            }
            TVSFunc objFunc = new TVSFunc();
            string PartnerAccount = "";
            PartnerAccount = objFunc.getPartnerAccount();
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "UPDATE tblPartner SET Account = @Account, DayCreate = getdate(), AccountPass = '123123' WHERE Id = @Id";
            Cmd.Parameters.Add("Account", SqlDbType.NVarChar).Value = PartnerAccount + this.itemId.ToString("0000");
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = this.itemId;
            Cmd.ExecuteNonQuery();
            this.txtAccount.Text = PartnerAccount + this.itemId.ToString("0000");
            this.btnCreate.Enabled = false;
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch { }
    } 
    #endregion



    #region method getProductBillCountById
    public int getProductBillCountById(string PartnerId)
    {
        int CountItem = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblPartnerCustomer WHERE PartnerId = @PartnerId";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            CountItem = ds.Tables[0].Rows.Count;
        }
        catch
        {

        }
        return CountItem;
    }
    #endregion

    #region method getProductDoanhSoById
    public double getProductDoanhSoById(string PartnerId)
    {
        double TotalMoney = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT SUM(Price*Number) AS TotalMoney FROM tblPartnerCustomer WHERE PartnerId = @PartnerId";
            Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            if (ds.Tables[0].Rows.Count > 0)
            {
                TotalMoney = double.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
        }
        catch
        {

        }
        return TotalMoney;
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
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "UPDATE tblPartner SET DiscountTotal = @DiscountTotal, Discount = @Discount, DiscountAdv = @DiscountAdv, DiscountCard = @DiscountCard WHERE Id = @Id";
            Cmd.Parameters.Add("DiscountTotal", SqlDbType.Float).Value = this.txtDiscountTotal.Text;
            Cmd.Parameters.Add("Discount", SqlDbType.Float).Value = this.txtDiscount.Text;
            Cmd.Parameters.Add("DiscountAdv", SqlDbType.Float).Value = this.txtDiscountAdv.Text;
            Cmd.Parameters.Add("DiscountCard", SqlDbType.Float).Value = this.txtDiscountCard.Text;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = this.itemId;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            this.lblMsg.Text = "Thông tin đã được cập nhật vào hệ thống.";
        }
        catch(Exception Ex)
        {
            this.lblMsg.Text = Ex.Message;
        }
    }
    #endregion
}