<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartHere.aspx.cs" Inherits="VisualVault.Examples.SingleSignOn.StartHere" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Single Sign On Examples</title>
    <link href="menu.css" rel="stylesheet" />
</head>
<body class="loginBg" style="text-align: center;">

    <form runat="server">

        <div id="divLogin">

            <div class="contentArea">

                <div class="adLoginContainer">

                    <fieldset class="login">

                        <img class="loginLogo" id="ImageLoginLogo" src="images/vv_logo.png" alt="" />
                        
                        <div style="padding-left: 50px; padding-top: 80px; color: #595959; font-family: arial; font-size: 22px; margin-top: 10px;">
                            Single Sign On Examples
                        </div>

                        <div style="padding-left: 50px; padding-top: 20px; color: #595959; font-family: arial; font-size: 16px; margin-top: 10px;">
                            <br />
                            <br />
                            <a href="UserInterfaceTokenLogin.aspx">Web UI Token Login</a>
                            <br />
                            <br />
                            <a href="ImpersonatedApiCalls.aspx">Impersonated User API calls</a>
                            <br />
                            <br />
                            <a href="ExternalWebApp.aspx">Single sign-on with external ASP.Net Web application</a>
                            <br />
                            <br />
                            <a href="AspNetSharedCookie.aspx">Single sign-on using shared ASP.Net authentication cookie</a>

                        </div>

                    </fieldset>

                </div>

            </div>

        </div>

    </form>
</body>
</html>
