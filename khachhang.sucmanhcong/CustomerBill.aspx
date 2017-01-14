<%@ Page Title="DOANH SỐ" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerBill.aspx.cs" Inherits="Customer_CustomerBill" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .card-small {
            font-size: 12px;
        }

        .body-bill {
            font-size: 12px;
        }
        .content-bill-left
        {
            width: 100%; height: 40px; line-height: 40px; font-weight: bold; font-size: 12px; overflow: hidden

        }
        .row-bill {
         
            float: left;
            border: solid 1px #f3f1f1;
            border-right: none;
            text-align: center;
            font-weight: bold;
            height: 30px;
            line-height: 30px;
            color: #000;
        }
    </style>
    <div class="container">


        <div class="row" style="margin-top: 20px;">

             <div style="width: 20%; float: left; font-size: 14px; margin-left: 0%; margin-top:50px; background-color: whitesmoke">
                <h4 style="color: darkgoldenrod; margin-left: 1px;">• DOANH SỐ GIAO DỊCH </h4>
                <div style="width: 100%; height: 40px; line-height: 40px; font-weight: bold; font-size: 12px; overflow: hidden">
                Doanh số  ngày:        <% Response.Write(this.strDSInDay); %>
                </div>
                <div style="width: 100%; height: 30px; line-height: 30px;" class="body-bill">
                    <div style="width: 50%; float: left;" class="card-small">
                    Doanh số  tuần :
                    </div>
                    <div style="width: 50%; float: right; text-align: left;">
                        <% Response.Write(this.strDSInWeek); %>
                    </div>
                </div>
                <div style="width: 100%; height: 30px; line-height: 30px;">
                    <div style="width: 50%; float: left;" class="card-small">
                       Doanh số tháng :
                    </div>
                    <div style="width: 50%; float: right; text-align: left;">
                        <% Response.Write(this.strDSInMonth); %>
                    </div>
                </div>
                <div style="width: 100%; height: 30px; line-height: 30px;">
                    <div style="width: 50%; float: left;" class="card-small">
                       Tổng doanh số :
                    </div>
                    <div style="width: 50%; float: right; text-align: left;">
                        <% Response.Write(this.strDSTotal); %>
                    </div>
                </div>
                   <div style="width: 100%; height: 30px; line-height: 30px;">
                    <div style="width: 50%; float: left;" class="card-small">
                    Doanh số cân đối : 
                    </div>
                    <div style="width: 50%; float: right; text-align: left;">
                        <% Response.Write(this.strDSCard); %> 
                    </div>
                </div>
                <div style="width: 100%; height: 30px; line-height: 30px;">
                    <div style="width: 50%; float: left;" class="card-small">
                     Tích luỹ thẻ : 
                    </div>
                    <div style="width: 50%; float: right; text-align: left;">
                        <% Response.Write(this.strDSCard); %> 
                    </div>
                </div>
              
            </div>


         
            <div class="col-md-9">
                <div class="row" style="margin-bottom: 10px;">
                    <div class="col-md-1" style="height: 100%">
                        Từ 
                    </div>
                    <div class="col-md-3">
                        <input runat="server" id="txtFromDate" type="date" class="form-control" value="" placeholder="yyy-mm-dd" />
                    </div>
                    <div class="col-md-1">
                        đến 
                    </div>
                    <div class="col-md-3">
                        <input type="date" runat="server" id="txtToDate" class="form-control" value="" placeholder="yyy-mm-dd" />
                    </div>
                    <div class="col-md-2">
                        <select class="form-control" name="optType" >
                            <option value="0">Tất cả</option>
                            <option value="1" <% if (this.Type == 1) Response.Write("selected='selected'"); %>>Tiền mặt</option>
                            <option value="2" <% if (this.Type == 2) Response.Write("selected='selected'"); %>>Dùng thẻ</option>
                        </select>
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
                <div style="width: 100%; margin-top: 0px;">
                    <div class="row-bill " style="width:5%">
                        TT   
                    </div>
                    <div style="width: 18%; overflow:hidden  !important ;  margin-left:-10px;" class="row-bill" >
                        Ngày, giờ giao dịch
                    </div>
                    <div style="width: 10%;"class="row-bill">
                        Tổng tiền
                    </div>
                    <div style="width: 10%; "class="row-bill">
                        Tiền CK
                    </div>
                    <div style="width: 5%;"class="row-bill">
                        CK(%)
                    </div>
                    <div style="width: 5%;" class="row-bill">
                        TL(%)
                    </div>
                    <div style="width: 10%;"class="row-bill">
                        Thanh toán
                    </div>
                    <div style="width: 32%; "class="row-bill">
                        Ghi chú
                    </div>
                    <div style="width: 5%;" class="row-bill">
                        -:-
                    </div>
                </div>
                <% Response.Write(this.strHtml); %>
            </div>
        </div>
    </div>
</asp:Content>

