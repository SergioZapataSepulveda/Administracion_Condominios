<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="accResidentes.aspx.cs" Inherits="WebCaso14_Inicio.accResidentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div id="Titulos">
            Acceso de Residentes y Directivos
            </div>

            <div id="ContentPlaceHolder" align="center" >
            <br/><br/><br/><br/><br/><br/>
                <asp:Login ID="LoginAccRes" runat="server" onauthenticate="LoginAccRes_Authenticate">
                </asp:Login>

            <asp:Label ID="lblDato" runat="server" Text="----  :::  "></asp:Label>
            </div>


</asp:Content>




