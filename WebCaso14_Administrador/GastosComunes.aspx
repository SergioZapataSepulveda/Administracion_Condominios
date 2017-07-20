<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GastosComunes.aspx.cs" Inherits="WebCaso14_Administrador.GastosComunes" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	</asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="Titulos">
		Gestionar Gastos Comunes
	</div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px;">
			<tr>
				<td style="width: 57%; padding:15px" >

					<table style="width: 100%;" class="tablaFijada">
	                <tr>
							<td class="textoDestacado">
								<asp:Label ID="Label9" runat="server" Text="Ver Detalle Gasto Comun"></asp:Label>
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
						Mantencion
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Mantencion_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;">
								<asp:Label ID="lbl_Mantencion_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Mantencion_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;">
								<asp:Label ID="lbl_Mantencion_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
						Sueldo
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Sueldos_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;">
								<asp:Label ID="lbl_Sueldos_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Sueldos_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;">
								<asp:Label ID="lbl_Sueldos_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
						Servicios
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Servicios_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;">
								<asp:Label ID="lbl_Servicios_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Servicios_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;">
								<asp:Label ID="lbl_Servicios_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
                        <asp:Label ID="Label10" runat="server" Text="Otros"></asp:Label>
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Otros_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;">
								<asp:Label ID="lbl_Otros_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Otros_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;">
								<asp:Label ID="lbl_Otros_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>

					<table style="width: 100%;">
						Ingresos
					</table>
					<table style="width: 100%;">
						<tr>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Recaudacion_id" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;">
								<asp:Label ID="lbl_Recaudacion_Detalle" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 20%;">
								<asp:Label ID="lbl_Recaudacion_Monto" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;">
								<asp:Label ID="lbl_Recaudacion_Observacion" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>
					<table style="width: 100%;">
                    <tr>
							
							<td style="width: 60%;">
								Total a Prorratear entre todos los residentes
							</td>
							<td style="width: 15%;">
								 <b style="text-align: center;"><asp:Label ID="lbl_total" runat="server" Text="Label" ></asp:Label></b>
							</td>
						</tr>
					</table>
				</td>
				
				<td style="width: 37%; padding-right:2%; padding:15px">
                     <table style="width: 100%;">
                        <tr>
							<td class="textoDestacado" >
								<asp:Label ID="Label11" runat="server" Text="Ingresar Nuevo Registro a Gasto Comun"></asp:Label>
							</td>
						</tr>
					</table>


                    <table style="width: 100%; font-size: 12px; line-height:10px">
                        <tr>
							<td style="width: 100px;">
								<asp:Label ID="Label12" runat="server" Text="Tipo de Registro"></asp:Label><br><br>
                                <asp:Label ID="Label6" runat="server" Text="Categoria"></asp:Label><br><br>
                                <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label><br><br>
                                <asp:Label ID="Label7" runat="server" Text="Monto"></asp:Label><br><br><br><br><br>
							</td>
                            <td >
								<asp:DropDownList ID="ddlTipo" runat="server"> </asp:DropDownList><br />
                                <asp:DropDownList ID="ddl_Categoria" runat="server"> </asp:DropDownList><br>
                                <asp:TextBox ID="txt_Descripcion" runat="server"></asp:TextBox><br>
                                <asp:TextBox ID="txt_Monto" runat="server" type="number"  min="0"></asp:TextBox><br><br />
                                <asp:Button ID="Crear_Registro" runat="server" Text="Ingresar Nuevo Registro" onclick="Crear_Registro_Click" /><br /><br />
                                
							</td>
                            <td >
                                <asp:Label ID="lbl_crear_registro" runat="server" Text=""></asp:Label><br /><br />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                    ErrorMessage="* Largo Minimo de Descripcion 3 Caracteres" ControlToValidate="txt_Descripcion" 
                                    onservervalidate="CustomValidator2_ServerValidate" BorderStyle="NotSet"></asp:CustomValidator><br /><br />
                                <asp:CustomValidator ID="CustomValidator2" runat="server" 
                                    ErrorMessage="* Largo Minimo Monto 3 Caracteres" ControlToValidate="txt_Monto" 
                                    onservervalidate="CustomValidator2_ServerValidate" BorderStyle="NotSet"></asp:CustomValidator>
							</td>
						</tr>
					</table>
                    <br />
                    <table style="width: 100%;">
                        <tr>
							<td class="textoDestacado" >
								<asp:Label ID="Label19" runat="server" Text="Actualizar Registro a Gasto Comun"></asp:Label>
							</td>
						</tr>
					</table>

                    <table style="width: 100%; font-size: 12px; line-height:10px">
                        <tr>
							<td style="width: 100px;">
								<asp:Label ID="Label13" runat="server" Text="Tipo de Registro"></asp:Label><br><br>
                                <asp:Label ID="Label14" runat="server" Text="Categoria"></asp:Label><br><br>
                                <asp:Label ID="Label15" runat="server" Text="Descripcion"></asp:Label><br><br>
                                <asp:Label ID="Label16" runat="server" Text="Monto"></asp:Label><br><br>
                                <asp:Label ID="Label5"  runat="server" Text="Id a Modificar"></asp:Label><br /><br><br><br><br>
							</td>
                            <td >
								<asp:DropDownList ID="ddlTipo2" runat="server"> </asp:DropDownList><br />
                                <asp:DropDownList ID="ddl_Categoria2" runat="server"> </asp:DropDownList><br>
                                <asp:TextBox ID="txt_Descripcion_2" runat="server"></asp:TextBox><br>
                                <asp:TextBox ID="txt_monto_2" runat="server" type="number"  min="0"></asp:TextBox><br>
                                <asp:TextBox ID="txt_id_a_Modificar" runat="server" type="number"  min="0"></asp:TextBox><br /><br />
                                <asp:Button ID="Modificar_Registro" runat="server" Text="Modificar Registro" onclick="Modificar_Registro_Click" /><br><br>
                                
							</td>
                            <td >
                                <asp:Label ID="lbl_actualizar_registro" runat="server" Text=""></asp:Label><br /><br />
                                <asp:CustomValidator ID="CustomValidator3" runat="server" 
                                    ErrorMessage="* Largo Minimo de Descripcion 3 Caracteres" ControlToValidate="txt_Descripcion_2" 
                                    onservervalidate="CustomValidator3_ServerValidate" BorderStyle="NotSet"></asp:CustomValidator><br /><br />
                                <asp:CustomValidator ID="CustomValidator4" runat="server" 
                                    ErrorMessage="* Largo Minimo Monto 3 Caracteres" ControlToValidate="txt_monto_2" 
                                    onservervalidate="CustomValidator4_ServerValidate" BorderStyle="NotSet"></asp:CustomValidator><br /><br />
                                <asp:CustomValidator ID="CustomValidator5" runat="server" 
                                    ErrorMessage="* Largo Minimo de Id a Modificar 1 Caracteres" ControlToValidate="txt_id_a_Modificar" 
                                    onservervalidate="CustomValidator5_ServerValidate" BorderStyle="NotSet"></asp:CustomValidator>
							</td>
						</tr>
					</table>

                    <br />
                    <table style="width: 100%;">
                        <tr>
							<td class="textoDestacado" >
								<asp:Label ID="Label20" runat="server" Text="Cuotas Por Residente Proximo Mes"></asp:Label>
							</td>
						</tr>
					</table>

                    <table style="width: 100%; font-size: 12px; line-height:10px">
                        <tr>
							<td style="width: 100px;">
								<asp:Button ID="btn_Crear_Cuota_Proximo_Mes" runat="server" 
				                    Text="Generar Cuota Proximo Mes" onclick="btn_Crear_Cuota_Proximo_Mes_Click" /><br /><br />
				                <%-- <asp:Button ID="btn_Actualizar_Cuota_Proximo_Mes" runat="server" 
				                    Text="Actualizar Cuota Proximo Mes" 
				                    onclick="btn_Actualizar_Cuota_Proximo_Mes_Click" /><br /><br />
                                --%>
                                <asp:Button ID="btn_Notificacion_Correo" runat="server" 
                                    Text="Enviar Notificacion por Correo" onclick="btn_Notificacion_Correo_Click" /><br /><br />
				                <asp:Label ID="lbl_estado_cuota_proximo_mes" runat="server" Text="-- Estado Cuota Proximo Mes --"></asp:Label><br><br>
                                <asp:Label ID="lbl_Lista_Correos" runat="server" Text="-- Estado lista correos --"></asp:Label><br><br>
                                
                                    
							</td>
						</tr>
					</table>




     
					
			
				</td>
			</tr>
		</table>
	</div>
	</asp:Content>









