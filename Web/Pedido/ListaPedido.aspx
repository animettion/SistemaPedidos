<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaPedido.aspx.cs" Inherits="Web.Pedido.ListaPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Pedidos</h2>
    <asp:GridView ID="grvPedido" runat="server" AutoGenerateColumns="false" Width="800px" OnRowCommand="grvPedido_RowCommand" CssClass="table table-hover table-striped" GridLines="None">
        <Columns>
            <asp:BoundField DataField="CodigoPedido" HeaderText="Codigo Pedido" />

            <asp:BoundField DataField="DataPedido" HeaderText="Data" />
            <asp:BoundField DataField="Comprador.pessoa.nome" HeaderText="Comprador" />
            <asp:BoundField DataField="Vendedor.pessoa.nome" HeaderText="Vendedor" />
            <asp:TemplateField ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Button ID="btnDetalhes" runat="server" CommandName="Detalhes" Text="Detalhes" class="btn btn-primary"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CodigoPedido")%>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
