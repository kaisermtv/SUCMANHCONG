<%@ Page Title="QUẢN LÝ BANNER" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VideoEdit.aspx.cs" Inherits="VideoEdit" ValidateRequest="false" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%; height: 32px; line-height: 30px; background-color: #dde8ec; font-family: Arial; font-size: 13px; font-weight: bold; text-transform: uppercase;">
        <div style="float: left; width: 12%;">&nbsp;&nbsp;Thêm ảnh</div>
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
        <div style="width: 12%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Tên video :
        </div>
        <div style="width: 87.5%; height: 30px; line-height: 30px; float: right;">
            <asp:TextBox ID="txtName" runat="server" Style="height: 22px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
    </div>

    <div style="width: 100%; height: 220px; line-height: 220px;">
        <div style="width: 12%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;Liên kết :
        </div>
        <div style="width: 87.5%; height: 220px; line-height: 220px; float: right;">
            <asp:TextBox ID="txtUrl" runat="server" TextMode ="MultiLine" Style="height: 220px; line-height: 22px; width: 99%; font-size: 13px; font-family: Arial;"></asp:TextBox>
        </div>
    </div>
    
   

    <div style="width: 100%; height: 35px; line-height: 35px;">
        <div style="width: 12%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;
        </div>
        <div style="width: 87.5%; height: 30px; line-height: 30px; float: right; font-family: Arial; font-size: 12px;">
            <asp:CheckBox ID="ckbState" Text="  Trạng thái" runat="server" />
        </div>
    </div>
    
        <div style="width: 87.5%; height: 100px; line-height: 15px; float: right;">
            <a href="">
              <p class="title_post_from">Hướng Dẩn : Nhúng Video hoặc Playlist Youtube</p>
<div style="font-family:'Comic Sans MS'">
 <p>  Trên  máy tính, Đi đến video Youtube bạn muốn nhúng vào.</p> 
  <p>   Phía dưới video , chọn Share(Chia Sẻ) .</p> 
  <p>   Chọn Embed(Nhúng).</p> 
  <p>  Trong hộp thoại hiện lên, Chép mã HTML .</p> 
  <p>   Dán vào ô đường dẩn, và xóa đi các thuộc tính .</p> 
  <p>    width="560" height="315"</p>
    <p> (xóa đi chiều rộng cao để không làm lộn xộn trang web của bạn).</p> 
             <p> --------------------------</p> 
<p style="font-size:larger">Nhúng một danh sách</p>
    <p>  </p>
   <p> Đăng nhập Youtube với tài khỏan google.</p> 
   <p>  Trong thanh bên trái Chọn Danh Sách Phát.</p> 
  <p>  Trong danh sách bạn muốn nhúng .</p> 
  <p>   Chọn  Share (Chia sẻ) .</p> 
   <p>  Chọn Embed(Nhúng).</p> 
   <p>  Trong hộp thoại hiện lên, Chép mã HTML .</p> 
   <p>  Dán vào ô đường dẩn, và xóa đi các thuộc tính .</p> 
   <p>   width="560" height="315" (xóa đi chiều rộng cao để không làm lộn xộn trang web của bạn).</p> 
   </div>

            </a>
             </div>
    <div style="width: 100%; height: 35px; line-height: 35px;">
        <div style="width: 12%; height: 30px; line-height: 30px; float: left; font-size: 13px; font-family: Arial;">
            &nbsp;&nbsp;
        </div>
        <div style="width: 87.5%; height: 30px; line-height: 30px; float: right; font-family: Arial; font-size: 12px;">
        </div>
    </div>
</asp:Content>
