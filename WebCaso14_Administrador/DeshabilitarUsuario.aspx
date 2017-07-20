<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DeshabilitarUsuario.aspx.cs" Inherits="WebCaso14_Administrador.DeshabilitarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div id="Titulos">
            Deshabilitar Usuario
            </div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px; ">
			<tr>
				<td style="padding:15px"">

					<table style="width: 100%; padding-top:2%;">
	                    <tr>
							<td class="textoDestacado">
								<asp:Label ID="Label9" runat="server" Text="Rut a Deshabilitar"></asp:Label>
							</td>
						</tr>
                        <td >
                                </br><asp:TextBox ID="txt_Rut_Deshabilitar" runat="server" Width="170px"></asp:TextBox>
                                <asp:Button ID="btn_SP_Deshabilitar_Residente" runat="server" 
                                    Text="Deshabilitar Residente" onclick="btn_SP_Deshabilitar_Residente_Click" />
                                <asp:Label ID="lbl_estado_Deshabilitar" runat="server" Text="-- estado --"></asp:Label></br></br>
						</td>
					</table>

                    </br></br>

                    <table style="width: 100%; padding-top:2%;" >
	                    <tr>
							<td class="textoDestacado">
								<asp:Label ID="Label3" runat="server" Text="Rut a Habilitar"></asp:Label>
							</td>
						</tr>
                        <td >
                                </br><asp:TextBox ID="txt_Rut_Habilitar" runat="server"></asp:TextBox>
                                <asp:Button ID="btn_SP_Habilitar_Residente" runat="server" 
                                    Text="Habilitar Residente" onclick="btn_SP_Habilitar_Residente_Click" />
                                <asp:Label ID="lbl_estado_Habilitar" runat="server" Text="-- estado --"></asp:Label></br></br>
						</td>
					</table>
                    </br></br>

          
			
				</td>
			</tr>
		</table>
	</div>
	</asp:Content>
