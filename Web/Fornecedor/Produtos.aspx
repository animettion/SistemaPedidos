<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Web.Fornecedor.Produtos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                        <ItemTemplate >
                            <asp:Button ID="btnAddExcluir" runat="server" CommandName="Excluir" Text="Excluir"
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoProduto")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
               </Columns>
           </asp:GridView>
        </div>
    </form>
</body>
</html>
