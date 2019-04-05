<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="App.UI.WebForm.Mantenimiento.UpdateArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="form-group">
            <label for="formGroupExampleInput">ID</label>
            <asp:TextBox ID="txtId" runat="server" placeholder="ID"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="formGroupExampleInput2">Nombre del Artista</label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del artista"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        </div>
    </div>
</asp:Content>
