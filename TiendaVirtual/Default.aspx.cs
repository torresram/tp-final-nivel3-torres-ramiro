using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;
using dominio;
using negocio;
using System.Net;

namespace TiendaVirtual
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> articulos = new List<Articulo>();
        bool favEstado;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            articulos = negocio.listarSP();
            Session.Add("listaArticulos", articulos);

            if (!IsPostBack)
            {
                repRepetidor.DataSource = Session["listaArticulos"];
                repRepetidor.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            mensajeNoEncontrado.Style.Add("display", "none");

            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> filtro = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(txtBuscar.Text.ToUpper()));

            if (filtro.Count == 0)
            {
                mensajeNoEncontrado.Style.Add("display", "block");
            }

            repRepetidor.DataSource = filtro;
            repRepetidor.DataBind();
            txtBuscar.Focus();
        }

        protected void repRepetidor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Info")
            {
                string id = e.CommandArgument.ToString();
                try
                {
                    Response.Redirect("Detalle.aspx?id=" + id, false);
                }
                catch (Exception)
                {
                    Response.Redirect("Detalle.aspx?id=none", false);
                }
            }

            if (e.CommandName == "Fav")
            {
                Usuario user = (Usuario)Session["usuario"];
                FavoritosNegocio favorito = new FavoritosNegocio();

                if (user != null)
                {
                    int idUser = user.Id;
                    int idArt = int.Parse(e.CommandArgument.ToString());

                    try
                    {
                        if (favEstado)
                        {
                            favorito.quitarFav(idUser, idArt);
                        }
                        else
                        {
                            favorito.agregarFav(idUser, idArt);
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        protected void btnAFavorito_Click(object sender, ImageClickEventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];

            if (user != null)
            {
                ImageButton btn = (ImageButton)sender;

                //string noEsFav = "https://www.iconninja.com/files/561/918/415/heart-icon.png";
                //string esFav = "https://icons.iconarchive.com/icons/paomedia/small-n-flat/128/heart-icon.png";
                string noEsFav = ResolveUrl("~/Images/heart.png");
                string esFav = ResolveUrl("~/Images/heartFill.png");

                if (btn.ImageUrl == noEsFav)
                {
                    favEstado = false;
                    btn.ImageUrl = esFav;
                }
                else
                {
                    favEstado = true;
                    btn.ImageUrl = noEsFav;
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

