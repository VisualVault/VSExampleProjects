<%@ Page Title="" Language="C#" MasterPageFile="~/Ui/MasterPages/DocumentSearch.Master"
    AutoEventWireup="true" CodeBehind="ContractSearch.aspx.cs" Inherits="VisualVault.Examples.AdvancedSearch.ContractSearch"
    Theme="Blue" %>

<%@ Import Namespace="VVRuntime.Library.Documents" %>
<%@ Register Assembly="VisualVault.Examples.AdvancedSearch" Namespace="VisualVault.Examples.AdvancedSearch.DataAccess"
    TagPrefix="vv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend><span class="subtitle">Enter Search Criteria</span></legend>
        <div>
            <table cellpadding="5" cellspacing="5">
                <tr>
                    <td class="FormLabel">
                        MTN
                    </td>
                    <td>
                        <asp:TextBox ID="txtMtn" runat="server" Width="200"></asp:TextBox>
                    </td>
                    <td style="width: 100%;">
                    </td>
                    <td rowspan="5" style="text-align: right;">
                        <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Ui/Images/verizon.jpg" />
                    </td>
                </tr>
                <tr>
                    <td class="FormLabel">
                        ESN
                    </td>
                    <td>
                        <asp:TextBox ID="txtEsn" runat="server" Width="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FormLabel">
                        Signed
                    </td>
                    <td>
                        <asp:DropDownList ID="cboSigned" runat="server" Width="205">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Y" Value="Y"></asp:ListItem>
                            <asp:ListItem Text="N" Value="N"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="FormLabel">
                        Agent&nbsp;ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtAgentId" runat="server" Width="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="FormLabel">
                        Account&nbsp;Number
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccountNumber" runat="server" Width="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="BtnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
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
                    <asp:GridView ID="gvSearchResults" runat="server" SkinID="DocumentGridView">
                        <Columns>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#((Document)Container.DataItem).DocumentLink.Replace(((Document)Container.DataItem).DocID,"View Contract") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MTN">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["MTN"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ESN">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["ESN"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Signed">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["Signed"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agent ID">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["Agent ID"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Activation Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#string.Format(((Document)Container.DataItem).IndexFieldCollection["Activation Date"].Value,"d") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Number">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#((Document)Container.DataItem).IndexFieldCollection["Account Number"].Value %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
