<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="VerUsuariosMorosos.aspx.cs" Inherits="WebCaso14_Administrador.VerUsuariosMorosos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Ver usuarios morosos
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 13px;">
            <tr>
                <td style="width: 57%; padding:15px">
                    <table style="width: 100%;">
                        <tr>
                            <td class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text="Listado de Residente Morosos"></asp:Label>
                                </b>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                </br>
                                <asp:GridView ID="GridView2" runat="server" OnPageIndexChanging="GridView2_PageIndexChanging"
                                    AllowPaging="True" OnRowDataBound="GridView2_RowDataBound" PageSize="15">
                                    <HeaderStyle Height="30px" />
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
