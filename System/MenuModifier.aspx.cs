using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_MenuModifier : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

 
    
        if (!Page.IsPostBack)
        {
            CollectionPager2.MaxPages = 1000;
            CollectionPager2.PageSize = 120;
            CollectionPager2.DataSource = getTopic().DefaultView;
            CollectionPager2.BindToControl = ddlMenu;
            ddlMenu.DataSource = CollectionPager2.DataSourcePaged;
            ddlMenu.DataBind();
        }
    }
   

    #region method getTopic
    public DataTable getTopic()
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
        sqlCon.Open();
        SqlCommand Cmd = sqlCon.CreateCommand();
        Cmd.CommandText = "SELECT 0 AS TT, * FROM tblMenu";
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = Cmd;
        DataSet ds = new DataSet();
        da.Fill(ds);
        sqlCon.Close();
        sqlCon.Dispose();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ds.Tables[0].Rows[i]["TT"] = (i + 1);
        }
        if (ds.Tables[0].Rows.Count < 10)
        {
            this.tblABC.Visible = false;
        }
        return ds.Tables[0];
    }
    #endregion
}