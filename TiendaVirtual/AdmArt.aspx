<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdmArt.aspx.cs" Inherits="TiendaVirtual.AdmArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row">
        <h2 class="display-6" style="margin-bottom: 20px;">Modificar artículo</h2>
        <div class="col" style="border: solid 2px #bab6b6; border-radius: 20px; position: relative; margin: auto;">
            <h2 class="h4" runat="server" id="lblIdArticulo" style="padding: 10px;">ID XXX</h2>
            <div class="col d-flex">
                <div class="col-6" style="padding: 10px;">
                    <div class="mb-3">
                        <label for="txtCodigo" class="form-label">Código</label>
                        <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="ddlMarca" class="form-label">Marca</label>
                        <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select" />
                    </div>
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría</label>
                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select" />
                    </div>
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
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
                                <label for="txtImgUrl" class="form-label">Imágen URL</label>
                                <asp:TextBox runat="server" ID="txtImgUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImgUrl_TextChanged" />
                                <asp:Image runat="server" ID="imgArticulo" onerror="this.onerror=null; this.src='./Images/noImageIcon.jpg'" CssClass="img-fluid" Style="margin: 10px; max-height:300px;" />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="mb-3" style="width: fit-content; margin: auto;">
                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />
                <a href="Articulos.aspx" class="btn btn-outline-danger">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>

