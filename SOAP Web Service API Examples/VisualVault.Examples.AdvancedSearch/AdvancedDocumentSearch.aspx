<%@ Page Title="" Language="C#" MasterPageFile="~/Ui/MasterPages/DocumentSearch.Master"
    AutoEventWireup="true" CodeBehind="AdvancedDocumentSearch.aspx.cs" Inherits="VisualVault.Examples.AdvancedSearch.AdvancedDocumentSearch"
    Theme="Blue" %>

<%@ Import Namespace="VVRuntime.Library.Documents" %>
<%@ Register Assembly="VisualVault.Examples.AdvancedSearch" Namespace="VisualVault.Examples.AdvancedSearch.DataAccess" TagPrefix="vv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend><span class="subtitle">Advanced Document Search Example</span></legend>
        <div>
            <table cellpadding="5" cellspacing="5">
                <tr>
                    <td class="FormLabel">
                        Invoice#
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvoiceNumber" runat="server" Width="200"></asp:TextBox>                        
                    </td>
                    <td style="width: 20px;" rowspan="9">
                        &nbsp;</td>                   
                    <td style="width: 100%;" rowspan="9">
                        To configure this example:<br />
                        <br />
                        (1) Set the top level folder Id (Guid value) you 
                        wish to search in the web.config file.&nbsp;
                        <br />
                        <br />
                        To get a folder&#39;s Guid Id value right click on any document in the web UI and 
                        click on the Folder Path label within the context menu.&nbsp; This action will 
                        refresh the screen and the end of URL in the web browser address will have the 
                        folder Guid value after the fsid=(guid value will be here).&nbsp; Copy and paste 
                        this value into the web.config file&#39;s TopLevelFolderId value.<br />
                        <br />
                        (2)&nbsp; Configure Index fields<br />
                        <br />
                        This example of a custom search relies on specific index fields to be configured 
                        on the folder defined above or on one or more sub-folders of the folder defined 
                        above.&nbsp; You can use these index fields for testing or you can easily change 
                        the code in this page to use index fields which are already defined on the 
                        folder(s).<br />
                        <br />
                        Index fields used by this example are: Invoice,Doc Type,Company Name,Cert No,Pages
                        <br />
                        <br />
                        <br />
                        (2) Configure VisualVault server authentication<br />
                        <br />
                        Set these values in the web.config file appropriately:&nbsp; 
                        VaultApiUrl,VVUserId,VVPassword<br />
                        <br />
                        User impersonation allows you to take the Authenticated User Id value passed to you from 
                        VisualVault and then make API calls on behalf of that user.<br />
                    </td>                   
                </tr>
                <tr>
                    <td class="FormLabel">
                        Doc&nbsp;Type
                    </td>
                    <td>
                        <asp:TextBox ID="txtDocType" runat="server" Width="200"></asp:TextBox>                       
                    </td>
                </tr>
                <tr>
                    <td class="FormLabel">
                        Company&nbsp;Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanyName" runat="server" Width="200"></asp:TextBox>  
                    </td>
                </tr>               
                <tr>
                    <td class="FormLabel">
                        Cert&nbsp;No
                    </td>
                    <td>
                       <asp:TextBox ID="txtCertNo" runat="server" Width="200"></asp:TextBox>    
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        <asp:Button runat="server" ID="btnSearch" Text="Search as Admin" OnClick="BtnSearchClick" />
                        <br />
                        <br />
                        <asp:Button runat="server" ID="btnImpersonatedSearch" Text="Search as Impersonated User" OnClick="BtnImpersonatedSearchClick" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </fieldset>
    <div>
        <table cellspacing="0" cellpadding="0" style="width: 100%">
            <tr>
                <td>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStatusMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvSearchResults" runat="server" SkinID="DocumentGridView" AllowPaging="true" AllowSorting="true" OnSorting="GridViewSorting">
                        <Columns>
                            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                <ItemTemplate>                                   
                                   <asp:Label ID="Label1" runat="server" Text='<%#((Document)Container.DataItem).DocumentLink %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice #" SortExpression="Invoice">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["Invoice"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Doc Type" SortExpression="Doc Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["Doc Type"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Company Name" SortExpression="Company Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["Company Name"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Cert No" SortExpression="Cert No">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["Cert No"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                           
                            <asp:TemplateField HeaderText="Created At" SortExpression="CreateDate">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# string.Format(((Document)Container.DataItem).CreateDate.ToString(),"d") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
