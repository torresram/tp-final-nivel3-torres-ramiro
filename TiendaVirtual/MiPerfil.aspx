<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaVirtual.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row" style="margin: 30px auto;">
        <div class="col-3" style="border: solid 2px #bab6b6; border-radius: 20px; height:fit-content;margin: 0px auto;">
            <div style="height: 150px; width: 150px; margin: 30px auto 15px;">
                <img class="img-fluid" src="./Images/userDefault.png" alt="Imágen de perfil" style="height: 150px;" />
            </div>
            <div style="width: fit-content; margin: 15px auto 30px;">
                <asp:Button Text="Cambiar imágen" runat="server" ID="btnPerfilImg" OnClick="btnPerfilImg_Click" CssClass="btn btn-secondary" Style="position: relative;" />
            </div>
        </div>
        <div class="col-7" style="border: solid 2px #bab6b6; border-radius: 20px; position:relative; margin:auto;">
            <div class="col-9" style="margin: auto;">
                <div class="mb-3" style="margin-top:15px;">
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
