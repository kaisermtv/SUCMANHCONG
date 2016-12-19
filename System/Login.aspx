<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="System_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang đăng nhập quản trị</title>

    <link rel="stylesheet" href="/css/bootstrap.min.css" />

    <style type="text/css">
        body {
            /*background-image: url('/images/looping-bg.jpg');*/
        }

        .form-signin input[type="text"] {
            margin-bottom: -1px;
            border-bottom-left-radius: 0;
            border-bottom-right-radius: 0;
        }

        .form-signin input[type="password"] {
            margin-bottom: 10px;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }

        .form-signin .form-control {
            position: relative;
            font-size: 16px;
            height: auto;
            padding: 10px;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="POST">
        <div class="container">
            <h4 style="text-align: center; margin-top: 30px;">Trang quản trị hệ thống</h4>
            <div class="row" style="margin-top: 0px;">
                <div class="col-md-4 col-md-offset-4">
                    <%--<form method="POST" action="#" accept-charset="UTF-8" role="form" id="loginform" class="form-signin">--%>
                    <input name="_token" type="hidden" value="et5P8piiFzRANKXE78lAIjiKZUGcpFTrXJqDQvZf" />
                    <fieldset>
                        <h3 class="sign-up-title" style="color: dimgray; text-align: center; font-size: 20px;">Xin mời đăng nhập vào hệ thống</h3>

                        <hr class="colorgraph" />
                        <input class="form-control email-title" placeholder="Account" id="txtAccount" name="email" type="text" runat="server" style="text-transform: uppercase;" />
                        <br />
                        <input class="form-control" placeholder="Password" name="password" id="txtPassWord" type="password" value="" runat="server" />

                        <div class="checkbox" style="width: 140px;">
                            <label>
                                <input name="remember" type="checkbox" value="Remember Me" />
                                Nhớ mật khẩu</label>
                        </div>
                        <input type="submit" class="btn btn-lg btn-success btn-block" value="ĐĂNG NHẬP" />
                        <br/>

                    </fieldset>
                    <%--</form>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
