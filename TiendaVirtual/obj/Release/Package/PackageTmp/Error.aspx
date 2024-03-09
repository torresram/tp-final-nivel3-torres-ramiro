<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TiendaVirtual.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p class="display-5" runat="server" id="msgError" style="text-align:center;"></p>
    <div class="row">
        <div class="col justify-content-center">
            <asp:Button Text="Volver..." ID="btnVolver" CssClass="btn btn-link" runat="server" OnClick="btnVolver_Click" />
        </div>
    </div>
</asp:Content>
