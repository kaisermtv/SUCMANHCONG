<%@ Page Title="TÌM KIẾM" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script>
        function urlrl(vp, gr, lt, loca, spage, ppage) {
            var str = "?";
            if (vp != 0) {
                str += "Type=" + vp;
            }

            if (loca != 0) {
                if (str != "?") str += "&";
                str += "Location=" + loca;
            }

            if (lt != 0) {
                if (str != "?") str += "&";
                str += "lt=" + lt;
            }

            if (gr != 0) {
                if (str != "?") str += "&";
                str += "StoreType=" + gr;
            }
            
            sch = document.getElementById('inp_search').value;
            if (sch != "") {
                if (str != "?") str += "&";
                str += "Search=" + sch;
            }

            if (spage > 1) {
                if (str != "?") str += "&";
                str += "StorePage=" + spage;
            }

            if (ppage > 1) {
                if (str != "?") str += "&";
                str += "ProductPage=" + ppage;
            }

            return str;
        }

        $(function () {
            $('#inp_search').keypress(function (e) {
                if (e.which == 10 || e.which == 13) {
                    window.location=urlrl(<%=this.VBType %>,<%=this.StoreType %>,<%=this.LTFind %>,<%=this.Location %>,0,0);
                }
            });
        });

    </script>

    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-4">
                <div class="input-group" style="text-align: right; margin-left: 42px; height: 100%;width: 319px;">
                    <input type="text" name="Search" class="form-control" id="inp_search" value="<%=this.sSearch %>" placeholder="Tìm kiếm" style="width: 280px; height: 30px; line-height: 30px; margin-top: 3px;">
                    <div class="input-group-btn">
                        <div class="btn btn-default" onclick="window.location=urlrl(<%=this.VBType %>,<%=this.StoreType %>,<%=this.LTFind %>,<%=this.Location %>,0,0)" style="width: 40px; height: 30px; margin-top: 3px"><i class="glyphicon glyphicon-search"></i></div>
                    </div>
                </div>
            </div>
            <div class="col-md-2" style="float: right">
                <div class="dropdown">
                    <select class="form-control" name="Location" onchange="window.location=urlrl(<%=this.VBType %>,<%=this.StoreType %>,<%=this.LTFind %>,this.value,0,0)">
                        <option value="0">--Vùng miền--</option>
                        <% for (int i = 0; i < this.objTableLocation.Count; i++) { %>
                        <option value="<%= this.objTableLocation[i]["Id"] %>" <% if (this.Location == (int)this.objTableLocation[i]["Id"]) Response.Write("selected='selected'"); %>><%= this.objTableLocation[i]["Name"] %></option>
                        <% } %>
                    </select>
                </div>
            </div>
