<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ProductsVIP.aspx.cs" Inherits="ProductsVIP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-6">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    display: table; vertical-align: middle;">
                    SẢN PHẨM BÁN CHẠY VIP
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">Hiện tại có <%Response.Write(this.objTableProductVIP.Rows.Count); %>
                        sản phẩm
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
    <div style="clear: both"></div>
    <div class="container sanpham">
        <%for (int i = 0; i < this.objTableProductVIP.Rows.Count; i++)
          {  %>
        <div class="col-md-3" style="margin-bottom: 10px">
            <div style="background-color: #f9faf5; height: 375px; padding: 5px;">
                <a style="width: 100%" href="/detailt.aspx?id=<%Response.Write(this.objTableProductVIP.Rows[i]["Id"].ToString()); %>">
                    <img style="height: 250px; width: 100%"
                        src="/Images/Products/<%Response.Write(this.objTableProductVIP.Rows[i]["Image"].ToString()); %>"
                        onerror="this.onerror = null; this.src = '../img/noImg.jpg';" alt=" Nổi bật" /></a>
                <p class="ProductLink" style="font-family: Arial; font-size: 15px; font-weight: bold;
                    color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;">
                    <a style="height: 40px; overflow: hidden;" href="/detailt.aspx?id=<%Response.Write(this.objTableProductVIP.Rows[i]["Id"].ToString()); %>">
                        <%Response.Write(this.objTableProductVIP.Rows[i]["Name"].ToString()); %></a>
                </p>
                <div style="text-align: right; margin-top: -2px;">
                    <div style="font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal;
                        padding-top: 0px; padding-left: 25px;">
                        <img src="Images/user.png" alt="So nguoi thich" style="width: 20px; margin-top: -8px;" />
                        <%Response.Write(this.objTableProductVIP.Rows[i]["CountLike"].ToString()); %>
                    </div>
                </div>
                <p style="font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;
                    padding: 5px; text-align: justify; margin-top: -4px;">
                    <span style="font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;">
                        <%Response.Write(this.objTableProductVIP.Rows[i]["Price"].ToString()); %>&nbsp;<sup><u>đ</u></sup></span>
                    <span style="background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat;
                        font-size: 14px; color: #fff;">&nbsp; -
                                <%Response.Write(this.objTableProductVIP.Rows[i]["Discount"].ToString()); %>%
                        &nbsp;</span>
                </p>

                <input type="button" value="Đã mua: <%Response.Write(this.objTableProductVIP.Rows[i]["CountBuy"].ToString()); %>"
                    style="margin-top: -46px;" />
            </div>

        </div>
        <% } %>
    </div>




</asp:Content>

