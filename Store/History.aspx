<%@ Page Title="LỊCH SỬ GIAO DỊCH" Language="C#" MasterPageFile="~/Store.master" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="Store_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container" style="width: 100%; text-align: right;">
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-1" style="height: 100%">
                Từ ngày
            </div>
            <div class="col-md-3">
                <input runat="server" id="txtFromDate" type="date" class="form-control" value="" placeholder="yyy-mm-dd" />
            </div>
            <div class="col-md-1">
                tới ngày
            </div>
            <div class="col-md-3">
                <input type="date" runat="server" id="txtToDate" class="form-control" value="" placeholder="yyy-mm-dd" />
            </div>
            <div class="col-md-2">
                <input type="submit" style="float: left" class="btn btn-default" value="Lọc kết quả" />
            </div>
        </div>
        <% if(this.Message != ""){ %>
        <div class="row" >
            <pre><%= this.Message %></pre>
        </div>
        <% } %>
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div style="width: 100%; margin-top: 0px;">
                        <div id="tn1" class="table_header_item" style="width: 5%;">
                            TT   
                        </div>
                        <div id="tn3" class="table_header_item1" style="width: 18%;">
                            Ngày, giờ giao dịch
                        </div>
                        <div id="tn4" class="table_header_item2" style="width: 10%;">
                            Tổng tiền
                        </div>
                        <div  id="tn5"class="table_header_item2" style="width: 10%;">
                            Tiền CK
                        </div>
                        <div id="tn6" class="table_header_item2" style="width: 5%;">
                            CK(%)
                        </div>
                        <div id="tn7" class="table_header_item2" style="width: 5%;">
                            TL(%)
                        </div>
                        <div id="tn8" class="table_header_item2" style="width: 5%;">
                            QC(%)
                        </div>
                        <div id="tn9" class="table_header_item2" style="width: 10%;">
                            Thanh toán
                        </div>
                        <div id="tn10" class="table_header_item2" style="width: 27%;">
                            Ghi chú
                        </div>
                        <div id="tn11" class="table_header_item2" style="width: 5%;">
                         Chi tiết
                        </div>
                    </div>
                    <% Response.Write(this.strHtml); %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

