<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ListProduct.aspx.cs" Inherits="ListProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script>
        function urlrl(vp, gr,page) {
            var str = "?";
            if (vp != 0) {
                str += "Type=" + vp;
            }

            if (gr != 0) {
                if (str != "?") str += "&";
                str += "Group=" + gr;
            }

            if (page != 0) {
                if (str != "?") str += "&";
                str += "Page=" + page;
            }

            return str;
        }
    </script>

    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-5">
                <div style="font-family: Arial; font-size: 15px; font-weight: bold; text-transform: uppercase; display: table; vertical-align: middle;">
                    Danh sách sản phẩm
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">Hiện tại có <%= this.ncount %> sản phẩm
                    </span>
                </div>
            </div>
            <div class="col-md-3" style="float: right">
                <div class="dropdown">
                    <select class="form-control" onchange="window.location=urlrl(<%=this.VBType %>,this.value,0)">
                        <option value="0">--Nhóm sản phẩm--</option>
                        <% for (int i = 0; i < this.objRowProductGroup.Count; i++){ %>
                        <option value="<%= this.objRowProductGroup[i]["Id"] %>" <% if (this.ProductGroup == (int)this.objRowProductGroup[i]["Id"]) Response.Write("selected='selected'"); %>><%= this.objRowProductGroup[i]["Name"] %></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div class="col-md-2" style="float: right">
                <div class="dropdown">
                    <select class="form-control" onchange="window.location=urlrl(this.value,<%=this.ProductGroup %>,0)">
                        <option value="0">Tất cả</option>
                        <option value="1" <% if (this.VBType == 1) Response.Write("selected='selected'"); %>>Vip</option>
                        <option value="2" <% if (this.VBType == 2) Response.Write("selected='selected'"); %>>Bán chạy</option>
                    </select>
                </div>
            </div>
        </div>
        <hr />
    </div>

    <div class="container sanpham">
        <%for (int i = 0; i < this.objTableProduct.Rows.Count; i++) {  %>
        <%--<% if (this.objTableProduct.Rows[i]["Image"] == "" || this.objTableProduct.Rows[i]["Image"] == null) this.objTableProduct.Rows[i]["Image"] = "noImg.jpg"; %>--%>
            <div class="col-md-3" style="margin-top: 10px">
                <div class="sanpham_background">
                    <a class="fw" href="/detailt.aspx?id=<%= this.objTableProduct.Rows[i]["Id"].ToString() %>">
                        <img src="/images/Products/<%= this.objTableProduct.Rows[i]["Image"].ToString() %>" class="sanpham_avata" alt=" Nổi bật" onerror=" this.onerror = null  ; this.src ='/img/noImg.jpg'" />
                    </a>
                    <p class="ProductLink sanpham_title">
                        <a href="/detailt.aspx?id=<%= this.objTableProduct.Rows[i]["Id"].ToString() %> ">
                            <%= this.objTableProduct.Rows[i]["Name"].ToString() %>
                        </a>
                    </p>
                    <div style="text-align: right; margin-top: -2px;">
                        <div class="sanpham_like">
                            <img src="/images/User.png" alt="So nguoi thich" class="sanpham_like_img" style="width: 20px" />
                            <%= this.objTableProduct.Rows[i]["CountLike"].ToString() %>
                        </div>
                    </div>
                    <div class="sanpham_price_line">
                        <span class="sanpham_price">
                            <%= this.objTableProduct.Rows[i]["Price"].ToString() %>&nbsp;<sup><u>đ</u></sup>
                        </span>
                        <div class="sanpham_Discount">
                            &nbsp; -
                                <%= this.objTableProduct.Rows[i]["Discount"].ToString() %>% &nbsp;
                        </div>
                        <input type="button" value="Đã mua: <%= this.objTableProduct.Rows[i]["CountBuy"].ToString() %>" style="float: right;" />
                    </div>

                </div>

            </div>
            <% } %>
    </div>
    <div class="sotrang">
        <table>
            <tr>
                <td><a href="<%= this.GetUrlPage((this.nPage-1 > 0)?(this.nPage-1):1) %>"><i class="fa fa-angle-left"></i></a></td>
                <% if (this.nPage != 1){ %>
                <td><a href="<%=this.GetUrlPage(1) %>">1</a></td>
                <% } %>

                <% for (int i = ((this.nPage - 4 > 1) ? (this.nPage - 4) : 2); i < this.nPage; i++){ %>
                <td><a href="<%=this.GetUrlPage(i) %>"><%=i.ToString() %></a></td>
                <% } %>

                <td style="border-radius: 0%; background-color: aqua;"><%=this.nPage.ToString() %></td>

                <% for (int i = (this.nPage + 1); i < this.MaxPage && i < (this.nPage + 6); i++){ %>
                <td><a href="<%=this.GetUrlPage(i) %>"><%=i.ToString() %></a></td>
                <% } %>

                <% if (this.nPage < this.MaxPage){ %>
                <td><a href="<%=this.GetUrlPage(this.MaxPage) %>"><%= this.MaxPage.ToString() %></a></td>
                <% } %>
                <td><a href="<%=this.GetUrlPage((this.nPage+1 < this.MaxPage)?(this.nPage+1):this.MaxPage) %>"><i class="fa fa-angle-right"></i></a></td>

            </tr>
        </table>
    </div>

</asp:Content>

