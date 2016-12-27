<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DelMedia.aspx.cs" Inherits="System_Del_DelMedia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="title_post_from">
        <div style="float: left; text-align: left;">
            Bạn xác nhận xóa slide
        </div>
        <div style="float: right; width: 25%; text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="Xác nhận" class="btn_post_from" Style="margin-right: -2px;" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" class="btn_post_from" Style="margin-right: 6px;" OnClick="btnCancel_Click" />
        </div>
    </div>

    <div class="warning">
        Bạn có chắc chắn muốn xóa mục này hay không?
    </div>
</asp:Content>

