using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace TiendaVirtual
{
    public partial class Default : System.Web.UI.Page
    {   
        public List<Articulo> articulos = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            articulos = negocio.listarSP();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = articulos;
                repRepetidor.DataBind();
            }

        }
    }
}