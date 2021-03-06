﻿<%@ Page Title="QUẢN TRỊ NỘI DUNG" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GroupAccEdit.aspx.cs" Inherits="System_GroupAccEdit" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="title_post_from">
        <div style="float: left; width: 12%;">&nbsp;&nbsp;Nhóm tài khoản</div>
        <div style="float: right; width: 87.5%;">

            
            <div style="float: right; width: 25%; text-align: right;">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" class="btn_post_from" Style="margin-right: -2px;" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" class="btn_post_from" Style="margin-right: 6px;" OnClick="btnCancel_Click" />
            </div>
            <div style="float: right; text-align: right;">
                <asp:CheckBox ID="chkStatus" Text="  Trạng thái" runat="server" />
            </div>
        </div>
    </div>

    <div class="line_post_from">
        <div class="label_post_from">
            &nbsp;&nbsp;Tên nhóm :
        </div>
        <div class="main_post_from">
            <input id="txtName" runat="server" class="input_post_from"/>
        </div>
    </div>
    <div class="line_post_from">
        <div class="label_post_from">
            &nbsp;&nbsp;Quyền hạn :
        </div>
        <div class="main_post_from">
            <input id="txtPer" runat="server" class="input_post_from"/>
        </div>
    </div>

</asp:Content>
