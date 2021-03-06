﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Detailt.aspx.cs" Inherits="Store_Detailt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div  class="container">
        <div class="row" style="margin-top: 20px;">
            <div id="div-detailt-1" class="col-md-6">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    display: table; vertical-align: middle;">
                    <% if (this.objTablePartner.Rows.Count > 0) Response.Write(this.objTablePartner.Rows[0]["Name"].ToString()); else Response.Write("&nbsp;"); %>
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">
                        <% if (this.objTablePartner.Rows.Count > 0) Response.Write(this.objTablePartner.Rows[0]["Address"].ToString()); else Response.Write("&nbsp;"); %>
                    </span>
                </div>
            </div>
            <div id="div-detailt-2"  class="col-md-6">
                <div style="float: right;">
                    <div style="float: left; margin-right: 8px;">
                        <asp:Button type="button" ID="btnMoicapnhat" class="btn btn-primary " runat="server"
                            OnClick="btnMoicapnhat_Click" Text="Mới cập nhật" />
                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <asp:Button type="button" ID="btnHotnhat" class="btn btn-success" runat="server"
                            OnClick="btnHotnhat_Click" Text="Hot nhất" />

                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <asp:Button type="button" ID="btnGiaTot" class="btn btn-info " runat="server" OnClick="btnGiaTot_Click"
                            Text="Giá tốt" />
                    </div>
                  
                    <div style="float: right; margin-right: 8px;">
                        <asp:Button type="button" ID="btnGiamGia" class="btn btn-danger " runat="server"
                            OnClick="btnGiamGia_Click" Text="Giảm giá nhiều" />

                    </div>

                </div>
            </div>
        </div>
        <hr />
    </div>


    
    <div class="container">

        
        <div style="width: 100%; margin: auto; display: table; margin-bottom: 10px; margin-top: 0px;">
            <div class="sanpham"> 
                  <div id="contentRight2" runat="server" class="col-md-7" style="float: right; width: 75%; height: 100%; vertical-align: top;  margin-left:-30px;
                        text-align: justify;">
                        
                       <%for (int i = 0; i < this.objTableRight.Rows.Count; i++)
                         {  %>
                    <div class="col-md-4" style="margin-bottom:10px ; margin-left:-10px;">
                <div style="background-color: #f9faf5; height: 375px; padding: 5px;">
                    <a style="width: 100%" href="/detailt.aspx?id=<%Response.Write(this.objTableRight.Rows[i]["Id"].ToString()); %>">
                     
                        <img style="height: 256px; width: 100%"
                             src="../Images/Products/<%Response.Write(this.objTableRight.Rows[i]["Image"].ToString()); %>"
                        onerror="this.onerror = null; this.src = '../img/noImg.jpg';"     alt=" Nổi bật" /></a>
                    <p class="ProductLink" style="font-family: Arial; font-size: 15px; font-weight: bold;
                        color: #50505a; padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;">
                        <a style="height: 40px; overflow: hidden;" 
                            href="/detailt.aspx?id=<%Response.Write(this.objTableRight.Rows[i]["Id"].ToString()); %>">
                            <%Response.Write(this.objTableRight.Rows[i]["Name"].ToString()); %></a>
                    </p>
                   
                    <div style="text-align: right; margin-top: -2px;">
                        <div style="font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal;
                            padding-top: 0px; padding-left: 25px;">
                            <img src="/images/User.png" alt="So nguoi thich" style="width: 20px; margin-top: -8px;" />
                             <%Response.Write(this.objTableRight.Rows[i]["CountLike"].ToString()); %>
                        </div>
                    </div>
                    <p style="font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;
                        padding: 5px; text-align: justify; margin-top: -4px;">
                        <span style="font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;">
                            <%Response.Write(this.objTableRight.Rows[i]["Price"].ToString()); %>&nbsp;<sup><u>đ</u></sup></span>
                        <span style="background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat; font-size: 14px; color: #fff;">&nbsp; -
                                <%Response.Write(this.objTableRight.Rows[i]["Discount"].ToString()); %>%
                            &nbsp;</span>
                    </p>

                    <input type="button" value="Đã mua: <%Response.Write(this.objTableRight.Rows[i]["CountBuy"].ToString()); %>" style="margin-top: -46px;" />
                </div>

            </div>
                         <% } %>
                
          
                </div>

                  <div id="contentText" runat="server" class="col-md-9" style="float: right; width: 70%; height: 100%; vertical-align: top;
                        text-align: justify;">
                        <h3 style="text-align: justify; font-family: Arial; font-size: 16px; font-weight: bold;
                            padding-top: 0px;">
                            <% if (this.objTablePartner.Rows.Count > 0) Response.Write(this.objTablePartner.Rows[0]["Name"].ToString()); %>
                        </h3>
                        <hr style="width: 98%; color: #00ffff;" />
                        <div style="width: 100%; text-align: justify; margin-top: 0px;">
                            <% if (this.objTablePartner.Rows.Count > 0) Response.Write(this.objTablePartner.Rows[0]["Content"].ToString()); %>
                        </div>
                    </div>

                <div  id="div-content-left-detailt" class="col-md-3" style="float: left; width: 25%; height: 100%; vertical-align: top;">
                      <div style="width: 95%; height:355px; background-color: #f6f6f6; border: solid 1px #c6c6c6;">
                        <div style="padding: 5px;">
                            <h5>THÔNG TIN LIÊN HỆ</h5>
                            Điện thoại:      <% Response.Write(this.objTablePartner.Rows[0]["Phone"].ToString()); %>
                            <br />
                            Email:  <% Response.Write(this.objTablePartner.Rows[0]["Email"].ToString()); %>
                            <br />
                            Website:www.sucmanhcong.com
                        </div>
                        <img style="width: 98%; padding-left: 5px; margin-bottom: 10px;" src="/Images/Partner/<% Response.Write(this.objTablePartner.Rows[0]["Image"].ToString()); %>"
                            alt="Hinh dai dien" />
                    </div>

                    <asp:DataList ID="ddlLeft" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="100%" ItemStyle-BorderStyle="None" Style="margin-left: -7px;" >
                        <ItemTemplate>
                            <div style="height: 355px; padding: 0px; margin-bottom:15px; float:left  ">
                                <a href="/detailt.aspx?id=<%# Eval("Id") %>" style="width: 100%; height: 252px;"  >
                                    <img id="img-vip-store" src="/images/Products/<%# Eval("Image") %>" alt="San pham VIP" style="width: 100%; height: 252px;" 
                                         onerror="this.onerror = null; this.src = '../img/noImg2.jpg';"
                                        /></a>
                                <p class ="ProductLink" style="font-family: Arial; font-size: 15px; font-weight: bold; color: #50505a; padding: 5px; text-align: justify; height:54px; overflow:hidden; border-bottom: solid 2px #f0f0fb;">
                                    <a style="display: block; vertical-align: middle;" href="#">
                                        <%# Eval("Name") %>
                                    </a>
                                </p>
                               <div style="text-align: right; margin-top: -4px;">
                                    <div style="font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal; padding-top: 0px; padding-left: 25px;">
                                        <img src="/images/User.png" alt="So nguoi thich" style="width: 20px; margin-top: -8px;" />
                                      <%# Eval("CountLike") %>
                                    </div>
                                </div>
                                <p style="font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a; padding: 5px; text-align: justify; margin-top: -4px;">
                                    <span style="font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;"><%# Eval("Price") %>&nbsp;<sup><u>đ</u></sup></span>
                                    <span style="background-image: url('/images/DiscountBg.png'); background-repeat: no-repeat; font-size: 14px; color: #fff;">&nbsp; -<%# Eval("Discount") %>% &nbsp;</span>
                                </p>
                                <input type="button" value="Đã mua:   <%# Eval("CountBuy") %>" style="margin-top: -40px; margin-left:155px; font-size:12px; background-color :#ff7a00; border-color:#ff7a00;" class="btn btn-success" />
                            </div>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>

                    
                </div>
            </div>
        </div>
           
        
            <% // Response.Write(this.htmtStr); %>
        
    </div>
</asp:Content>

