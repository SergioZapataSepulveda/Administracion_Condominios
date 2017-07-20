<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GastosComunesResidente.aspx.cs" Inherits="WebCaso14_Administrador.GastosComunesResidente" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	</asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	    <div id="Titulos">
		Pagos Residentes
	</div>

	<div id="ContentPlaceHolder">





    <table style="width: 100%; font-size: 11px; ">
			<tr>
				<td style=" padding:15px">

					<table style="width: 100%;">
	                        <tr>
								<td style="width: 70%;" class="textoDestacado" >
	                                <b><asp:Label ID="Label2" runat="server" Text="Ver Detalle Gasto Comun Por Residente"></asp:Label><br>
								</td>
                                <td style="width: 2%;"><br>
                                </td>
                                <td style="width: 27;" class="textoDestacado" >
	                                <b><asp:Label ID="Label4" runat="server" Text="Gestionar Pago Gasto Comun"></asp:Label></b>
								</td>
							</tr>
					</table>
	 


                   <table style="width: 100%;" >
	                    <tr>
							<td style="width: 70%;"><br>
                             <asp:TextBox ID="txt_rut_Buscar" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_rut_Buscar" runat="server" Text="Rut a Buscar" 
                            onclick="btn_rut_Buscar_Click" /><br><br>

                        <asp:Label ID="Label1" runat="server" Text="Nombre Residente Buscado: "></asp:Label>
                        <b><asp:Label ID="lbl_nombre_Rut_buscado" runat="server" Text="---"></asp:Label></b><br><br>
                        <table style="width: 100%;">
						<tr>
							<td style="width: 15%;">
                            <asp:GridView ID="GridView2" runat="server" 
	                                    onpageindexchanging="GridView2_PageIndexChanging" AllowPaging="True" 
	                                    onrowdatabound="GridView2_RowDataBound" Height="355px" >
                                    <HeaderStyle Wrap="False" />
                                    <RowStyle Wrap="False" />
	                                </asp:GridView>
							</td>
						</tr>
					</table>

					
		

                        
                             </td>

                             <td style="width: 2%;"><br>
                                </td>
                             <td style="width: 28%;" >
                                
                                 Id Cuota Mensual<br>
                                <asp:TextBox ID="txt_id_a_Modificar" runat="server" type="number"  min="0"></asp:TextBox><br /><br />
                                Estado<br>
								<asp:DropDownList ID="ddl_Estado" runat="server"> </asp:DropDownList><br /><br />
                                Monto<br>
                                <asp:TextBox ID="txt_Monto" runat="server" type="number"  min="0"></asp:TextBox><br><br />
                                Fecha Pago Residente<br>
                                <asp:Calendar ID="Calendar1" runat="server" SelectedDate="07/12/2017 14:52:14"></asp:Calendar><br /><br />

                                <asp:Button ID="Modificar_Registro" runat="server" Text="Modificar Registro" onclick="Modificar_Registro_Click" /><br>
                                
                                <asp:Label ID="lbl_estado_rectificacion" runat="server" Text=""></asp:Label><br>
                                <asp:Label ID="lbl_estado_rectificacion1" runat="server" Text=""></asp:Label><br>
                                <asp:Label ID="lbl_estado_rectificacion2" runat="server" Text=""></asp:Label><br>
                                <asp:CustomValidator ID="CustomValidator4" runat="server" 
                                    ErrorMessage="* Largo Minimo Id 1 Caracter" ControlToValidate="txt_id_a_Modificar" 
                                    onservervalidate="CustomValidator4_ServerValidate" BorderStyle="NotSet"></asp:CustomValidator><br />
                                <asp:CustomValidator ID="CustomValidator5" runat="server" 
                                    ErrorMessage="* Largo Minimo de Monto a Modificar 3 Caracteres" ControlToValidate="txt_Monto" 
                                    onservervalidate="CustomValidator5_ServerValidate" BorderStyle="NotSet"></asp:CustomValidator>
								</td>

						</tr>
					</table>


				</td>
			</tr>
		</table>
	</div>
	</asp:Content>









