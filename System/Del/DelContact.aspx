<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DelContact.aspx.cs" Inherits="System_Del_DelContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="title_post_from">
        <div style="float: left; text-align: left;">
            Bạn xác nhận xóa yêu cầu gửi từ  : <% Response.Write(this.name); %>
        </div>
        <div style="float: right; width: 25%; text-align: right;">
            <asp:Button ID="btnOk" runat="server" Text="Xác nhận" class="btn_post_from" Style="margin-right: -2px;" OnClick="btnOk_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" class="btn_post_from" Style="margin-right: 6px;" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>

