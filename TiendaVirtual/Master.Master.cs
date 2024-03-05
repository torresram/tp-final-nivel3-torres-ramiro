﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Master : System.Web.UI.MasterPage
    {
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["usuario"];
            imgAvatar.ImageUrl = ResolveUrl("~/Images/userDefault.png");

            if (usuario != null)
            {
                if (!string.IsNullOrEmpty(usuario.Nombre))
                {
                    lblUsuario.Text = "Hola, " + usuario.Nombre;
                }
                else
                {
                    lblUsuario.Text = usuario.Email;
                }
                imgAvatar.ImageUrl = "~/Images/userImg/" + usuario.UrlImagen;
            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}