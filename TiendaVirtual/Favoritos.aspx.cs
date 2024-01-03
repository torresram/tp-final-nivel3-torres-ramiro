using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> favoritos = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            favoritos = negocio.listarSP();
            Session.Add("listaFavs", favoritos);

            if(!IsPostBack)
            {
                repFavoritos.DataSource = Session["listaFavs"];
                repFavoritos.DataBind();
            }
        }
    }
}