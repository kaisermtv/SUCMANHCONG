<%@ Page Title="Giới Thiệu  " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container" style="margin-top:10px;">
           <div class ="col-md-6">
               <div class ="row">
               <p style="text-align:center ; font-family:Arial; font-size:30px"><%= this.Name %></p>
                   <p style="text-align:center ; font-family:'Comic Sans MS'; font-size:12px"><%= this.Address %></p>
                    <p style="text-align:center ; font-family:'Comic Sans MS'; font-size:12px"><%= this.Phone %></p>
                    <p style="text-align:center ; font-family:'Comic Sans MS'; font-size:12px"><%= this.Email %></p>
                   </div>
                 
               </div>
           <div class ="col-md-6">
                <div class ="row" style="">
                    <img src="/img/banner.jpg"  style="height:200px;width:100%; text-align:center; align-content:flex-end ; border-radius:20px ;"/>
                   </div>
                <div class ="row">
              
                    <div class="row">


                        
                    </div>



                   </div>
           </div>
            
       
  
    <div class="row">
    <blockquote><%= this.Intro %></blockquote>
        </div>
       </div>
</asp:Content>
