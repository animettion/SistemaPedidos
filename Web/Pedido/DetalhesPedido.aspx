<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalhesPedido.aspx.cs" Inherits="Web.Pedido.DetalhesPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="bd-title">Detalhes do Pedido</h2>
    <div class="form-group">
        <label for="exampleInputNome">Codigo do Pedido</label>
        <asp:Label ID="lblCodigoPedido" runat="server" class="form-control"></asp:Label>
    </div>
    <div class="form-group">
        <label for="exampleInputEndereço">Comprador</label>
        <asp:Label ID="lblNomePessoa" runat="server" class="form-control"></asp:Label>

    </div>
    <div class="form-group">
        <label for="exampleInputCPF">Fornecedor</label>
        <asp:Label ID="lblNomeFornecedor" runat="server" class="form-control"></asp:Label>
    </div>

    Itens:<br />
    <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="false" Width="800px" CssClass="table table-hover table-striped" GridLines="None">
        <Columns>
            <asp:BoundField DataField="produto.Nome" HeaderText="Nome" />
            <asp:BoundField DataField="ValorUnitario" HeaderText="Preço Unitario" />
            <asp:BoundField DataField="Qtd" HeaderText="Quantidade" />
            <asp:BoundField DataField="ValorTotal" HeaderText="Preço Total" />
        </Columns>
    </asp:GridView>
    Total: R$
    <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
</asp:Content>
