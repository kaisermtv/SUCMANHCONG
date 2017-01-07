<%@ Page Title="QUẢN TRỊ NỘI DUNG" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="System_Product" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style ="width:100%; height:32px; line-height:30px; background-color:#dde8ec; font-family:Arial; font-size:13px; font-weight:bold; text-transform:uppercase;">
        <div style ="float:left;">&nbsp;&nbsp;Hàng hóa - Dịch vụ</div>
       
        <div style ="float:right;"><a href ="Edit/ProductEdit.aspx"><span style ="border:solid 1px #f8fbfc; padding:5px; font-size:11px; font-weight:bold; padding-left:20px; padding-right:20px;">Thêm mới</span></a>&nbsp;</div>
          <div style ="float:right; margin-right:1%">&nbsp;&nbsp;<asp:Button runat="server" ID="btnSearch"   OnClick="txtSearch_TextChanged"  Text="Tìm"  ></asp:Button></div>
         
         <div style ="float:right; margin-right:1%">&nbsp;&nbsp;<asp:TextBox runat="server" ID="txtSearch"    placeholder="Tìm kiếm theo Tên / Giá  "></asp:TextBox></div>
         
    
          </div>
    <div class="row">
     <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; font-family:'Comic Sans MS'; font-family:13px;  width: 99.9%; height: 30px;">
                <tr>   
                     <td style="text-align: center; font-size:10px; vertical-align: middle; font-family: Arial;  color: #262626; background-color: #FFF; width: 4%;">
                        <div style="float: left; display: table-cell;  line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 14px; border-bottom: solid 1px #808080; border-left: solid 1px #808080;">
                        TT
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial;  color: #fff; background-color: #FFF; width: 60%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify;  vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                         <p style="font-size:11px; ">     TÊN <asp:Button runat="server" ID="btnShortByTen" OnClick="btnShortByTen_Click" Text="^" /></p>
                                </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial;color: #fff; background-color: #FFF; width: 6%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify;  vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                       <p style="font-size:11px; ">        GIÁ <asp:Button runat="server" ID="btnShortByGia" OnClick="btnShortByGia_Click" Text="^" /></p>
                            </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; color: #fff; background-color: #FFF; width: 5%; text-align:center">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: left; vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                           <p style="font-size:11px; ">   VIP <asp:Button runat="server" ID="btnShortByVip" OnClick="btnShortByVip_Click" Text="^" /></p>
                            </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial;  color: #fff; background-color: #FFF; width: 6%; margin-left:1px">
                        <div style="float: right; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: left;  vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; font-size:13px; vertical-align: middle;" href="#">
                        <p style="font-size:11px; ">  BÁN  <asp:Button runat="server" ID="btnShortByBestSale" OnClick="btnShortByBestSale_Click" Text="^" /></p>
                            </a>
                        </div>
                    </td>
                    <td style="text-align: left; vertical-align: middle; font-family: Arial;  color: #fff; background-color: #FFF; width: 4%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: left;  vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; font-size:13px; vertical-align: middle;" href="#">
                        <p style="font-size:11px; float:left ">  Mua <asp:Button runat="server"  ID="btnShortByBuy"  OnClick="btnShortByBuy_Click" Text="^" /></p>
                            </a>
                        </div>
                    </td>
                     <td style="text-align: left; vertical-align: middle; font-family: Arial;  color: #fff; background-color: #FFF; width:5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: left;  vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; font-size:13px; vertical-align: middle;" href="#">
                        <p style="font-size:11px; ">  Thích <asp:Button runat="server"  ID="btnShortByLike"  OnClick="btnShortByLike_Click" Text="^" /></p>
                            </a>
                        </div>
                    </td>
                    
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; font-weight:bold;">
                            
                        </div>
                    </td>
                     <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; border-right: solid 1px #808080; font-weight:bold;">
                            
                        </div>
                    </td>
                </tr>
            </table>
    </div>
    <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; width: 99.9%; height: 30px;">
                <tr>   
                     <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #262626; background-color: #FFF; width: 4%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 14px; border-bottom: solid 1px #808080; border-left: solid 1px #808080;">
                            <%# Eval("TT")  %>|
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 60%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="Edit/ProductEdit.aspx?Id=<%# Eval("Id")  %>">
                                <%# Eval("Name")  %>
                            </>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 6%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                                   
                                  <%# Eval("Price")  %>
                            </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                                <%# Eval("VIP1") %>
                            </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 6%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                                <%# Eval("BESTSALE1")  %>
                            </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 4%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                                <%# Eval("CountBuy")  %>
                            </a>
                        </div>
                    </td>
                     <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                                <%# Eval("CountLike")  %>
                            </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; font-weight:bold;">
                            <a href="Edit/ProductEdit.aspx?Id=<%# Eval("Id")  %>">|
                                Sửa
                            </a>
                        </div>
                    </td>
                     <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; border-right: solid 1px #808080; font-weight:bold;">
                            <a href="Del/DelProduct.aspx?Id=<%# Eval("Id") %>">|
                                Xóa
                            </a>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #daf2a5; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td>
                <cc1:CollectionPager ID="CollectionPager2" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
</asp:Content>

