<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Fornecedor.aspx.cs" Inherits="Web.Fornecedor.Fornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="bd-title">Fornecedor</h2>
    <div class="form-group">
        <label for="exampleInputNome">Nome</label>
        <asp:TextBox ID="txtNome" runat="server" class="form-control" MaxLength="150"></asp:TextBox>

    </div>
    <div class="form-group">
        <label for="exampleInputEndereço">Endereço</label>
        <asp:TextBox ID="txtEndereço" runat="server" class="form-control" MaxLength="150"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputCPF">CNPJ</label>
        <asp:TextBox ID="txtCNPJ" runat="server" class="form-control" MaxLength="14"></asp:TextBox>
    </div>
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" class="btn btn-primary" />
</asp:Content>

