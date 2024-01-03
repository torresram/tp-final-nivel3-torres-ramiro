<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TiendaVirtual.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div>
        <h3 class="display-6">Tus Favoritos</h3>
    </div>
    <div class="row">
        <asp:Repeater runat="server" ID="repFavoritos">
            <ItemTemplate>
                <div class="col-10" style="padding: 10px;">
                    <div class="card" style="width: 75%; margin: auto;">
                        <div class="card-body d-flex">
                            <div style="margin:auto;">
                                <div class="card-body" style="width:120px; height:120px; padding:0;">
                                    <asp:ImageButton ImageUrl='<%#Eval("ImagenUrl") %>' runat="server" Style="width: 100%; height:120px;" CssClass="object-fit-contain" onerror="this.onerror=null; this.src='./Images/noImageIcon.jpg'" />
                                </div>
                            </div>
                            <div class="col-9" style="margin:auto;">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <h6 class="card-subtitle mb-2 text-body-secondary"><%#Eval("Marca") %></h6>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <a href="Detalle.aspx?id=<%#Eval("Id") %>" class="card-link">Detalles</a>
                                <a href="#" class="card-link">Another link</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
