<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductsBestSale.aspx.cs" Inherits="ProductsBestSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-6">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase; display: table; vertical-align: middle;">
                    SẢN PHẨM BÁN CHẠY
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">
                        Hiện tại có <%Response.Write(this.objTableProductBestSale.Rows.Count); %> sản phẩm
                    </span>
                </div>
            </div>
            <div class="col-md-6">
                <div style="float: right;">
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-warning">Mới cập nhật</button>
                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-success">Hot nhất</button>
                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-info">Giá tốt</button>
                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-primary">Sắp hết hạn</button>
                    </div>
                    <div style="float: right;">
                        <button type="button" class="btn btn-secondary">Giảm giá</button>
                    </div>
                </div>
            </div>
        </div>
        <hr />
    </div>
    <div class="container">
            <% int k = 1;  %>
        <%for (int i = 0; i < this.objTableProductBestSale.Rows.Count; i++)
          {  %>
        <% if (k % 4 == 0 || k == 1)   // hết 1 dòng
           {
               Response.Write(" <div class='row'>");
           }
        %>
        <div class="sanpham">
            <div class="col-md-3">
                <div style="background-color: #f9faf5; height: 375px; padding: 5px;">
                    <a href="/detailt.aspx?id=<%Response.Write(this.objTableProductBestSale.Rows[i]["Id"].ToString()); %>">
                        <img src="images/Products/<%Response.Write(this.objTableProductBestSale.Rows[i]["Image"].ToString()); %>"
                            alt=" Nổi bật" /></a>
                    <p class="ProductLink" style="font-family: Arial; font-size: 15px; font-weight: bold;
                        color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;">
                        <a href="/detailt.aspx?id=<%Response.Write(this.objTableProductBestSale.Rows[i]["Id"].ToString()); %>">
                            <%Response.Write(this.objTableProductBestSale.Rows[i]["Name"].ToString()); %></a>
                    </p>
                    <div style="text-align: right; margin-top: -2px;">
                        <div style="font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal;
                            padding-top: 0px; padding-left: 25px;">
                            <img src="images/User.png" alt="So nguoi thich" style="width: 20px; margin-top: -8px;" />
                            122
                        </div>
                    </div>
                    <p style="font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;
                        padding: 5px; text-align: justify; margin-top: -4px;">
                        <span style="font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;">
                            <%Response.Write(this.objTableProductBestSale.Rows[i]["Price"].ToString()); %>&nbsp;<sup><u>đ</u></sup></span>
                        <span style="background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat;
                            font-size: 15px; color: #fff;">&nbsp; -
                                <%Response.Write(this.objTableProductBestSale.Rows[i]["Discount"].ToString()); %>%
                            &nbsp;</span>
                    </p>

                    <input type="button" value="Đã mua: 123" style="margin-top: -46px;" />
                </div>

            </div>
        </div>
        <%  %>
        <% if (k % 4 == 0 || k == 0)   // hết 1 dòng
           {
               Response.Write(" </div>");
           }
           k++;
                      }  %>
    </div>

    <div class="row" style="margin-left: 45%">
        <div class="col-md-2">
            <div class="sotrang">
                <table>
                    <tr>
                        <td><a href="" style="move-to: normal"><i class="fa fa-angle-left"></i></a></td>
                        <td><a href="">1</a></td>
                        <td><a href="">2</a></td>
                        <td><a href="">3</a></td>
                        <td><a href="">All</a></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>


</asp:Content>

