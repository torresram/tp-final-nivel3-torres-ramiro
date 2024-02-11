using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
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
            ConfirmarEliminar = false;
            articuloElegido = (Articulo)Session["artSeleccion"];
            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio marca = new MarcaNegocio();
                    CategoriaNegocio categoria = new CategoriaNegocio();

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

                if(txtPrecio.Text.Length == 0)
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

                string checkCadena = txtPrecio.Text.Replace('.', ',');

                if(soloNumeros(checkCadena))
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
                    nuevo.Id = int.Parse(id);
                    negocio.modificarSP(nuevo);
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
                if (!(char.IsNumber(caracter) || caracter == ','))
                {
                    return false;
                }
            }
            return true;
        }
    }
}