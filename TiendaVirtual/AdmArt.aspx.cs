using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class AdmArt : System.Web.UI.Page
    {
        public bool ConfirmarEliminar { get; set; }
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarEliminar = false;
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
                if(id != "" && !IsPostBack )
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

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenURL = txtImgUrl.Text;

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
    }
}