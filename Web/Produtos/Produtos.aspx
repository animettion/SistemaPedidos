<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Web.Produtos.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="bd-title">Produtos</h2>
    <div class="form-group">
        <label for="exampleInputNome">Fornecedor</label>
         <asp:Label ID="lblNome" runat="server" class="form-control"></asp:Label>

    </div>
    <div class="form-group">
        <label for="exampleInputEndereço">Nome</label>
        <asp:TextBox ID="txtNome" runat="server" class="form-control" MaxLength="150"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputCPF">Preço</label>
        <asp:TextBox ID="txtPreco" runat="server" class="form-control" MaxLength="6"></asp:TextBox>
    </div>
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"  class="btn btn-primary" />

    <br />
    Produtos
           <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="false" Width="800px" OnRowCommand="grvProdutos_RowCommand"  CssClass="table table-hover table-striped"   GridLines="None">
               <Columns>
                   <asp:BoundField DataField="Nome" HeaderText="Nome" />
                   <asp:BoundField DataField="Preco" HeaderText="Preço" />
                   <asp:TemplateField ItemStyle-Width="100px">
                       <ItemTemplate>
                           <asp:Button ID="btnAddExcluir" runat="server" CommandName="Excluir" Text="Excluir"  class="btn btn-danger"
                               CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoProduto")%>' />
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>

</asp:Content>
