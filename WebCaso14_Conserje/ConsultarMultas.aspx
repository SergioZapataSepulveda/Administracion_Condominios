<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConsultarMultas.aspx.cs" Inherits="WebCaso14_Conserje.ConsultarMultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Consultar Multas
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 11px; border-top: 12px">
            <tr>
                <td style="width: 68%; padding: 15px">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 45%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label11" runat="server" Text="Listado de Multas por Residente"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 45%;">
                                <br>
                                <asp:TextBox ID="txt_rut_Buscar" runat="server"></asp:TextBox>
                                <asp:Button ID="btn_rut_Buscar" runat="server" Text="Buscar por Rut" OnClick="btn_rut_Buscar_Click" />
                                <asp:Button ID="btn_mostrarTodos" runat="server" Text="Mostrar Todos" 
                                    onclick="btn_mostrarTodos_Click"/><br><br>
                                <asp:Label ID="Label3" runat="server" Text=": "></asp:Label>
                                <b>
                                    <asp:Label ID="lbl_nombre_Rut_buscado" runat="server" Text="---"></asp:Label></b><br>
                                <br>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView2" runat="server" OnPageIndexChanging="GridView2_PageIndexChanging"
                                    AllowPaging="True" OnRowDataBound="GridView2_RowDataBound" >
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
