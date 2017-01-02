<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="StoreBestSale.aspx.cs" Inherits="StoreBestSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-6">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase;
                    display: table; vertical-align: middle;">
                    CỬA HÀNG BÁN CHẠY
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">Hiện tại có <%Response.Write(this.objTableStoreBestSale.Rows.Count); %>
                        cửa hàng bán chạy
                    </span>
                </div>
            </div>
            <div class="col-md-4" style="float:right;" >
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
        <%for (int i = 0; i < this.objTableStoreBestSale.Rows.Count; i++)
          {  %>
        <div class="col-md-3">
            <div class="fw" style="border: solid 1px #f6f6f6; height: 320px;">
                <div class="fw" style="text-align: center;">
                    <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial;
                        height: 39px; overflow: hidden; text-align: center; text-transform: uppercase;">
                        <%= this.objTableStoreBestSale.Rows[i]["Name"].ToString() %>
                    </h4>
                    <a class="fw" href="/Store/Detailt.aspx?id=<%= this.objTableStoreBestSale.Rows[i]["Id"].ToString() %>">
                        <img src="/Images/Partner/<%= this.objTableStoreBestSale.Rows[i]["Image"].ToString() %>"
                            alt="Cua hang" style="width: 99%; margin-left: auto; margin-right: auto; height: 145px"
                            onerror="this.onerror = null; this.src = '../img/noImg.jpg';" /></a>
                </div>
                <div style="font-family: Arial; font-size: 13px; text-align: justify; padding: 5px;
                    color: #414441; height: 40px; overflow: hidden;">
                    <%= this.objTableStoreBestSale.Rows[i]["Address"].ToString() %>
                </div>
                <div style="font-family: Arial; font-size: 13px; font-weight: bold; text-align: justify;
                    padding: 5px; color: #414441; height: 30px; overflow: hidden;">
                    Điện thoại :      <%= this.objTableStoreBestSale.Rows[i]["Phone"].ToString() %>
                </div>
                <div style="text-align: center;">
                    <div class="Sotre_Location" <%="style=\"background-color:#" + ((int)this.objTableStoreBestSale.Rows[i]["Color"]).ToString("X") + "\" " %>>
                        <%= this.objTableStoreBestSale.Rows[i]["Location"].ToString() %>
                    </div>
                    <div style="margin-right: 5px; float: right; width: 47%; background-color: #ffc000;
                        color: #fff; height: 30px; line-height: 30px; display: block; vertical-align: middle;"
                        class="DetailtLink">
                        <a href="/Store/Detailt.aspx?id=<%= this.objTableStoreBestSale.Rows[i]["Id"].ToString() %>">
                            Chi tiết</a>
                    </div>
                </div>
            </div>
            <br />
        </div>
        <% } %>
    </div>

</asp:Content>

