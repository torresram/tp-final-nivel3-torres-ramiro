using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Articulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Seguridad.esAdmin(Session["usuario"]))
            //{
            //    Session.Add("error", "Se requiere ser administrador para acceder a esta pantalla");
            //    Response.Redirect("Error.aspx");
            //}

            FiltroAvanzado = false;
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listarSP());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("AdmArt.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdmArt.aspx", false);
        }
    }
}