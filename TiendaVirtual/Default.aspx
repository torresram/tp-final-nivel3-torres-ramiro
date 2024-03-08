<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaVirtual.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media (min-width: 768px) {
            .row-cols-md-2 > * {
                flex: 0 0 auto;
                width: 70%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <h2 class="text-center display-6">Bienvenido a la tienda virtual con precios y artículos del 2020 o antes</h2>
    <asp:UpdatePanel runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="row row-cols-md-2 g-4">
                <div class="d-flex" style="padding-top: 60px; margin: auto;">
                    <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control me-2" placeholder="Buscar" aria-label="Buscar" />
                    <asp:Button Text="Buscar" ID="btnBuscar" runat="server" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                </div>
                <div class="col-10">
                    <h2 class="h5" runat="server" id="mensajeNoEncontrado" style="display: none; margin-top: 20px; text-align: center;">No se encontró el artículo.</h2>
                </div>
            </div>
            <div class="row row-cols-md-3 g-4" style="padding-top: 30px;">
                <asp:Repeater runat="server" ID="repRepetidor" OnItemCommand="repRepetidor_ItemCommand" OnItemDataBound="repRepetidor_ItemDataBound">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card" style="width: 18rem; margin: auto;">
                                <img src="<%#Eval("ImagenUrl")%>" class="card-img-top object-fit-contain" style="height: 200px; width: 100%; padding: 10px;" alt="<%#Eval("Nombre") %>" onerror="this.onerror=null; this.src='./Images/noImageIcon.jpg'">
                                <div class="card-body">
                                    <div class="row justify-content-end">
                                        <asp:ImageButton ImageUrl='<%# ResolveUrl("~/Images/heart.png") %>' runat="server" CssClass="btn justify-content-end" Style="position: absolute; width: auto; height: 35px; border-color: transparent;" ID="btnAFavorito" OnClick="btnAFavorito_Click" CommandName="Fav" CommandArgument='<%#Eval("Id") %>' />
                                    </div>
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text" style="font-size: small;"><%#Eval("Marca")%></p>
                                    <p class="card-text lead" style="font-weight: 400">$<%#(Math.Truncate(100 * (decimal)Eval("Precio")) / 100)%></p>
                                    <div class="d-flex">
                                        <asp:Button Text="Añadir al carrito" runat="server" ID="btnAddCarrito" CssClass="btn btn-warning btn-sm" />
                                        <asp:LinkButton ID="lnkMasInfo" runat="server" Style="padding-left: 10px; font-size: small; align-self: center;" CommandName="Info" CommandArgument='<%#Eval("Id") %>'>Más información</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
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
