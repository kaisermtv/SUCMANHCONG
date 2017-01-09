<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendEmailtoCustomer.aspx.cs" Inherits="System_SendEmailtoCustomer" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function selectAll(source) {
            checkboxes = document.getElementsByName('chk');
            for (var i = 0, n = checkboxes.length; i < n; i++) {
                checkboxes[i].checked = source.checked;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 100%; height: 32px; line-height: 30px; background-color: #dde8ec; font-family: Arial; font-size: 13px; font-weight: bold; text-transform: uppercase;">

      
        <div style="width: 10%; height: 100%; float: left;">
            <asp:Button runat="server" ID="btnEnterEmail" CssClass="btn center" OnClick="ClickMe_Click1" Text="Nhập nội dung" />
        </div>
        <div style="float: left; width: 20%; text-align: left;">
            <div style="float: left; width: 100%">
        Tất cả 
                <input type="checkbox" runat="server" id="chkState" onclick="selectAll(this)"  title="toàn bộ" />
            </div>
        </div>
        
           <div style="float: left; width: 30%; text-align: left;">
               <asp:TextBox  runat="server" Width="150px" ID="txtMailFrom" placeholder="example@gmail.com" ></asp:TextBox>
                  <asp:TextBox  runat="server"  Width="120px"  ID="txtPassword"  placeholder="**********" ></asp:TextBox>
            </div>

           <div style="float: right; width: 30%; text-align: right;">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold; margin-right: -2px;"
                    OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" Style="height: 28px; width: 75px; padding-bottom: 4px; font-weight: bold; margin-right: 6px;"
                    OnClick="btnCancel_Click" />
            </div>

    </div>

    <asp:Panel runat="server" ID="panel" CssClass="DialogueBackground" Visible="false">
        <div class="Dialogue">
            <div class="popup">

                <div class="clear10">
                    <asp:TextBox ID="txtEmailTitle" Width="500px" Height="30px" runat="server" placeholder="Tiêu đề email"></asp:TextBox>

                </div>
                <div class="clear10">
                    <asp:TextBox ID="txtEmailContent" Rows="5" runat="server" Width="500px" Height="300px" placeholder="Nội Dung email"></asp:TextBox>

                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="Hoàn thành" BorderStyle="None" CssClass="btn" OnClick="can1_Click" />
                <asp:Button ID="can1" runat="server" Text="Close" BorderStyle="None" CssClass="btn" OnClick="can1_Click" />
                <div class="clr">
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:DataList ID="DataList2" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" border="0" style="margin: 0px; width: 99.9%; height: 30px;">
                <tr>

                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #262626; background-color: #FFF; width: 4%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: center; vertical-align: middle; font-size: 14px; border-bottom: solid 1px #808080; border-left: solid 1px #808080;">
                            <%# Eval("TT") %>
                        </div>
                    </td>

                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 61%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                            <a style="display: block; vertical-align: middle;" href="PartnerProduct.aspx?Id=<%# Eval("Id") %>">
                                <%# Eval("Email") %>
                            </a>
                        </div>
                    </td>

                    <td style="text-align: center; vertical-align: middle; font-family: Arial; font-size: 15px; color: #fff; background-color: #FFF; width: 61%;">
                        <div style="float: left; display: table-cell; line-height: 30px; width: 100%; height: 30px; text-align: justify; padding-left: 5px; vertical-align: middle; font-size: 15px; border-bottom: solid 1px #808080;">
                            <input type="checkbox"  name="chk" value="" disabled="disabled" />
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

