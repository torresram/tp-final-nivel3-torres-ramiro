using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Detalle : System.Web.UI.Page
    {
        public Articulo articulo = new Articulo();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            int id;
            string idObt = ""; //id obtenido del querystring

            if (Request.QueryString["id"] != null)
            {
                idObt = Request.QueryString["id"].ToString();
                if (idObt == "none")
                {
                    nombreItem.InnerText = "Artículo no disponible";
                }

                try
                {
                    id = int.Parse(idObt);
                    articulo = negocio.getArticulo(id);
                }
                catch (Exception ex)
                {
                    nombreItem.InnerText = "Artículo no disponible";
                    Session.Add("error", ex.ToString());
                }

                detalleArticulo.DataBind();
            }
            else
            {
                nombreItem.InnerText = "Artículo no disponible";
            }
        }
    }
}