<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="StoreVIP.aspx.cs" Inherits="StoreVIP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-6">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    display: table; vertical-align: middle;">
                    CỬA HÀNG BÁN CHẠY VIP
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">Hiện tại có  <%Response.Write(this.objTableStoreVip.Rows.Count); %>
                        cửa hàng bán chạy
                        VIP
                    </span>
                </div>
            </div>
            <div class="col-md-4" style="float:right">
                <div class="dropdown">
                    <asp:DropDownList runat="server" ID="ddlStoreType" OnSelectedIndexChanged ="ddlStoreType_SelectedIndexChanged" 
                        AutoPostBack="true" CssClass="form-control"  BackColor="White"    >
                       
                    </asp:DropDownList>
                    </div>
                   
            </div>
        </div>
        <hr />
    </div>
   
        
         <div class="container sanpham">
        <%for (int i = 0; i < this.objTableStoreVip.Rows.Count; i++)
          {  %>
            <div class="col-md-3">
                <div style="border: solid 1px #f6f6f6; height: 370px;">
                    <div style="text-align: center;">
                        <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial;
                       height:39px; overflow:hidden;      text-align: center; text-transform: uppercase;">
                            <%Response.Write(this.objTableStoreVip.Rows[i]["Name"].ToString()); %>
                        </h4>
                        <a href="/Store/Detailt.aspx?id= <%Response.Write(this.objTableStoreVip.Rows[i]["Id"].ToString()); %>">
                            <img src="../Images/Partner/<%Response.Write(this.objTableStoreVip.Rows[i]["Image"].ToString()); %>"
                                alt="Cua hang" style="width: 99%; margin-left: auto; height:200px; margin-right: auto;"
                                 onerror=" this.onerror = null  ; this.src = '../img/noImg.jpg'" /></a>
                    </div>
                    <div style="font-family: Arial; font-size: 13px; text-align: justify; padding: 5px;
                        color: #414441; height: 40px; overflow: hidden;">
                        <%Response.Write(this.objTableStoreVip.Rows[i]["Address"].ToString()); %>
                    </div>
                    <div style="font-family: Arial; font-size: 13px; font-weight: bold; text-align: justify;
                        padding: 5px; color: #414441; height: 30px; overflow: hidden;">
                        Điện thoại :      <%Response.Write(this.objTableStoreVip.Rows[i]["Phone"].ToString()); %>
                    </div>
                    <div style="text-align: center;">
                        <div class="Sotre_Location" <%="style=\"background-color:#" + ((int)this.objTableStoreVip.Rows[i]["Color"]).ToString("X") + "\" " %>>
                            <%Response.Write(this.objTableStoreVip.Rows[i]["Location"].ToString()); %>
                        </div>
                        <div style="margin-right: 5px; float: right; width: 47%; background-color: #ffc000;
                            color: #fff; height: 30px; line-height: 30px; display: block; vertical-align: middle;"
                            class="DetailtLink">
                            <a href="/Store/Detailt.aspx?id=<%Response.Write(this.objTableStoreVip.Rows[i]["Id"].ToString()); %>">Chi tiết</a>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        <% } %>

             </div>



</asp:Content>

