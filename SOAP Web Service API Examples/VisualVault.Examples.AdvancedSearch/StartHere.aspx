<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartHere.aspx.cs" Inherits="VisualVault.Examples.AdvancedSearch.StartHere"
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
    <div id="Div2" style="padding: 5px 50px 5px 50px;">
        <fieldset style="padding: 15px;">
            <legend>Document Search</legend>
            <div style="padding: 20px;">
                For a simple document search example see the VisualVault.Examples WinForms project.
                <br />
                <br />
                <asp:Button ID="btnAdvancedDocumentSearch" runat='server' Text="Advanced Document Search"
                    OnClick="BtnAdvancedDocumentSearchClick" />
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
