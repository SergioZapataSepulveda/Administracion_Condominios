<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginResidente.aspx.cs"
    Inherits="WebCaso14.Residentes.LoginResidente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="background: linear-gradient(to right, #f6f1d3, #648880, #293f50);">
    <br /><br /><br /><br />
                <div id="AccesoPorLogin"  style="width: 450px; height: 250px; margin-left: auto; margin-right: auto; background-color: white; font-family: arial; ">
                    <asp:Label ID="Label1" runat="server" style="margin-top: -40px; position: absolute; font-family: Arvo; font-weight: 700; color: White; font-size: 30px;" Text="Acceso para Residente"></asp:Label>
                    <form id="form1" class="form-signin" runat="server" ><br /><br />


                    <asp:Login ID="LoginR" runat="server" OnAuthenticate="LoginResidente_Authenticate"



                        align="center" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Names="Arial" Font-Size="0.9 em" 
                        ForeColor="#333333" 
                        FailureText="El intento de conexión no fue correcto. Inténtelo de nuevo."
                        FailureText1="El intento de conexión no fue correcto. Inténtelo de nuevo." 
                        UserNameLabelText="Rut Residente:">
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                            BorderWidth="1px" Font-Names="Arial" Font-Size="0.9 em" ForeColor="#284775" />
                        
                        <TitleTextStyle BackColor="#1c7793" Font-Bold="True" Font-Size="1.1em" Height="28px" BorderWidth="15px" ForeColor="White" />
                    </asp:Login>
                    </form>
                </div>
            
</body>
</html>
