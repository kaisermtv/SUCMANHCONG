﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DelVideo.aspx.cs" Inherits="System_Del_DelSlide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="row-warning">
        <div style="float: left; width: 12%;">&nbsp;&nbsp;Xóa Slide</div>
        <div style="float: right; width: 87.5%;">

            <div style="float: left; width: 30%;">
                &nbsp;
            </div>
            <div style="float: right; width: 70%; text-align: right;">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold;" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold; margin-right: 6px;" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>

    <div class="warning">
        Bạn có chắc chắn muốn xóa mục này hay không?
    </div>


</asp:Content>

