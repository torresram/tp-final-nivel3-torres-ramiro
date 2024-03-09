using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Detalle : System.Web.UI.Page
    {
        public Articulo articulo = new Articulo();
        string urlAnterior;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            ArticuloNegocio negocio = new ArticuloNegocio();
            FavoritosNegocio favorito = new FavoritosNegocio();

            if (!IsPostBack)
            {
                Session.Add("urlAnterior", Request.UrlReferrer);
            }

            if (Request.QueryString["id"] != null)
            {
                string idObtenido = Request.QueryString["id"].ToString();
                if (idObtenido == "none")
                {
                    nombreItem.InnerText = "Artículo no disponible";
                    btnAFavoritos.Enabled = false;
                    btnAlCarrito.Enabled = false;
                }
                try
                {
                    int idArt = int.Parse(idObtenido);
                    articulo = negocio.getArticulo(idArt);
                }
                catch (Exception)
                {
                    nombreItem.InnerText = "Artículo no disponible";
                    btnAFavoritos.Enabled = false;
                    btnAlCarrito.Enabled = false;
                }

                detalleArticulo.DataBind();

                if (user != null)
                {
                    int idUser = user.Id;
                    int idArt = articulo.Id;

                    if (favorito.esFav(idUser, idArt))
                    {
                        btnAFavoritos.Text = "Quitar de favoritos";
                        btnAFavoritos.CssClass = "btn btn-outline-danger btn-sm";
                    }
                }
            }
            else
            {
                nombreItem.InnerText = "Artículo no disponible";
                btnAFavoritos.Enabled = false;
                btnAlCarrito.Enabled = false;
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            urlAnterior = Session["urlAnterior"] != null ? Session["urlAnterior"].ToString() : "Default.aspx";
            Response.Redirect(urlAnterior);
        }
        protected void btnAlCarrito_Click(object sender, EventArgs e)
        {

        }
        protected void btnAFavoritos_Click(object sender, EventArgs e)
        {
            FavoritosNegocio favorito = new FavoritosNegocio();
            Usuario user = (Usuario)Session["usuario"];

            if (user != null)
            {
                int idUser = user.Id;
                int idArticulo = articulo.Id;

                if (btnAFavoritos.Text == "Quitar de favoritos")
                {
                    btnAFavoritos.Text = "Añadir a favoritos";
                    btnAFavoritos.CssClass = "btn btn-success btn-sm";
                    favorito.quitarFav(idUser, idArticulo);
                }
                else
                {
                    btnAFavoritos.Text = "Quitar de favoritos";
                    btnAFavoritos.CssClass = "btn btn-outline-danger btn-sm";
                    favorito.agregarFav(idUser, idArticulo);
                }
            }
            else
            {
                toast.Style.Add("display", "block");
            }
        }
        protected void btnCerrarNotificacion_Click(object sender, EventArgs e)
        {
            toast.Style.Remove("display");
        }
    }
}