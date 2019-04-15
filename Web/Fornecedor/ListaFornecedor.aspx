<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaFornecedor.aspx.cs" Inherits="Web.Fornecedor.ListaFornecedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <h2>Fornecedores</h2>
            <asp:GridView ID="grvFornecedor" runat="server" AutoGenerateColumns="false" Width="800px" OnRowCommand="grvFornecedor_RowCommand">
                <Columns>
                    <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" />
                    <asp:BoundField DataField="ATIVA" HeaderText="Ativo" />
                    <asp:BoundField DataField="Pessoa.Nome" HeaderText="Nome" />
                    <asp:TemplateField ItemStyle-Width="100px">
                        <ItemTemplate >
                            <asp:Button ID="btnAddProduto" runat="server" CommandName="Produtos" Text="Produtos"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoPJ")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField ItemStyle-Width="100px">
                        <ItemTemplate >
                            <asp:Button ID="btnAddEditar" runat="server" CommandName="Editar" Text="Editar"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoPJ")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField ItemStyle-Width="100px">
                        <ItemTemplate >
                            <asp:Button ID="btnAddExcluir" runat="server" CommandName="Excluir" Text="Excluir"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoPJ")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

</asp:Content>
