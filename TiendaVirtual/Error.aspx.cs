using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Error : System.Web.UI.Page
    {
        string urlAnterior;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Add("urlAnterior", Request.UrlReferrer);
            }
            msgError.InnerHtml = Session["error"].ToString();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            urlAnterior = Session["urlAnterior"] != null ? Session["urlAnterior"].ToString() : "Default.aspx";
            Response.Redirect(urlAnterior);
        }
    }
}