<%--            <div class="col-md-2" style="float: right">
                <div class="dropdown">
                    <select class="form-control" name="StoreType" onchange="window.location=urlrl(<%=this.VBType %>,this.value,<%=this.Location %>,0)">
                        <option value="0">--Nhóm sản phẩm kinh doanh--</option>
                        <% for (int i = 0; i < this.objTableBusiness.Count; i++){ %>
                        <option value="<%= this.objTableBusiness[i]["Id"] %>" <% if (this.StoreType == (int)this.objTableBusiness[i]["Id"]) Response.Write("selected='selected'"); %>><%= this.objTableBusiness[i]["Name"] %></option>
                        <% } %>
                    </select>
                </div>
            </div> --%>
            <div class="col-md-2" style="float: right">
                <div class="dropdown">
                    <select class="form-control" name="Type" onchange="window.location=urlrl(this.value,<%=this.StoreType %>,<%=this.LTFind %>,<%=this.Location %>,0,0)">
                        <option value="0">Tất cả</option>
                        <option value="1" <% if (this.VBType == 1) Response.Write("selected='selected'"); %>>Vip</option>
                        <option value="2" <% if (this.VBType == 2) Response.Write("selected='selected'"); %>>Bán chạy</option>
                    </select>
                </div>
            </div>
            <%--<div class="col-md-2" style="float: right">
                <div class="dropdown">
                    <select class="form-control" name="lt" onchange="window.location=urlrl(<%=this.VBType %>,<%=this.StoreType %>,this.value,<%=this.Location %>,0,0)">
                        <option value="0">Tất cả</option>
                        <option value="1" <% if (this.LTFind == 1) Response.Write("selected='selected'"); %>>Cửa hàng</option>
                        <option value="2" <% if (this.LTFind == 2) Response.Write("selected='selected'"); %>>Sản phẩm</option>
                    </select>
                </div>
            </div>--%>
        </div>
        <hr />
    </div>
    <div class="container panel panel-success" style="padding-left:0px;padding-right:0px">
                 <div class="panel-heading">Cửa hàng :<span class="badge"> <%Response.Write(this.ncount.ToString()); %> </span>  .</div>
    <div class="sanpham">
        <%for (int i = 0; i < this.objTableStore.Rows.Count; i++){  %>
        <div class="col-md-3">
            <div style="border: solid 1px #f6f6f6; height: 370px;">
                <div style="text-align: center;">
                    <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial; height: 39px; overflow: hidden; text-align: center; text-transform: uppercase;">
                        <%Response.Write(this.objTableStore.Rows[i]["Name"].ToString()); %>
                    </h4>
                    <a href="/Store/Detailt.aspx?id= <%Response.Write(this.objTableStore.Rows[i]["Id"].ToString()); %>">
                        <img src="../Images/Partner/<%Response.Write(this.objTableStore.Rows[i]["Image"].ToString()); %>"
                            alt="Cua hang" style="width: 99%; margin-left: auto; height: 200px; margin-right: auto;"
                            onerror=" this.onerror = null  ; this.src = '../img/noImg.jpg'" /></a>
                </div>
                <div style="font-family: Arial; font-size: 13px; text-align: justify; padding: 5px; color: #414441; height: 40px; overflow: hidden;">
                    <%Response.Write(this.objTableStore.Rows[i]["Address"].ToString()); %>
                </div>
                <div style="font-family: Arial; font-size: 13px; font-weight: bold; text-align: justify; padding: 5px; color: #414441; height: 30px; overflow: hidden;">
                    Điện thoại :      <%Response.Write(this.objTableStore.Rows[i]["Phone"].ToString()); %>
                </div>
                <div style="text-align: center;">
                    <div class="Sotre_Location" <%="style=\"background-color:#" + ((int)this.objTableStore.Rows[i]["Color"]).ToString("X") + "\" "%>>
                        <%Response.Write(this.objTableStore.Rows[i]["Location"].ToString()); %>
                    </div>
                    <div style="margin-right: 5px; float: right; width: 47%; background-color: #ffc000; color: #fff; height: 30px; line-height: 30px; display: block; vertical-align: middle;"
                        class="DetailtLink">
                        <a href="/Store/Detailt.aspx?id=<%Response.Write(this.objTableStore.Rows[i]["Id"].ToString()); %>">Chi tiết</a>
                    </div>
                </div>
            </div>
            <br />
        </div>
        <% } %>
    </div>

    <div class="sotrang">
        <table>
            <tr>
                <td><a href="<%= this.GetUrlPage((this.nPage-1 > 0)?(this.nPage-1):1,this.pPage) %>"><i class="fa fa-angle-left"></i></a></td>
                <% if (this.nPage != 1){ %>
                <td><a href="<%=this.GetUrlPage(1,this.pPage) %>">1</a></td>
                <% } %>

                <% for (int i = ((this.nPage - 4 > 1) ? (this.nPage - 4) : 2); i < this.nPage; i++){ %>
                <td><a href="<%=this.GetUrlPage(i,this.pPage) %>"><%=i.ToString() %></a></td>
                <% } %>

                <td style="border-radius: 0%; background-color: aqua;"><%=this.nPage.ToString() %></td>

                <% for (int i = (this.nPage + 1); i < this.MaxPage && i < (this.nPage + 6); i++){ %>
                <td><a href="<%=this.GetUrlPage(i,this.pPage) %>"><%=i.ToString() %></a></td>
                <% } %>

                <% if (this.nPage < this.MaxPage){ %>
                <td><a href="<%=this.GetUrlPage(this.MaxPage,this.pPage) %>"><%= this.MaxPage.ToString() %></a></td>
                <% } %>
                <td><a href="<%=this.GetUrlPage((this.nPage+1 < this.MaxPage)?(this.nPage+1):this.MaxPage,this.pPage) %>"><i class="fa fa-angle-right"></i></a></td>

            </tr>
        </table>
    </div>
        </div>

    <div class="container panel panel-success" style="padding-left:0px;padding-right:0px">
                 <div class="panel-heading">Sản phẩm :<span class="badge"> <%Response.Write(this.pcount.ToString()); %> </span>  .</div>
    
    <div class="sanpham">
        <%for (int i = 0; i < this.objTableProduct.Rows.Count; i++) {  %>
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
                                 <%                  
                       TVSFunc tvsPrice = new TVSFunc();
                       Response.Write(tvsPrice.formatPrice(this.objTableProduct.Rows[i]["Price"].ToString()));
                                %>
                          
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
                <td><a href="<%= this.GetUrlPage(this.nPage,(this.pPage-1 > 0)?(this.pPage-1):1) %>"><i class="fa fa-angle-left"></i></a></td>
                <% if (this.pPage != 1) { %>
                <td><a href="<%=this.GetUrlPage(this.nPage,1) %>">1</a></td>
                <% } %>

                <% for (int i = ((this.pPage - 4 > 1) ? (this.pPage - 4) : 2); i < this.pPage; i++){ %>
                <td><a href="<%=this.GetUrlPage(this.nPage,i) %>"><%=i.ToString() %></a></td>
                <% } %>

                <td style="border-radius: 0%; background-color: aqua;"><%=this.pPage.ToString() %></td>

                <% for (int i = (this.pPage + 1); i < this.pMaxPage && i < (this.pPage + 6); i++){ %>
                <td><a href="<%=this.GetUrlPage(this.nPage,i) %>"><%=i.ToString() %></a></td>
                <% } %>

                <% if (this.pPage < this.pMaxPage){ %>
                <td><a href="<%=this.GetUrlPage(this.nPage,this.pMaxPage) %>"><%= this.pMaxPage.ToString() %></a></td>
                <% } %>
                <td><a href="<%=this.GetUrlPage(this.nPage,(this.pPage+1 < this.pMaxPage)?(this.pPage+1):this.pMaxPage) %>"><i class="fa fa-angle-right"></i></a></td>

            </tr>
        </table>
    </div>
    </div>
</asp:Content>

