<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="Web.Pedido.Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Pessoa:
    <asp:DropDownList runat="server" ID="drpPessoas" Width="200px"></asp:DropDownList>
    <br />
    Fornecedor:
    <asp:DropDownList runat="server" ID="drpFornecedor" Width="200px"></asp:DropDownList>
    <br />
    <asp:Button ID="btnAvancar" runat="server" Text="Avançar" OnClick="btnAvancar_Click" />
    <br />
    <div runat="server" id="DivGrid" visible="false">
        <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="false" Width="800px" OnRowCommand="grvProdutos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Fornecedor.Pessoa.Nome" HeaderText="Fornecedor" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Preco" HeaderText="Preço" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Button ID="btnAdd" runat="server" CommandName="Add" Text="Incluir"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoProduto")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        Produtos Adicionados:
    <br />
        <asp:GridView ID="grvProdutosSelecionados" runat="server" AutoGenerateColumns="false" Width="800px" OnRowCommand="grvProdutosSelecionados_RowCommand">
            <Columns>

                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Preco" HeaderText="Preço" />
                <asp:TemplateField ItemStyle-Width="100px">

                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="Remove" Text="Remover"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoProduto")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        Total: R$ <asp:Label ID="lblTotal" runat="server"></asp:Label>
        <br />
        <asp:Button runat="server" ID="btnFinalizar" OnClick="Finalizar_Click" Text="Finalizar" />
    </div>
</asp:Content>
