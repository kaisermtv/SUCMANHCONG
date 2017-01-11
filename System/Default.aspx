<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
       Các chức năng hiện có cho quản trị trang web : 
    </p>
        <h3> I .Chat trực tuyến - Thống kê website </h3>
    <p>đi tới :  https://dashboard.subiz.com/  </p>
       <p>Tài khoản : support_sucmanhcong  </p>
       <p>Mật khẩu : hieupham  </p>
    <p style="font-family:'Comic Sans MS'">Lưu ý : Chức năng hổ trợ trực tuyến thuộc bên thứ 3 cung cấp . Mọi vấn đề phát sinh từ chức năng này có thể không thuộc quyền hạn của chúng tôi</p>
   <div class="popup">
        <h3> II .Các phản hồi từ trang web  </h3>
         <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; width: 99.9%; height: 30px;">
        <tr>
            <td class="head_table_item" style="width: 2%;">
                <div class="head_table_item_mg">
                    STT
                </div>
            </td>
            <td class="head_table_item" style="width: 16%;">
                <div class="head_table_item_mg" style="overflow:hidden">
                Tên
                </div>
            </td>
            <td class="head_table_item" style="width: 50%;">
                <div class="head_table_item_mg" style="overflow:hidden" >
                 Tiêu đề
                </div>
            </td>
            
            <td class="head_table_item" style="width: 20%;">
                <div class="head_table_item_mg" style="overflow:hidden">
                    Email
                </div>
            </td>
            

            <td class="head_table_item" style="width: 12%;">
                <div class="head_table_item_mg">
                    &nbsp;
                </div>
            </td>
        </tr>
    </table>
    <asp:DataList ID="dtlGroupAcc" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="99.9%">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; width: 99.9%; height: 30px;">
                <tr>
                    <td class="page_table_item" style="width: 2.3%;">
                        <div class="page_table_item center">
                            <%# Eval("TT") %>
                        </div>
                    </td>
                    <td class="page_table_item" style="width: 16%;">
                        <div class="page_table_item_mg">
                            <a style="display: block; vertical-align: middle;">
                                <%# Eval("Name") %>
                            </a>
                        </div>
                    </td>
                    <td class="page_table_item" style="width: 50%;">
                        <div class="page_table_item_mg center">
                            <a style="display: block; vertical-align: middle;" href="#">
                                <%# Eval("Subject") %>
                            </a>
                        </div>
                    </td>
                    
                    <td class="page_table_item" style="width: 20%;">
                        <div class="page_table_item_mg">
                            <a style="display: block; vertical-align: middle;" href="#">
                                <%# Eval("Email") %>
                            </a>
                        </div>
                    </td> 
                   
                    <td class="page_table_item" style="width: 8%;">
                        <div class="page_table_item_mg center">
                            <a href="ViewContactDetailt.aspx?Id=<%# Eval("Id") %>">Chi tiết
                             
                            </a>
                        </div>
                      
                    </td>
                   
                    <td class="page_table_item" style="width: 4%;">
                        <div class="page_table_item_mg center">
                            <a href="Del/DelContact.aspx?Id=<%# Eval("Id") %>">Xóa
                            </a>
                        </div>
                    </td>
               
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
     
      
    <table width="100%" cellpadding="0" cellspacing="0" border="0" class="footer_table"
        id="tblABC" runat="server">
        <tr>
            <td>
                <cc1:CollectionPager ID="cpGroupAcc" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>

   </div>
</asp:Content>

