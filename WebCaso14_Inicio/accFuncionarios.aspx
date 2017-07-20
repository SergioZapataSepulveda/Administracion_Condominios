<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="accFuncionarios.aspx.cs" Inherits="WebCaso14_Inicio.accFuncionarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div id="Titulos">
            Acceso para Funcionarios
            </div>

            <div id="ContentPlaceHolder" align="center" >
            <br><br><br><br><br><br>
                <asp:Login ID="LoginAccFun" runat="server" onauthenticate="LoginAccFun_Authenticate">
                </asp:Login>
                <asp:Label ID="lblDato" runat="server" Text="----  :::  "></asp:Label>
            </div>
            </div>
</asp:Content>


