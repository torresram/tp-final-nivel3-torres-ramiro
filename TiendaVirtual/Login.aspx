<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaVirtual.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-4">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <div runat="server" id="emailMensajes" style="padding: 3px; font-size: 13px; display: none;">
                </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
                <div runat="server" id="passMensajes" style="padding: 3px; font-size: 13px; display: none;">
                </div>
            </div>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
