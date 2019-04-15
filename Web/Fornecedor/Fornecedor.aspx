<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Fornecedor.aspx.cs" Inherits="Web.Fornecedor.Fornecedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
            <h1>Fornecedor</h1>
            <br />
            Nome: <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>  <br />
            Endereço: <asp:TextBox ID="txtEndereço" runat="server"></asp:TextBox>  <br />
            CNPJ: <asp:TextBox ID="txtCNPJ" runat="server"></asp:TextBox>  <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    </asp:Content>

