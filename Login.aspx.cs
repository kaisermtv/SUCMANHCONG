using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    #region declare objects
    private TVSFunc objFunc = new TVSFunc();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();

        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT * FROM tblAccount";
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);

        Partner objPartner = new Partner();
        Customers objCustomers = new Customers();

        for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
        {
            int type = (int)ds.Tables[0].Rows[i]["Acct_Type"];
            if (type == 0)
            {
                DataRowCollection objRow = objPartner.getPartnerInforByAccount(ds.Tables[0].Rows[i]["Acct_Name"].ToString()).Rows;
                if (objRow.Count > 0)
                {
                    Cmd = sqlCon.CreateCommand();
                    Cmd.CommandText = "UPDATE [tblAccount] SET [Acct_PGKEY] = @id WHERE [Acct_Name] = @acct";
                    Cmd.Parameters.Add("id", SqlDbType.Int).Value = (int)objRow[0]["Id"];
                    Cmd.Parameters.Add("acct", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i]["Acct_Name"].ToString();
                    Cmd.ExecuteNonQuery();

                }
            }
            else if (type == 1)
            {
                DataRowCollection objRow = objCustomers.getCustomerByAccount(ds.Tables[0].Rows[i]["Acct_Name"].ToString()).Rows;
                if (objRow.Count > 0)
                {
                    Cmd = sqlCon.CreateCommand();
                    Cmd.CommandText = "UPDATE [tblAccount] SET [Acct_PGKEY] = @id  WHERE [Acct_Name] = @acct";
                    Cmd.Parameters.Add("id", SqlDbType.Int).Value = (int)objRow[0]["Id"];
                    Cmd.Parameters.Add("acct", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i]["Acct_Name"].ToString();
                    Cmd.ExecuteNonQuery();
                }
            }

        }


         sqlCon.Close();
         sqlCon.Dispose();

         /**/

        

        Session["ACCOUNT"] = null;

        if (Page.IsPostBack)
        {
            if (this.txtAccount.Value.ToString() == "")
            {
                this.lblMsg.Text = "Tên đăng nhập không hợp lệ";
                return;
            }
            if (this.txtPassWord.Value.ToString() == "")
            {
                this.lblMsg.Text = "Mật khẩu nhập không hợp lệ";
                return;
            }

            DataTable accout = this.GetAccount(this.txtAccount.Value.ToString());
            if (accout.Rows.Count == 0)
            {
                this.lblMsg.Text = "Tài khoản không tồn tại";
                return;
            }

            if (accout.Rows[0]["Acct_Pass"].ToString() != this.objFunc.CryptographyMD5(this.txtPassWord.Value.ToString()))
            {
                this.lblMsg.Text = "Mật khẩu không chính xác";
                return;
            }


            int type = (int)accout.Rows[0]["Acct_Type"];
            if (type == 0)
            {

                Partner objPartner = new Partner();
                DataRowCollection objRow = objPartner.getPartnerInforByAccount(accout.Rows[0]["Acct_Name"].ToString()).Rows;
                if (objRow.Count > 0)
                {
                    if ((bool)objRow[0]["State"])
                    {
                        Session["ACCOUNT"] = accout.Rows[0]["Acct_Name"].ToString();
                        Response.Redirect("/Store");
                    } else
                    {
                        this.lblMsg.Text = "tài khoản của bạn chưa được kích hoạt. Xin liên hệ với quản lý để xử lý!";
                        return;
                    }
                } else
                {
                    this.lblMsg.Text = "Có lỗi xảy ra với tài khoản này. Xin liên hệ với quản lý để xử lý!";
                    return;
                }

                
            }
            else if (type == 1)
            {
                Customers objCustomers = new Customers();
                DataRowCollection objRow = objCustomers.getCustomerByAccount(accout.Rows[0]["Acct_Name"].ToString()).Rows;
                if (objRow.Count > 0)
                {
                    if ((bool)objRow[0]["State"])
                    {
                        Session["ACCOUNT"] = accout.Rows[0]["Acct_Name"].ToString();
                        Response.Redirect("/Customer");
                    }
                    else
                    {
                        this.lblMsg.Text = "tài khoản của bạn chưa được kích hoạt. Xin liên hệ với quản lý để xử lý!";
                        return;
                    }
                }
                else
                {
                    this.lblMsg.Text = "Có lỗi xảy ra với tài khoản này. Xin liên hệ với quản lý để xử lý!";
                    return;
                }
            }
        }
        /**/
    }
    #endregion

    #region method GetAccount
    protected DataTable GetAccount(string account)
    {
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT * FROM tblAccount WHERE Acct_Name = @account";
            Cmd.Parameters.Add("account", SqlDbType.NVarChar).Value = account;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            return ds.Tables[0];
        }
        catch
        {
            return new DataTable();
        }
    }
    #endregion

}