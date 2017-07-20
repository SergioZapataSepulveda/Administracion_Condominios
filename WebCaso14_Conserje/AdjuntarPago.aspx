<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdjuntarPago.aspx.cs" Inherits="WebCaso14_Conserje.AdjuntarPago" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Titulos">
        Adjuntar Boleta de Pago Offline
    </div>
    <div id="ContentPlaceHolder">
        <table style="width: 100%; font-size: 11px; vertical-align: text-top;">
            <tr>
                <td style="width: 57%; padding: 15px">
                    <table style="width: 100%;" class="tablaFijada">
                        <tr>
                            <td class="textoDestacado">
                                <b>
                                    <asp:Label ID="Label9" runat="server" Text="Subir Comprobante de Pago"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br>
                    <br>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 50%;">
                                
                                <asp:Label ID="Labelsds3" runat="server" Text="Ingrese un Rut para buscar y mostrar los archivos de Residente"></asp:Label>
                                <asp:TextBox ID="txtrut" runat="server"></asp:TextBox>
                                <asp:Button ID="btn_buscar" runat="server" Text="Buscar Residente" 
                                    onclick="btn_buscar_Click" />
                                <br><br>
                                <asp:Label ID="Label1" runat="server" Text="Seleccionar tipo de pago"></asp:Label>
                                <asp:DropDownList ID="ddl_tipo" runat="server">
                                </asp:DropDownList>
                                <br><br>
                                <asp:FileUpload ID="FileUpload1" runat="server" ViewStateMode="Disabled" />
                                <asp:Button ID="btn_subir_archivo" runat="server" Text="Enviar Archivo" OnClick="btn_subir_archivo_Click" /><br>
                                <br>
                                <b>
                                    <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label></b>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1"
                                    ErrorMessage="* Solo se permiten archivos en formato .JPEG" ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)"
                                    Font-Bold="True" ForeColor="Red"></asp:RegularExpressionValidator><br>
                                <br>
                        </tr>
                    </table>
                    <table style="width: 100%;" class="tablaFijada">
                        <tr>
                            <td style="width: 50%;">
                                <asp:GridView ID="GridView2" runat="server" OnPageIndexChanging="GridView2_PageIndexChanging"
                                    AllowPaging="True" OnRowDataBound="GridView2_RowDataBound" Height="355px" AutoGenerateSelectButton="True"
                                    PageSize="7" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                    <HeaderStyle Wrap="False" />
                                    <RowStyle Wrap="False" />
                                </asp:GridView>
                            </td>
                            <td style="width: 5%;">
                            </td>
                            <td style="width: 45%;">
                                <asp:Label ID="Label2" runat="server" Text="Seleccione de su lista documentos el archivo que desea visualizar"></asp:Label><br>
                                <asp:Image ID="img_nombre_archivo" runat="server" Height="340" />
                            </td>
                        </tr>
                    </table>
                    <br>
                    <br>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

