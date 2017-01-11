<%@ Page Title="TÀI KHOẢN" Language="C#" MasterPageFile="~/Customer.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="Customer_MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .btn-left-select
        {
            border:none;
            background-color:#367fa9;
        }
    </style>
    <script>
        function  btnTichLuyThang_Click()
        {
            alert('Số tiền tích lũy : <% Response.Write(this.tichluythang); %> Vnđ ');
        }
        function btnTongSoDu_Click() {
            alert('Tổng số dư : <% Response.Write(this.tongsodu); %> ');
        }

    </script>
    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-3">
                <div style="width: 100%; color: #fff;" class="TVS-Col-md20">
                    <a href="#"><b>THÔNG TIN TÀI KHOẢN</b></a>
                </div>
                <div style="width: 100%; text-align: center">
                    <asp:Label ID="lblImg1" runat="server" style="width:auto;height:100%;overflow:hidden" Text=""></asp:Label>
                </div>
                <div style="width: 100%; color: #fff;" class="TVS-Col-md2">
                    <asp:Button runat="server"  Text="Hồ sơ của tôi" Id="btnHoSoCuaToi" Class="btn-left-select" OnClick="btnHoSoCuaToi_Click"></asp:Button>
                </div>
                <div style="width: 100%; color: #fff;" class="TVS-Col-md2">
                    <asp:Button runat="server" ID="btnDoiNhom" OnClick="btnDoiNhom_Click" Class="btn-left-select" Text="Đội nhóm"/> 
                </div>
                <div style="width: 100%; color: #fff;" class="TVS-Col-md2-1">
            <a href="#"  onclick="btnTichLuyThang_Click()"> • Tích lũy tháng </a>
                </div>
                <div style="width: 100%; color: #fff;" class="TVS-Col-md2-1">
                   <a href="#"  onclick="btnTongSoDu_Click()"> • Tổng số dư </a>
                </div>
                <div style="width: 100%; color: #fff;" class="TVS-Col-md2">
                    <a href="#">+ Chia sẻ link</a>
                </div>
                <div style="width: 100%; color: #fff;" class="TVS-Col-md2">
                    <a href="#">+ Thay đổi mật khẩu</a>
                </div>
                <div style="width: 100%; color: #fff;" class="TVS-Col-md2-2">
                    <a href="../Logout.aspx">+ Thoát</a>
                </div>
            </div>
            <div class="col-md-9">
                <div class="row">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Hồ sơ của tôi</div>
                        <div class="panel-body">
                            <p>Mã Thẻ :<% Response.Write(strCard); %></p>
                            <br />
                            <p>Ngày kích hoạt : <% Response.Write(strDaycreate); %></p>
                        </div>

                        <!-- List group -->
                        <ul class="list-group">
                            <li class="list-group-item">Tên tài khoản: <% Response.Write(strName); %></li>
                            <li class="list-group-item">Địa chỉ: <% Response.Write(strAddress); %></li>
                            <li class="list-group-item">Điện thoại: <% Response.Write(strPhone); %></li>
                            <li class="list-group-item">Ngày sinh: <% Response.Write(strBirthday); %></li>
                            <li class="list-group-item">Số CMND: <% Response.Write(strIdCard); %></li>
                            <li class="list-group-item">Địa chỉ Email: <% Response.Write(strEmail); %></li>
                        </ul>
                    </div>
                </div>

                <div class="row">
                    <asp:Button ID="btnUpdate" CssClass="btn btn-primary" runat="server" Text=" Cần Cập nhật thông tin" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <style>
            div.DialogueBackground {
                position: fixed;
                width: 100%;
                height: 100%;
                top: 0;
                left: 0;
                background-color: #696969;
                background-color: rgba(0,0,0,0.6);
                overflow: hidden;
                text-align: center;
                color: #000000;
                
                overflow: hidden;
                z-index: 35;
            }

                div.DialogueBackground div.Dialogue {
                    position: fixed;
                    left: 50%;
                    top: 50%;
                    margin-left: -150px;
                    margin-top: -150px;
                    color: #000000;
                    margin-top:-200px;
                      margin-left:-300px;
                    border-radius: 5px;
                    -webkit-border-radius: 5px;
                    -moz-border-border-radius: 5px;
                }

            .popup {
                padding: 2px;
                margin: 5px auto 0px auto;
                border: 6px solid #333333;
                -webkit-border-radius: 5px;
                -moz-border-border-radius: 5px;
             
                z-index: 99999;
            }
        </style>
        <asp:Panel runat="server" ID="panel" CssClass="DialogueBackground" Visible="false">
            <div class="Dialogue">
                <div class="popup" style="background-color:whitesmoke; font-family:Arial; font-size:25px;">
                    <%Response.Write(this.html); %>
                 
                    <div class="clear10">
                    </div>
                    <asp:Button ID="can1" runat="server" Text="Đóng" BorderStyle="None" CssClass="btn" BackColor="Yellow" OnClick="can1_Click" />
                    <div class="clr">
                    </div>
                </div>
            </div>
        </asp:Panel>

    </div>
</asp:Content>

