<%@ Page Title="SUCMANHCONG" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="top_main">
            <div class="row">
                <div class="col-md-12">
                    <div class="slide">
                        <script type="text/javascript" src="js/jssor.slider-21.1.5.min.js"></script>
                        <!-- use jssor.slider-21.1.5.debug.js instead for debug -->

                        <script>
                            jssor_1_slider_init = function () {
                                var jssor_1_SlideoTransitions = [
                                  [{ b: 0, d: 1140, y: -290, e: { y: 27 } }],
                                  [{ b: 0, d: 1000, y: 185 }, { b: 1000, d: 500, o: -1 }, { b: 1500, d: 500, o: 1 }, { b: 2000, d: 1500, r: 360 }, { b: 3500, d: 1000, rX: 30 }, { b: 4500, d: 500, rX: -30 }, { b: 5000, d: 1000, rY: 30 }, { b: 6000, d: 500, rY: -30 }, { b: 6500, d: 500, sX: 1 }, { b: 7000, d: 500, sX: -1 }, { b: 7500, d: 500, sY: 1 }, { b: 8000, d: 500, sY: -1 }, { b: 8500, d: 500, kX: 30 }, { b: 9000, d: 500, kX: -30 }, { b: 9500, d: 500, kY: 30 }, { b: 10000, d: 500, kY: -30 }, { b: 10500, d: 500, c: { x: 87.50, t: -87.50 } }, { b: 11000, d: 500, c: { x: -87.50, t: 87.50 } }],
                                  [{ b: 0, d: 1140, x: 410, e: { x: 27 } }],
                                  [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, o: 1, e: { o: 5 } }],
                                  [{ b: -1, d: 1, c: { x: 175.0, t: -175.0 } }, { b: 0, d: 800, c: { x: -175.0, t: 175.0 }, e: { c: { x: 7, t: 7 } } }],
                                  [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, x: -570, o: 1, e: { x: 6 } }],
                                  [{ b: -1, d: 1, o: -1, r: -180 }, { b: 0, d: 800, o: 1, r: 180, e: { r: 7 } }],
                                  [{ b: 0, d: 1000, y: 80, e: { y: 24 } }, { b: 1000, d: 1100, x: 570, y: 170, o: -1, r: 30, sX: 9, sY: 9, e: { x: 2, y: 6, r: 1, sX: 5, sY: 5 } }],
                                  [{ b: 2000, d: 1140, rY: 30 }],
                                  [{ b: 0, d: 500, x: -105 }, { b: 500, d: 500, x: 230 }, { b: 1000, d: 500, y: -120 }, { b: 1500, d: 500, x: -70, y: 120 }, { b: 2600, d: 500, y: -80 }, { b: 3100, d: 900, y: 160, e: { y: 24 } }],
                                  [{ b: 0, d: 1000, o: -0.4, rX: 2, rY: 1 }, { b: 1000, d: 1000, rY: 1 }, { b: 2000, d: 1000, rX: -1 }, { b: 3000, d: 1000, rY: -1 }, { b: 4000, d: 1000, o: 0.4, rX: -1, rY: -1 }]
                                ];
                                var jssor_1_options = {
                                    $AutoPlay: true,
                                    $Idle: 2000,
                                    $CaptionSliderOptions: {
                                        $Class: $JssorCaptionSlideo$,
                                        $Transitions: jssor_1_SlideoTransitions,
                                        $Breaks: [
                                          [{ d: 2000, b: 1000 }]
                                        ]
                                    },
                                    $ArrowNavigatorOptions: {
                                        $Class: $JssorArrowNavigator$
                                    },
                                    $BulletNavigatorOptions: {
                                        $Class: $JssorBulletNavigator$
                                    }
                                };
                                var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);
                                //responsive code begin
                                //you can remove responsive code if you don't want the slider scales while window resizing
                                function ScaleSlider() {
                                    var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                                    if (refSize) {
                                        refSize = Math.min(refSize, 1140);
                                        jssor_1_slider.$ScaleWidth(refSize);
                                    }
                                    else {
                                        window.setTimeout(ScaleSlider, 30);
                                    }
                                }
                                ScaleSlider();
                                $Jssor$.$AddEvent(window, "load", ScaleSlider);
                                $Jssor$.$AddEvent(window, "resize", ScaleSlider);
                                $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
                                //responsive code end
                            };
                        </script>

                        <style>
                            /* jssor slider bullet navigator skin 01 css */
                            /*
                            .jssorb01 div           (normal)
                            .jssorb01 div:hover     (normal mouseover)
                            .jssorb01 .av           (active)
                            .jssorb01 .av:hover     (active mouseover)
                            .jssorb01 .dn           (mousedown)
                            */
                            .jssorb01 {
                                position: absolute;
                            }

                                .jssorb01 div, .jssorb01 div:hover, .jssorb01 .av {
                                    position: absolute;
                                    /* size of bullet elment */
                                    width: 12px;
                                    height: 12px;
                                    filter: alpha(opacity=70);
                                    opacity: .7;
                                    overflow: hidden;
                                    cursor: pointer;
                                    border: #000 1px solid;
                                }

                                .jssorb01 div {
                                    background-color: gray;
                                }

                                    .jssorb01 div:hover, .jssorb01 .av:hover {
                                        background-color: #d3d3d3;
                                    }

                                .jssorb01 .av {
                                    background-color: #fff;
                                }

                                .jssorb01 .dn, .jssorb01 .dn:hover {
                                    background-color: #555555;
                                }
                            /* jssor slider arrow navigator skin 02 css */
                            /*
                            .jssora02l                  (normal)
                            .jssora02r                  (normal)
                            .jssora02l:hover            (normal mouseover)
                            .jssora02r:hover            (normal mouseover)
                            .jssora02l.jssora02ldn      (mousedown)
                            .jssora02r.jssora02rdn      (mousedown)
                            */
                            .jssora02l, .jssora02r {
                                display: block;
                                position: absolute;
                                /* size of arrow element */
                                width: 55px;
                                height: 55px;
                                cursor: pointer;
                                background: url('img/a02.png') no-repeat;
                                overflow: hidden;
                            }

                            .jssora02l {
                                background-position: -3px -33px;
                            }

                            .jssora02r {
                                background-position: -63px -33px;
                            }

                            .jssora02l:hover {
                                background-position: -123px -33px;
                            }

                            .jssora02r:hover {
                                background-position: -183px -33px;
                            }

                            .jssora02l.jssora02ldn {
                                background-position: -3px -33px;
                            }

                            .jssora02r.jssora02rdn {
                                background-position: -63px -33px;
                            }
                        </style>

                        <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 1140px; height: 238px; overflow: hidden; visibility: hidden;">
                            <!-- Loading Screen -->
                            <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
                                <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;">
                                </div>
                                <div style="position: absolute; display: block; background: url('img/loading.gif') no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;">
                                </div>
                            </div>

                            <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 1140px; height: 238px; overflow: hidden;">

                                <% for (int i = 0; i < this.objTableSlide.Rows.Count; i++)
                                   {%>
                                <div data-p="112.50" style="display: none;">
                                    <img data-u="image" src="/Images/Slides/<% Response.Write(this.objTableSlide.Rows[i]["Image"].ToString()); %>" />
                                    <div data-u="caption" data-t="0" style="position: absolute; top: 320px; left: 30px; font-family: 'Comic Sans MS'; width: 350px; height: 30px; background-color: whitesmoke; text-decoration-color: red; font-size: 40px; opacity: 0.8; color: #ffffff; line-height: 30px; text-align: center; font-size: 18px; border-radius: 30px;">
                                        <a style="font-family: 'Comic Sans MS'; font-size: 20px; color: red;" href="<%= this.objTableSlide.Rows[i]["Url"] %>">
                                            <%= this.objTableSlide.Rows[i]["Name"] %>
                                        </a>
                                    </div>
                                </div>
                                <%} %>
                            </div>
                            <!-- Bullet Navigator -->
                            <div data-u="navigator" class="jssorb01" style="bottom: 16px; right: 16px;">
                                <div data-u="prototype" style="width: 12px; height: 12px;"></div>
                            </div>
                            <!-- Arrow Navigator -->
                            <span data-u="arrowleft" class="jssora02l" style="top: 0px; left: 8px; width: 55px; height: 55px;"
                                data-autocenter="2"></span>
                            <span data-u="arrowright" class="jssora02r" style="top: 0px; right: 8px; width: 55px; height: 55px;"
                                data-autocenter="2"></span>
                        </div>

                        <script>
                            jssor_1_slider_init();
                        </script>
                        <!-- #endregion Jssor Slider End -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12">


                <!----->
                <div class="menu">
                    <a href="/ListProduct?Type=1"><i class="glyphicon glyphicon-th-list"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">SẢN PHẨM VIP</span>
                    </a>
                    <a href="/ListProduct?Type=2"><i class="glyphicon glyphicon-th"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">SẢN PHẨM BÁN CHẠY</span>
                    </a>
                    <a href="/ListStore?Type=1"><i class="glyphicon glyphicon-tower"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">CỬA HÀNG VIP</span></a>
                    <a href="/ListStore?Type=2"><i class="glyphicon glyphicon-tasks"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">CỬA HÀNG BÁN CHẠY</span></a>
                    <a href="/Brands.aspx"><i class="glyphicon glyphicon-check"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">ĐỒNG THƯƠNG HIỆU</span></a>
                    <a href="/TopBrands.aspx"><i class="glyphicon glyphicon-stats"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">THƯƠNG HIỆU NỔI BẬT</span></a>
                    <a href="/About.aspx"><i class="glyphicon glyphicon-home"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">CHÚNG TÔI</span></a>
                    <a href="/NewsDetailt?Id=9"><i class="glyphicon glyphicon-book"></i>
                        <br />
                        <span style="margin-top: -20px; font-size: 11px; font-family: Arial; font-weight: bold; text-transform: uppercase; color: #01a44b;">ĐÀO TẠO</span></a>
                </div>
                <!----->
            </div>
        </div>
        <div class="row">
            <div class="phan1">
                <div class="col-md-3">
                    <h2 class="StoreVIPLink">
                        <a href="/ListProduct?Type=1">SẢN PHẨM BÁN CHẠY VIP</a>
                    </h2>
                </div>
                <div class="col-md-9">
                    &nbsp;
                </div>
            </div>
        </div>
        <div id="myCarousel" class="sanpham carousel slide" data-ride="carousel">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%for (int i = 0; i < this.objTableProductVIP.Rows.Count; i++)
                      {  %>
                    <% if (i % 4 == 0 && i != 0)
                       { %>
                </div>
                <div class="item">
                    <% } %>
                    <div class="col-md-3" style="margin-top: 10px">
                        <div class="sanpham_background">
                            <a class="fw" href="/detailt.aspx?id=<%= this.objTableProductVIP.Rows[i]["Id"].ToString() %>">
                                <img src="/images/Products/<%= this.objTableProductVIP.Rows[i]["Image"].ToString() %>" class="sanpham_avata" alt=" Nổi bật" />
                            </a>
                            <p class="ProductLink sanpham_title">
                                <a href="/detailt.aspx?id=<%= this.objTableProductVIP.Rows[i]["Id"].ToString() %> ">
                                    <%= this.objTableProductVIP.Rows[i]["Name"].ToString() %>
                                </a>
                            </p>
                            <div style="text-align: right; margin-top: -2px;">
                                <div class="sanpham_like">
                                    <img src="/images/User.png" alt="So nguoi thich" class="sanpham_like_img" style="width: 20px" />
                                    <%= this.objTableProductVIP.Rows[i]["CountLike"].ToString() %>
                                </div>
                            </div>
                            <div class="sanpham_price_line">
                                <span class="sanpham_price">
                                    <%                  
                       TVSFunc tvsPrice = new TVSFunc();
                       Response.Write(tvsPrice.formatPrice(this.objTableProductVIP.Rows[i]["Price"].ToString()));
                                %>
                                </span>
                                <div class="sanpham_Discount">
                                    &nbsp; -
                                <%= this.objTableProductVIP.Rows[i]["Discount"].ToString() %>% &nbsp;
                                </div>
                                <input type="button" value="Đã mua: <%= this.objTableProductVIP.Rows[i]["CountBuy"].ToString() %>" style="float: right;" />
                            </div>

                        </div>

                    </div>
                    <% } %>
                </div>

            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>

    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h2 class="StoreVIPLink">
                    <a href="/ListProduct?Type=2">SẢN PHẨM BÁN CHẠY %</a>
                </h2>
            </div>

            <div class="line">
                <div class="col-md-7">
                    <img src="images/line.jpg" alt="" />
                </div>
            </div>
        </div>

        <div class="sanpham">
            <%for (int i = 0; i < this.objTableBestSale.Rows.Count && i < 8; i++)
              {  %>
            <div class="col-md-3" style="margin-top: 10px">
                <div class="sanpham_background">
                    <a class="fw" href="/detailt.aspx?id=<%= this.objTableBestSale.Rows[i]["Id"].ToString() %>">
                        <img src="/images/Products/<%= this.objTableBestSale.Rows[i]["Image"].ToString() %>" class="sanpham_avata" alt=" Nổi bật" />
                    </a>
                    <p class="ProductLink sanpham_title">
                        <a href="/detailt.aspx?id=<%= this.objTableBestSale.Rows[i]["Id"].ToString() %> ">
                            <%= this.objTableBestSale.Rows[i]["Name"].ToString() %>
                        </a>
                    </p>
                    <div style="text-align: right; margin-top: -2px;">
                        <div class="sanpham_like">
                            <img src="/images/User.png" alt="So nguoi thich" class="sanpham_like_img" style="width: 20px" />
                            <%= this.objTableBestSale.Rows[i]["CountLike"].ToString() %>
                        </div>
                    </div>
                    <div class="sanpham_price_line">
                        <span class="sanpham_price">
                            <% 
                  TVSFunc tvsPrice = new TVSFunc();
                  Response.Write(tvsPrice.formatPrice(this.objTableBestSale.Rows[i]["Price"].ToString()));
                            %>
                        
                        </span>
                        <div class="sanpham_Discount">
                            &nbsp; -
                                <%= this.objTableBestSale.Rows[i]["Discount"].ToString() %>% &nbsp;
                        </div>
                        <input type="button" value="Đã mua: <%= this.objTableBestSale.Rows[i]["CountBuy"].ToString() %>" style="float: right;" />
                    </div>

                </div>

            </div>
            <% } %>
        </div>

        <div class="col-md-12">
            <div class="sotrang">
                <table>
                    <tr>
                        <td><a href="<%= "?PageProduct="+ ((this.PageProduct-1 > 0)?(this.PageProduct-1):1) +"&PagePartner="+this.PagePartner.ToString() %>"><i class="fa fa-angle-left"></i></a></td>
                        <% if (this.PageProduct != 1)
                           { %>
                        <td><a href="<%= "?PageProduct=1&PagePartner="+this.PagePartner.ToString() %>">1</a></td>
                        <% } %>

                        <% for (int i = ((this.PageProduct - 4 > 1) ? (this.PageProduct - 4) : 2); i < this.PageProduct; i++)
                           { %>
                        <td><a href="<%= "?PageProduct="+i.ToString()+"&PagePartner="+this.PagePartner.ToString() %>"><%=i.ToString() %></a></td>
                        <% } %>

                        <td><%=this.PageProduct.ToString() %></td>

                        <% for (int i = (this.PageProduct + 1); i < this.CountPageProduct && i < (this.PageProduct + 6); i++)
                           { %>
                        <td><a href="<%= "?PageProduct="+i.ToString()+"&PagePartner="+this.PagePartner.ToString() %>"><%=i.ToString() %></a></td>
                        <% } %>

                        <% if (this.PageProduct < this.CountPageProduct)
                           { %>
                        <td><a href="<%= "?PageProduct="+ this.CountPageProduct.ToString() +"&PagePartner="+this.PagePartner.ToString() %>"><%= this.CountPageProduct.ToString() %></a></td>
                        <% } %>
                        <td><a href="<%= "?PageProduct="+ ((this.PageProduct+1 < this.CountPageProduct)?(this.PageProduct+1):this.CountPageProduct) +"&PagePartner="+this.PagePartner.ToString() %>"><i class="fa fa-angle-right"></i></a></td>

                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div style="clear: both;"></div>
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h2 class="StoreVIPLink">
                    <a href="/ListStore?Type=1">CỬA HÀNG BÁN CHẠY VIP</a>
                </h2>
            </div>
            <div class="line">
                <div class="col-md-7">
                    <img src="/images/line.jpg" alt="" />
                </div>
            </div>


        </div>


        <div id="myCarousel1" class="sanpham carousel slide" data-ride="carousel">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%for (int i = 0; i < this.objTablePartner.Rows.Count && i < 8; i++)
                      {  %>
                    <% if (i % 4 == 0 && i != 0)
                       { %>
                </div>
                <div class="item">
                    <% } %>
                    <div class="col-md-3">
                        <a class="fw" href="/Store/Detailt.aspx?id=<%= this.objTablePartner.Rows[i]["Id"].ToString() %>">
                            <img style="height: 145px; width: 100%" src="images/Partner/<%= this.objTablePartner.Rows[i]["Image"].ToString() %>" alt="" />
                        </a>
                        <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial; height: 35px; overflow: hidden;">
                            <a href="/Store/Detailt.aspx?id=<%= this.objTablePartner.Rows[i]["Id"].ToString() %>">
                                <%= this.objTablePartner.Rows[i]["Name"].ToString()+"(-"+ this.objTablePartner.Rows[i]["Discount"] +"%)"  %>
                            </a>
                        </h4>
                        <p style="text-align: justify; height: 20px; overflow: hidden;">
                            <%= this.objTablePartner.Rows[i]["Address"].ToString() %>
                        </p>
                        <p>
                            Điện thoại: <%= this.objTablePartner.Rows[i]["Phone"].ToString() %>
                        </p>
                    </div>
                    <% } %>
                </div>

            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel1" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel1" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>

    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h2 class="StoreVIPLink">
                    <a href="/ListStore?Type=2">CỬA HÀNG BÁN CHẠY</a>
                </h2>
            </div>
            <div class="line">
                <div class="col-md-7">
                    <img src="images/line.jpg" alt="" />
                </div>
            </div>
        </div>
        <div class="sanpham">
            <% for (int i = 0; i < this.objTablePartnerBestSale.Rows.Count; i++)
               { %>
            <div class="col-md-3">
                <a class="fw" href="/Store/Detailt.aspx?id=<%= this.objTablePartnerBestSale.Rows[i]["Id"].ToString() %>">
                    <img style="height: 145px; width: 100%" src="images/Partner/<%= this.objTablePartnerBestSale.Rows[i]["Image"].ToString() %>" alt="" />
                </a>
                <h4 style="font-size: 18px; font-weight: bold; color: #505068; font-family: Arial; height: 35px; overflow: hidden;">
                    <a href="/Store/Detailt.aspx?id=<%= this.objTablePartnerBestSale.Rows[i]["Id"].ToString() %>">
                        <%= this.objTablePartnerBestSale.Rows[i]["Name"].ToString()+"(-"+ this.objTablePartnerBestSale.Rows[i]["Discount"].ToString() +"%)"  %>
                    </a>
                </h4>
                <p style="text-align: justify; height: 20px; overflow: hidden;">
                    <%= this.objTablePartnerBestSale.Rows[i]["Address"].ToString() %>
                </p>
                <p>
                    Điện thoại: <%= this.objTablePartnerBestSale.Rows[i]["Phone"].ToString() %>
                </p>
            </div>
            <% } %>
        </div>


        <div class="col-md-12">
            <div class="sotrang">
                <table>
                    <tr>
                        <td><a href="<%= "?PagePartner="+ ((this.PagePartner-1 > 0)?(this.PagePartner-1):1) +"&PageProduct="+this.PageProduct.ToString() %>"><i class="fa fa-angle-left"></i></a></td>
                        <% if (this.PagePartner != 1)
                           { %>
                        <td><a href="<%= "?PagePartner=1&PageProduct="+this.PageProduct.ToString() %>">1</a></td>
                        <% } %>

                        <% for (int i = ((this.PagePartner - 4 > 1) ? (this.PagePartner - 4) : 2); i < this.PagePartner; i++)
                           { %>
                        <td><a href="<%= "?PagePartner="+i.ToString()+"&PageProduct="+this.PageProduct.ToString() %>"><%=i.ToString() %></a></td>
                        <% } %>

                        <td><%=this.PagePartner.ToString() %></td>

                        <% for (int i = (this.PagePartner + 1); i < this.CountPagePartner && i < (this.PagePartner + 6); i++)
                           { %>
                        <td><a href="<%= "?PagePartner="+i.ToString()+"&PageProduct="+this.PageProduct.ToString() %>"><%=i.ToString() %></a></td>
                        <% } %>

                        <% if (this.PagePartner < this.CountPagePartner)
                           { %>
                        <td><a href="<%= "?PagePartner="+ this.CountPagePartner.ToString() +"&PageProduct="+this.PageProduct.ToString() %>"><%= this.CountPagePartner.ToString() %></a></td>
                        <% } %>
                        <td><a href="<%= "?PagePartner="+ ((this.PagePartner+1 < this.CountPagePartner)?(this.PagePartner+1):this.CountPagePartner) +"&PageProduct="+this.PageProduct.ToString() %>"><i class="fa fa-angle-right"></i></a></td>

                    </tr>
                </table>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h2 style="font-family: Arial; font-size: 18px; font-weight: bold; color: black; padding-top: 18px; padding-left: 25px; color: #4e4e57;">ĐỒNG THƯƠNG HIỆU</h2>
            </div>
            <div class="line">
                <div class="col-md-7">
                    <img src="/images/line.jpg" alt="" />
                </div>
            </div>
            <div class="col-lg-2" style="text-align: right; margin-top: 42px;">
                <div class="btn-group">
                    <button onclick="window.location.href='Brands.aspx'" type="button" class="btn btn-danger">Xem tất cả</button>
                    <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">
                        <span class="caret"></span>
                       
                    </button>
                   
                </div>
            </div>
        </div>

        <div class="thuonghieu">
            <div class="row">
                <div class="col-md-3">
                    <img src="/images/dongthuonghieubg.png" alt="" />
                </div>
                <% for (int i = 0; i < this.objTableBrand.Rows.Count && i < 3; i++)
                   { %>
                <div class="col-md-3">
                    <img class="fw" src="/Images/<%Response.Write(this.objTableBrand.Rows[i]["Logo"].ToString()); %>"
                        alt="" style="border: solid 1px #f4f4f4; padding: 10px;" />
                    <img class="fw" src="/Images/<%Response.Write(this.objTableBrand.Rows[i + 3]["Logo"].ToString()); %>"
                        alt="" style="border: solid 1px #f4f4f4; padding: 10px; margin-top: 10px;" />
                </div>

                <% } %>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <h2 style="font-family: Arial; font-size: 18px; font-weight: bold; color: black; padding-top: 18px; padding-left: 25px; color: #4e4e57;">THƯƠNG HIỆU NỔI BẬT</h2>
            </div>
            <div class="line">
                <div class="col-md-7">
                    <img src="/images/line.jpg" alt="" />
                </div>
            </div>
            <div class="col-lg-2" style="text-align: right; margin-top: 42px;">
                <div class="btn-group">
                    <button type="button" onclick="window.location.href='TopBrands.aspx'" class="btn btn-danger">Xem tất cả</button>
                    <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">
                        <span class="caret"></span>
                     
                </div>
            </div>
        </div>

        <div class="thuonghieu">
            <div class="row">
                <% for (int i = 0; i < this.objTableBrand.Rows.Count && i < 4; i++)
                   { %>
                <div class="col-md-3">
                    <img class="fw" src="/Images/<%Response.Write(this.objTableBrand.Rows[i]["Logo"].ToString()); %>"
                        style="border: solid 1px #dedee3; padding: 10px;" alt="<%Response.Write(this.objTableBrand.Rows[i]["Logo"].ToString()); %>" />
                </div>
                <% } %>
            </div>
        </div>

    </div>

    <div class="row" style="padding: 0 -25px 0 -25px">
        <iframe src="brand.html" style="width: 100%; border: none;"></iframe>
    </div>



    <div style="margin-top: -40px; width: 98%; margin-left: 0px; margin-right: 0px;">
        <div class="row" style="text-align: center;">
            <div class="col-md-12" style="text-align: center;">
                <h3 style="font-family: Arial; font-size: 25px; color: black; padding-top: 18px; color: #4e4e57; text-align: center;">TIN TỨC SUCMANHCONG.COM</h3>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row" style="margin-top: 20px;">
            <% if (this.objTableNews.Rows.Count >= 3)
               { %>
            <% for (int i = 0; i < 3; i++)  %>
            <% { %>
            <div class="col-md-4">
                <div>
                    <a href="NewsDetailt.aspx?Id=<% Response.Write(objTableNews.Rows[i]["Id"].ToString()); %>">
                        <img src="Images/<% Response.Write(objTableNews.Rows[i]["Image"].ToString()); %>"
                            alt="" style="border: solid 1px #beddeb; height: 253px; width: 100%" /></a>
                </div>
                <div style="width: 100%;">
                    <div style="float: left; width: 20%; text-align: center; font-family: Arial; font-size: 18px; font-weight: bold; padding: 9px; padding-left: 0px;">
                        <div style="border: solid 1px #f4f4f4; margin-top: 11px;">
                            <% Response.Write(DateTime.Parse(objTableNews.Rows[i]["DayCreate"].ToString()).ToString("dd/MM")); %>
                        </div>
                        <div style="border: solid 1px #f4f4f4; border-top: none; font-size: 22px; height: 40px; padding-top: 1px;">
                            <% Response.Write(DateTime.Parse(objTableNews.Rows[i]["DayCreate"].ToString()).ToString("yyyy")); %>
                        </div>
                    </div>
                    <div style="float: right; width: 80%; text-align: justify; padding: 9px;">
                        <div style="vertical-align: top; height: 50px; overflow: hidden;">
                            <h5 style="font-family: Arial; font-size: 15px; font-weight: bold; color: #4e4e57; text-transform: uppercase; margin-top: -22px;"
                                class="NewsHomeLink"><a href="NewsDetailt.aspx?Id=<% Response.Write(objTableNews.Rows[i]["Id"].ToString()); %>">
                                    <% Response.Write(objTableNews.Rows[i]["Title"].ToString()); %></a></h5>
                        </div>
                        <div style="font-family: Arial; font-size: 14px; color: #4e4e57; height: 80px; overflow: hidden;">
                            <% Response.Write(objTableNews.Rows[i]["ShortContent"].ToString()); %>
                        </div>
                    </div>
                </div>
            </div>
            <% }
               }%>
        </div>
    </div>
</asp:Content>
