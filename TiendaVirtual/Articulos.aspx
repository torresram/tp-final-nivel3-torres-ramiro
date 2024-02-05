<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TiendaVirtual.Articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="col" style="margin: 0px 0px 2% 0px;">
        <h2 class="display-6">Administrar artículos</h2>
    </div>
    <div class="row" style="">
        <div class="col">
            <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table table-hover" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString=""/>
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
