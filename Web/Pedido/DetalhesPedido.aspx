<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalhesPedido.aspx.cs" Inherits="Web.Pedido.DetalhesPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="bd-title">Detalhes do Pedido</h2>
    <div class="form-group">
        <label for="exampleInputNome">Codigo do Pedido</label>
        <asp:label id="lblCodigoPedido" runat="server" class="form-control"></asp:label>
        

    </div>
    <div class="form-group">
        <label for="exampleInputEndereço">Comprador</label>
        <asp:label id="lblNomePessoa" runat="server" class="form-control"></asp:label>
        
    </div>
    <div class="form-group">
        <label for="exampleInputCPF">Fornecedor</label>
        <asp:label id="lblNomeFornecedor" runat="server" class="form-control"></asp:label>
    </div>

    Itens:<br />
    <asp:gridview id="grvProdutos" runat="server" autogeneratecolumns="false" width="800px" cssclass="table table-hover table-striped" gridlines="None">
               <Columns>
                   <asp:BoundField DataField="produto.Nome" HeaderText="Nome" />
                   <asp:BoundField DataField="produto.Preco" HeaderText="Preço" />
                   <asp:BoundField DataField="Qtd" HeaderText="Quantidade" />
               </Columns>
           </asp:gridview>
    Total: R$
    <asp:label id="lblTotal" runat="server" text="0"></asp:label>
</asp:Content>
