<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TiendaVirtual.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager runat="server" />
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
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row row-cols-3" style="margin-top: 30px;">
                <div class="col-6 d-flex">
                    <asp:Button Text="Volver..." CssClass="btn btn-outline-info btn-sm" ID="btnVolver" runat="server" OnClick="btnVolver_Click" Style="width: fit-content; position: relative; margin: 0px 52%;" />
                </div>
                <div class="col d-flex align-self-end" style="width: fit-content;">
                    <asp:Button Text="Añadir al carrito" runat="server" ID="btnAlCarrito" CssClass="btn btn-warning btn-sm" Style="margin: 0px 56%;" OnClick="btnAlCarrito_Click" />
                </div>
                <div class="col d-flex align-self-end" style="width: fit-content;">
                    <asp:Button Text="Añadir a favoritos" runat="server" ID="btnAFavoritos" CssClass="btn btn-success btn-sm" Style="margin: 0px 36%;" OnClick="btnAFavoritos_Click" />
                </div>
            </div>
            <div class="toast-container position-fixed bottom-0 end-0 p-3">
                <div class="toast" role="alert" aria-live="assertive" aria-atomic="true" runat="server" id="toast">
                    <div class="toast-header">
                        <img src="./Images/notificacion.png" class="rounded me-2" alt="alerta" style="height: 20px;">
                        <strong class="me-auto">Atención</strong>
                        <%--<button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>--%>
                        <asp:Button Text="" CssClass="btn-close" runat="server" ID="btnCerrarNotificacion" OnClick="btnCerrarNotificacion_Click" />
                    </div>
                    <div class="toast-body" style="text-align: center;">
                        Debe iniciar sesión para añadir favoritos.
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
