<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BioHR.Login" %>

<!DOCTYPE html>

<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!-->
<html xmlns="http://www.w3.org/1999/xhtml">
<!--<![endif]-->
<head runat="server">
    <meta charset="utf-8" />
    <title> :: Login Biofarma :: </title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <%--Bootstrap CSS File--%>
    <%--<link rel="stylesheet" href="~/CSS/bootstrap.min.css" />--%>
    <link rel="stylesheet" href="~/CSS/LoginStyle/bootstrap.min.css" />
    <link rel="stylesheet" href="~/CSS/bootstrap-reset.css" />

    <%--External CSS File --%>
    <link rel="stylesheet" href="~/Assets/font-awesome/css/font-awesome.css" />

    <%--Custom CSS styles for this Web Application--%>
    <link rel="stylesheet" href="~/CSS/LoginStyle/ca-style.css" />
    <link rel="stylesheet" href="~/CSS/LoginStyle/ca-style_responsive.css" />
    <link rel="stylesheet" href="~/CSS/LoginStyle/ca-style_default.css" id="style_color"/>
</head>
<body id="login-body">
    <div class="login-header">
        <!-- BEGIN LOGO -->
        <div id="logo" class="center">
            <%--<img src="Images/Login/ca-header-logo.png" alt="logo" class="center logo desktop" />--%>
            <%--<img src="Images/Login/ca-header-logo-mobile.png" alt="logo" class="center logo mobile" />--%>
        </div>
        <!-- END LOGO -->
    </div>
    <form id="formLogin" runat="server">
        <%-- BEGIN Login Body --%>
        <div id="login">
            <%-- END Login Title --%>
            <div id="loginHeader">
                <p id="loginLogo">Logo BioFarma</p>
                <content id="loginTitle">
			<h1><strong>WEL</strong>COME</h1>
			<p>Bio Farma Single Sign On Login Page</p>       
		</content>
            </div>
	    <%-- END Login Title --%>
            <%--BEGIN Login Form --%>
            <div id="loginform" class="no-padding no-margin">
                <div class="lock">
                    <i class="icon-lock"></i>
                </div>
                <div class="control-wrap">
                    <!-- Modif -->
                    <!-- <h4>User Login</h4> -->
                    <div class="control-group">
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-user"></i></span>
                                <%--<input id="input-username" type="text" placeholder="Username" />--%>
                                <asp:TextBox id="tbUsername" placeholder="Username" runat="server" />
                                <asp:RequiredFieldValidator ErrorMessage="Username harus diisi" ControlToValidate="tbUsername" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-key"></i></span>
                                <%--<input id="input-password" type="password" placeholder="Password" />--%>
                                <asp:TextBox id="tbPassword" type="password" placeholder="Password" runat="server" />
                                <asp:RequiredFieldValidator ErrorMessage="Password harus diisi" ControlToValidate="tbPassword" runat="server" />
                            </div>
                            <div class="mtop10">
                                <%--<div class="block-hint pull-left small">
                                    <input type="checkbox" id="" />
                                    Remember Me
                                </div>--%>
                                <div class="block-hint pull-right">
                                    <a href="javascript:;" class="" id="forget-password">Forgot Password?</a>
                                </div>
                            </div>

                            <div class="clearfix space5"></div>
                        </div>

                    </div>
                </div>
                <asp:Button id="btnLogin" CssClass="btn btn-block login-btn" Text="Login" runat="server" OnClick="btnLogin_Click"/>
            </div>
	    <%-- END Login Form --%>
            <%-- BEGIN Forgot Password --%>
            <div id="forgotform" class="no-padding no-margin hide">
                <p class="center">Enter your e-mail address below to reset your password.</p>
                <div class="control-group">
                    <div class="controls">
                        <div class="input-prepend">
                            <span class="add-on"><i class="icon-envelope"></i></span>
                            <input id="input-email" type="text" placeholder="Email" />
                        </div>
                    </div>
                    <div class="space20"></div>
                </div>
                <asp:Button id="btnForget" CssClass="btn btn-block login-btn" Text="Submit" runat="server" />
            </div>
            <%-- END Forgot Password --%>
        </div>
        <%-- END Login Body --%>
        <%-- BEGIN Footer --%>
        <div id="login-copyright">
            2014 &copy; Bio Farma IT Division.
        </div>
        <%-- END Footer --%>
    </form>

    <%--Common JavaScript Library--%>
    <%--<script src="JS/jquery.js"></script>--%>
    <script src="JS/LoginScript/jquery-1.8.3.min.js"></script>
    <script src="JS/bootstrap.min.js"></script>
    <%--<script src="JS/LoginScript/jquery.blockui.js"></script>--%>

    <%--JavaScript for this Page--%>
    <script src="JS/LoginScript/LoginScripts.js"></script>
    <script>
    	jQuery(document).ready(function () {
    		App.initLogin();
    	});
    </script>
</body>
</html>
