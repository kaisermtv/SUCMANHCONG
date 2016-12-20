<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Detailt.aspx.cs" Inherits="Store_Detailt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-6">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    display: table; vertical-align: middle;">
                    <% if (this.objTablePartner.Rows.Count > 0) Response.Write(this.objTablePartner.Rows[0]["Name"].ToString()); else Response.Write("&nbsp;"); %>
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">
                        <% if (this.objTablePartner.Rows.Count > 0) Response.Write(this.objTablePartner.Rows[0]["Address"].ToString()); else Response.Write("&nbsp;"); %>
                    </span>
                </div>
            </div>
            <div class="col-md-6">
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
                    <div style="float: left; margin-right: 8px;">
                        <asp:Button type="button" ID="btnSaphethan" class="btn btn-warning " runat="server"
                            OnClick="btnSaphethan_Click" Text="Sắp hết hạn" />

                    </div>
                    <div style="float: right; margin-right: 8px;">
                        <asp:Button type="button" ID="btnGiamGia" class="btn btn-danger " runat="server"
                            OnClick="btnGiamGia_Click" Text="Giảm giá" />

                    </div>

                </div>
            </div>
        </div>
        <hr />
    </div>
    <div class="container">
        <div class="row">


            <% if (this.objTablePartner.Rows.Count > 0)
               { %>

            <div class="col-md-3">
                <div style="width: 100%; background-color: #f6f6f6; border: solid 1px #c6c6c6;">
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
                <br />
                <%} %>

                <% int loop = 0; %>
                <% if (this.objTable.Rows.Count > 4) { loop = 4; } else { loop = this.objTable.Rows.Count; } %>
                <%  for (int i = 0; i < loop; i++) %>
                <% {  %>

                <div style="border: solid 1px #f6f6f6; height: 382px;">
                    <div>
                        <img src="/Images/Products/<% Response.Write(this.objTable.Rows[i]["Image"].ToString());%>"
                            alt="San pham 1" style="width: 100%; height: 150px" />
                    </div>
                    <div style="font-family: Arial; font-size: 13px; font-weight: bold; text-align: justify;
                        padding: 5px; color: #414441; height: 45px; overflow: hidden;">
                        <% Response.Write(this.objTable.Rows[i]["Name"].ToString());%>
                    </div>
                    <div style="font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a;
                        padding: 5px; text-align: justify; margin-top: -4px;">
                        <span style="font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;">
                            <% Response.Write(this.objTable.Rows[i]["Price"].ToString());%><sup><u>đ</u></sup></span>
                    </div>
                    <div style="text-align: center;">
                        <div style="margin-left: 5px; float: left; width: 47%; background-color: #337ab7;
                            color: #fff; height: 30px; line-height: 30px; display: table; vertical-align: middle;">
                            <% Response.Write(this.objTable.Rows[i]["Location"].ToString());%>
                        </div>
                        <div style="margin-right: 5px; float: right; width: 47%; background-color: #ffc000;
                            color: #fff; height: 30px; line-height: 30px; display: block; vertical-align: middle;"
                            class="DetailtLink">
                            <a href="../../Detailt.aspx?id=<% Response.Write(this.objTable.Rows[i]["Id"].ToString());%>">
                                Chi tiết</a>
                        </div>
                    </div>
                </div>
                <br />
                <% } %>
            </div>
            <asp:Panel runat="server" ID="pnlContent" Visible="true">
                <div class="col-md-9" style="float: left; width: 75%; height: 100%; vertical-align: top;
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


            </asp:Panel>


        </div>
    </div>
    <div class="container">
        <div class="row">
            <%// Response.Write(this.htmlCard); %>
       
    <% Response.Write(this.htmtStr); %>
        </div>
        </div>
</asp:Content>

