<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ListStore.aspx.cs" Inherits="ListStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-6">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase; display: table; vertical-align: middle;">
                   Tất cả đại lý
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">Danh sách 
                    </span>
                </div>
            </div>
            <div class="col-md-6">
                <div style="float: right;">
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-warning">Điện thoại - Máy tính</button>
                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-success">Điện máy</button>
                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-info">Làm đẹp</button>
                    </div>
                    <div style="float: left; margin-right: 8px;">
                        <button type="button" class="btn btn-primary">Ẩm thực</button>
                    </div>
                    <div style="float: right;">
                        <button type="button" class="btn btn-secondary">Thời trang</button>
                    </div>
                </div>
            </div>
        </div>
        <hr />
    </div>
     <div class="row">
                    <div class="sanpham">
 
     
            <%if (this.objTablePartner.Rows.Count > 0) { %>
            <%for (int i = 0; i < this.objTablePartner.Rows.Count;i++ ) %>
               <%{ %>
              <div class="col-md-3">
                            <a href="/Store/?id=<%  Response.Write(this.objTablePartner.Rows[i]["Id"].ToString()); %>">
                                <img src="images/Partner/<%  Response.Write(this.objTablePartner.Rows[i]["Image"].ToString()); %>" alt="" />
                            </a>
                            <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial;">
                                <a href="/Store/?id=<% Response.Write(this.objTablePartner.Rows[i]["Id"].ToString()); %>">
                                    <%  Response.Write(this.objTablePartner.Rows[i]["Name"].ToString()); %>
                                </a>
                            </h4>
                            <p style ="text-align:justify;">
                                <%  Response.Write(this.objTablePartner.Rows[i]["Address"].ToString()); %>
                            </p>
                            <p>Điện thoại: <%  Response.Write(this.objTablePartner.Rows[i]["Phone"].ToString()); %></p>
                        </div>
            
            <%}}%>
            
       
     </div>
         </div>
    <div style="width:100%; margin-left:41%">
    <div class="col-md-2">
                    <div class="sotrang">
                        <table>
                            <tr>
                                <td><a href=""><i class="fa fa-angle-left"></i></a></td>
                                <td><a href="">1</a></td>
                                <td><a href="">2</a></td>
                                <td><a href="">3</a></td>
                                <td><a href="">4</a></td>
                                <td><a href="">5</a></td>
                                <td><a href="">6</a></td>
                                <td><a href=""><i class="fa fa-angle-right"></i></a></td>
                            </tr>
                        </table>
                    </div>
                </div>

    </div>
</asp:Content>

