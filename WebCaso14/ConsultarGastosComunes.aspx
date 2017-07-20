<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ConsultarGastosComunes.aspx.cs" Inherits="WebCaso14.Residentes.PaginaDaniel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    <div id="Titulos">
		Detalle Gastos Comunes
	</div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px;">
			<tr>
				<td style="width: 57%; padding:15px">

					<table style="width: 100%;" class="tablaFijada">
	                <tr>
							<td class="textoDestacado">
								<b><asp:Label ID="Label9" runat="server" Text="Ver Detalle Gasto Común"></asp:Label></b>
							</td>
						</tr>
						
					</table>

	                <table style="width: 100%;">
	                <tr>
	                <td><br>
	                    <asp:DropDownList ID="ddl_mes" runat="server">
						</asp:DropDownList>
						<asp:DropDownList ID="ddl_anio" runat="server">
						</asp:DropDownList>
						<asp:Button ID="Button1" runat="server" Text="Buscar Registros" onclick="Button1_Click" /><br><br>
	                    </td>
	                </tr>
	                </table>


					<table style="width: 100%;">
						<b>Mantencion</b>
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;"><b><asp:Label ID="Label2" runat="server" Text="Id"></asp:Label></b><br>
								<asp:Label ID="lbl_Mantencion_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;"><b><asp:Label ID="Label4" runat="server" Text="Detalle"></asp:Label></b><br>
								<asp:Label ID="lbl_Mantencion_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;"><b><asp:Label ID="Label5" runat="server" Text="Monto"></asp:Label></b><br>
								<asp:Label ID="lbl_Mantencion_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;"><b><asp:Label ID="Label6" runat="server" Text="Observacion"></asp:Label></b><br>
								<asp:Label ID="lbl_Mantencion_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
						<b>Sueldos</b>
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;"><b><asp:Label ID="Label7" runat="server" Text="Id"></asp:Label></b><br>
								<asp:Label ID="lbl_Sueldos_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;"><b><asp:Label ID="Label13" runat="server" Text="Detalle"></asp:Label></b><br>
								<asp:Label ID="lbl_Sueldos_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;"><b><asp:Label ID="Label17" runat="server" Text="Monto"></asp:Label></b><br>
								<asp:Label ID="lbl_Sueldos_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;"><b><asp:Label ID="Label20" runat="server" Text="Observacion"></asp:Label></b><br>
								<asp:Label ID="lbl_Sueldos_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
						<b>Servicios</b>
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;"><b><asp:Label ID="Label8" runat="server" Text="Id"></asp:Label></b><br>
								<asp:Label ID="lbl_Servicios_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;"><b><asp:Label ID="Label14" runat="server" Text="Detalle"></asp:Label></b><br>
								<asp:Label ID="lbl_Servicios_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;"><b><asp:Label ID="Label24" runat="server" Text="Monto"></asp:Label></b><br>
								<asp:Label ID="lbl_Servicios_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;"><b><asp:Label ID="Label21" runat="server" Text="Observacion"></asp:Label></b><br>
								<asp:Label ID="lbl_Servicios_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
                        <asp:Label ID="Label10" runat="server" Text="Otros"></asp:Label>
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;"><b><asp:Label ID="Label11" runat="server" Text="Id"></asp:Label></b><br>
								<asp:Label ID="lbl_Otros_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;"><b><asp:Label ID="Label15" runat="server" Text="Detalle"></asp:Label></b><br>
								<asp:Label ID="lbl_Otros_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;"><b><asp:Label ID="Label18" runat="server" Text="Monto"></asp:Label></b><br>
								<asp:Label ID="lbl_Otros_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;"><b><asp:Label ID="Label23" runat="server" Text="Observacion"></asp:Label></b><br>
								<asp:Label ID="lbl_Otros_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
						<b>Ingresos</b>
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;"><b><asp:Label ID="Label12" runat="server" Text="Id"></asp:Label></b><br>
								<asp:Label ID="lbl_Recaudacion_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;"><b><asp:Label ID="Label16" runat="server" Text="Detalle"></asp:Label></b><br>
								<asp:Label ID="lbl_Recaudacion_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;"><b><asp:Label ID="Label19" runat="server" Text="Monto"></asp:Label></b><br>
								<asp:Label ID="lbl_Recaudacion_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;"><b><asp:Label ID="Label22" runat="server" Text="Observacion"></asp:Label></b><br>
								<asp:Label ID="lbl_Recaudacion_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>
					<table style="width: 100%;">
                    <tr>
							
							<td style="width: 60%;">
								Numero de Viviendas Activas:
							</td>
							<td style="width: 15%;">
								 <b><asp:Label ID="lbl_num_Casas" runat="server" Text="----"></asp:Label></b>
							</td>
						</tr>
					</table>
					<table style="width: 100%;">
                    <tr>
							
							<td style="width: 60%;">
                                <asp:Label ID="Label3" runat="server" Text="Total a Prorratear entre todos las Vivendas:  "></asp:Label>
                                
							</td>
							<td style="width: 15%;">
								 <b style="text-align: center;"><asp:Label ID="lbl_total" runat="server" Text="Label" ></asp:Label></b>
							</td>
						</tr>
                    
					</table>
                    <table style="width: 100%;">
                    <tr>
                    <td style="width: 60%;">
                    Ingresar Id de gasto 
                        <asp:TextBox ID="txt_id_gasto" runat="server"></asp:TextBox></br>
                    Ingresar Observacion
                        <asp:TextBox ID="txt_observacion" runat="server" Width="357px"></asp:TextBox></br>
                     <asp:Button ID="btn_ingresar_observacion" runat="server" 
                            Text="Ingresar Observacion" onclick="btn_ingresar_observacion_Click" />
                        <asp:Label ID="lbl_Creacion_Obseracion" runat="server" Text="-- Estado Creacion --"></asp:Label>
                    </td>
                    </tr>
                    </table>
				</td>
			</tr>
		</table>
	</div>
	</asp:Content>