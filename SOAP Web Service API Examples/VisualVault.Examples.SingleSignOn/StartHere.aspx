<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartHere.aspx.cs" Inherits="VisualVault.Examples.SingleSignOn.StartHere"
    Theme="Blue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Div1" style="padding: 5px 50px 5px 50px;">
        <asp:Label ID="lblStatusMessage" runat="server"></asp:Label>
    </div>
    <div style="padding: 5px 50px 5px 50px;">
        <fieldset style="padding: 15px;">
            <legend>Impersonated User Requests</legend>
            <div style="padding: 20px;">
                These examples demonstrate impersonated web user interface token login and impersonated
                API calls.
                <br />
                <br />
                User interface impersonation requests a login token for a user which can be appended
                to VisualVault secure URL's as a query string parameter (?token=tokenvalue). This
                is useful when you have an application which needs to display secure VisualVault
                content using the context of a specific user. An API call is made using an administrator
                account and a login token is requested for a specific user Id.
                <br />
                <br />
                API user impersonation allows an adminitrative user to supply the User Id of another
                user and make API (web service) calls on behalf of the user.
                <br />
                <br />
                The administrator account is credentials, target server URI, and User Id to impersonate
                are stored in the web.config file for this example.
                <br />
                <br />
                <asp:Button ID="btnGetLoginToken" runat='server' Text="Log into VisualVault web application using impersonation"
                    OnClick="BtnLaunchVisualVaultPortalScreen" />
                <br />
                <br />
                <asp:Button ID="btnGetFormTemplates" runat='server' Text="Get Form Template List"
                    OnClick="BtnGetFormTemplatesList" />
                <asp:DropDownList ID="ddlFormTemplates" runat='server' Width="300px">
                </asp:DropDownList>
                <asp:Button ID="btnSubmitForm" runat='server' Text="Fill in Selected Form Template"
                    OnClick="BtnSubmitForm" />
                <br />
                <br />
                <asp:Button ID="btnGetFormDashboards" runat='server' Text="Get Form Dashboard List" OnClick="BtnGetFormDashboards" />
                <asp:DropDownList ID="ddlFormDashboards" runat='server' Width="300px">
                </asp:DropDownList>
                <asp:Button ID="btnDislayDashboard" runat='server' Text="Display Form Dashboard"
                    OnClick="BtnDisplayDashboard" />
            </div>
        </fieldset>
    </div>
    <div id="getUserRoles" style="padding: 5px 50px 5px 50px;">
        <fieldset style="padding: 15px;">
            <legend>Securely access a custom ASP.Net application from within VisualVault</legend>
            <div style="padding: 20px;">
                This example is for use cases where you have an Asp.Net web application running
                inside of VisualVault.<br />
                <br />
                There are two simple methods for displaying a custom asp.net app within VisualVault:&nbsp;
                <br />
                <br />
                (1) Using the &quot;PageViewer&quot; portal control with VisualVault custom page
                tabs or Portal screen tabs<br />
                (2) Create custom menu items with the URL of your custom application&#39;s web pages.<br />
                <br />
                You can secure your custom application an use VisualVault&#39;s various user authentication
                methods through the use of "sharing" the Asp.Net forms authentication cookie. To
                configure this your custom application must meet the following criteria:
                <br />
                <br />
                <ul>
                    <li>Change the Authorization value in the web.config file to allow only authorized users.
                        Example: <span style="color: #FF0000;">&lt;allow users="?"/&gt;</span></li>
                        <li>Configure the login page URL in the web.config file to be the VisualVault login
                            page URL.&nbsp; This redirects requests made directly to your custom application
                            to the VisualVault login screen if the user has not already authenticated with VisualVault.</li>
                            <li>Use the same base domain name (company.com or something.company.com) as used to
                                login into the VisualVault web application</li>
                            <li>Identical machine key values in the web.config files for both the custom application
                                and VisualVault (this will work across web servers)</li>
                            <li>Forms authentication cookie name must be identical in both web.config files</li>
                </ul>
                The two applications may run on different servers provided the criteria above is
                met. Once you have followed the instructions above, clicking the button below will
                display the VisualVault authenticated user information.&nbsp;&nbsp; This demonstrates
                how you can get information about the authenticated use from within your custom
                web application.<br />
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
