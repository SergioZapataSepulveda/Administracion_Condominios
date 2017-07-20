<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InformacionResidente.aspx.cs" Inherits="WebCaso14_Directiva.InformacionResidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Información de Residentes
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 11px; vertical-align: text-top;">
            <tr>
                <td style=" padding: 15px">
                    <table style="width: 100%;" class="tablaFijada">
                        <tr>
                            <td class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text="Listado de Residentes"></asp:Label></b>
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
                    
                    </br></br>
                    <table style="width: 100%;">
                    <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Recuerde que los usuarios que en la columna <b>Niv. Acceso</b> valor = 0, esta dehabilitados, y no podran entrar al sistema"></asp:Label>
                            </td>
                        </tr>
                    </table> 
                </td>
             </tr>
        </table>
    </div>
</asp:Content>
