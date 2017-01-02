<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ListStore.aspx.cs" Inherits="ListStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script>
        function urlrl(vp, gr, loca, page)
        {
            var str = "?";
            if(vp != 0)
            {
                str += "Type=" + vp;
            }

            if (gr != 0) {
                if (str != "?") str += "&";
                str += "StoreType=" + gr;
            }

            if (loca != 0) {
                if (str != "?") str += "&";
                str += "Location=" + loca;
            }

            if (page > 1) {
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
                    Danh sách cửa hàng
                    <br />
                    <span style="font-size: 12px; font-weight: normal;">Hiện tại có <%= this.ncount %> cửa hàng
                    </span>
                </div>
            </div>
            <div class="col-md-2" style="float: right">
                <div class="dropdown">
                    <select class="form-control" onchange="window.location=urlrl(<%=this.VBType %>,<%=this.StoreType %>,this.value,0)">
                        <option value="0">--Vùng miền--</option>
                        <% for (int i = 0; i < this.objTableLocation.Count; i++) { %>
                        <option value="<%= this.objTableLocation[i]["Id"] %>" <% if (this.Location == (int)this.objTableLocation[i]["Id"]) Response.Write("selected='selected'"); %>><%= this.objTableLocation[i]["Name"] %></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div class="col-md-3" style="float: right">
                <div class="dropdown">
                    <select class="form-control" onchange="window.location=urlrl(<%=this.VBType %>,this.value,<%=this.Location %>,0)">
                        <option value="0">--Nhóm sản phẩm kinh doanh--</option>
                        <% for (int i = 0; i < this.objTableBusiness.Count; i++){ %>
                        <option value="<%= this.objTableBusiness[i]["Id"] %>" <% if (this.StoreType == (int)this.objTableBusiness[i]["Id"]) Response.Write("selected='selected'"); %>><%= this.objTableBusiness[i]["Name"] %></option>
                        <% } %>
                    </select>
                </div>
            </div>
            <div class="col-md-2" style="float: right">
                <div class="dropdown">
                    <select class="form-control" onchange="window.location=urlrl(this.value,<%=this.StoreType %>,<%=this.Location %>,0)">
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

