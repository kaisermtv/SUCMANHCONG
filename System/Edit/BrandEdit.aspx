<%@ Page Title="QUẢN LÝ BANNER" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BrandEdit.aspx.cs" Inherits="System_Edit_BrandEdit" ValidateRequest="false" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%; height: 32px; line-height: 30px; background-color: #dde8ec; font-family: Arial; font-size: 13px; font-weight: bold; text-transform: uppercase;">
        <div style="float: left; width: 12%;">&nbsp;&nbsp;Thêm nhóm</div>
        <div style="float: right; width: 87.5%;">

            <div style="float: left; width: 30%;">
                &nbsp;
            </div>
            <div style="float: right; width: 70%; text-align: right;">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold; margin-right: -2px;" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold; margin-right: 6px;" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px;">
        <div style="width: 18%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Tên thương hiệu :
        </div>
        <div style="width: 81.5%; height: 35px; line-height: 35px; float: right;">
            <asp:TextBox ID="txtName" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
    </div>

    <div style="width: 100%; height: 105px; line-height: 105px;">
        <div style="width: 18%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Diễn giải :
        </div>
        <div style="width: 81.5%; height: 100px; line-height: 100px; float: right;">
            <asp:TextBox ID="txtDescription" runat="server" TextMode ="MultiLine" Style="height: 100px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px;">
        <div style="width: 18%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            <br />
            Hình đại diện
            <br />
            <asp:Label ID="lblImg1" Text="Ảnh minh hoạ" CssClass="MQTT_Normal_Text" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtImage" runat="server" Width="10px" Visible="false"></asp:TextBox>
            <label class="file-upload" style ="margin-top:-12px;">
                <span><strong>Upload Image</strong></span>
            <asp:FileUpload ID="upImage1" runat="server" Width="100px" CssClass="FileUploadImage" Height="22px" />
                </label>
        </div>
        <div style="width: 81.5%; height: 30px; line-height: 30px; float: right; font-family: Arial; font-size: 12px;">
            <asp:CheckBox ID="CheckVip" Text=" VIP" runat="server" />
        </div>
    </div>
</asp:Content>
