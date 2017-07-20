<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConsultarAreasComunes.aspx.cs" Inherits="WebCaso14_Directiva.ConsultarAreasComunes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Reservar Areas Comunes
    </div>
    <div id="ContentPlaceHolder" align="left" />
    <table style="width: 100%; font-size: 11px; vertical-align: text-top;">
        <tr>
            <td style="width: 57%; padding: 15px">
                <table style="width: 100%;" class="tablaFijada">
                    <tr>
                        <td class="textoDestacado">
                            <b>
                                <asp:Label ID="Label9" runat="server" Text="Elegir fecha para Reserva "></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <li>Recordar que para que su reserva sea valida tienes 48 horas para el realizar el
                                pago </li>
                            <li>Toda reserva solo puede ser hecha con un minimo de 3 dias antes de la fecha deseada
                            </li>
                            <li>El costo total se calcula multiplicando la cantidad de tramos por la cantidad y
                                por el costo individual.</li>
                            <li>Seleccionar sobre una fecha para ver disponibilidad segun tramo y servicio</li>
                            <li>
                                <asp:Label ID="Resultado_1" runat="server" Text="Fecha Seleccionada: --/--/----"></asp:Label></li>
                        </td>
                        <td>
                            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
                            </asp:Calendar>
                        </td>
                    </tr>
                </table><br><br>
                <table style="width: 100%;">
                    <tr>
                        <td class="textoDestacado" style="width: 19%;">
                            <b class="Titulos2">
                                <asp:Label ID="Label10" runat="server" Text="Sevicio"></asp:Label></b>
                        </td>
                        <td class="textoDestacado" style="width: 27%;">
                            <asp:Label ID="Label11" runat="server" Text="<b>Tramo 1:</b> 07:00 a 12:00 "></asp:Label>
                        </td>
                        <td class="textoDestacado" style="width: 27%;">
                            <asp:Label ID="Label12" runat="server" Text="<b>Tramo 2:</b> 12:00 a 18:00"></asp:Label>
                        </td>
                        <td class="textoDestacado" style="width: 27%;">
                            <asp:Label ID="Label13" runat="server" Text="<b>Tramo 3:</b> 18:00 a 01:00 "></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 19%;">
                            <b>
                                <asp:Label ID="Label2" runat="server" Text="Quincho"></asp:Label></b>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Quincho_T1" runat="server" type="number" min="0" value="0" Width="50px"
                                class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Quincho_T1" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Quincho_T1" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Quincho_T2" runat="server" type="number" min="0" value="0" Width="50px"
                                class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Quincho_T2" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Quincho_T2" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Quincho_T3" runat="server" type="number" min="0" value="0" Width="50px"
                                class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Quincho_T3" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Quincho_T3" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="Label3" runat="server" Text="Multicancha"></asp:Label></b>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Multicancha_T1" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Multicancha_T1" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Multicancha_T1" OnServerValidate="CustomValidator4_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Multicancha_T2" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Multicancha_T2" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Multicancha_T2" OnServerValidate="CustomValidator5_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Multicancha_T3" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Multicancha_T3" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Multicancha_T3" OnServerValidate="CustomValidator6_ServerValidate"></asp:CustomValidator></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="Label4" runat="server" Text="Salon Eventos"></asp:Label></b>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_SalonEventos_T1" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_SalonEventos_T1" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_SalonEventos_T1" OnServerValidate="CustomValidator7_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_SalonEventos_T2" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_SalonEventos_T2" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_SalonEventos_T2" OnServerValidate="CustomValidator8_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_SalonEventos_T3" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_SalonEventos_T3" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator9" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_SalonEventos_T3" OnServerValidate="CustomValidator9_ServerValidate"></asp:CustomValidator></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>
                                <asp:Label ID="Label5" runat="server" Text="Estacionamientos"></asp:Label></b>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Estacionamientos_T1" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Estacionamientos_T1" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator10" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Estacionamientos_T1" OnServerValidate="CustomValidator10_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Estacionamientos_T2" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Estacionamientos_T2" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator11" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Estacionamientos_T2" OnServerValidate="CustomValidator11_ServerValidate"></asp:CustomValidator></div>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Estacionamientos_T3" runat="server" type="number" min="0" value="0"
                                Width="50px" class="Text_Box_Reserva"></asp:TextBox>
                            <asp:Label ID="lbl_Estacionamientos_T3" runat="server" Text=" "></asp:Label>
                            <div class="ErrorDinamico">
                                <asp:CustomValidator ID="CustomValidator12" runat="server" ErrorMessage="Cantidad Sobrepasada"
                                    ControlToValidate="txt_Estacionamientos_T3" OnServerValidate="CustomValidator12_ServerValidate"></asp:CustomValidator></div>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Button ID="Button4" runat="server" Text="Calcular Costo" OnClick="Button4_Click" />
                        </td>
                        <td>
                            <asp:Label ID="lbl_Costo_Reserva_S1" runat="server" Text="Costo Quincho: "></asp:Label><br />
                            <asp:Label ID="lbl_Costo_Reserva_S2" runat="server" Text="Costo Multicancha: "></asp:Label><br />
                            <asp:Label ID="lbl_Costo_Reserva_S3" runat="server" Text="Costo Salon Eventos: "></asp:Label><br />
                            <asp:Label ID="lbl_Costo_Reserva_S4" runat="server" Text="Costo Estacionamientos: "></asp:Label><br />
                            <b>
                                <asp:Label ID="lbl_Costo_Reserva_ST" runat="server" Text="Total a Pagar: "></asp:Label></b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
