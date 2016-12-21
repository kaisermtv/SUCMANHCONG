using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_Detailt : System.Web.UI.Page
{
    #region declare objects
    private Partner objPartner = new Partner();
    private DataProduct objProduct = new DataProduct();

    public DataTable objTablePartner = new DataTable();
    public DataTable objTable = new DataTable();
    public DataTable objTableSelect = new DataTable();
    private int itemId = 0, itemProductId = 0;

    public string htmtStr = "", htmlCard = "";
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
            this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
            this.objTable = this.objProduct.getProductByIdJoin(this.itemId);

        }
    }



    #endregion

    public string getCard()
    {
        this.objTablePartner = this.objPartner.getPartnerInforById(this.itemId);
        if (this.objTablePartner.Rows.Count > 0)
        {

            htmlCard += "  <div class='sanpham'>     <div class='col-md-3'>" +
                   "<div style='width: 100%; background-color: #f6f6f6; border: solid 1px #c6c6c6;'>" +
                      " <div style='padding: 5px;'>"
                        + "  <h5>THÔNG TIN LIÊN HỆ</h5>" +
                           "Điện thoại:      " + this.objTablePartner.Rows[0]["Phone"].ToString() + "" +
                           "<br />" +
                           "Email:  " + this.objTablePartner.Rows[0]["Email"].ToString() + "" +
                           "<br />" +
                           "Website:www.sucmanhcong.com" +
                       "</div>" +
                        "<img style ='width:98%; padding-left:5px; margin-bottom:10px;' style='width: 100%; height:250px' src ='/Images/Partner/"
                        + this.objTablePartner.Rows[0]["Image"] + "' alt = 'Hinh dai dien' />" +
                  " </div> </div></div> ";
        }
        return htmlCard;
    }

    protected void btnMoicapnhat_Click(object sender, EventArgs e)
    {
        con.Visible = false;
        this.objTableSelect = this.objProduct.getProductByIdWithJoinAndRecentlyUpdate(this.itemId);
        if (this.objTableSelect.Rows.Count > 0)
        {
            int j = 1;
            for (int i = 0; i < this.objTableSelect.Rows.Count; i++)
            {
                if (this.objTableSelect.Rows[i]["Id"].ToString() == "") { break; }
                if (j % 4 == 0 || j == 1)   // hết 1 dòng
                {
                    htmtStr += " <div class='row'>";

                    if (j == 1) { htmtStr += getCard(); }

                }

                htmtStr += " " +
                   " <div class='sanpham'>" +
                    "<div class='col-md-3'>" +
                        "<div style='background-color: #f9faf5; height: 375px; padding: 5px;'/>";
                htmtStr +=
                            "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                                "<img src='/Images/Products/" + this.objTableSelect.Rows[i]["Image"] + "'   style='width: 100%; height:250px' alt='Mới cập nhật'></a>";
                htmtStr +=
                        " <p class='ProductLink' style='font-family: Arial; font-size: 15px; font-weight: bold; height:50px; overflow:hidden  " +
                                "color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;'>";

                htmtStr += "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                     "" + this.objTableSelect.Rows[i]["Name"] + "</a>" +
                           "</p>";
                htmtStr += "<div style='text-align: right; margin-top: -2px;'>" +
                     "<div style='font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal;" +
                         "padding-top: 0px; padding-left: 25px;'>";
                htmtStr += "<img src='../img/User.png' alt='So nguoi thich' style='width: 20px; margin-top: -8px;'>" +
                      "" + this.objTableSelect.Rows[i]["CountLike"] + "" +
                  "</div>" +
                                   "</div>";
                htmtStr += "<p style='font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;" +
                        "padding: 5px; text-align: justify; margin-top: -4px;'>" +
                        "<span style='font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;'>" +
                         "   " + this.objTableSelect.Rows[i]["Price"] + "&nbsp;<sup><u>đ</u></sup></span>";
                htmtStr += "   <span style='background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat;" +
                       "   font-size: 15px; color: #fff;'>&nbsp; -" +
                       "       " + this.objTableSelect.Rows[i]["Discount"] + "%" +
                        "  &nbsp;</span>" +
                                           "  </p>";
                htmtStr += " <input value='Đã mua: 123' style='margin-top: -46px;' type='button'>" +
                               " </div>" +
                                 "</div></div>";
                if (j % 5 == 0 || j == 0)
                {
                    htmtStr += " </div>";

                }

                j++;
            }

        }
    }
    protected void btnHotnhat_Click(object sender, EventArgs e)
    {
        con.Visible = false;

        this.objTableSelect = this.objProduct.getProductByIdWithJoinAndSortByPrice(this.itemId);
        if (this.objTableSelect.Rows.Count > 0)
        {
            int j = 1;
            for (int i = 0; i < this.objTableSelect.Rows.Count; i++)
            {
                if (this.objTableSelect.Rows[i]["Id"].ToString() == "") { break; }
                if (j % 4 == 0 || j == 1)   // hết 1 dòng
                {
                    htmtStr += " <div class='row'>";

                    if (j == 1) { htmtStr += getCard(); }

                }

                htmtStr += " " +
                   " <div class='sanpham'>" +
                    "<div class='col-md-3'>" +
                        "<div style='background-color: #f9faf5; height: 375px; padding: 5px;'/>";
                htmtStr +=
                            "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                                "<img src='/Images/Products/" + this.objTableSelect.Rows[i]["Image"] + "'   style='width: 100%; height:250px' alt='Mới cập nhật'></a>";
                htmtStr +=
                        " <p class='ProductLink' style='font-family: Arial; font-size: 15px; font-weight: bold; height:50px; overflow:hidden  " +
                                "color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;'>";

                htmtStr += "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                     "" + this.objTableSelect.Rows[i]["Name"] + "</a>" +
                           "</p>";
                htmtStr += "<div style='text-align: right; margin-top: -2px;'>" +
                     "<div style='font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal;" +
                         "padding-top: 0px; padding-left: 25px;'>";
                htmtStr += "<img src='../img/User.png' alt='So nguoi thich' style='width: 20px; margin-top: -8px;'>" +
                      "" + this.objTableSelect.Rows[i]["CountLike"] + "" +
                  "</div>" +
                                   "</div>";
                htmtStr += "<p style='font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;" +
                        "padding: 5px; text-align: justify; margin-top: -4px;'>" +
                        "<span style='font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;'>" +
                         "   " + this.objTableSelect.Rows[i]["Price"] + "&nbsp;<sup><u>đ</u></sup></span>";
                htmtStr += "   <span style='background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat;" +
                       "   font-size: 15px; color: #fff;'>&nbsp; -" +
                       "       " + this.objTableSelect.Rows[i]["Discount"] + "%" +
                        "  &nbsp;</span>" +
                                           "  </p>";
                htmtStr += " <input value='Đã mua: 123' style='margin-top: -46px;' type='button'>" +
                               " </div>" +
                                 "</div></div>";
                if (j % 5 == 0 || j == 0)
                {
                    htmtStr += " </div>";

                }

                j++;
            }

        }
    }
    protected void btnGiaTot_Click(object sender, EventArgs e)
    {
        con.Visible = false;
        this.objTableSelect = this.objProduct.getProductByIdWithJoinAndSortByPriceAsc(this.itemId);
        if (this.objTableSelect.Rows.Count > 0)
        {
            int j = 1;
            for (int i = 0; i < this.objTableSelect.Rows.Count; i++)
            {
                if (this.objTableSelect.Rows[i]["Id"].ToString() == "") { break; }
                if (j % 4 == 0 || j == 1)   // hết 1 dòng
                {
                    htmtStr += " <div class='row'>";

                    if (j == 1) { htmtStr += getCard(); }

                }

                htmtStr += " " +
                   " <div class='sanpham'>" +
                    "<div class='col-md-3'>" +
                        "<div style='background-color: #f9faf5; height: 375px; padding: 5px;'/>";
                htmtStr +=
                            "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                                "<img src='/Images/Products/" + this.objTableSelect.Rows[i]["Image"] + "'   style='width: 100%; height:250px' alt='Mới cập nhật'></a>";
                htmtStr +=
                        " <p class='ProductLink' style='font-family: Arial; font-size: 15px; font-weight: bold; height:50px; overflow:hidden  " +
                                "color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;'>";

                htmtStr += "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                     "" + this.objTableSelect.Rows[i]["Name"] + "</a>" +
                           "</p>";
                htmtStr += "<div style='text-align: right; margin-top: -2px;'>" +
                     "<div style='font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal;" +
                         "padding-top: 0px; padding-left: 25px;'>";
                htmtStr += "<img src='../img/User.png' alt='So nguoi thich' style='width: 20px; margin-top: -8px;'>" +
                      "" + this.objTableSelect.Rows[i]["CountLike"] + "" +
                  "</div>" +
                                   "</div>";
                htmtStr += "<p style='font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;" +
                        "padding: 5px; text-align: justify; margin-top: -4px;'>" +
                        "<span style='font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;'>" +
                         "   " + this.objTableSelect.Rows[i]["Price"] + "&nbsp;<sup><u>đ</u></sup></span>";
                htmtStr += "   <span style='background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat;" +
                       "   font-size: 15px; color: #fff;'>&nbsp; -" +
                       "       " + this.objTableSelect.Rows[i]["Discount"] + "%" +
                        "  &nbsp;</span>" +
                                           "  </p>";
                htmtStr += " <input value='Đã mua: 123' style='margin-top: -46px;' type='button'>" +
                               " </div>" +
                                 "</div></div>";
                if (j % 5 == 0 || j == 0)
                {
                    htmtStr += " </div>";

                }

                j++;
            }

        }
    }
  
    protected void btnGiamGia_Click(object sender, EventArgs e)
    {
        con.Visible = false;
        this.objTableSelect = this.objProduct.getProductByIdWithJoinAndSortByDiscount(this.itemId);
        if (this.objTableSelect.Rows.Count > 0)
        {
            int j = 1;
            for (int i = 0; i < this.objTableSelect.Rows.Count; i++)
            {
                if (this.objTableSelect.Rows[i]["Id"].ToString() == "") { break; }
                if (j % 4 == 0 || j == 1)   // hết 1 dòng
                {
                    htmtStr += " <div class='row'>";

                    if (j == 1) { htmtStr += getCard(); }

                }

                htmtStr += " " +
                   " <div class='sanpham'>" +
                    "<div class='col-md-3'>" +
                        "<div style='background-color: #f9faf5; height: 375px; padding: 5px;'/>";
                htmtStr +=
                            "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                                "<img src='/Images/Products/" + this.objTableSelect.Rows[i]["Image"] + "'   style='width: 100%; height:250px' alt='Mới cập nhật'></a>";
                htmtStr +=
                        " <p class='ProductLink' style='font-family: Arial; font-size: 15px; font-weight: bold; height:50px; overflow:hidden  " +
                                "color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;'>";

                htmtStr += "<a href='/detailt.aspx?id=" + this.objTableSelect.Rows[i]["Id"] + "'>" +
                     "" + this.objTableSelect.Rows[i]["Name"] + "</a>" +
                           "</p>";
                htmtStr += "<div style='text-align: right; margin-top: -2px;'>" +
                     "<div style='font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal;" +
                         "padding-top: 0px; padding-left: 25px;'>";
                htmtStr += "<img src='../img/User.png' alt='So nguoi thich' style='width: 20px; margin-top: -8px;'>" +
                      "" + this.objTableSelect.Rows[i]["CountLike"] + "" +
                  "</div>" +
                                   "</div>";
                htmtStr += "<p style='font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;" +
                        "padding: 5px; text-align: justify; margin-top: -4px;'>" +
                        "<span style='font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;'>" +
                         "   " + this.objTableSelect.Rows[i]["Price"] + "&nbsp;<sup><u>đ</u></sup></span>";
                htmtStr += "   <span style='background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat;" +
                       "   font-size: 15px; color: #fff;'>&nbsp; -" +
                       "       " + this.objTableSelect.Rows[i]["Discount"] + "%" +
                        "  &nbsp;</span>" +
                                           "  </p>";
                htmtStr += " <input value='Đã mua: 123' style='margin-top: -46px;' type='button'>" +
                               " </div>" +
                                 "</div></div>";
                if (j % 5 == 0 || j == 0)
                {
                    htmtStr += " </div>";

                }

                j++;
            }

        }

    }
}