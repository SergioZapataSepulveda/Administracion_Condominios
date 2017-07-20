<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VerResidentesMorosos.aspx.cs" Inherits="WebCaso14_Conserje.VerResidentesMorosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Residentes Morosos
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 11px; border-top: 12px">
            <tr>
                <td style="width: 68%; padding: 15px">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 45%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text="Listado de Residente Morosos"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" OnPageIndexChanging="GridView2_PageIndexChanging"
                                    AllowPaging="True" OnRowDataBound="GridView2_RowDataBound" PageSize="12"  >
                                    <RowStyle Height="30px" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

