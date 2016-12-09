<%@ Page Title="THÔNG TIN CỬA HÀNG" Language="C#" MasterPageFile="~/Store.master" AutoEventWireup="true" CodeFile="PartnerInfo.aspx.cs" Inherits="Store_PartnerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="col-md-12">
            <div style="width: 100%; display: table; margin-top:20px;">
                <div style="width: 40%; display: table; float: left;">
                    
                    <div class="info-partner-head">
                        <b>THÔNG TIN CỬA HÀNG</b>
                    </div>

                    <div class="info-partner-head mgt10">
                        <asp:Label ID="lblImg1" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="info-partner-line mgt10">
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="info-partner-line">
                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                    </div>
                    
                    <div class="info-partner-line">
                        <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                    </div>
                    
                    <div class="info-partner-line">
                        <asp:Label ID="lblManager" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="info-partner-line">
                        <asp:Label ID="lblTaxCode" runat="server" Text=""></asp:Label>
                    </div>
                    
                    <div class="info-partner-line">
                        <asp:CheckBox ID="ckbBestSale" Enabled = "false" Text="  Bán chạy %" runat="server" />
                    </div>

                    <div class="info-partner-line">
                        <asp:CheckBox ID="ckbVIP" Enabled = "false" Text="  Bán chạy VIP" runat="server" />
                    </div>
                        
                    <div class="info-partner-line">
                        <asp:CheckBox ID="ckbState" Enabled = "false" Text="  Trạng thái" runat="server" />
                    </div>
                </div>
                <div style="width: 60%; display: table; float: right;">
                    <div class="info-partner-label">
                        &nbsp;
                    </div>
                    <div class="info-partner-out">
                        <b>THÔNG TIN TÀI KHOẢN GIAN HÀNG</b>
                    </div>

                    <div class="info-partner-label">
                        Tài khoản:
                    </div>
                    <div class="info-partner-out">
                        <asp:Label ID="lblAccount" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="info-partner-label">
                        Số sản phẩm:
                    </div>
                    <div class="info-partner-out">
                        <% Response.Write(this.SoSanPham.ToString()); %>
                    </div>

                    <div class="info-partner-label">
                        Sản phẩm VIP:
                    </div>
                    <div class="info-partner-out">
                        <% Response.Write(this.SoSanPhamVIP.ToString()); %>
                    </div>

                    <div class="info-partner-label">
                        Sản phẩm bán chạy:
                    </div>
                    <div class="info-partner-out">
                        <% Response.Write(this.SoSanPhamBanChay.ToString()); %>
                    </div>

                    <div class="info-partner-label">
                        Số lần giao dịch:
                    </div>
                    <div class="info-partner-out">
                       <% Response.Write(this.SoGiaoDich.ToString()); %>
                    </div>

                    <div class="info-partner-label">
                        Doanh số:
                    </div>
                    <div class="info-partner-out">
                        <% Response.Write(this.TongDoanhSo.ToString()); %>
                    </div>

                     <div class="info-partner-label" style="height:50px; line-height:50px;">
                        &nbsp;
                    </div>
                    <div class="info-partner-out" style="height:50px; line-height:50px;">
                        &nbsp;
                    </div>

                     <div class="info-partner-label">
                        Mật khẩu cũ:
                    </div>
                    <div class="info-partner-out">
                        <asp:TextBox ID="txtOldPass" runat="server" TextMode = "Password" Height = "26px" Width = "200px"></asp:TextBox>
                    </div>
                    <div class="info-partner-label">
                        Mật khẩu mới:
                    </div>
                    <div class="info-partner-out">
                        <asp:TextBox ID="txtNewPass" runat="server" TextMode = "Password" Height = "26px" Width = "200px"></asp:TextBox>
                    </div>

                    <div class="info-partner-label" style="height:50px; line-height:50px;">
                        &nbsp;
                    </div>
                    <div class="info-partner-out" style="height:50px; line-height:50px;">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="info-partner-label">
                        &nbsp;
                    </div>
                    <div class="info-partner-out">
                        <asp:Button ID="btnOK" runat="server" Text="GHI NHẬN" Width = "200px" class="btn btn-lg btn-success btn-block" OnClick="btnOK_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

