<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="IngresarMulta.aspx.cs" Inherits="WebCaso14_Directiva.IngresarMulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	</asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                        <div id="Titulos">
	            Gestionar Multas
	            </div>

		<div id="ContentPlaceHolder">


			<table style="width: 100%; font-size: 11px; border-top: 12px">
				<tr>
					<td style= "width: 68%; padding:15px"  class="TablaLimpia" >

						


	                    <table style="width: 100%;">
	                        <tr>
								<td style="width: 100%;" class="textoDestacado" >
	                                <b><asp:Label ID="Label11" runat="server" Text="Listado de Multas por Residente"></asp:Label></b>
								</td>
							</tr>
                            <tr>
								<td style="width: 45%;"><br>
									<asp:TextBox ID="txt_rut_Buscar" runat="server"></asp:TextBox><br><br>
	                        <asp:Button ID="btn_rut_Buscar" runat="server" Text="Buscar por Rut" 
	                            onclick="btn_rut_Buscar_Click" />

	                        <asp:Label ID="Label3" runat="server" Text=": "></asp:Label><br><br>
	                        <b><asp:Label ID="lbl_nombre_Rut_buscado" runat="server" Text="---"></asp:Label><br><br>
								</td>
                                
							</tr>
						</table>


	                    <table style="width: 100%; font-size: 12px; line-height:10px">
	                        

							<tr>
	                            <td>
								 <asp:GridView ID="GridView2" runat="server" 
	                                    onpageindexchanging="GridView2_PageIndexChanging" AllowPaging="True" 
	                                    onrowdatabound="GridView2_RowDataBound" Height="355px">
	                                </asp:GridView>
	                                </td>
							</tr>
						</table>
                </td>



                <td style= "width: 28%; padding-right:15px; padding-bottom:326px; padding-top:15px;" class="TablaLimpia">
	                    <table  class="TablaLimpia" >
	                       
								<td class="TablaLimpia" >
									<table style="width: 100%; " class="TablaLimpia" >
	                                    
								            <td class="textoDestacado" >
									            <b><asp:Label ID="Label8" runat="server" Text="Ingreser Nueva Multa"></asp:Label></b>
								            </td>
							            
						            </table>

                                    <table style="width: 100%; font-size: 12px; line-height:10px" class="TablaLimpia" >
	                                    
								            <td style="width: 100px;">
	                                            <asp:Label ID="Label6" runat="server" Text="Rut a Multar"></asp:Label><br /><br />
	                                            <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label><br /><br /><br /><br /><br />
	                                            <asp:Label ID="Label7" runat="server" Text="Monto"></asp:Label><br /><br /><br /><br /><br /><br /><br />

								            </td>
	                                        <td >
	                                            <asp:TextBox ID="txt_rut_Multa" runat="server" Width="195px"></asp:TextBox><br />
	                                            <asp:TextBox ID="txt_Descripcion" runat="server" Height="40px" 
	                                                TextMode="MultiLine" Width="193px"></asp:TextBox><br>
	                                            <asp:TextBox ID="txt_Monto" runat="server" type="number"  min="0" Width="195px"></asp:TextBox><br /><br />
	                                            <asp:Button ID="btn_Crear_Multa" runat="server" Text="Crear Multa" 
	                                                onclick="btn_Crear_Multa_Click" /><br /><br />
	                                            <asp:Label ID="lbl_Estado_Creacion_Multa" runat="server" Text="---"></asp:Label><br /><br />
								            </td>
						            </table>

									

	                                
								</td>
							
						</table>

	                    


	                    


	                    


	                </td>
				</tr>
			</table>



						



						







				
					
		</div>
		</asp:Content>

