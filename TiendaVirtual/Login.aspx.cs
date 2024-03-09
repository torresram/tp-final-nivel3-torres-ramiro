using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();

            string user = txtEmail.Text;
            string pass = txtPassword.Text;
            int contError = 0;

            try
            {
                if(user.Length == 0)
                {
                    checkError(0);
                    contError++;
                }

                if(pass.Length == 0)
                {
                    checkError(1);
                    contError++;
                }

                if (contError > 0)
                {
                    return;
                }

                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;

                if (negocio.login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos...");
                    Response.Redirect("Error.aspx", false );
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false );
            }
        }
        private void checkError(int error)
        {
            switch (error)
            {
                case 0:
                    emailMensajes.InnerHtml = "Debes completar este campo";
                    emailMensajes.Style.Remove("display");
                    txtEmail.BorderWidth = 1;
                    txtEmail.Style.Add("border-color", "red");
                    txtEmail.Focus();
                    break;
                case 1:
                    passMensajes.InnerHtml = "Debes completar este campo";
                    passMensajes.Style.Remove("display");
                    txtPassword.BorderWidth = 1;
                    txtPassword.Style.Add("border-color", "red");
                    txtPassword.Focus();
                    break;
            }
        }
    }
}