<%@ Page Title="TÌM KIẾM" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Search_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
  
  
      <div class="container">
      <div class="well well-sm"><a href="#" class="alert-link">Tìm kiếm cho </a> : <%Response.Write(this.strFind); %></div>
            <div class="panel panel-success">
                 <div class="panel-heading">Cửa hàng :<span class="badge"> <%Response.Write(this.objTableStoreVip.Rows.Count.ToString()); %> </span>  .</div>
             <div class="row">
             
            <div class="sanpham">
          <!-- Tìm ra cửa hàng : 1 dòng 4 -->
              
                      <%for (int i = 0; i < this.objTableStoreVip.Rows.Count; i++)
          {  %>
            <div class="col-md-3" style="padding-bottom:20px;">
                <div style="border: solid 1px #f6f6f6; height: 262px;">
                    <div style="text-align: center;">
                        <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial;
                       height:39px; overflow:hidden;      text-align: center; text-transform: uppercase;">
                            <%Response.Write(this.objTableStoreVip.Rows[i]["Name"].ToString()); %>
                        </h4>
                        <a href="/Store/?id=1">
                            <img src="../Images/Partner/<%Response.Write(this.objTableStoreVip.Rows[i]["Image"].ToString()); %>"
                                alt="Cua hang" style="width: 100%; height:180px;  margin-right: auto;"  
                                onerror="this.onerror = null; this.src = '../img/noImg.jpg';" /></a>
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
           </div>
        </div>
           <div class="panel panel-success">
                 <div class="panel-heading">Sản phẩm :<span class="badge"> <%Response.Write(this.objTableProductVIP.Rows.Count.ToString()); %> </span>   </div>
      <div class="row">
            <div class="sanpham">
           <!-- Tìm ra sản phẩm : nhiều dòng dòng 4 -->
                
                      <%for (int i = 0; i < this.objTableProductVIP.Rows.Count; i++)
                 {  %>
                <div class="col-md-3" style="margin-bottom:10px">
                    <div style="background-color: #f9faf5; height: 375px; padding: 5px;">
                        <a href="/detailt.aspx?id=<%Response.Write(this.objTableProductVIP.Rows[i]["Id"].ToString()); %>">
                            <img src="images/Products/<%Response.Write(this.objTableProductVIP.Rows[i]["Image"].ToString()); %>" style="width: 100%; margin-left: auto; height:254px;"
                                 alt="San pham VIP"   onerror="this.onerror = null; this.src = '../img/noImg.jpg';"  /></a>
                        <p class="ProductLink" style="font-family: Arial; font-size: 15px; font-weight: bold; color: #50505a; height:50px; overflow:hidden; 
                             padding: 5px; text-align: justify; border-bottom: solid 2px #f0f0fb;" >
                            <a href="/detailt.aspx?id=<%Response.Write(this.objTableProductVIP.Rows[i]["Id"].ToString()); %>">
                                <%Response.Write(this.objTableProductVIP.Rows[i]["Name"].ToString()); %></a>
                        </p>
                        <div style="text-align: right; margin-top: -2px;">
                            <div style="font-family: Arial; font-size: 12px; color: #00a84b; font-weight: normal; padding-top: 0px; padding-left: 25px;">
                                <img src="/images/User.png" alt="So nguoi thich" style="width: 20px; margin-top: -8px;" />
                                  <%Response.Write(this.objTableProductVIP.Rows[i]["CountLike"].ToString()); %>
                            </div>
                        </div>
                        <p style="font-family: Arial; font-size: 14px; font-weight: bold; color: #50505a; padding: 5px; text-align: justify; margin-top: -4px;">
                            <span style="font-family: Arial; font-size: 22px; color: #00a84b; font-weight: normal;">
                                <%Response.Write(this.objTableProductVIP.Rows[i]["Price"].ToString()); %>&nbsp;<sup><u>đ</u></sup></span>
                            <span style="background-image: url('/Images/DiscountBg.png'); background-repeat: no-repeat; font-size: 14px; color: #fff;">&nbsp; -
                                <%Response.Write(this.objTableProductVIP.Rows[i]["Discount"].ToString()); %>% &nbsp;</span>
                        </p>

                        <input type="button" value="Đã mua:   <%Response.Write(this.objTableProductVIP.Rows[i]["CountBuy"].ToString()); %>" style="margin-top: -46px;" />
                    </div>
                </div>
                <%} %>

            </div>
        </div>
               </div>

    </div>
</asp:Content>

