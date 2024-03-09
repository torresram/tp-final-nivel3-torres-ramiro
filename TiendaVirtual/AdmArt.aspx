<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdmArt.aspx.cs" Inherits="TiendaVirtual.AdmArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <h2 class="display-6" style="margin-bottom: 20px;" runat="server" id="h2Titulo">Modificar artículo</h2>
        <div class="col" style="border: solid 2px #bab6b6; border-radius: 20px; position: relative; margin: auto;">
            <h2 class="h4" runat="server" id="lblIdArticulo" style="padding: 10px;">ID XXX</h2>
            <div class="col d-flex">
                <div class="col-6" style="padding: 10px;">
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Código</label>
                        <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" MaxLength="3" />
                        <div runat="server" id="codigoMensajes" style="padding: 3px; font-size: 13px; display: none;">
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                        <div runat="server" id="nombreMensajes" style="padding: 3px; font-size: 13px; display: none;">
                        </div>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="mb-3">
                                <label for="ddlMarca" class="form-label">Marca</label>
                                <div class="d-flex mb-3">
                                    <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" />
                                    <asp:ImageButton ImageUrl="./Images/plus.png" runat="server" ID="btnNuevaMarca" Style="height: 38px; padding: 5px;" OnClick="btnNuevaMarca_Click" />
                                </div>
                                <div class="col-6 d-flex" runat="server" id="divAgregarMarca" style="display: none;">
                                    <asp:TextBox CssClass="form-control" ID="txtNuevaMarca" runat="server" />
                                    <asp:ImageButton ImageUrl="./Images/check.png" runat="server" Style="height: 38px; padding: 5px;" ID="btnOkMarca" OnClick="btnOkMarca_Click" />
                                    <asp:ImageButton ImageUrl="./Images/cancel.png" runat="server" Style="height: 38px; padding: 5px;" ID="btnCancelMarca" OnClick="btnCancelMarca_Click" />
                                </div>
                                <div runat="server" id="marcaMensajes" style="padding: 3px; font-size: 13px; display: none;">
                                </div>
                            </div>
                            <div class="mb-3">
                                <label for="ddlCategoria" class="form-label">Categoría</label>
                                <div class="d-flex mb-3">
                                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" />
                                    <asp:ImageButton ImageUrl="./Images/plus.png" runat="server" ID="btnNuevaCategoria" Style="height: 38px; padding: 5px;" OnClick="btnNuevaCategoria_Click" />
                                </div>
                                <div class="col-6 d-flex" runat="server" id="divAgregarCategoria" style="display: none;">
                                    <asp:TextBox CssClass="form-control" ID="txtNuevaCategoria" runat="server" />
                                    <asp:ImageButton ImageUrl="./Images/check.png" runat="server" Style="height: 38px; padding: 5px;" ID="btnOkCategoria" OnClick="btnOkCategoria_Click" />
                                    <asp:ImageButton ImageUrl="./Images/cancel.png" runat="server" Style="height: 38px; padding: 5px;" ID="btnCancelCategoria" OnClick="btnCancelCategoria_Click" />
                                </div>
                                <div runat="server" id="categoriaMensajes" style="padding: 3px; font-size: 13px; display: none;">
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnOkMarca" />
                            <asp:PostBackTrigger ControlID="btnOkCategoria" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                        <div runat="server" id="precioMensajes" style="padding: 3px; font-size: 13px; display: none;">
                        </div>
                    </div>
                </div>
                <div class="col-6" style="padding: 10px;">
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" />
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="mb-3">
                                <label for="txtImgUrl" class="form-label">Imágen</label>
                                <asp:TextBox runat="server" ID="txtImgUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImgUrl_TextChanged" />
                                <asp:Image runat="server" ID="imgArticulo" onerror="this.onerror=null; this.src='./Images/noImageIcon.jpg'" CssClass="img-fluid mb-3" Style="margin: 10px; max-height: 300px;" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="mb-3" style="width: fit-content; margin: auto;">
                <div class="form-check form-switch" style="width: fit-content; margin: 0px auto 15px;" runat="server" id="chkGuardarDiv">
                    <input class="form-check-input" type="checkbox" role="switch" id="chkGuardar" runat="server">
                    <label class="form-check-label" for="chkGuardar">Guardar cambios</label>
                </div>
                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" />
                <a href="Articulos.aspx" class="btn btn-primary">Cancelar</a>
                <asp:Button Text="Eliminar" ID="btnEliminar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" />
                <%
                    if (ConfirmarEliminar)
                    {%>
                <div class="mb-3" style="margin: 10px auto; border: solid 2px red; border-radius: 10px; padding: 10px;">
                    <div class="form-check form-switch" style="width: fit-content; margin: 0px auto 15px;">
                        <input class="form-check-input" type="checkbox" role="switch" id="chkEliminar" runat="server">
                        <label class="form-check-label" for="flexSwitchCheckDefault">Confirmar eliminación</label>
                    </div>
                    <div class="row">
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnConfirmaEliminar" runat="server" OnClick="btnConfirmaEliminar_Click" Style="width: fit-content; margin: auto;" />
                    </div>
                </div>
                <%}%>
            </div>
        </div>
        <div class="h5" runat="server" id="contError" style="display: none; color: red;">
        </div>
    </div>
</asp:Content>

