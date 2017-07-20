<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReservarAreasComunes_Pago.aspx.cs" Inherits="WebCaso14_Administrador.ReservarAreasComunes_Pago" %>
<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Portal de Pago
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 11px; border-top: 12px">
            <tr>
                <td style="width: 68%; padding: 20px">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 32%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text="Informacion de Pago"></asp:Label><br>
                            </td>
                            <td style="width: 2%;">
                            </td>
                            <td style="width: 32%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label10" runat="server" Text="Transferencia Electronica"></asp:Label></b>
                            </td>
                            <td style="width: 2%;">
                            </td>
                            <td style="width: 32%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label7" runat="server" Text="Cupon de Pago Offline"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 32%;">
                                <b>
                                    <asp:Label ID="Label3" runat="server" Text="Tipo de Pago: "></asp:Label>
                                    <b>
                                        <asp:Label ID="lbl_tipo_pago" runat="server" Text="---"></asp:Label><br>
                                        <br>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                                                </td>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="Label4" runat="server" Text="Costo"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="lbl_id" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="width: 60%;">
                                                    <asp:Label ID="lbl_detalle" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td style="width: 20%;">
                                                    <asp:Label ID="lbl_costo" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br>
                                        <br>
                                        <b>Costo Total a Pagar:
                                            <asp:Label ID="lbl_total_pago_info" runat="server" Text="Label"></asp:Label></b>
                            </td>
                            <td style="width: 2%;">
                            </td>
                            <td style="width: 32%;">
                                <br><br><br>
                                <li>Destinatario: <b>Condominio Las Araucarias S.A. </b></li>
                                <li>Rut del Destinatario: <b>71.238.300-3.</b> </li>
                                <li>Número de cuenta: <b>53.735-07. </b></li>
                                <li>Tipo: <b>Cta Corriente </b></li>
                                <li>Banco: <b>Banco de Chile. </b></li>
                                <li>Monto: $ <b>
                                    <asp:Label ID="lbl_total_Pagar" runat="server" Text=""></asp:Label></asp:Label>
                                </b></li>
                                <br>
                                <br><br><br>
                            </td>
                            <td style="width: 2%;">
                            </td>
                            <td style="width: 32%;">
                                <br>
                                <asp:Label ID="Label12" runat="server" Text="Generar cupon de pago Offline, el archivo generado debes imprimirlo y pagarlo en cualquier banco Estado o Servipag "></asp:Label>
                                <br>
                                <br>
                                <asp:Button ID="btn_guardar_cupon_pago" runat="server" Text="Guardar Cupon" OnClick="btn_guardar_cupon_pago_Click" /><br>
                                <br>
                            </td>
                        </tr>
                </td>
            </tr>
        </table>
        <br>
        <br>
        <table>
            <tr>
                <li>Recuerda que después que pagues y recibas tu comprobante, debes subir el archivo
                    a esta portal</li>
                <li>Se Recomienda encarecidamente que cualquier pago por lo haga exclusivamente en un
                    computador de confianza</li>
                <li>Si tiene cualquier dificultad contactese con el Administrador del condominio
                </li>
            </tr>
        </table>
    </div>
</asp:Content>