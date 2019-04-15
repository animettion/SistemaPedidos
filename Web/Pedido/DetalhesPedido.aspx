<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalhesPedido.aspx.cs" Inherits="Web.Pedido.DetalhesPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Pedido: <asp:Label ID="lblCodigoPedido" runat="server"> </asp:Label><br />
    Comprador: <asp:Label ID="lblNomePessoa" runat="server"></asp:Label> <br />
    Fornecedor: <asp:Label ID="lblNomeFornecedor" runat="server"></asp:Label> <br />

    Itens:<br />
    <asp:Label ID="lblItems" runat="server"></asp:Label>

</asp:Content>
