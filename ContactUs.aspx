<%@ Page Title="LIÊN HỆ " Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" enableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Liên hệ với Sucmanhcong.com </title>
    <style>
.red{
    color:red;
    }
.form-area
{
    background-color: #FAFAFA;
	padding: 10px 40px 60px;
	margin: 10px 0px 60px;
	border: 1px solid GREY;
	}
    </style>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div class="container">
<div class="col-md-5">
    <div class="form-area">  
        <form role="form">
        <br style="clear:both">
                    <h3 style="margin-bottom: 25px; text-align: center;">Liên hệ với Sucmanhcong.com - Hợp tác cùng phát triễn . </h3>
    				<div class="form-group">
						<asp:TextBox type="text"  runat="server" class="form-control" ID="txtName" name="name" placeholder="Tên" required/>
					</div>
					<div class="form-group">
						<asp:TextBox type="text" runat="server" class="form-control" id="txtEmail" name="email" placeholder="Email" required/>
					</div>
					<div class="form-group">
						<asp:TextBox type="text" runat="server" class="form-control" id="txtPhone" name="mobile" placeholder="Điện thoại" required/>
					</div>
					<div class="form-group">
						<asp:TextBox type="text" runat="server" class="form-control" id="txtSubject" name="subject" placeholder="Tiêu đề " required/>
					</div>
                    <div class="form-group">
                    <textarea class="form-control" runat="server"  type="textarea" id="txtMessage" placeholder="Nội dung" maxlength="140" rows="7"></textarea>
                        <span class="help-block"><p id="characterLeft" class="help-block ">Vui lòng nhập đầy đủ thông tin cần thiết</p></span>                    
                    </div>
            
        <asp:Button type="button" runat="server" id="submit"  OnClick="submit_Click"  class="btn btn-primary pull-right" Text="Gửi đi"></asp:Button>
        </form>
    </div>
</div>
</div>

    </div>
    </form>
    <script>

        $(document).ready(function () {
            $('#characterLeft').text('140 characters left');
            $('#message').keydown(function () {
                var max = 140;
                var len = $(this).val().length;
                if (len >= max) {
                    $('#characterLeft').text('You have reached the limit');
                    $('#characterLeft').addClass('red');
                    $('#btnSubmit').addClass('disabled');
                }
                else {
                    var ch = max - len;
                    $('#characterLeft').text(ch + ' characters left');
                    $('#btnSubmit').removeClass('disabled');
                    $('#characterLeft').removeClass('red');
                }
            });
        });

    </script>

</body>
</html>
