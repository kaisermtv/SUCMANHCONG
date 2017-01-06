<%@ Page Title="Yêu Cầu Quoảng Bá Sản Phẩm" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdvertmentProduct.aspx.cs" Inherits="System_Product" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style ="width:100%; height:32px; line-height:30px; background-color:#dde8ec; font-family:Arial; font-size:13px; font-weight:bold; text-transform:uppercase;">
        <div style ="float:left;">&nbsp;&nbsp;Hàng hóa - Dịch vụ</div>
       
          </div>
    <div class="row">
     <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; font-family:'Comic Sans MS'; font-family:13px;  width: 99.9%; height: 30px;">
                <tr>   
                     <td style="text-align: center; font-size:10px; vertical-align: middle; font-family: Arial;  color: #262626; background-color: #FFF; width: 4%;">
                        <div style="float: left; display: table-cell;  line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 14px; border-bottom: solid 1px #808080; border-left: solid 1px #808080;">
                        TT
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial;  color: #fff; background-color: #FFF; width: 40%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify;  vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                         <p style="font-size:11px; ">     TÊN </p>
                                </a>
                        </div>
                    </td>
                    <td style="text-align: center; vertical-align: middle; font-family: Arial;color: #fff; background-color: #FFF; width: 6%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify;  vertical-align: middle; font-size: 13px; border-bottom:solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="#">
                       <p style="font-size:11px; ">        GIÁ </p>
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
                            <a style="display: block; vertical-align: middle;" href="Edit/AdvertmentProductEdit.aspx?Id=<%# Eval("Id")  %>">
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
                   
                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; font-weight:bold;">
                            <a href="Edit/AdvertmentProductEdit.aspx?Id=<%# Eval("Id")  %>">|
                                Xem
                            </a>
                        </div>
                    </td>
                     <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 7.5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; font-weight:bold;">
                            <a href="#" onclick="">|
                            Đồng ý
                            </a>
                        </div>
                    </td>
                     <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 13px; color: #262626; background-color: #FFF; width: 5%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 13px; border-bottom: solid 1px #808080; border-right: solid 1px #808080; font-weight:bold;">
                            <a href="Del/DelAdvermnetProduct.aspx?Id=<%# Eval("Id") %>">|
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

