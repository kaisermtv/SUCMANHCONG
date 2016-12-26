<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TopBrands.aspx.cs" Inherits="TopBrands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <style>
        .panel
        {
            padding-top:3px;
        }
        
.box {
  background:#fff;
  transition:all 0.1s ease;
  border:0.1px dashed #dadada;
  margin-top: 10px;
  box-sizing: border-box;
  border-radius: 5px;
  background-clip: padding-box;
  padding:0 20px 20px 20px;
  min-height:340px;
}

.box:hover {
  border:0.01px solid #525C7A;
}

.box span.box-title {
    color: #fff;
    font-size: 24px;
    font-weight: 300;
    text-transform: uppercase;
}

.box .box-content {
  padding: 16px;
  border-radius: 0 0 2px 2px;
  background-clip: padding-box;
  box-sizing: border-box;
}
.box .box-content p {
  color:#515c66;
  text-transform:none;
}

    </style>
     <div class="panel panel-success">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <span class="glyphicon glyphicon-bookmark"></span> Thương hiệu nổi bật cùng  <a href="http://sucmanhcong.com/">SUCMANHCONG.COM</a> </h3>
                    </div>
                    <div class="panel-body">

    <div class="container">
	<div class="row">
            <div class="row">
                   <div class="col-md-4 text-center">
                    <div class="box">
                        <div class="box-content">
                             <h4>Hải Hà</h4>
                            <hr />
                                 <img class="fw" src="/Images/<%Response.Write(this.objTableBrandVip.Rows[0]["Logo"].ToString()); %>"
                                        style="border: solid 1px #dedee3; padding: 10px; height:100% ; width:300px;"  alt="<%Response.Write(this.objTableBrandVip.Rows[0]["Logo"].ToString()); %>" />
                              
                            <p>Miêu tả thương hiệu</p>
                            <br />
                            <a href="#" class="btn btn-block btn-primary">Xem thêm</a>
                        </div>
                    </div>
                </div>
                   <div class="col-md-4 text-center">
                    <div class="box">
                        <div class="box-content">
                             <h4>Thăng Long</h4>
                            <hr />
                             <img class="fw" src="/Images/<%Response.Write(this.objTableBrandVip.Rows[1]["Logo"].ToString()); %>"
                                        style="border: solid 1px #dedee3; padding: 10px; height:100% ; width:300px;"  alt="<%Response.Write(this.objTableBrandVip.Rows[1]["Logo"].ToString()); %>" />
                              
                            <p>Miêu tả thương hiệu</p>
                            <br />
                            <a href="#" class="btn btn-block btn-primary">Xem thêm</a>
                        </div>
                    </div>
                </div>
                   <div class="col-md-4 text-center">
                    <div class="box">
                        <div class="box-content">
                             <h4>Viễn Phố </h4>
                            <hr />
                             <img class="fw" src="/Images/<%Response.Write(this.objTableBrandVip.Rows[2]["Logo"].ToString()); %>"
                                        style="border: solid 1px #dedee3; padding: 10px; height:100% ; width:300px;"  alt="<%Response.Write(this.objTableBrandVip.Rows[2]["Logo"].ToString()); %>" />
                              
                            <p>Miêu tả thương hiệu</p>
                            <br />
                            <a href="#" class="btn btn-block btn-primary">Xem thêm</a>
                        </div>
                    </div>
                </div>
                
            </div>           
        </div>
	</div>
</div>
         </div>

      
</asp:Content>

