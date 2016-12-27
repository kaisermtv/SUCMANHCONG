<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListMedia.aspx.cs" Inherits="System_ListMedia" %>


<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style ="width:100%; height:32px; line-height:30px; background-color:#dde8ec; font-family:Arial; font-size:13px; font-weight:bold; text-transform:uppercase;">
        <div style ="float:left;">&nbsp;&nbsp;MEDIA - HÌNH ẢNH</div>
        <div style ="float:right;"><a href ="Edit/MediaEdit.aspx"><span style ="border:solid 1px #f8fbfc; padding:5px; font-size:11px; font-weight:bold; padding-left:20px; padding-right:20px;">Thêm mới</span></a>&nbsp;</div>
    </div>
    <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"
        Width="100%">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="1" border="0" style="margin: 0px; width: 100%; height: 150px;">
                <tr>   
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 100%;">
                        <div style="float: left; display: table-cell; line-height: 150px; width: 100%; height: 150px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px;">
                                <img src ="../Images/Media/<%# Eval("Image") %>" style ="width:100%; height:100%; margin-top:5px;" />
                        </div>
                    </td>
                </tr>
                <tr>   
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 11px; color: #fff; background-color: #FFF; width: 100%;">
                        <div style="float: left; display: table-cell; line-height: 34px; width: 100%; height: 34px; text-align: right; vertical-align: middle; font-size: 11px; font-weight:bold;">

                            &nbsp;&nbsp;
                            <a style="vertical-align: middle;" href="Del/DelMedia.aspx?Id=<%# Eval("Id") %>">
                                XÓA ẢNH
                            </a>
                            &nbsp;&nbsp;
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