<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="LogIn_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
        body { padding-top:0px; }
.panel-body .btn:not(.btn-block) { margin-left:10%; width:50%;margin-bottom:10px; }

    </style>

    <div class="container" style="margin-top:30px; ">
    <div class="row" >
        <div class="col-md-10">
            <div class="panel panel-primary" style="height:350px; margin-left:10%">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <span class="glyphicon glyphicon-bookmark"></span> Chọn tài khoản </h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-6 col-md-6" style="align-content:center">
                              <a href="../Store/Register.aspx" class="btn btn-primary btn-lg" style=" width:60%; margin-left:20%" role="button">    <img src="../img/company.png" style="height:150px; width:100%; margin-left:1px;" /> <br/>Cửa hàng - Đối tác </a>
                        </div>
                        <div class="col-xs-3 col-md-6"  style="padding-left:10px">
                           <a href="../Customer/Register.aspx" class="btn btn-primary btn-lg" style=" width:60%; margin-left:20%" role="button"><img src="../img/customer-logo.png" style="height:150px; width:100%; margin-left:1px;" /> <br/>Thành viên </a>
                        </div>
                    </div>
                    <a href="../LogIn/login.aspx" class="btn btn-success btn-lg btn-block" style="" role="button"><span class="glyphicon glyphicon-globe"></span> Đã có tài khoản ? Đăng nhập  </a>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>

