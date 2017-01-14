<%@ Page Title="Trang Chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container CustomerHomePage">

       <div class ="row CustomerHomePageRow1">
           <div class ="col-md-4 ColMd4-1">THẺ ĐỒNG</div>
             <div class ="col-md-4 ColMd4-2">THẺ BẠC </div>
        <div class ="col-md-4 ColMd4-3">THẺ VÀNG</div>
       </div>
        
        <!-- +++ -->

        <div class ="row CustomerHomePageRow2">
           <div class ="col-md-4 ColMd4-1" style="padding-right:108px;">30,000 đ </div>
             <div class ="col-md-4 ColMd4-2">350,000 đ  </div>
        <div class ="col-md-4 ColMd4-3" ">1,000,000 đ </div>
               <!-- +++ -->
       </div>
        <div class ="row CustomerHomePageRow3">
           <div class ="col-md-4 ColMd4-1" style="padding-right:190px;"> <a href="#" style="color:white">Xem chi tiết </a>   </div>   
             <div class ="col-md-4">
                 <div style="float:left; display:inline; padding-left:22px;" class="col-md-6"  >
                     <a href="NewsDetailt?Id=1" style="color:white;margin-left:-20px; padding-right:-30px;">Xem chi tiết </a></div>
               
                  <div style="float:right; padding-right:105px; display:inline;" class="col-md-6" >
                      <a href="#" style="color:white;float:right">Nâng cấp </a> </div> </div>   


        <div class ="col-md-4"  >

                   <div style="float:left; display:inline; padding-left:35px;" class="col-md-6"  >
                       <a href="NewsDetailt?Id=2" style="color:white;margin-left:-80px; padding-right:100px;">Xem chi tiết </a></div>
               
                  <div style="float:right; padding-right:0px; display:inline;" class="col-md-6" >
                      <a href="#" style="color:white;float:left; margin-left:-70px; padding-right:100px;">Nâng cấp </a> </div> </div>   

        </div>
   
        <div class ="row CustomerHomePageRow4">
           <div class ="col-md-6 Col-new"> <a href="/NewsDetailt?Id=1" style="color:black">Thẻ Đồng </a>   
               <span style="color:black;font-size:12px; font-family:'Comic Sans MS'"></span>   </div> 
                    </div>  
     
        <div class ="row">
           <div class ="col-md-6 Col-new"> <a href="/NewsDetailt?Id=2" style="color:black">Thẻ Bạc </a> 
             <span style="color:black"> </span>   </div>  
        
                  </div>   
     
        <div class ="row">
           <div class ="col-md-6 Col-new"> <a href="/NewsDetailt?Id=3" style="color:black">Thẻ Vàng </a>   
             <span style="color:black"></span>   </div>   
                  
        </div>  
   

    </div>

</asp:Content>
