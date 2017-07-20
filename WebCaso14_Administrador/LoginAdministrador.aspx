<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdministrador.aspx.cs" Inherits="WebCaso14_Administrador.LoginAdministrador" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title></title>
</head>
<body style="background: linear-gradient(to right, #f6f1d3, #648880, #293f50);">
    <br /><br /><br /><br />
                <div id="AccesoPorLogin"  style="width: 450px; height: 250px; margin-left: auto; margin-right: auto; background-color: white; font-family: arial; ">
                    <asp:Label ID="Label1" runat="server" style="margin-top: -40px; position: absolute; font-family: Arvo; font-weight: 700; color: White; font-size: 30px;" Text="Acceso para Administrador"></asp:Label>
                    <form id="form2" class="form-signin" runat="server" ><br /><br />


                    <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate"



                        align="center" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="0.9 em" 
                        ForeColor="#333333">
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                            BorderWidth="1px" Font-Names="Arial" Font-Size="0.9 em" ForeColor="#284775" />
                        
                        <TitleTextStyle BackColor="#1c7793" Font-Bold="True" Font-Size="1.1em" Height="28px" BorderWidth="15px" ForeColor="White" />
                    </asp:Login>
                    </form>
                </div>
            
</body>
</html>