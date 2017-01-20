<%@ Page Title="ĐỒNG THƯƠNG HIỆU " Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Brands.aspx.cs" Inherits="Brands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        .panel
        {
            padding-top:3px;
        }

    </style>
  
    <asp:Panel runat="server" ID="pnlBrands"  CssClass="panel" EnableViewState="false" BackColor="WhiteSmoke"  Height="100%" Width="100%">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <span class="glyphicon glyphicon-bookmark"></span> Đồng thương hiệu cùng  <a href="http://sucmanhcong.com/">SUCMANHCONG.COM</a> </h3>
                    </div>
                    <div class="panel-body">
                        <div class="thuonghieu">
                            <div class="row">
                                <% for (int i = 0; i < this.objTableBrand.Rows.Count; i++)
                                   { %>
                                <div class="col-md-3">
                                       <a href="<%Response.Write(this.objTableBrand.Rows[i]["Url"].ToString()); %>">
                                    <img class="fw" src="/Images/<%Response.Write(this.objTableBrand.Rows[i]["Logo"].ToString()); %>"
                                        style="border: solid 1px #dedee3; padding: 10px;" alt="<%Response.Write(this.objTableBrand.Rows[i]["Logo"].ToString()); %>" />
                                            </a>
                                </div>
                                <% } %>
                            </div>
                        </div>
                        </div>

                        
                </div>
            </div>
        </div>
    </div>
        </asp:Panel>


</asp:Content>

