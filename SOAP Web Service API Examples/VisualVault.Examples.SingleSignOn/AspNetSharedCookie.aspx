<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AspNetSharedCookie.aspx.cs" Inherits="VisualVault.Examples.SingleSignOn.AspNetSharedCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Single Sign On Examples</title>
    <link href="examples.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblStatusMessage" runat="server"></asp:Label>
        </div>
        <div class="example">
            <fieldset class="contentArea">
                <legend>Single Sign-On with an ASP.Net application running on the same DNS Domain</legend>
                <div>
                    <br />
                    <br />
                    This example applies to customers running their own on-premise instance of VisualVault
                     <br />
                    <br />
                    You can share the ASP.Net Forms Authentication cookie between two ASP.Net Web applications. To
                configure this your Web application must meet the following criteria:
                <br />
                    <br />
                    <ul>
                        <li>Must be an ASP.Net 4.0 or higher Web application</li>
                        <li>Change the Authorization value in your web.config file (not the VisualVault web.config file) to allow only authorized users.
                        Example: <span style="font-weight: bold;">&lt;allow users="?"/&gt;</span></li>
                        <li>Configure the login page URL in your web.config file (not the VisualVault web.config file) to be the VisualVault login
                            page URL.&nbsp; This redirects requests made directly to your ASP.Net Web application
                            to the VisualVault login screen if the user has not already authenticated with VisualVault.</li>
                        <li>Use the same base domain name (company.com or something.company.com) as used to
                                login into the VisualVault web application</li>
                        <li>Configure Identical machine key values in the web.config files for both your ASP.Net Web application
                                and VisualVault (if the Web applications are running on different Web servers)</li>
                        <li>The Forms authentication cookie name in your ASP.Net Web application must be identical to the VisualVault Forms authentication cookie name (set in the web.config file)</li>
                    </ul>
                    The two applications may run on different servers provided the criteria above is
                met. Once you have followed the instructions above, clicking the button below will
                display the ASP.Net authenticated user information.&nbsp;&nbsp; This button click example code demonstrates
                how you can get information about the authenticated user from within your ASP.Net Web application.<br />
                    <br />
                    <asp:Button ID="btnGetUserRoles" runat='server' Text="Get User Info" OnClick="BtnGetUserInfoClick" />
                    <br />
                    <br />
                    <asp:Label ID="lblUserStatus" runat="server" Text="IsAuthenticated:"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblUserId" runat="server" Text="User Name:"></asp:Label>
                    <br />
                </div>
            </fieldset>
        </div>

    </form>
</body>
</html>
