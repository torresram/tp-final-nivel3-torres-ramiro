<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaVirtual.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 class="text-center display-6">Bienvenido a la tienda virtual con precios y artículos del 2020 o antes</h2>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <div class="col-10 d-flex" style="padding-top: 60px; width:70%; margin:auto;">
            <input class="form-control me-2" type="search" placeholder="Buscar" aria-label="Buscar">
            <asp:Button Text="Buscar" ID="btnBuscar" runat="server" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4" style="padding-top: 30px;">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top object-fit-contain" style="height: 200px; width: 100%;" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text" style="font-size:small;"><%#Eval("Marca")%></p>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <p class="card-text">$<%#Eval("Precio")%></p>
                            <div class="d-flex">
                                <asp:Button Text="Añadir al carrito" runat="server" ID="btnAddCarrito" CssClass="btn btn-primary" />
                                <a href="Detalle.aspx" style="padding-left:10px; font-size:small; align-self:center;">Más información</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>