<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewArtist.aspx.cs" Inherits="App.UI.WebForm.Mantenimiento.NewArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div>

  <div class="form-group">
      <label for="exampleInputEmail1">Nombre del artista:</label>
      <asp:TextBox ID="txtNombre" runat="server" ClientIDMode="Static" 
          CssClass="form-control"></asp:TextBox>
  </div>
      <asp:Button ID="btnGrabar" runat="server" Text="Button" CssClass="btn btn-primary"
          OnClick="btnGrabar_Click"/>
  </div>

</asp:Content>
