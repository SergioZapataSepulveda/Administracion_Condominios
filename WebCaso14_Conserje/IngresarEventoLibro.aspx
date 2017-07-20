<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="IngresarEventoLibro.aspx.cs" Inherits="WebCaso14_Conserje.IngresarEventoLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Eventos del Libro
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 11px;">
            <tr>
                <td style="padding: 15px">
                    <table style="width: 100%;" class="tablaFijada">
                        <tr>
                            <td style="width: 70%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text="Listado de Eventos en Condominio"></asp:Label><br>
                            </td>
                            <td style="width: 2%;">
                                <br>
                            </td>
                            <td style="width: 25%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label10" runat="server" Text="Ingresar Nuevo Evento"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;" class="tablaFijada">
                        <tr>
                            <td style="width: 70%;">
                                <asp:GridView ID="GridView2" runat="server" OnPageIndexChanging="GridView2_PageIndexChanging"
                                    AllowPaging="True" OnRowDataBound="GridView2_RowDataBound" Height="400px" 
                                    PageSize="10" >
                                    <HeaderStyle Height="30px" />
                                </asp:GridView>
                            </td>
                            <td style="width: 2%;">
                                <br>
                            </td>
                            <td style="width: 25%;">
                                <b>
                                    <asp:Label ID="Label3" runat="server" Text="Complete todos los campos para registrar un nuevo evento del Libro"></asp:Label></b>
                                <br />
                                <br />
                                Titulo del Evento<br />
                                <asp:TextBox ID="txt_Titulo" runat="server"></asp:TextBox><br>
                                <br />
                                Descripcion del Evento
                                <br />
                                <asp:TextBox ID="txt_Descripcion" runat="server" Height="51px" TextMode="MultiLine"></asp:TextBox><br>
                                <br>
                                Zona involucrada<br />
                                <asp:DropDownList ID="ddl_areaComun" runat="server">
                                </asp:DropDownList>
                                <br>
                                <br>
                                Rut de involucrado<br />
                                <asp:TextBox ID="txt_Rut_Involucrado" runat="server"></asp:TextBox><br>
                                <br>
                                <asp:Button ID="btn_Crear_Evento" runat="server" Text="Registrar Evento" OnClick="btn_Crear_Evento_Click" /><br>
                                <br>
                                <asp:Label ID="Label1" runat="server" Text="Estado Registro: "></asp:Label>
                                <asp:Label ID="lbl_Estado_Creacion" runat="server" Text="---"></asp:Label><br>
                                <br>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
