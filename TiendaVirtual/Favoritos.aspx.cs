using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> favoritos = new List<Articulo>();
        public bool refresh;
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            FavoritosNegocio negocio = new FavoritosNegocio();
            
            try
            {
                if (usuario != null)
                {
                    int id = usuario.Id;
                    favoritos = negocio.listaFavs(id);
                    Session.Add("listaFavs", favoritos);

                    if(favoritos.Count == 0)
                    {
                        mensajeNoFavs.Style.Remove("display");
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            if (!IsPostBack || refresh == true)
            {
                repFavoritos.DataSource = Session["listaFavs"];
                repFavoritos.DataBind();
            }
        }
        protected void repFavoritos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            FavoritosNegocio favorito = new FavoritosNegocio();

            int idUser = user.Id;
            int idArticulo = int.Parse(e.CommandArgument.ToString());
            try
            {
                if (e.CommandName == "eliminarFav")
                {
                    favorito.quitarFav(idUser, idArticulo);
                    refresh = true;
                    Page_Load(Page, e);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}