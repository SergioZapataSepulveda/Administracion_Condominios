<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pago_Tarjeta.aspx.cs" Inherits="WebCaso14.Pago_Tarjeta" %>
<asp:Content ID="Content4" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <div id="Titulos">
            Pago Tarjeta
            </div>


<div id="ContentPlaceHolder">


			<table style="width: 100%; font-size: 11px; border-top: 12px">
				<tr>
					<td style= "width: 68%; padding:20px">

						


	                    <table style="width: 100%;">
	                        <tr>
								<td style="width: 45%;" >
                                    
								</td>
                                <td style="width: 5%;"><br>
                                </td>
                                <td style="width: 45%;" class="textoDestacado" >
	                                <b><asp:Label ID="Label10" runat="server" Text="Detalle de Pago"></asp:Label></b>
								</td>
							</tr>



                            <tr>
								<td style="width: 45%;"><br>
                                    
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Banco-Estado.jpg" Height="100px" />
                           

								    </td>

                                    <td style="width: 5%;"><br>
                                    </td>

                                    </td>
                                    <td style="width: 45%;"><br>
                                        <li> Benefociario: <b>Condominio Las Araucarias S.A. </b> </li>
                                        <li> Numero de Pago <b>2533904272367</b> </li>
                                        <li> Total a Pagar: $ <b><asp:Label ID="lbl_total_Pagar" runat="server" Text=""></asp:Label></asp:Label>       </b> </li><br>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="width: 45%;">
	                                    <b><asp:Label ID="Label8" runat="server" Text=""></asp:Label><br><br>
								    </td>
                                    <td style="width: 5%;">
	                                    <b><asp:Label ID="Label13" runat="server" Text=""></asp:Label><br><br>
								    </td>
                                    <td style="width: 45%;">
	                                    <b><asp:Label ID="Label14" runat="server" Text=""></asp:Label><br><br>
								    </td>
                                </tr>
                                

                                
						</table>
                        <table>
                            <tr>
								    <td style="width: 45%;" class="textoDestacado" >
	                                    <b><asp:Label ID="Label6" runat="server" Text="Validacion de Tarjeta"></asp:Label>
								    </td>
							 </tr>
                         </table>
                         <table>
                            <tr>
                                    <td style="width: 15%;" align="right"><br>
                                        <b><asp:Label ID="Label2" runat="server" Text="Número de tarjeta"></asp:Label></b><br><br><br>
                                        <b><asp:Label ID="Label3" runat="server" Text="Fecha de vencimiento"></asp:Label></b><br><br><br>
                                        <b><asp:Label ID="Label4" runat="server" Text="Código de seguridad"></asp:Label></b><br><br><br>
                                        <b><asp:Label ID="Label5" runat="server" Text="Rut Titular"></asp:Label></b><br><br><br><br>
								    </td>
                                    <td style="width: 1%;">
								    </td>
                                    <td style="width: 29%;"><br>
                                        <asp:TextBox ID="txt_tarjeta_n" runat="server" Height="20px" MaxLength="16"></asp:TextBox> <br><br>
                                        <asp:DropDownList ID="ddl_mes" runat="server" Height="20px">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddl_anio" runat="server" Height="20px">
                                        </asp:DropDownList>
                                        <br><br>
                                        <asp:TextBox ID="txt_seguridad" runat="server" Height="20px" MaxLength="3" Width="40px"></asp:TextBox>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/code.jpg" Height="20" /><br><br>
                                        <asp:TextBox ID="txt_rut" runat="server" Height="20px" Width="100px"></asp:TextBox><br><br>
                                        <asp:Button ID="btn_pagar" runat="server" Text="Validar Datos" 
                                            onclick="btn_pagar_Click" />    
                                        <asp:Button ID="btn_Finalizar" runat="server" Text="Finalizar" 
                                            onclick="btn_Finalizar_Click" />
                                            <br>
                                            <asp:Button ID="btn_comprobante" runat="server" 
                                            Text="Guardar Comprobante de Pago" onclick="btn_comprobante_Click" />

								    </td>
                                    <td style="width: 5%;">
								    </td>
                                    <td style="width: 45%;">
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/padlock.jpg" Height="16" />
                                    <b><asp:Label ID="Label1" runat="server" Text="Pago 100% seguro"></asp:Label></b><br><br>
                                    Banco Estado utiliza los últimos estándares de seguridad y no almacena nunca su información bancaria. Esta información se envía directamente a Be2bill a través de la tecnología SSL que garantiza un pago 100% seguro. 
								    <br><br>
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/secure.jpg" Height="30" /> <asp:Image ID="Image4" runat="server" ImageUrl="~/img/dss.jpg" Height="30" /><br><br>
                                    <b>Banco Estado, la solución de cobro en línea preferida de los comerciantes</b><br>
                                    Si realiza su transacción bancaria mediante Banco Estado, se hará con la máxima eficacia.
                                    Banco Estado, empresa del grupo Banco Estado, está homologada por el Banco Central de Chile, miembro del GIE tarjetas bancarias y especialista del pago en línea desde 2002.
                                    </td>
                                </tr>
                         </table>
                         <table>
                            <tr>
								    <td style="width: 45%;">
	                                    <b><asp:Label ID="Label7" runat="server" Text="Mensaje Validacion: "></asp:Label></b>
                                        <asp:Label ID="lbl_mensaje" runat="server" Text="--- "></asp:Label><br><br>
                                        <b><asp:Label ID="Label9" runat="server" Text="Mensaje Finalizar Pago: "></asp:Label></b>
                                        <asp:Label ID="lbl_mensaje_FP" runat="server" Text="--- "></asp:Label>
								    </td>
                                    <td style="width: 5%;"></td>
                                    <td style="width: 45%;">
                                    <br><br>
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/card-type.jpg" Height="30" /> 
                                    </td>
							 </tr>
                         </table>
                    </td>
				</tr>
			</table>




				
					
		</div>
		</asp:Content>
    




