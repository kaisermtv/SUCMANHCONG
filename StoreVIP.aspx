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
                    <span style="font-size: 12px; font-weight: normal;">Hiện tại có    <%Response.Write(this.objTableStoreVip.Rows.Count); %> cửa hàng bán chạy
                        VIP
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



    <div class="container">
        <% int k = 1;  %>
        <%for (int i = 0; i < this.objTableStoreVip.Rows.Count; i++)
          {  %>
        <% if (k % 4 == 0 || k == 1)   // hết 1 dòng
           {
               Response.Write(" <div class='row'>");
           }
        %>
        <div class="">
            <div class="col-md-3">
                <div style="border: solid 1px #f6f6f6; height: 262px;">
                    <div style="text-align: center;">
                            <%if (this.objTableStoreVip.Rows[i]["Name"].ToString().Length > 17)
                              {
                                  Response.Write("<h4 style='font-size: 18px; font-weight: bold; color: #505068; font-family: Arial;text-align: center; text-transform: uppercase;'>");
                                  Response.Write("<marquee behavior='scroll' direction='left 'style='font-size: 18px; font-weight: bold; color: #505068; font-family: Arial;text-align: center; text-transform: uppercase;' > ");
                                 Response.Write((this.objTableStoreVip.Rows[i]["Name"].ToString()));
                                 Response.Write("</marquee>");
                                 Response.Write("</h4>");
                              }
                              else
                              { %>
                        <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial;
                            text-align: center; text-transform: uppercase;">
                            <%Response.Write(this.objTableStoreVip.Rows[i]["Name"].ToString());
                              } %>
                        </h4>
                        <a href="/Store/?id=1">
                            <img src="../Images/Partner/<%Response.Write(this.objTableStoreVip.Rows[i]["Image"].ToString()); %>" alt="Cua hang" style="width: 95%; margin-left: auto;
                                margin-right: auto;" /></a>
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
                        <div style="margin-left: 5px; float: left; width: 47%; background-color: #337ab7;
                            color: #fff; height: 30px; line-height: 30px; display: table; vertical-align: middle;">
                            Nghệ An
                        </div>
                        <div style="margin-right: 5px; float: right; width: 47%; background-color: #ffc000;
                            color: #fff; height: 30px; line-height: 30px; display: block; vertical-align: middle;"
                            class="DetailtLink">
                            <a href="/Store.aspx/?id=1">Chi tiết</a>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>

        <%  %>
        <% if (k % 4 == 0 || k == 0)
           {
               Response.Write(" </div>");  // hết 1 dòng
               }
           k++;
          }  %>
    </div>

    <div class="row" style="margin-left: 45%">
        <div class="col-md-2">
            <div class="sotrang">
                <table>
                    <tr>
                        <td><a href="" style="move-to: normal"><i class="fa fa-angle-left"></i></a></td>
                        <td><a href="">1</a></td>
                        <td><a href="">2</a></td>
                        <td><a href="">3</a></td>
                        <td><a href="">All</a></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>


    <style> 
       

.textAmination {  
    position: relative;
    -webkit-animation: myfirst 5s linear 2s infinite alternate; /* Safari 4.0 - 8.0 */
    animation: myfirst 10s linear 2s infinite alternate;
}

/* Safari 4.0 - 8.0 */
@-webkit-keyframes myfirst {
    0%   { left:0px; top:0px;}
    25%  { left:200px; top:0px;}
    50%  { left:200px; top:0;}
    75%  { left:0px; top:0;}
    100% { left:0px; top:0px;}
}

/* Standard syntax */
@keyframes myfirst {
    0%   { left:0px; top:0px;}
    25%  { left:200px; top:0px;}
    50%  {left:200px; top:0;}
    75%  { left:0px; top:0;}
    100% { left:0px; top:0px;}
}
</style>
</asp:Content>

