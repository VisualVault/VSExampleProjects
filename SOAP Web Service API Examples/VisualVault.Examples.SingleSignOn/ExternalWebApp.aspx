<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExternalWebApp.aspx.cs" Inherits="VisualVault.Examples.SingleSignOn.ExternalWebApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <legend>Single Sign-On with an external Web application from within VisualVault</legend>
                <div>
                    <br />
                    This example is for use cases where you have an ASP.Net Web application which needs API access to VisualVault, and the ASP.Net application is loaded within a VisualVault portal page (i-frame)<br />
                    <br />
                    This example does not require the external ASP.Net Web applicaition to be running in the same DNS domain as the VisualVault application and is suitable for use when your application is running in a different data center.
                    <br />
                    <br />
                    (1) Using the &quot;PageViewer&quot; portal control within the VisualVault Portal Admin screen, enter the URL of the external ASP.Net Web application.
                    <br />
                    <br />
                    (2) In the iframe URL configured in step (1), append two query string parameters which take advantage of VisualVault replaceable tokens.
                    <br />
                    <br />
                    <div class="code">
                        http://mywebapp.com?token=[LoginToken]&userId=[ContextUserId]
                    </div>
                    <br />
                    (3) Within your external Web application, get the query string parameter values for token and userId.  The token is a login token valid for one use which expires
                    after a configurable period of time (default is 5 minutes).  If you are testing this page from within a VisualVault portal screen i-frame, click the button below to display the authenticated User Id.
                    <br />
                    <br />
                    <div>
                        <asp:Label ID="Label3" runat="server" AssociatedControlID="txtVisualVaultApiUrl">VisualVault SOAP API URL:</asp:Label>
                        <asp:TextBox runat="server" ID="txtVisualVaultApiUrl" Width="800px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtAdminUserId">Admin User Id:</asp:Label>
                        <asp:TextBox runat="server" ID="txtAdminUserId"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtAdminPassword">Admin Password:</asp:Label>
                        <asp:TextBox runat="server" ID="txtAdminPassword" TextMode="Password"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button runat="server" ID="btnTokenTest" OnClick="btnTokenTestOnClick" Text="Test Login Token" />
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" AssociatedControlID="lblTestResults">Test Results:</asp:Label>
                        <asp:Label runat="server" ID="lblTestResults"></asp:Label>
                    </div>
                <br />
                <br />
                </div>
            </fieldset>
        </div>

    </form>
</body>
</html>
