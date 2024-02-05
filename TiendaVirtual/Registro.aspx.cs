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

                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;
                usuario.Id = negocio.nuevoUsuario(usuario);
                Session.Add("usuario", usuario);

                emailService.nuevoCorreo(usuario.Email, "Bienvenido a la Tienda Virtual", "Hola te damos la bienvenida a la mejor tienda del universo conocido");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error",ex.ToString());
            }
        }
    }
}