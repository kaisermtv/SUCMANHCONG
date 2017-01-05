using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_CustomerInfo : System.Web.UI.Page
{
    #region declare objects
    private Customers objCustomers = new Customers();
    private DataProduct objProducts= new DataProduct();

    private TVSFunc objFunc = new TVSFunc();
    private int itemId = 0;
    public int SoGiaoDich = 0;
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
        }
        if (!Page.IsPostBack)
        {
            this.getCustomer();
            this.SoGiaoDich = this.getProductBillCountById(this.itemId.ToString());
            this.TongDoanhSo = this.getProductDoanhSoById(this.itemId.ToString());
            if (this.txtAccount.Text.Trim() == "")
            {
                this.btnCreate.Enabled = true;
            }
            else
            {
                this.btnCreate.Enabled = false;
                this.ddlTypeCard.Enabled = false;
                this.txtAccount.ReadOnly = true;
            }
        }
    } 
    #endregion

    #region method getCustomer
    public void getCustomer()
    {
        DataTable objData = this.objCustomers.getCustomerById(this.itemId);
        if(objData.Rows.Count > 0)
        {
            this.lblName.Text = objData.Rows[0]["Name"].ToString();
            this.lblAddress.Text = "Địa chỉ: " + objData.Rows[0]["Address"].ToString();
            this.lblPhone.Text = "Điện thoại : " + objData.Rows[0]["Phone"].ToString();
            try
            {
                this.lblBirthday.Text = "Ngày sinh : " + DateTime.Parse(objData.Rows[0]["Birthday"].ToString()).ToString("dd/MM/yyyy");
            }
            catch { }
            this.lblEmail.Text = "Email : " + objData.Rows[0]["Email"].ToString();
            this.lblIdCard.Text = "Số CMND : " + objData.Rows[0]["IdCard"].ToString();
            this.txtAccount.Text = objData.Rows[0]["Account"].ToString();
            this.lblAvatar.Text = "<img width = \"125px\" height = \"100px\" alt = \"Hình đại diện\" src = \"/Images/Customer/" + objData.Rows[0]["Avatar"].ToString() + "\">";
            this.ddlTypeCard.SelectedValue = objData.Rows[0]["AccountType"].ToString();
        }
    }
    #endregion

    #region method btnCreate_Click
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (this.itemId == 0)
        {
            return;
        }

        string CustomerAccount = this.objFunc.getCustomerAccount(this.ddlTypeCard.SelectedValue.ToString());

        string strCardNumber = "";
        if (this.txtAccount.Text.Trim() == "")
        {
            strCardNumber = this.itemId.ToString("000000");
        }
        else
        {
            strCardNumber = this.txtAccount.Text.Trim();
        }

        int ret = this.objFunc.updateCustomerAccount(this.itemId, CustomerAccount + strCardNumber, this.ddlTypeCard.SelectedValue.ToString());
        if (ret > 0)
        {
            this.txtAccount.Text = CustomerAccount + strCardNumber;
            this.btnCreate.Enabled = false;
        }
    }
    #endregion

    #region method getProductCountById
    public int getProductCountById(string PartnerId)
    {
        try{
            int id = Int32.Parse(PartnerId);

            return this.objProducts.getCountProductByPartnerId(id);
        } catch {
            return 0;
        }
    }
    #endregion

    #region method getProductVIPCountById
    public int getProductVIPCountById(string PartnerId)
    {
        try{
            int id = Int32.Parse(PartnerId);

            return this.objProducts.getProductVIPCountByPartnerId(id);
        } catch {
            return 0;
        }
    }
    #endregion

    #region method getProductBestSaleCountById
    public int getProductBestSaleCountById(string PartnerId)
    {
        try{
            int id =  Int32.Parse(PartnerId);

            return this.objProducts.getProductBestSaleCountByPartnerId(id);
        } catch {
            return 0;
        }
    }
    #endregion

    #region method getProductBillCountById
    public int getProductBillCountById(string PartnerId)
    {
        int CountItem = 0;
        try
        {
            //SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            //sqlCon.Open();
            //SqlCommand Cmd = sqlCon.CreateCommand();
            //Cmd.CommandText = "SELECT * FROM tblPartnerCustomer WHERE PartnerId = @PartnerId";
            //Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = Cmd;
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //sqlCon.Close();
            //sqlCon.Dispose();
            //CountItem = ds.Tables[0].Rows.Count;
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
            //SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            //sqlCon.Open();
            //SqlCommand Cmd = sqlCon.CreateCommand();
            //Cmd.CommandText = "SELECT SUM(Price*Number) AS TotalMoney FROM tblPartnerCustomer WHERE PartnerId = @PartnerId";
            //Cmd.Parameters.Add("PartnerId", SqlDbType.Int).Value = PartnerId;
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = Cmd;
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //sqlCon.Close();
            //sqlCon.Dispose();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    TotalMoney = double.Parse(ds.Tables[0].Rows[0][0].ToString());
            //}
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
        //try
        //{
        //    if (this.itemId == 0 || this.txtDiscountCard.Text.Trim() == "")
        //    {
        //        return;
        //    }
        //    TVSFunc objFunc = new TVSFunc();
        //    string CustomerAccount = "";
        //    CustomerAccount = objFunc.getCustomerAccount();
        //    SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        //    sqlCon.Open();
        //    SqlCommand Cmd = sqlCon.CreateCommand();
        //    Cmd.CommandText = "UPDATE tblCustomers SET DiscountCard = @DiscountCard WHERE Id = @Id";
        //    Cmd.Parameters.Add("DiscountCard", SqlDbType.NVarChar).Value = this.txtDiscountCard.Text;
        //    Cmd.Parameters.Add("Id", SqlDbType.Int).Value = this.itemId;
        //    Cmd.ExecuteNonQuery();
        //    sqlCon.Close();
        //    sqlCon.Dispose();
        //}
        //catch { }
    } 
    #endregion
}