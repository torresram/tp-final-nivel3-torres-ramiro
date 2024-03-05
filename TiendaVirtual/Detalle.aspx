<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TiendaVirtual.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div runat="server" id="detalleArticulo">
        <div class="row">
            <h3 runat="server" id="nombreItem" class="display-5 text-center" style="font-weight: bold;">Características <%#articulo.Nombre %></h3>
        </div>
        <div class="row" style="padding-top: 30px;">
            <div class="col-6" style="margin: auto;">
                <div id="carouselExampleIndicators" class="carousel slide">
                    <div class="carousel-inner">
                        <div class="carousel-item active" style="height: 358px;">
                            <img src="<%#articulo.ImagenURL %>" class="d-block w-100 object-fit-contain" style="height: inherit;" alt="<%#articulo.Nombre %>" onerror="this.onerror=null; this.src='https://icon-library.com/images/no-image-icon/no-image-icon-13.jpg'">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="margin-top: 20px;">
            <div class="col-6" style="margin: auto;">
                <table class="table">
                    <tbody>
                        <tr>
                            <th scope="row">Código</th>
                            <td><%#articulo.Codigo %></td>
                        </tr>
                        <tr>
                            <th scope="row">Nombre</th>
                            <td><%#articulo.Nombre %></td>
                        </tr>
                        <tr>
                            <th scope="row">Descripción</th>
                            <td><%#articulo.Descripcion %></td>
                        </tr>
                        <tr>
                            <th scope="row">Marca</th>
                            <td><%#articulo.Marca.Descripcion %></td>
                        </tr>
                        <tr>
                            <th scope="row">Categoría</th>
                            <td><%#articulo.Categoria.Descripcion %></td>
                        </tr>
                        <tr>
                            <th scope="row">Precio</th>
                            <td>$<%#(Math.Truncate(100 * (decimal)articulo.Precio) / 100) %></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <div class="row justify-content-center" style="margin-top:30px;">
        <div class="col-3 d-flex align-self-start">
            <asp:Button Text="Añadir al carrito" runat="server" ID="btnAlCarrito" CssClass="btn btn-primary btn-sm" />
        </div>
        <div class="col-3 d-flex justify-content-end">
            <asp:Button Text="Añadir a favoritos" runat="server" ID="btnAFavoritos" CssClass="btn btn-success btn-sm" />
        </div>
    </div>
    <div class="row justify-content-center">
        <a href="Default.aspx" class="btn btn-outline-info btn-sm" style="width:fit-content;">Volver...</a>
    </div>
</asp:Content>
