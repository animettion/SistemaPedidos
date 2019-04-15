<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pessoa.aspx.cs" Inherits="Web.Pessoa.Pessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Nome:
    <asp:textbox runat="server" id="txtNome"></asp:textbox>
    <br />
    Endereço: 
    <asp:textbox runat="server" id="txtEndereco"></asp:textbox>
    <br />
    CPF: 
    <asp:textbox runat="server" id="txtCpf"></asp:textbox>
    <br />
    Data de Nascimento:
    <asp:textbox runat="server" id="txtDataNasc"></asp:textbox>
    <br />
    Sexo:
    <asp:RadioButtonList ID="rdbSexo" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True" Value="M">Masc</asp:ListItem>
        <asp:ListItem Value="F">Fem</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:button runat="server" id="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click"/>
</asp:Content>
