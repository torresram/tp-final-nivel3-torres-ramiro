using System;
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

            if(filtro.Count == 0)
            {
                mensajeNoEncontrado.Style.Add("display","block");
            }

            repRepetidor.DataSource = filtro;
            repRepetidor.DataBind();            
        }

        protected void repRepetidor_ItemCommand(object source, RepeaterCommandEventArgs e)
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
    }
}

