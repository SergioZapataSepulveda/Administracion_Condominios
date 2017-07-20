<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GenerarReportes.aspx.cs" Inherits="WebCaso14_Administrador.GenerarReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div id="Titulos">
            Generar Reportes
           </div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px;">
			<tr>
				


				<td style="width: 37%; padding:15px">
                     <table style="width: 100%;">
                        <tr>
							<td class="textoDestacado" >
								<asp:Label ID="Label11" runat="server" Text="Ingresar Nuevo Registro de Multa"></asp:Label>
							</td>
						</tr>
					</table>


                    <table style="width: 100%; font-size: 12px; line-height:10px">
                        <tr>
							<td style="width: 100px;">
                                <asp:Label ID="Label6" runat="server" Text="Tipo"></asp:Label><br><br>
                                <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label><br><br><br><br><br>
                                <asp:Label ID="Label7" runat="server" Text="Rut a Reportar"></asp:Label><br><br><br><br>
							</td>
                            <td >
                                <asp:DropDownList ID="ddl_Tipo" runat="server">
                                </asp:DropDownList><br>
                                <asp:TextBox ID="txt_Descripcion" runat="server" Height="51px" 
                                    TextMode="MultiLine"></asp:TextBox><br>
                                <asp:TextBox ID="txt_Rut_Reportar" runat="server"  ></asp:TextBox><br>
                                <asp:Button ID="btn_Crear_Reporte" runat="server" Text="Crear Reporte" 
                                    onclick="btn_Crear_Reporte_Click1" />
                                
							</td>
                            <td >
                                <asp:Label ID="lbl_Estado_Creacion_Multa" runat="server" Text="---"></asp:Label><br><br>
							</td>
						</tr>
					</table>
                    <br />
                    
                    <table style="width: 100%;">
                        <tr>
							<td class="textoDestacado" >
								<asp:Label ID="Label1" runat="server" Text="Listado de Reportes "></asp:Label>
							</td>
						</tr>
					</table>
                    <br /><br />
			        <table style="width: 100%;">
                        <tr>
							<td>
                                <asp:GridView ID="GridView2" runat="server" 
            onpageindexchanging="GridView2_PageIndexChanging" AllowPaging="True" 
                                    onrowdatabound="GridView2_RowDataBound">
        </asp:GridView>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</div>
	</asp:Content>
