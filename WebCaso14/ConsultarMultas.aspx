<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConsultarMultas.aspx.cs" Inherits="WebCaso14.ConsultarMultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    <div id="Titulos">
		Consultar Multas 
	</div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px; ">
			<tr>
				<td style=" padding:15px">

					<table style="width: 100%;" class="tablaFijada">
	                        <tr>
								<td style="width: 65%;" class="textoDestacado" >
	                                <b><asp:Label ID="Label9" runat="server" Text="Listado de multas asociadas a mi Perfil "></asp:Label><br>
								</td>
                                <td style="width: 5%;"><br>
                                </td>
                                <td style="width: 30%;" class="textoDestacado" >
	                                <b><asp:Label ID="Label10" runat="server" Text="Opciones de Pago"></asp:Label></b>
								</td>
							</tr>
					</table>
                    </br></br>
	 


                   <table style="width: 100%;" class="tablaFijada">
	                    <tr>
							<td style="width: 65%;">
								<asp:GridView ID="GridView2" runat="server" 
	                                    onpageindexchanging="GridView2_PageIndexChanging" AllowPaging="True" 
	                                    onrowdatabound="GridView2_RowDataBound" Height="355px" 
                                          autogenerateselectbutton="True" 
                                    onselectedindexchanged="GridView2_SelectedIndexChanged">
                                    <HeaderStyle Wrap="False" />
                                    <RowStyle Wrap="False" />
	                                </asp:GridView>
                             </td>

                             <td style="width: 5%;"><br>
                                </td>
                             <td style="width: 30%;" >
                                    <b><asp:Label ID="Label4" runat="server" Text="Seleccione una multa para poder pasar a las opciones de pago, alli encontrara:"></asp:Label></b>

                                    <li>Pago con Tarjeta</li>
                                    <li>Informacion para Transferencia Electronica</li>
                                    <li>Descarga de Copon de Pago </li>

                                    <br><br><br>
	                                <asp:Label ID="Label3" runat="server" Text="Id multa seleccionada: "></asp:Label>
                                    <b><asp:Label ID="lbl_selccion_ID" runat="server" Text=" - nada seleccionado -  "></asp:Label></b><br>
                                    <asp:Label ID="Label1" runat="server" Text="Monto multa seleccionada: "></asp:Label>
                                    <b><asp:Label ID="lbl_selccion_Monto" runat="server" Text=" - nada seleccionado -  "></asp:Label></b><br>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha creacion multa: "></asp:Label>
                                    <b><asp:Label ID="lbl_selccion_fecha" runat="server" Text=" - nada seleccionado -  "></asp:Label></b><br>
                                    <asp:Label ID="Label5" runat="server" Text="Estado multa seleccionada: "></asp:Label>
                                    <b><asp:Label ID="lbl_selccion_estado" runat="server" Text=" - nada seleccionado -  "></asp:Label></b><br><br><br><br>

                                    <asp:Button ID="Pagar_Cuota" runat="server" Text="Portal de Pago" 
                                    onclick="Pagar_Cuota_Click" /><br><br><br />

                                    <asp:Label ID="Label7" runat="server" Text="Estado: "></asp:Label>
                                    <b><asp:Label ID="lbl_Mensaje_boton" runat="server" Text=" ---  "></asp:Label></b><br><br>

								</td>

						</tr>
					</table>


				</td>
			</tr>
		</table>
	</div>
	</asp:Content>