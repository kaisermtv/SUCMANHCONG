<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HistoryPartner.aspx.cs" Inherits="System_HistoryPartner" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <script type="text/javascript" src="/js/bootstrap.min.js"></script>

    <div class="container" style="width: 100%; text-align: right;">
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-1" style="height: 100%">
                Từ ngày
            </div>
            <div class="col-md-3">
                <input runat="server" id="txtFromDate" type="date" class="form-control" value="" placeholder="yyyy-mm-dd" />
            </div>
            <div class="col-md-1">
                tới ngày
            </div>
            <div class="col-md-3">
                <input type="date" runat="server" id="txtToDate" class="form-control" value="" placeholder="yyyy-mm-dd" />
            </div>
            <div class="col-md-2">
                <input type="submit" style="float: left" class="btn btn-default" value="Lọc kết quả" />
            </div>
        </div>
        <% if(this.Message != ""){ %>
        <div class="row" >
            <pre><%= this.Message %></pre>
        </div>
        <% } %>
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div style="width: 100%; margin-top: 0px;">
                        <div style="width: 5%; float: left; border:solid 1px #f3f1f1; border-right:none;text-align:center;height:26px; line-height:26px; color:#000;">
                            TT   
                        </div>
                        <div style="width: 12%; float: left; border:solid 1px #f3f1f1;border-top:none;text-align:center;height:26px; line-height:26px; color:#000;">
                            Thời gian
                        </div>
                        <div style="width: 15%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                            Tổng tiền
                        </div>
                        <div style="width: 10%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                            Tiền CK
                        </div>
                        <div style="width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                            CK(%)
                        </div>
                        <div style="width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                            TL(%)
                        </div>
                        <div style="width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                            QC(%)
                        </div>
                        <div style="width: 10%; float: left; border:solid 1px #f3f1f1; border-left:none; text-align:right;border-top:none;padding-right:5px;height:26px; line-height:26px; color:#000; padding-right:5px;">
                            Thanh toán
                        </div>
                        <div style="width: 27%; float: left; border:solid 1px #f3f1f1; border-left:none; text-align:justify;border-top:none;height:26px; line-height:26px; color:#000;">
                            Ghi chú
                        </div>
                        <div style="width: 5%; float: left; border:solid 1px #f3f1f1; border-left:none; border-top:none;text-align:center;height:26px; line-height:26px; color:#000;">
                         Chi tiết
                        </div>
                    </div>
                    <%  if (this.objTable.Rows.Count > 0) { %>
                        <% for (int i = 0; i < this.objTable.Rows.Count; i++){ %>
                            <div  style ="width:100%; margin-top:1px; display:table;">
                                <div style="width: 5%; float: left; border:solid 1px #f3f1f1; border-right:none; border-top:none;text-align:center;height:26px; line-height:26px; color:#000;">
                                    <%= i+1 %>
                                </div>
                                <div style="width: 12%; float: left; border:solid 1px #f3f1f1;border-top:none;text-align:center;height:26px; line-height:26px; color:#000;">
                                    <%=DateTime.Parse(this.objTable.Rows[i]["DayCreate"].ToString()).ToString("dd/MM/yyyy HH:mm") %>
                                </div>
                                <div style="width: 15%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                                    <%=string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["TotalMoney"].ToString())) %>
                                </div>
                                <div style="width: 10%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                                    <%=string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["TotalMoneyDiscount"].ToString())) %>
                                </div>
                                <div style="width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                                    <%=string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["Discount"].ToString())) %>
                                </div>
                                <div style="width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                                    <%=string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["DiscountCard"].ToString())) %>
                                </div>
                                <div style="width: 5%; float: left; border:solid 1px #f3f1f1;border-top:none;border-left:none; text-align:right;height:26px; line-height:26px; color:#000; padding-right:5px;">
                                    <%=string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["DiscountAdv"].ToString())) %>
                                </div>
                                <div style="width: 10%; float: left; border:solid 1px #f3f1f1; border-left:none; text-align:right;border-top:none;padding-right:5px;height:26px; line-height:26px; color:#000; padding-right:5px;">
                                    <%=string.Format("{0:0,0}", double.Parse(this.objTable.Rows[i]["TotalPeyment"].ToString())) %>
                                </div>
                                <div style="width: 27%; float: left; border:solid 1px #f3f1f1; border-left:none; text-align:justify;border-top:none;height:26px; line-height:26px; color:#000;">
                                    <%=this.objTable.Rows[i]["Note"].ToString() %>
                                </div>
                                <div style="width: 5%; float: left; border:solid 1px #f3f1f1; border-left:none; border-top:none;text-align:center;height:26px; line-height:26px; color:#000;">
                                    <a href = "/System/ViewBill.aspx?id=<%=this.objTable.Rows[i]["Id"].ToString() %>"><img src="/img/Edit.png" alt="Chi tiết\" title="Chi tiết hoá đơn" /></a>
                                </div>
                            </div>
                        <% } %>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>