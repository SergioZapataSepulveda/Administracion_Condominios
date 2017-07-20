<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Pago_Central.aspx.cs" Inherits="WebCaso14.Pago_Central" %>

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
                            <td style="width: 45%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text="Informacion de Pago"></asp:Label><br>
                            </td>
                            <td style="width: 5%;">
                                <br>
                            </td>
                            <td style="width: 45%;" class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label10" runat="server" Text="Pago Mediante Transferencia Electronica"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 45%;">
                                <br>
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
                                    </table>
                                    <table style="width: 100%;">
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
                            <td style="width: 5%;">
                                <br>
                            </td>
                </td>
                <td style="width: 45%;">
                    <br>
                    <li>Destinatario: <b>Condominio Las Araucarias S.A. </b></li>
                    <li>Rut del Destinatario: <b>71.238.300-3.</b> </li>
                    <li>Número de cuenta: <b>53.735-07. </b></li>
                    <li>Tipo: <b>Cta Corriente </b></li>
                    <li>Banco: <b>Banco de Chile. </b></li>
                    <li>Monto: $ <b>
                        <asp:Label ID="lbl_total_Pagar" runat="server" Text=""></asp:Label></asp:Label>
                    </b></li>
                    <br>
                    <asp:Label ID="Label5" runat="server" Text="* Recuerda que después que pagues y recibas tu comprobante, debes adjuntar al archivo mediante la sección 'Adjuntar Comprobante de Pago' "></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 45%;">
                    </br></br></br>
                </td>
                <td style="width: 5%;">
                </td>
                <td style="width: 45%;">
                </td>
            </tr>
            <tr>
                <td style="width: 45%;" class="textoDestacado">
                    <b>
                        <asp:Label ID="Label6" runat="server" Text="Cupon de Pago Offline"></asp:Label></b>
                </td>
                <td style="width: 5%;">
                </td>
                <td style="width: 45%;" class="textoDestacado">
                    <b>
                        <asp:Label ID="Label7" runat="server" Text="Pago Mediante Tarjeta de Credito"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td style="width: 45%;">
                    <br>
                    <asp:Button ID="btn_guardar_cupon_pago" runat="server" Text="Guardar Cupon" OnClick="btn_guardar_cupon_pago_Click" /><br>
                    <br>
                    <asp:Label ID="Label12" runat="server" Text="* Recuerda que después de pagar y tener timbrado tu cupon, debes adjuntar al archivo mediante la sección 'Adjuntar Comprobante de Pago' "></asp:Label>
                </td>
                <td style="width: 5%;">
                    <br>
                </td>
                <td style="width: 45%;">
                    <br>
                    <asp:Button ID="btn_pago_tarjeta" runat="server" Text="Pagar con Tarjeta" OnClick="btn_pago_tarjeta_Click" /><br>
                    <br>
                    <asp:Label ID="Label11" runat="server" Text=" Al elejir esta opcion seras redirijido a la seccion de pago con tu tarjeta de credito"></asp:Label>
                </td>
            </tr>
        </table>
        </td> </tr> </table>
    </div>
</asp:Content>
