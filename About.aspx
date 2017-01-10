<%@ Page Title="Giới Thiệu  " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 10px;">
        <div class="col-md-6">
            <div class="row">
                <p style="text-align: center; font-family: Arial; font-size: 30px"><%= this.Name %></p>
                <p style="text-align: center; font-family: 'Comic Sans MS'; font-size: 12px"><%= this.Address %></p>
                <p style="text-align: center; font-family: 'Comic Sans MS'; font-size: 12px"><%= this.Phone %></p>
                <p style="text-align: center; font-family: 'Comic Sans MS'; font-size: 12px"><%= this.Email %></p>
            </div>

        </div>
        <div class="col-md-6">
            <div class="row" style="">
                <img src="/img/banner.jpg" style="height: 200px; width: 100%; text-align: center; align-content: flex-end; border-radius: 20px;" />
            </div>
         
        </div>
        <div style="height:20px; width:100%; clear:both"></div>
        <div class="col-md-1"></div>
        <div class="col-md-12">
            <p style="font-size:25px;"><%= this.Intro %></p>
        </div>
    </div>
</asp:Content>
