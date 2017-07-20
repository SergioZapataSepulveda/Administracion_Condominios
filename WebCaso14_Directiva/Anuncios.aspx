<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Anuncios.aspx.cs" Inherits="WebCaso14_Directiva.Anuncios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div id="Titulos">
            Crear Anuncios
            </div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px;">
			<tr>


				<td style="width: 100%; padding:15px">
                     <table style="width: 100%;">
                        <tr>
							<td class="textoDestacado" >
								<asp:Label ID="Label11" runat="server" Text="Ingresar Nuevo Registro de Multa"></asp:Label>
							</td>
						</tr>
					</table>

                    <br><br>
                    <table style="width: 100%; font-size: 12px; line-height:10px">
                        <tr>
							<td style="width: 20px;">
                                <asp:Label ID="Label6" runat="server" Text="Titulo Anuncio"></asp:Label><br><br>
                                <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
							</td>


                            <td style="width: 40%;">
                                <asp:TextBox ID="txt_Titulo" runat="server" Width="293px"></asp:TextBox><br>
                                <asp:TextBox ID="txt_Descripcion" runat="server" Height="200px" 
                                    TextMode="MultiLine" Width="300px"></asp:TextBox><br><br>
                                <asp:Button ID="btn_Crear_Anuncio" runat="server" Text="Crear Anuncio" 
                                    onclick="btn_Crear_Anuncio_Click" />
                                    <asp:Label ID="lbl_estado" runat="server" Text="-- Estado --"></asp:Label>
                                
							</td>
                            <td style="width: 40%; padding-right:5%; padding-left:5%;">
                                <asp:Label ID="Label1" runat="server" Text="Ultimo Anuncio Creado Para los Residentes: "></asp:Label><br><br><br>
                                <asp:Label ID="lbl_detalle_Anuncio" runat="server" Text="-- Estado --"></asp:Label>
							</td>


						</tr>
					</table>

				</td>
			</tr>
		</table>
	</div>
	</asp:Content>
