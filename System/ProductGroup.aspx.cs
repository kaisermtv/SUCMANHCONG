﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductGroup : System.Web.UI.Page
{
    #region declare objects
    private DataProduct objProduct = new DataProduct();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CollectionPager2.MaxPages = 1000;
            CollectionPager2.PageSize = 120;
            CollectionPager2.DataSource = getProductGroup().DefaultView;
            CollectionPager2.BindToControl = DataList2;
            DataList2.DataSource = CollectionPager2.DataSourcePaged;
            DataList2.DataBind();
        }
    }
    #endregion

    #region method getProductGroup
    public DataTable getProductGroup()
    {
        DataTable objData = this.objProduct.getProductGroup();
        if (objData.Rows.Count < 120)
        {
            this.tblABC.Visible = false;
        }
        return objData;
    }
    #endregion
}