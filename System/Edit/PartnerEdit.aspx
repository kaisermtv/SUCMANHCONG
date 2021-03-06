﻿<%@ Page Title="QUẢN TRỊ NỘI DUNG" ValidateRequest="false" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PartnerEdit.aspx.cs" Inherits="PartnerEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script>
        var roxyFileman = '/fileman/index.html';
        $(function () {
            CKEDITOR.replace('ContentPlaceHolder1_txtContent', {
                filebrowserBrowseUrl: roxyFileman,
                filebrowserImageBrowseUrl: roxyFileman + '?type=image',
                removeDialogTabs: 'link:upload;image:upload'
            });
        });
    </script>

    <panel class="panel panel-default">
    </panel>
    <div style="width: 100%; height: 32px; line-height: 30px; background-color: #dde8ec; font-family: Arial; font-size: 12px; font-weight: bold; text-transform: uppercase;">
        <div style="float: left; width: 15%;">&nbsp;&nbsp;Thêm cửa hàng</div>
        <div style="float: right; width: 80.5%;">

            <div style="float: left; width: 45%;">
                &nbsp;
            </div>
            <div style="float: left; width: 25%; text-align: right;">
                <asp:DropDownList ID="ddlLocation" runat="server" Style="width: 99%; height: 26px; line-height: 26px; margin-top: 3px;">
                </asp:DropDownList>
            </div>
            <div style="float: right; width: 30%; text-align: right;">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold;" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold; margin-right: 6px;" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>

    <div style="width: 100%; height: 30px; line-height: 30px;">
        <div style="width: 15%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Tên doanh nghiệp :
        </div>
        <div style="width: 84.5%; height: 30px; line-height: 30px; float: right;">
            <asp:TextBox ID="txtName" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
    </div>
    <div style="width: 100%; height: 30px; line-height: 30px;">
        <div style="width: 15%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Địa chỉ :
        </div>
        <div style="width: 84.5%; height: 30px; line-height: 30px; float: right;">
            <asp:TextBox ID="txtAddress" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
    </div>

    <div style="width: 100%; height: 30px; line-height: 30px;">
        <div style="width: 14%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Điện thoại :
        </div>
        <div style="width: 15%; height: 30px; line-height: 30px; float: left;">
            <asp:TextBox ID="txtPhone" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
        <div style="width: 8%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Quản lý :
        </div>
        <div style="width: 15%; height: 30px; line-height: 30px; float: left;">
            <asp:TextBox ID="txtManager" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
        <div style="width: 8%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Mã số thuế :
        </div>
        <div style="width: 10%; height: 30px; line-height: 30px; float: left;">
            <asp:TextBox ID="txtTaxCode" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
        <div style="width: 9%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Ngành nghề :
        </div>
        <div style="width: 20%; height: 30px; line-height: 30px; float: left;">
            <asp:DropDownList ID="ddlBusiness" runat="server" Style="width: 100%; height: 26px; line-height: 26px; margin-top: 3px;"></asp:DropDownList>
        </div>
    </div>
    <div style="width: 100%; height: auto; margin-top: 5px; display: table;">
        <div style="width: 12%; height: auto; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Giới thiệu :
            <br />
            <br />
            Hình đại diện
            <br />
            <asp:Label ID="lblImg1" Text="Ảnh minh hoạ" CssClass="MQTT_Normal_Text" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="txtImage" runat="server" Width="10px" Visible="false"></asp:TextBox>
            <label class="file-upload" style="margin-top: -12px;">
                <span><strong>Upload Image</strong></span>
                <asp:FileUpload ID="upImage1" runat="server" Width="100px" CssClass="FileUploadImage" Height="22px" />
            </label>
        </div>
        <div style="width: 87.5%; height: auto; line-height: 30px; float: right;">
            <CKEditor:CKEditorControl ID="txtContent" CssClass="editor1" runat="server" Height="280" Width="99%" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
        </div>
    </div>
    <div style="width: 100%; height: 35px; line-height: 35px;">
        <div style="width: 12.5%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Mức chiết khấu :
        </div>
        <div style="width: 10%; height: 30px; line-height: 30px; float: left;">
            <asp:TextBox ID="txtDiscount" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>

        <div style="width: 10%; height: 30px; line-height: 30px; float: left; padding-left: 20px;">
            <asp:CheckBox ID="ckbBestSale" Text="  Bán chạy %" runat="server" />
        </div>

        <div style="width: 12%; height: 30px; line-height: 30px; float: left;">
            <asp:CheckBox ID="ckbVIP" Text="  Bán chạy VIP" runat="server" />
        </div>
        <div style="height: 30px; line-height: 30px; float: left; font-family: Arial; font-size: 12px;">
            <asp:CheckBox ID="ckbState" Text="  Trạng thái" runat="server" />
        </div>
        <div style="height: 30px; line-height: 30px; float: left; font-family: Arial; font-size: 12px; margin-left: 30px;">
            Ngày khởi tạo hợp đồng :   
            <input type="datetime" class="form-control" id="txtDateTime" runat="server" placeholder="dd/mm/yyyy hh:mm:ss " />
        </div>

    </div>
</asp:Content>

