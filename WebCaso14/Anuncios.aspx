<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Anuncios.aspx.cs" Inherits="WebCaso14.Anuncios" %>
<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div id="Titulos">
            Anuncios Comunidad
            </div>

	<div id="ContentPlaceHolder">


		<table style="width: 100%; font-size: 11px; vertical-align: text-top;">
			<tr>
				<td style="width: 57%; padding:15px;">

					<table style="width: 100%;" class="tablaFijada">
	                <tr>
							<td class="textoDestacado">
								<b><asp:Label ID="Label9" runat="server" Text="Lista de Ultimos Anuncios de la Comunidad"></asp:Label>
							</td>
						</tr>
						
					</table><br><br>


                    
                    <table style="width: 100%;">
						<tr>
							<td style="width: 30%;">
								<asp:Label ID="lbl_detalle_1" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 5%;">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;">
								<asp:Label ID="lbl_detalle_2" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 5%;">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;">
								<asp:Label ID="lbl_detalle_3" runat="server" Text=""></asp:Label>
							</td>
						</tr>
					</table>
					<br>



                    <table style="width: 100%;">
						<tr>
							<td style="width: 30%;">
								<asp:Label ID="lbl_detalle_4" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 5%;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
							</td>
							<td style="width: 30%;">
								<asp:Label ID="lbl_detalle_5" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 5%;">
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
							</td>
                            <td style="width: 30%;">
								<asp:Label ID="lbl_detalle_6" runat="server" Text=""></asp:Label>
							</td>
						</tr><br>
					</table>
					<br><br>
				</td>
				
			</tr>
		</table>
	</div>
	</asp:Content>
