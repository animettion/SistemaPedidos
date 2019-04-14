<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaFornecedor.aspx.cs" Inherits="Web.Fornecedor.ListaFornecedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
