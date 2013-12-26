<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImpersonatedApiCalls.aspx.cs" Inherits="VisualVault.Examples.SingleSignOn.ImpersonatedApiCalls" %>

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
                <legend>Impersonate User for API Calls</legend>

                <div>
                    <br />
                    API user impersonation allows a "VaultAccess" group member to supply a User Id and make API (SOAP Web service) calls on behalf of another user.
                <br />
                    <br />
                    The administrator account credentials, target server URI, and User Id to impersonate
                are stored in the web.config file for this example.
                <br />
                    <br />
                    <div class="code">
                        Vault vault = VVRuntime.VisualVaultLogin.LoginImpersonate(vaultApiUrl, vVUserId, vVPassword, impersonatedUserId, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId) 
                    </div>
                    <br />
                    <br />
                    <div>
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
                </div>

            </fieldset>
        </div>

    </form>
</body>
</html>
