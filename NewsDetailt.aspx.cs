using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsDetailt : System.Web.UI.Page
{
    #region declare objects
    public DataTopic objTopic = new DataTopic();

    public DataTable objTable = new DataTable();
    public DataTable objTableFull = new DataTable();

    public string GroupName = "";
    public int GroupId = 0;
    private int itemId = 0;
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
            Response.Redirect("/");
            this.itemId = 0;
        }
        if (!Page.IsPostBack)
        {
            this.objTable = this.objTopic.getTopicById(this.itemId);
            if (this.objTable.Rows.Count == 0)
            {
                Response.Redirect("/");
            } else
            {
                this.GroupId = Int32.Parse(this.objTable.Rows[0]["GroupId"].ToString());
                DataTable group = this.objTopic.getGroupTopicById(this.GroupId);
                if (group.Rows.Count > 0)
                {
                    this.GroupName = group.Rows[0]["Name"].ToString();
                }


                //this.objTableFull = this.getTopicFull(this.itemId.ToString());

                CollectionPager2.MaxPages = 1000;
                CollectionPager2.PageSize = 120;
                CollectionPager2.DataSource = this.getTopicFull().DefaultView;
                CollectionPager2.BindToControl = DataList2;
                DataList2.DataSource = CollectionPager2.DataSourcePaged;
                DataList2.DataBind();
            }
            

        }
    } 
    #endregion

    #region method getTopicFull
    public DataTable getTopicFull()
    {
        DataTable ret = this.objTopic.getTopic(this.GroupId);
        for (int i = 0; i < ret.Rows.Count; i++)
        {
            ret.Rows[i]["DayCreate1"] = DateTime.Parse(ret.Rows[i]["DayCreate"].ToString()).ToString("dd/MM/yyyy");
        }

        if (ret.Rows.Count < 120)
        {
            this.tblABC.Visible = false;
        }

        return ret;
    } 
    #endregion

}