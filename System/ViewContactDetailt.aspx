<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewContactDetailt.aspx.cs" Inherits="System_ViewContactDetailt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="line_post_from">
        <div class="label_post_from">
            &nbsp;&nbsp;Người yêu cầu liên hệ  :
        </div>
        <div class="main_post_from">
            <input id="txtName" runat="server" class="input_post_from" disabled="disabled" />
        </div>
    </div>
    <div class="line_post_from">
        <div class="label_post_from">
            &nbsp;&nbsp; Email :
        </div>
        <div class="main_post_from">
            <input id="txtEmail" runat="server" class="input_post_from" disabled="disabled" />
        </div>
    </div>
    <div class="line_post_from">
        <div class="label_post_from">
            &nbsp;&nbsp; ĐT  :
        </div>
        <div class="main_post_from">
            <input id="txtPhone" runat="server" class="input_post_from" disabled="disabled" />
        </div>
    </div>
    <div class="line_post_from">
        <div class="label_post_from">
            &nbsp;&nbsp; Tiêu đề   :
        </div>
        <div class="main_post_from">
            <input id="txtSubject" runat="server" class="input_post_from" disabled="disabled" />
        </div>
    </div>
    <div class="line_post_from">
        <div class="label_post_from">
            &nbsp;&nbsp; Nội dung   :
        </div>
        <div class="main_post_from">
            <textarea id="txtMessage"   runat="server"  style="" class="input_post_from" disabled="disabled" />
        </div>
    </div>


</asp:Content>

