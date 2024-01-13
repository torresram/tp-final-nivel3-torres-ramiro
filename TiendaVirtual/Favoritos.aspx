<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TiendaVirtual.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media (min-width: 768px) {
            .col-sm-10 {
                flex: 0 0 auto;
                width: 63%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <h3 class="display-6">Tus Favoritos</h3>
    </div>
    <div class="row">
        <asp:Repeater runat="server" ID="repFavoritos">
            <ItemTemplate>
                <div class="col-sm-10" style="padding: 10px; margin: auto;">
                    <div class="card">
                        <div class="card-body d-flex">
                            <div style="margin: auto;">
                                <div class="col-sm-3" style="height: 120px; width:120px; padding: 0;">
                                    <asp:ImageButton ImageUrl='<%#Eval("ImagenUrl") %>' runat="server" Style="width: 100%; height: 120px;" CssClass="object-fit-contain" onerror="this.onerror=null; this.src='./Images/noImageIcon.jpg'" />
                                </div>
                            </div>
                            <div class="card-body" style="margin: auto;">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <h6 class="card-subtitle mb-2 text-body-secondary"><%#Eval("Marca") %></h6>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <a href="Detalle.aspx?id=<%#Eval("Id") %>" class="card-link">Detalles</a>
                            </div>
                            <div style="width: 40px; height: 40px; position: absolute; right: 15px; bottom: 15px;">
                                <asp:ImageButton ImageUrl='<%#ResolveUrl("~/Images/tacho.png") %>' runat="server" ID="btnQuitarFav" CssClass="btn object-fit-contain" Style="border-color: transparent; height: 40px; padding: 0;" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
