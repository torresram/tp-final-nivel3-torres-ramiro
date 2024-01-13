<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaVirtual.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media (min-width: 768px) {
            .col-md-4 {
                flex: 0 0 auto;
                width: 25%;
            }

            .col-md-8 {
                flex: 0 0 auto;
                width: 65%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 class="display-6">Mi Perfil</h2>
    <div class="row" style="margin: 30px auto;">
        <div class="col-md-4" style="border: solid 2px #bab6b6; border-radius: 20px; height: fit-content; margin: 0px auto;">
            <div class="img-fluid" style="height: 150px; width: 150px; margin: 5% auto 2.5%;">
                <img class="img-fluid" src="./Images/userDefault.png" alt="Imágen de perfil" />
            </div>
            <div style="width: fit-content; margin: 15px auto 30px;">
                <asp:Button Text="Cambiar imágen" runat="server" ID="btnPerfilImg" OnClick="btnPerfilImg_Click" CssClass="btn btn-secondary" Style="position: relative;" />
            </div>
        </div>
        <div class="col-md-8" style="border: solid 2px #bab6b6; border-radius: 20px; position: relative; margin: auto;">
            <div class="col-9" style="margin: auto;">
                <div class="mb-3" style="margin-top: 15px;">
                    <label>ID XXX</label>
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Cambiar contraseña" runat="server" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
