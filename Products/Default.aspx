<%@ Page Title="SẢN PHẨM" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Products_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div class="container sanpham">
        <%for (int i = 0; i < this.objTableProductVIP.Rows.Count; i++){  %>
        
            <div class="col-md-3" style="margin-bottom:10px">
                <div style="background-color: #f9faf5; height: 375px; padding: 5px;">
                    <a style="width: 100%" href="/detailt.aspx?id=<%Response.Write(this.objTableProductVIP.Rows[i]["Id"].ToString()); %>">
                        <img style="height: 250px; width: 100%" src="/images/Products/<%Response.Write(this.objTableProductVIP.Rows[i]["Image"].ToString()); %>"
                            alt=" Nổi bật" /></a>
                    <p class="ProductLink" style="font-family: Arial; font-size: 15px; font-weight: bold; color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;">
                        <a style="height: 40px; overflow: hidden;" href="/detailt.aspx?id=<%Response.Write(this.objTableProductVIP.Rows[i]["Id"].ToString()); %>">
                            <%Response.Write(this.objTableProductVIP.Rows[i]["Name"].ToString()); %></a>
                    </p>

                    <div style="text-align: right; margin-top: -2px;">
                        <div style="font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal; padding-top: 0px; padding-left: 25px;">
                            <img src="/images/User.png" alt="So nguoi thich" style="width: 20px; margin-top: -8px;" />
                             <%Response.Write(this.objTableProductVIP.Rows[i]["CountLike"].ToString()); %>
                        </div>
                    </div>
                    <p style="font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a; padding: 5px; text-align: justify; margin-top: -4px;">
                        <span style="font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;">
                            <%Response.Write(this.objTableProductVIP.Rows[i]["Price"].ToString()); %>&nbsp;<sup><u>đ</u></sup></span>
                        <span style="background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat; font-size: 15px; color: #fff;"><small>&nbsp; -
                                    <%Response.Write(this.objTableProductVIP.Rows[i]["Discount"].ToString()); %>% &nbsp;</small></span>
                    </p>
                <input type="button" value="Đã mua:    <%Response.Write(this.objTableProductVIP.Rows[i]["CountBuy"].ToString()); %>" style="margin-top: -46px;" />
            </div>

            </div>
        
        <% } %> 
</div>


    <div class="row" style="margin-left:45%" >
     <div class="col-md-2">
                    <div class="sotrang">
                        <table>
                            <tr>
                                <td><a href="" style="move-to:normal"><i class="fa fa-angle-left"></i></a></td>
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

