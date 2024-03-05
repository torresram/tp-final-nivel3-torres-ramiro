<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TiendaVirtual.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row" style="margin:0px auto;">
        <h2 class="display-6">Creá tu usuario</h2>
        <div class="col-md-4" style="position: relative; margin: 15px auto; border: solid 2px #bab6b6; border-radius: 20px;padding:20px;">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Registrarse" CssClass="btn btn-success btn-sm" ID="btnRegistrarse" runat="server" OnClick="btnRegistrarse_Click" />
                <a class="btn btn-outline-danger btn-sm" href="/">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
