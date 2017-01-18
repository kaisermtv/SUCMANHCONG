<%@ Page Title="QUẢN LÝ CỬA HÀNG" Language="C#" MasterPageFile="~/Store.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Store_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container" style ="width:100%;">
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="panel panel-info">
                        <!-- Default panel contents -->
                        <div class="panel-heading"><b>THÔNG TIN CỬA HÀNG</b></div>
                        <!-- List group -->
                        <ul class="list-group" style="text-align:left !important; overflow:hidden;">
                            <li class="list-group-item" style="text-align:left !important;"><label for="inputEmail3" class="col-sm-3 control-label">Người đại diện: </label><% Response.Write(strManager+"."); %></li>
                            <li class="list-group-item" style="text-align:left !important; "><label for="inputEmail3" class="col-sm-3 control-label" >Tên cửa hàng:</label> <% Response.Write(strName + "."); %></li>
                            <li class="list-group-item" style="text-align:left !important;"><label for="inputEmail3" class="col-sm-3 control-label">Địa chỉ: </label><% Response.Write(strAddress + "."); %></li>
                            <li class="list-group-item" style="text-align:left !important;"><label for="inputEmail3" class="col-sm-3 control-label">Điện thoại : </label><% Response.Write(strPhone+ "."); %></li>
                            <li class="list-group-item" style="text-align:left !important;" ><label for="inputEmail3" class="col-sm-3 control-label">Địa chỉ email:</label>  <% Response.Write(strEmail + "."); %></li>
                            <li class="list-group-item" style="text-align:left !important;"><label for="inputEmail3" class="col-sm-3 control-label">Mã số thuế : </label><% Response.Write(strTaxcode + "."); %></li>
                            <li class="list-group-item" style="text-align:left !important;" ><label for="inputEmail3" class="col-sm-3 control-label">Tài khoản cửa hàng: </label> <% Response.Write(strAccount ); %></li>
                            <li class="list-group-item" style="text-align:left !important;"><label for="inputEmail3" class="col-sm-3 control-label">Số tài khoản: </label> <% Response.Write(strBankAccount + "."); %></li>
                            <li class="list-group-item" style="text-align:left !important;" ><label for="inputEmail3" class="col-sm-3 control-label">Ngân hàng: </label> <% Response.Write(strBankAccountName + "."); %></li>
                            <li class="list-group-item" style="text-align:left !important;" ><label for="inputEmail3" class="col-sm-3 control-label">Ngày hợp đồng hiệu lực: </label> <% Response.Write(strCreateDate +"."); %></li> 

                        </ul>
                    </div>
                </div>

                <%-- <div class="row">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading"><b>Thông tin khác</b></div>
                        <!-- List group -->
                        <ul class="list-group">
                            <li class="list-group-item">Cửa hàng bán chạy: <% Response.Write(strBestSale); %></li>
                            <li class="list-group-item">Cửa hàng VIP: <% Response.Write(strVIP); %></li>
                            <li class="list-group-item">Số sản phẩm: <% Response.Write(SoSanPham); %></li>
                            <li class="list-group-item">Sản phẩm bán chạy: <% Response.Write(SoSanPhamBanChay); %></li>
                            <li class="list-group-item">Số lần giao dịch: <% Response.Write(SoGiaoDich); %></li>
                            <li class="list-group-item">Tổng doanh số: <% Response.Write(TongDoanhSo); %></li>
                        </ul>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
</asp:Content>

