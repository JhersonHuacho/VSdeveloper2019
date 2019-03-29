<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageArtist.aspx.cs" 
    Inherits="App.UI.WebForm.Mantenimiento.ManageArtist" MasterPageFile="~/Site.Master" %>


<asp:Content ID="ArtistContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <div class="form-group row mb-3">
        <asp:Label ID="lblTexto" runat="server" Text="Buscar por nombre:" class="form-control-plaintext mr-2" ></asp:Label>
        <asp:TextBox ID="txtFiltroPorNombre" runat="server" CssClass="form-control mr-2" ></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
    </div>
   
    <div class="form-group row">
        <asp:GridView ID="gvListado" runat="server" CssClass="table" 
                HeaderStyle-CssClass="thead-dark" GridLines="None">
            </asp:GridView>
    </div>
</div>

</asp:Content>


