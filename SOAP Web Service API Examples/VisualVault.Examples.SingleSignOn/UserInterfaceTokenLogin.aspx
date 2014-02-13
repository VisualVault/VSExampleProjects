<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInterfaceTokenLogin.aspx.cs" Inherits="VisualVault.Examples.SingleSignOn.UserInterfaceTokenLogin" %>

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
                <legend><b>User interface token login</b></legend>
                <div>
                    <br />
                    This example demonstrates Web user interface token login.  The login token is a unique value associated with a specific user account valid for one-time use 
                    with a configurable expiration time (default expiration time is 5 minutes).
               
                    <br />
                    <br />
                    (1) Authenticate with the VisualVault SOAP API (vvruntime.dll) using the credentials of a "VaultAccess" group member
                        <br />
                    <br />
                    (2) Obtain a user interface login token for any named user account belonging to the same Customer database:
                        <br />
                    <br />
                    <div class="code">
                        string loginToken = User.GetUserLoginToken(); 
                    </div>
                    <br />
                    (3) Construct a VisualVault URL with vvlogin as the requested page, include the login token as a query string parameter.  Click the button below for an example.
                    <br />
                    <br />
                    <div>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtImpersonatedUserId">User Id to Login via Token:</asp:Label>
                        <asp:TextBox runat="server" ID="txtImpersonatedUserId"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtVisualVaultUrl">VisualVault User Interface URL:</asp:Label>
                        <asp:TextBox runat="server" ID="txtVisualVaultUrl" Width="800px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" AssociatedControlID="txtVisualVaultApiUrl">VisualVault SOAP API URL:</asp:Label>
                        <asp:TextBox runat="server" ID="txtVisualVaultApiUrl" Width="800px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" AssociatedControlID="txtAdminUserId">Admin User Id:</asp:Label>
                        <asp:TextBox runat="server" ID="txtAdminUserId" ></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" AssociatedControlID="txtAdminPassword">Admin Password:</asp:Label>
                        <asp:TextBox runat="server" ID="txtAdminPassword" TextMode="Password" ></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btnGetLoginToken" runat='server' Text="Build Token Login URL" OnClick="BtnBuildTokenLoginUrl" />
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server" AssociatedControlID="txtTokenLoginUrl">Token Login URL:</asp:Label>
                        <asp:TextBox runat="server" ID="txtTokenLoginUrl" Width="1000px"></asp:TextBox>
                        <br />
                        <br />
                        Copy and Paste the Token Login URL into a new Browser tab.  The one-time use token will authenticate the User.
                    </div>
                <br />
                </div>
            </fieldset>
        </div>
    </form>
</body>
</html>
