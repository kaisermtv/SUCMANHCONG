<%@ Page Title="TRANG CHỦ" Language="C#" MasterPageFile="~/Customer.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Customer_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .row_detailt {
            margin-left: 30px;
            border-top-left-radius:3px;
        }
        .title_card {

            width: 100%; height: 115px; margin-left: -8px; text-align: center; padding-top: 8px; color: #fff; font-size: 20px; font-weight:100;
            font-family:Arial;
           
        }
        .title-cost{
        width: 100%; height: 95px; text-align: center; margin-left: -10px; margin-top: -20px; color:  #fff; border-bottom: dotted 1px #fff; font-size: 20px;
        font:small-caption;
        }
    </style>
    <div class="container" style="width:85%">
        <div class="row">
            <h3 style="text-align: center; color: #000;">PHÂN HẠNG THẺ THÀNH VIÊN TRÊN SUCMANHCONG.COM</h3>
        </div>
        <div class="row" style="margin-top: 30px;">
            <div class="col-md-4" style="background-image: url('../Images/design/Thedong.png'); background-repeat: no-repeat">
                <div class="title_card" style="margin-left:3px;">
                    THẺ ĐỒNG 
                </div>
                <div class="title-cost">
                    30,000 đ
                </div>
                <div class="btn-group dropup" style="margin-top: -70px; margin-left:-15px;">
                    <a class="btn btn-primary" href="../../NewsDetailt?Id=1">Xem chi tiết</a>
                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="caret"></span>
                        <span class="sr-only">Toggle Dropdown</span>
                    </button>
                    <ul class="dropdown-menu">
                        <li>a</li>
                    </ul>
                </div>


            </div>
            <div class="col-md-4" style="background-image: url('../Images/design/Thebac.png'); background-repeat: no-repeat">
                <div class="title_card">
                          THẺ BẠC 
                </div>

               <div class="title-cost">
                     350,000 đ
                </div>

                <div class="btn-group dropup" style="margin-top: -70px; margin-left:-15px;">
                    <a class="btn btn-primary" href="../../NewsDetailt?Id=2">Xem chi tiết</a>
                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="caret"></span>
                        <span class="sr-only">Toggle Dropdown</span>
                    </button>
                    <ul class="dropdown-menu">
                        <li>a</li>
                    </ul>

                    <asp:Button ID="Button1" runat="server" Text="Nâng cấp" CssClass="btn btn-success row_detailt" />

                </div>
            </div>


            <div class="col-md-4" style="background-image: url('../Images/design/Thevang.png'); opacity: 0.9; background-repeat: no-repeat">
              <div class="title_card">
                         THẺ VÀNG
                </div>
             <div class="title-cost">
                       1,000,000 đ
                </div>
             <div class="btn-group dropup" style="margin-top: -70px; margin-left:-15px;">
                       <a class="btn btn-primary" href="../../NewsDetailt?Id=3">Xem chi tiết</a>
                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="caret"></span>
                        <span class="sr-only">Toggle Dropdown</span>
                    </button>
                    <ul class="dropdown-menu">
                        <li>a</li>
                    </ul>

                    <asp:Button ID="Button2" runat="server" Text="Nâng cấp" CssClass="btn btn-success row_detailt" />
                </div>
            </div>


        </div>
        <div class="row" style="margin-top: 30px;">
            <h4>Tin Khuyến Mãi</h4>
        </div>



    </div>

    <div class="line" style="width: 100%; background-color: ActiveBorder; height: 1px;"></div>
    <div class="container">
        <ul class="list-group">
            <% for (int i = 0; i < this.objtable.Rows.Count; i++)
               { %>
            <li class="list-group-item">
                <a href="../../NewsDetailt?Id=<% Response.Write(this.objtable.Rows[i]["Id"].ToString()); %>">
                    <% Response.Write(this.objtable.Rows[i]["Title"].ToString()); %>
                    <h4 style="font-size: 10px; font-family: 'Comic Sans MS'"><% Response.Write(this.objtable.Rows[i]["DayCreate"].ToString());%> </h4>
                </a></li>
            <%} %>
        </ul>
    </div>
</asp:Content>
