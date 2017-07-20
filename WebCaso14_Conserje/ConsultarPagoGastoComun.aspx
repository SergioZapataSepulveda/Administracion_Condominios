<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="ConsultarPagoGastoComun.aspx.cs" Inherits="WebCaso14_Conserje.ConsultarPagoGasoComun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Ver Pagos de Residentes 
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 11px; border-top: 12px">
            <tr>
                <td style="width: 68%; padding: 15px">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 45%;" class="textoDestacado">
                                <b><asp:Label ID="Label9" runat="server" Text="Detalle Gasto Comun Por Residente Medinte Rut"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <br>
                                <asp:TextBox ID="txt_rut_Buscar" runat="server"></asp:TextBox>
                                <asp:Button ID="btn_rut_Buscar" runat="server" Text="Rut a Buscar" OnClick="btn_rut_Buscar_Click" /><br>
                                <br>
                                <asp:Label ID="Label1" runat="server" Text="Nombre de Residente buscado:"></asp:Label></b>
                                <b>
                                    <asp:Label ID="lbl_nombre_Rut_buscado" runat="server" Text="---"></asp:Label></b><br>
                                <br>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 15%;">
                                <asp:Label ID="Label3" runat="server" Text="Id Cuota Mensual"></asp:Label>
                            </td>
                            <td style="width: 19%;">
                                <asp:Label ID="Label8" runat="server" Text="Fecha Inicio Pago"></asp:Label>
                            </td>
                            <td style="width: 19%;">
                                <asp:Label ID="Label10" runat="server" Text="Fecha Termino Pago"></asp:Label>
                            </td>
                            <td style="width: 14%;">
                                <asp:Label ID="Label21" runat="server" Text="Monto"></asp:Label>
                            </td>
                            <td style="width: 14%;">
                                <asp:Label ID="Label23" runat="server" Text="Estado"></asp:Label>
                            </td>
                            <td style="width: 19%;">
                                <asp:Label ID="Label24" runat="server" Text="Fecha Pago Residente"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%;">
                        <tr>
                            <td >
                             <asp:GridView ID="GridView2" runat="server" 
	                                    onpageindexchanging="GridView2_PageIndexChanging" AllowPaging="True" 
	                                    onrowdatabound="GridView2_RowDataBound" >
                                    <HeaderStyle Wrap="False" />
                                    <RowStyle Wrap="False" Height="30px" />
	                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
