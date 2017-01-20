<%@ Page Title="SẢN PHẨM" Language="C#" MasterPageFile="~/Store.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Store_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container" style = "width:100%;">
        <div class="row">
            <div class="col-md-12">
                <div class="row tvsRowHeader">
                    <div id="div-col-1" class="col-md-1" style = "text-align:center;">TT</div>
                    <div id="div-col-9" class="col-md-9">Hàng hoá, dịch vụ</div>
                    <div  id="div-col-2" class="col-md-2">
                        <div style ="float:right;">
                            <a href ="ProductEdit.aspx">
                                <span class="btn_tbl_hd">Thêm mới</span>
                            </a>
                        </div>
                    </div>
                </div>
                <% Response.Write(this.strHtml); %>
            </div>
        </div>
    </div>
</asp:Content>

