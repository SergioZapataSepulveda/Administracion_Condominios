<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IngresarNuevoResidente.aspx.cs" Inherits="WebCaso14_Administrador.IngresarNuevoResidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div id="Titulos">
            Ingresar a un nuevo residente
            </div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px; ">
			<tr>
				<td style="padding:15px"">

					


                    <table style="width: 100%;">
                        <tr>
							<td class="textoDestacado" >
								<asp:Label ID="Label19" runat="server" Text="Ingrese los datos para crear un nuevo Residete"></asp:Label>
							</td>
						</tr>
					</table>

                    <table style="width: 100%; font-size: 12px; line-height:10px">
                        <tr>
							<td style="width: 25%;">
								<asp:Label ID="Label13" runat="server" Text="Rut Residente"></asp:Label><br><br><br>
                                <asp:Label ID="Label14" runat="server" Text="Pass Residente"></asp:Label><br><br><br>
                                <asp:Label ID="Label15" runat="server" Text="Nombre Residente"></asp:Label><br><br><br>
                                <asp:Label ID="Label2" runat="server" Text="Direccion"></asp:Label><br><br><br>
                                <asp:Label ID="Label4" runat="server" Text="Correo"></asp:Label><br><br><br>
                                <asp:Label ID="Label5" runat="server" Text="Tipo De Residente"></asp:Label><br><br><br><br><br><br><br><br><br><br>
							</td>
                            <td style="width: 75%;"><br><br>
                                <asp:TextBox ID="txt_Rut_Residente" runat="server" ></asp:TextBox><br /><br />
                                <asp:TextBox ID="txt_Pass_Residente" runat="server" ></asp:TextBox><br /><br />
                                <asp:TextBox ID="txt_Nombre_Residente" runat="server" 
                                    Width="320px"></asp:TextBox><br /><br />
                                <asp:TextBox ID="txt_Direccion" runat="server"  
                                    Width="320px"></asp:TextBox><br /><br />
                                <asp:TextBox ID="txt_Correo" runat="server" 
                                    Width="320px"></asp:TextBox><br /><br />
								<asp:DropDownList ID="ddl_ID_TIPO_RESIDENTE" runat="server"> </asp:DropDownList><br /><br />

                                <asp:Button ID="btn_Ingresar_residente" runat="server" 
                                    Text="Ingresar Residente" onclick="btn_Ingresar_residente_Click1"  /><br><br><br />

                                    <asp:Label ID="lbl_estado_rectificacion" runat="server" Text="--"></asp:Label><br><br />
                                <asp:Label ID="lbl_estado_rectificacion1" runat="server" Text="--"></asp:Label><br><br />
                                <asp:Label ID="lbl_estado_rectificacion2" runat="server" Text="--"></asp:Label><br><br />
                                
							</td>
						</tr>
					</table>
					
				</td>
				




			
				</td>
			</tr>
		</table>
	</div>
	</asp:Content>
