﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PartnerProduct.aspx.cs" Inherits="System_PartnerProduct" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div style="width: 100%; height: 32px; line-height: 30px; background-color: #dde8ec; font-family: Arial; font-size: 13px; font-weight: bold; text-transform: uppercase;">
        <div style="float: left;">Hàng hóa - Dịch vụ : <% Response.Write(this.strName); %></div>
        <div style="float: right;"><a href="Edit/ProductEdit.aspx?partnerId=<% Response.Write(this.itemId); %>"><span style="border: solid 1px #f8fbfc; padding: 5px; font-size: 11px; font-weight: bold; padding-left: 20px; padding-right: 20px;">Thêm mới</span></a>&nbsp;</div>
    </div>


    
        <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; width: 99.9%; height: 30px;">
            <tr>
                <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #262626; background-color: #FFF; width: 4%;">
                    <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 14px; border-bottom: solid 1px #808080; border-left: solid 1px #808080; font-weight: bold;">
                        STT
                    </div>
                </td>
                <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 64%;">
                    <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080; font-weight: bold;">
                        Tên hàng
                    </div>
                </td>
                <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 6%;">
                    <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080; font-weight: bold;">
                        Đơn giá
                    </div>
                </td>
                <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 6%;">
                    <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080; font-weight: bold;">
                        SP VIP
                    </div>
                </td>
                <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 10%;">
                    <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080; font-weight: bold;">
                        SP bán chạy
                    </div>
                </td>
                <td class="head_table_item" style="width: 5%;">
                    <div class="head_table_item_mg">
                        &nbsp;
                    </div>
                </td>
                <td class="head_table_item" style="width: 5%;">
                    <div class="head_table_item_mg">
                        &nbsp;
                    </div>
                </td>
            </tr>
        </table>
        <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" BorderWidth="0"
            Width="100%">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; width: 99.9%; height: 30px;">
                    <tr>
                        <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #262626; background-color: #FFF; width: 4%;">
                            <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 14px; border-bottom: solid 1px #808080; border-left: solid 1px #808080;">
                                <%# Eval("TT") %>
                            </div>
                        </td>
                        <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 64%;">
                            <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                                <a style="display: block; vertical-align: middle;" href="#">
                                    <%# Eval("Name") %>
                                </a>
                            </div>
                        </td>
                        <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 6%;">
                            <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: right; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                                <a style="display: block; vertical-align: middle;" href="#">
                                    <%# Eval("Price") %>
                                </a>
                            </div>
                        </td>
                        <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 6%;">
                            <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                                <a style="display: block; vertical-align: middle;" href="#">
                                    <%# Eval("VIP1") %>
                                </a>
                            </div>
                        </td>
                        <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 10%;">
                            <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                                <a style="display: block; vertical-align: middle;" href="#">
                                    <%# Eval("BESTSALE1") %>
                                </a>
                            </div>
                        </td>
                        <td class="page_table_item" style="width: 5%;">
                            <div class="page_table_item center">
                                <a href="Edit/ProductEdit.aspx?Id=<%# Eval("Id") %>">Sửa
                                </a>
                            </div>
                        </td>

                        <td class="page_table_item" style="width: 5%;">
                            <div class="page_table_item center">
                                <a href="Del/DelProduct.aspx?Id=<%# Eval("Id") %>">Xóa
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
    </div>
</asp:Content>

