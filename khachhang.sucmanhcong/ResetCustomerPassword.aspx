<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ResetCustomerPassword.aspx.cs" Inherits="Customer_ResetCustomerPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <div class="container" style = "width:100%;">
        <div class="row">
            <div class=" col-md-6" style="float:left">
        <asp:Panel runat="server" ID="pnlInfo">
            <div class="panel panel-default">
                <!-- Default panel contents -->
                <div class="panel-heading"> <%Response.Write(this.strName); %></div>
                <div class="panel-body">
                    <p>Địa chỉ:  <%Response.Write(this.strAddress); %></p>
                </div>

                <!-- List group -->
                <ul class="list-group">
                    <li class="list-group-item"> Email     : <%Response.Write(this.strEmail); %></li>
                    <li class="list-group-item"> Tài khoản : <%Response.Write(this.strAccount); %></li>
                    <li class="list-group-item">Điện thoại : <%Response.Write(this.strPhone); %></li>
                    <li class="list-group-item">Loại thẻ   :  <%Response.Write(this.strCard); %></li>
                    
                </ul>
            </div>
        </asp:Panel>

            </div>
            <div class="col-md-6" style="float:right">
                <div class="row">
                    <div class="panel panel-default" style="margin-top:0px;">
                        <div class="panel-heading"><b>THAY ĐỔI MẬT KHẨU</b></div>
                        <ul class="list-group">
                            <li class="list-group-item" style="height:55px;">
                                <div class="form-group pgrp_post">
                                    <label class="sr-only" for="exampleInputAmount">Mật khẩu cũ</label>
                                    <div class="input-group right">
                                        <div class="input-group-addon lbip_post" style="width:30%">Mật khẩu cũ</div>
                                        <asp:TextBox type="password" ID="txtOldPass" runat="server" CssClass="form-control ipgr_post"></asp:TextBox>
                                        <div class="input-group-addon"></div>
                                    </div>
                                </div>
                            </li>
                            <li class="list-group-item" style="height:55px;">
                                <div class="form-group pgrp_post">
                                    <label class="sr-only" for="exampleInputAmount" >Mật khẩu mới</label>
                                    <div class="input-group right">
                                        <div class="input-group-addon lbip_post" style="width:30%">Mật khẩu mới</div>
                                        <asp:TextBox type="password" ID="txtNewPass" runat="server" CssClass="form-control ipgr_post"></asp:TextBox>
                                        <div class="input-group-addon"></div>
                                    </div>
                                </div>
                            </li> 
                            <li class="list-group-item" style="height:55px;">
                                <div class="form-group pgrp_post">
                                    <label class="sr-only" for="exampleInputAmount">Nhập lại mật khẩu</label>
                                    <div class="input-group right">
                                        <div class="input-group-addon lbip_post" style="width:30%">Nhập lại mật khẩu</div>
                                        <asp:TextBox  type="password" ID="txtNewPass2" runat="server" CssClass="form-control ipgr_post"></asp:TextBox>
                                        <div class="input-group-addon"></div>
                                    </div>
                                </div>
                            </li> 
                            <li class="list-group-item" style="background-color: #fff;height:40px;">
                                <div class="form-group pgrp2_post">
                                    <div class="input-group right" style="background-color: #fff; color:red;">
                                        <% Response.Write(this.strMsg); %>
                                    </div>
                                </div>
                            </li>
                            <li class="list-group-item" style="background-color: #fff;height:55px;">
                                <div class="form-group pgrp2_post">
                                    <label class="sr-only" for="exampleInputAmount" style="background-color: #fff;"></label>
                                    <div class="input-group right" style="background-color: #fff;">
                                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Lưu thông tin" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

