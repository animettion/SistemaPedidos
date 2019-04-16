<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pessoa.aspx.cs" Inherits="Web.Pessoa.Pessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
 
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <h2 class="bd-title">Pessoa</h2>
    <div class="form-group">
        <label for="exampleInputNome">Nome</label>
        <asp:TextBox runat="server" ID="txtNome" class="form-control" MaxLength="150"></asp:TextBox>

    </div>
    <div class="form-group">
        <label for="exampleInputEndereço">Endereço</label>
        <asp:TextBox runat="server" ID="txtEndereco" class="form-control" MaxLength="150"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputCPF">CPF</label>
        <asp:TextBox runat="server" ID="txtCpf" class="form-control " MaxLength="11"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputDataNasc">Data de Nascimento</label>
        <asp:TextBox runat="server" ID="txtDataNasc" class="form-control" MaxLength="10"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputSexo">Sexo</label>
        <asp:RadioButtonList ID="rdbSexo" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="M">Masculino</asp:ListItem>
            <asp:ListItem Value="F">Feminino</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click" class="btn btn-primary" />


    <br />

</asp:Content>
