<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaPessoa.aspx.cs" Inherits="Web.Pessoa.ListaPessoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Pessoa</h2>
    <asp:GridView ID="grvPessoa" runat="server" AutoGenerateColumns="false" Width="800px" OnRowCommand="grvPessoa_RowCommand">
        <Columns>
            <asp:BoundField DataField="Pessoa.Nome" HeaderText="Nome" />

            <asp:BoundField DataField="CPF" HeaderText="CPF" />
            <asp:BoundField DataField="Sexo" HeaderText="Sexo" />

            <asp:TemplateField ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Button ID="btnAddEditar" runat="server" CommandName="Editar" Text="Editar"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoPF")%>' />
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Button ID="btnPedido" runat="server" CommandName="Pedido" Text="Realizar Pedido"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoPF")%>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
