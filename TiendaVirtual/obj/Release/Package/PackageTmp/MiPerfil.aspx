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
    <asp:ScriptManager runat="server" />
    <h2 class="display-6">Mi Perfil</h2>
    <div class="row" style="margin: 30px auto;">
        <div class="col-md-4" style="border: solid 2px #bab6b6; border-radius: 20px; height: fit-content; margin: 0px auto;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="img-fluid" style="height: 150px; width: 150px; margin: 5% auto 2.5%;">
                        <img class="img-fluid rounded" src="./Images/userDefault.png" alt="Imágen de perfil" runat="server" id="imgUsuario" />
                    </div>
                    <div style="width: fit-content; margin: 15px auto 20px;">
                        <div class="mb-3 d-grid gap-2 d-md-flex justify-content-md-center">
                            <asp:Button Text="Cambiar imágen" runat="server" ID="btnPerfilImg" OnClick="btnPerfilImg_Click" CssClass="btn btn-secondary btn-sm" Style="position: relative;" />
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
                        <div class="d-flex" style="width: fit-content; position: relative; margin: 0px auto 10px; display: none;" runat="server" id="esAdminDiv">
                            <img src="./Images/adminOk.png" alt="AdministradorOk" class="img-fluid" style="height: 28px;" />
                            <p class="h5" style="margin: auto;">ADMINISTRADOR</p>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnOkPerfil" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-8" style="border: solid 2px #bab6b6; border-radius: 20px; position: relative; margin: auto;">
            <div class="col-9" style="margin: auto;">
                <div class="mb-3" style="margin-top: 15px;">
                    <label class="h6" runat="server" id="lblId" style="position: relative; left: 95%">ID XXX</label>
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Email:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" Enabled="false" />
                </div>
                <div class="mb-3">
                    <asp:UpdatePanel runat="server" ID="upDatos" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button Text="Cambiar contraseña" runat="server" CssClass="btn btn-success btn-sm" ID="btnCambiarPass" OnClick="btnCambiarPass_Click" />
                            <asp:Button Text="Guardar cambios" CssClass="btn btn-warning btn-sm" ID="btnGuardarDatos" OnClick="btnGuardarDatos_Click" runat="server" Style="left: 57%; position: relative;" />
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
                            <div class="toast-container position-fixed bottom-0 end-0 p-3">
                                <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true" runat="server">
                                    <div class="toast-header">
                                        <img src="./Images/notificacion.png" class="rounded me-2" alt="alerta" style="height: 20px;">
                                        <strong class="me-auto">Usuario</strong>
                                        <small>Cambio de datos</small>
                                        <%--<button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>--%>
                                        <asp:Button Text="" CssClass="btn-close" runat="server" ID="btnCerrarNotificacion" OnClick="btnCerrarNotificacion_Click" />
                                    </div>
                                    <div class="toast-body" style="text-align: center;">
                                        Datos actualizados correctamente!
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
