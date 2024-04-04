using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class AdmArt : System.Web.UI.Page
    {
        public bool ConfirmarEliminar { get; set; }
        string id;
        private Articulo articuloElegido;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requiere ser administrador para acceder a esta pantalla");
                Response.Redirect("Error.aspx");
            }
            ConfirmarEliminar = false;
            articuloElegido = (Articulo)Session["artSeleccion"];
            try
            {
                if (!IsPostBack)
                {
                    cargarDDL(0);
                    divAgregarMarca.Visible = false;
                    divAgregarCategoria.Visible = false;
                }

                id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccion = (negocio.getArticulo(int.Parse(id)));

                    Session.Add("artSeleccion", seleccion);

                    lblIdArticulo.InnerHtml = "ID " + seleccion.Id.ToString();
                    txtCodigo.Text = seleccion.Codigo;
                    txtNombre.Text = seleccion.Nombre;
                    ddlMarca.SelectedValue = seleccion.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccion.Categoria.Id.ToString();
                    decimal precio = Math.Truncate(100 * seleccion.Precio) / 100;
                    txtPrecio.Text = precio.ToString();
                    txtDescripcion.Text = seleccion.Descripcion;
                    txtImgUrl.Text = seleccion.ImagenURL;
                    txtImgUrl_TextChanged(sender, e);
                }
                else if (!IsPostBack)
                {
                    h2Titulo.InnerHtml = "Nuevo artículo";
                    lblIdArticulo.Style.Add("display", "none");
                    btnEliminar.Enabled = false;
                    chkGuardarDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void txtImgUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImgUrl.Text;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                string checkCodigo = txtCodigo.Text;
                int errorCont = 0;
                contError.Style.Add("display", "none");

                if (articuloElegido == null)
                {
                    articuloElegido = nuevo;
                }

                if (txtCodigo.Text.Length == 0)
                {
                    codigoError(1);
                    txtCodigo.Focus();
                    errorCont++;
                }
                else
                {
                    codigoMensajes.Style.Add("display", "none");
                    txtCodigo.Style.Add("border-color", "#dee2e6");
                }

                if (checkCodigo != articuloElegido.Codigo)
                {
                    if (negocio.validarCodigo(txtCodigo.Text))
                    {
                        codigoError(0);
                        txtCodigo.Focus();
                        errorCont++;
                    }
                }

                if (txtNombre.Text.Length == 0)
                {
                    nombreError();
                    txtNombre.Focus();
                    errorCont++;
                }
                else
                {
                    nombreMensajes.Style.Add("display", "none");
                    txtNombre.BorderWidth = 1;
                    txtNombre.Style.Add("border-color", "#dee2e6");
                }

                if (txtPrecio.Text.Length == 0)
                {
                    precioError(1);
                    txtPrecio.Focus();
                    errorCont++;
                }
                else
                {
                    txtPrecio.Style.Add("border-color", "#dee2e6");
                    txtNombre.BorderWidth = 1;
                }

                string checkCadena = txtPrecio.Text;//.Replace('.', ',');

                if (soloNumeros(checkCadena))
                {
                    nuevo.Precio = decimal.Parse(checkCadena);
                    precioMensajes.Style.Add("display", "none");
                }
                else
                {
                    precioError(0);
                    txtPrecio.Focus();
                    errorCont++;
                }

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Codigo = txtCodigo.Text.ToUpper();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenURL = txtImgUrl.Text;

                if (errorCont > 0)
                {
                    contError.InnerHtml = "Se encontraron " + errorCont.ToString() + " errores";
                    contError.Style.Remove("display");
                    return;
                }

                if (Request.QueryString["id"] != null)
                {
                    if (chkGuardar.Checked == true)
                    {
                        nuevo.Id = int.Parse(id);
                        negocio.modificarSP(nuevo);
                    }
                    else
                    {
                        chkGuardarDiv.Style.Add("border", "solid 2px");
                        chkGuardarDiv.Style.Add("border-radius", "5px");
                        chkGuardarDiv.Style.Add("border-color", "#fdf90e");
                        return;
                    }
                }
                else
                {
                    negocio.agregarSP(nuevo);
                }
                Response.Redirect("Articulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminar = true;
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkEliminar.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(articuloElegido.Id.ToString()));
                    Response.Redirect("Articulos.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnNuevaMarca_Click(object sender, ImageClickEventArgs e)
        {
            divAgregarMarca.Visible = true;
            btnNuevaMarca.Enabled = false;
        }
        protected void btnOkMarca_Click(object sender, ImageClickEventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            string chkMarca = txtNuevaMarca.Text;

            if (!string.IsNullOrEmpty(chkMarca))
            {
                if (!negocio.validarMarca(chkMarca))
                {
                    negocio.agregarMarca(chkMarca);
                    cargarDDL(0);
                    divAgregarMarca.Visible = false;
                    marcaMensajes.Style.Add("display", "none");
                    btnNuevaMarca.Enabled = true;
                }
                else
                {
                    marcaError(0);
                    txtNuevaMarca.Focus();
                    return;
                }
            }
            else
            {
                marcaError(1);
                txtNuevaMarca.Focus();
                return;
            }
        }
        protected void btnCancelMarca_Click(object sender, ImageClickEventArgs e)
        {
            divAgregarMarca.Visible = false;
            marcaMensajes.Style.Add("display", "none");
            btnNuevaMarca.Enabled = true;
            txtNuevaMarca.BorderWidth = 1;
            txtNuevaMarca.Style.Add("border-color", "#dee2e6");
        }
        protected void btnNuevaCategoria_Click(object sender, ImageClickEventArgs e)
        {
            divAgregarCategoria.Visible = true;
            btnNuevaCategoria.Enabled = false;
        }
        protected void btnOkCategoria_Click(object sender, ImageClickEventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            string chkCategoria = txtNuevaCategoria.Text;

            if (!string.IsNullOrEmpty(chkCategoria))
            {
                if (!negocio.validarCategoria(chkCategoria))
                {
                    negocio.agregarCategoria(chkCategoria);
                    cargarDDL(2);
                    divAgregarCategoria.Visible = false;
                    categoriaMensajes.Style.Add("display", "none");
                    btnNuevaCategoria.Enabled = true;
                }
                else
                {
                    categoriaError(0);
                    txtNuevaCategoria.Focus();
                    return;
                }
            }
            else
            {
                categoriaError(1);
                txtNuevaCategoria.Focus();
                return;
            }
        }
        protected void btnCancelCategoria_Click(object sender, ImageClickEventArgs e)
        {
            divAgregarCategoria.Visible = false;
            btnNuevaCategoria.Enabled = true;
            categoriaMensajes.Style.Add("display", "none");
            txtNuevaCategoria.BorderWidth = 1;
            txtNuevaCategoria.Style.Add("border-color", "#dee2e6");
        }
        protected void marcaError(int error)
        {
            txtNuevaMarca.BorderWidth = 2;
            txtNuevaMarca.Style.Add("border-color", "red");
            marcaMensajes.Style.Remove("display");
            marcaMensajes.Style.Add("color", "red");

            switch (error)
            {
                case 0:
                    marcaMensajes.InnerHtml = "La marca ya existe";
                    break;
                case 1:
                    marcaMensajes.InnerHtml = "El campo no puede ser vacío";
                    break;
                default:
                    break;
            }
        }
        protected void categoriaError(int error)
        {
            txtNuevaCategoria.BorderWidth = 2;
            txtNuevaCategoria.Style.Add("border-color", "red");
            categoriaMensajes.Style.Remove("display");
            categoriaMensajes.Style.Add("color", "red");

            switch (error)
            {
                case 0:
                    categoriaMensajes.InnerHtml = "La categoría ya existe";
                    break;
                case 1:
                    categoriaMensajes.InnerHtml = "El campo no puede ser vacío";
                    break;
                default:
                    break;
            }
        }
        protected void codigoError(int error)
        {
            txtCodigo.BorderWidth = 2;
            txtCodigo.Style.Add("border-color", "red");
            codigoMensajes.Style.Add("color", "red");
            codigoMensajes.Style.Remove("display");

            switch (error)
            {
                case 0:
                    codigoMensajes.InnerHtml = "El código ya existe.";
                    break;
                case 1:
                    codigoMensajes.InnerHtml = "El campo no puede ser vacío";
                    break;
                default:
                    break;
            }
        }
        protected void precioError(int error)
        {
            txtPrecio.BorderWidth = 2;
            txtPrecio.Style.Add("border-color", "red");
            precioMensajes.Style.Add("color", "red");
            precioMensajes.Style.Remove("display");

            switch (error)
            {
                case 0:
                    precioMensajes.InnerHtml = "Ingrese solamente números.";
                    break;
                case 1:
                    txtPrecio.Text = "0,00";
                    break;
                default:
                    break;
            }
        }
        protected void nombreError()
        {
            txtNombre.BorderWidth = 2;
            txtNombre.Style.Add("border-color", "red");
            nombreMensajes.InnerHtml = "El nombre no puede ser vacío.";
            nombreMensajes.Style.Add("color", "red");
            nombreMensajes.Style.Remove("display");
        }
        protected bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter) || caracter == '.'))
                {
                    return false;
                }
            }
            return true;
        }
        protected void cargarDDL(int ddl)
        {
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();

            switch (ddl)
            {
                case 0:
                    List<Marca> lstMarca = marca.listar();
                    List<Categoria> lstCategoria = categoria.listar();

                    ddlMarca.DataSource = lstMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = lstCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                    break;
                case 1:
                    List<Marca> updMarca = marca.listar();

                    ddlMarca.DataSource = updMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    break;
                case 2:
                    List<Categoria> updCategoria = categoria.listar();

                    ddlCategoria.DataSource = updCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                    break;
                default:
                    break;
            }

        }
    }
}