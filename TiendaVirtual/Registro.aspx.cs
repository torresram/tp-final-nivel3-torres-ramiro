using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TiendaVirtual
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                string email = txtEmail.Text;
                string pass = txtPassword.Text;

                if(!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(pass))
                {
                    usuario.Email = txtEmail.Text;
                    usuario.Password = txtPassword.Text;
                    usuario.Id = negocio.nuevoUsuario(usuario);
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    registroMensajes.Style.Remove("display");
                    registroMensajes.Style.Add("color", "red");
                    registroMensajes.InnerHtml = "Los campos no pueden ser vacíos";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error",ex.ToString());
            }
        }
    }
}