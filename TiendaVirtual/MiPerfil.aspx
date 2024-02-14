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
                <img class="img-fluid" src="./Images/userDefault.png" alt="Imágen de perfil" runat="server" id="imgUsuario" />
            </div>
            <div style="width: fit-content; margin: 15px auto 20px;">
                <div class="mb-3 d-grid gap-2 d-md-flex justify-content-md-center">
                    <asp:Button Text="Cambiar imágen" runat="server" ID="btnPerfilImg" OnClick="btnPerfilImg_Click" CssClass="btn btn-secondary" Style="position: relative;" />
                </div>
                <div class="mb-3" runat="server" id="cambiarImgDiv" style="display: none;">
                    <div class="mb-3">
                        <asp:FileUpload ID="fluImgPerfil" runat="server" CssClass="form-control form-control-sm" Style="position: relative;" />
                    </div>
                    <div class="mb-3 d-grid gap-2 d-md-flex justify-content-md-end">
                        <asp:Button Text="Ok" CssClass="btn btn-success btn-sm" runat="server" ID="btnOkPerfil" OnClick="btnOkPerfil_Click" />
                        <asp:Button Text="Atrás" CssClass="btn btn-outline-danger btn-sm" runat="server" ID="btnCancelarPerfil" OnClick="btnCancelarPerfil_Click" />
                    </div>
                </div>
            </div>
            <%if (adminOk)
                {%>
            <div class="d-flex" style="width: fit-content; position: relative; margin: 0px auto 10px;" runat="server" id="esAdminDiv">
                <img src="./Images/adminOk.png" alt="AdministradorOk" class="img-fluid" style="height: 28px;" />
                <p class="h5" style="margin: auto;">ADMINISTRADOR</p>
            </div>
            <%}%>
        </div>
        <div class="col-md-8" style="border: solid 2px #bab6b6; border-radius: 20px; position: relative; margin: auto;">
            <div class="col-9" style="margin: auto;">
                <div class="mb-3" style="margin-top: 15px;">
                    <label class="h6" runat="server" id="lblId" style="position: relative; left: 90%">ID XXX</label>
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
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" Enabled="false" />
                </div>
                <div class="mb-3">
                    <asp:Button Text="Cambiar contraseña" runat="server" CssClass="btn btn-success btn-sm" ID="btnCambiarPass" OnClick="btnCambiarPass_Click" />
                    <div class="col-6" runat="server" id="cambiarPassDiv" style="display: none;">
                        <div class="mb-3">
                            <label class="form-label">Contraseña actual:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassActual" TextMode="Password" />
                            <div runat="server" id="actualPassMensajes" style="padding: 3px; font-size: 13px; display: none;">
                            </div>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Contraseña nueva:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassNueva" TextMode="Password" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Reingrese contraseña nueva:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPassCheck" TextMode="Password" />
                            <div runat="server" id="nuevoPassMensajes" style="padding: 3px; font-size: 13px; display: none;">
                            </div>
                        </div>
                        <div>
                            <asp:Button Text="Guardar" runat="server" ID="btnGuardarPass" CssClass="btn btn-success btn-sm" OnClick="btnGuardarPass_Click" />
                            <asp:Button Text="Cancelar" runat="server" ID="btnCancelarPass" CssClass="btn btn-outline-danger btn-sm" OnClick="btnCancelarPass_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
