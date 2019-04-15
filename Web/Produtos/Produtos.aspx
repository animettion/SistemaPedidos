<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Web.Produtos.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Fornecedor</h2>
    <br />
    Fornecedor:
            <asp:Label ID="lblNome" runat="server"></asp:Label>
    <br />
    Nome:
            <asp:TextBox ID="txtNome" runat="server">
            </asp:TextBox>
    <br />
    Preço:
            <asp:TextBox ID="txtPreco" runat="server">
            </asp:TextBox>
    <br />
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    <br />
    Produtos
           <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="false" Width="800px" OnRowCommand="grvProdutos_RowCommand">
               <Columns>
                   <asp:BoundField DataField="Nome" HeaderText="Nome" />
                   <asp:BoundField DataField="Preco" HeaderText="Preço" />
                   <asp:TemplateField ItemStyle-Width="100px">
                       <ItemTemplate>
                           <asp:Button ID="btnAddExcluir" runat="server" CommandName="Excluir" Text="Excluir"
                               CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoProduto")%>' />
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
           </asp:GridView>

</asp:Content>
