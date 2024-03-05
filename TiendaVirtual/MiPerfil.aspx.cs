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
    public partial class MiPerfil : System.Web.UI.Page
    {
        public bool adminOk { get; set; }
        Usuario usuario = new Usuario();
        string nombreOriginal;
        string apellidoOriginal;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        adminOk = usuario.EsAdmin;
                        lblId.InnerHtml = "ID " + usuario.Id.ToString();

                        if (!string.IsNullOrEmpty(usuario.UrlImagen))
                        {
                            imgUsuario.Src = "~/Images/userImg/" + usuario.UrlImagen;
                        }
                    }
                    esAdminDiv.Visible = adminOk;
                }
                usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    nombreOriginal = usuario.Nombre;
                    apellidoOriginal = usuario.Apellido;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnCambiarPass_Click(object sender, EventArgs e)
        {
            cambiarPassDiv.Style.Remove("display");
            btnCambiarPass.Enabled = false;
        }
        protected void btnGuardarPass_Click(object sender, EventArgs e)
        {
            string actualPass = txtPassActual.Text;
            string nuevoPass = txtPassNueva.Text;
            string checkPass = txtPassCheck.Text;
            int errorCont = 0;

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                usuario = (Usuario)Session["usuario"];

                if (actualPass != usuario.Password)
                {
                    passError(0);
                    errorCont++;
                }
                else
                {
                    actualPassMensajes.Style.Add("display", "none");
                    txtPassActual.Style.Add("border-color", "#dee2e6");
                    txtPassActual.BorderWidth = 1;
                }

                if (nuevoPass != checkPass)
                {
                    passError(1);
                    errorCont++;
                }
                else
                {
                    nuevoPassMensajes.Style.Add("display", "none");
                    txtPassCheck.Style.Add("border-color", "#dee2e6");
                    txtPassCheck.BorderWidth = 1;
                }

                if (errorCont > 0)
                {
                    return;
                }
                else
                {
                    usuario.Password = checkPass;
                    negocio.actualizarPass(usuario);
                    cambiarPassDiv.Style.Add("display", "none");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnCancelarPass_Click(object sender, EventArgs e)
        {
            txtPassActual.Text = string.Empty;
            txtPassNueva.Text = string.Empty;
            txtPassCheck.Text = string.Empty;
            cambiarPassDiv.Style.Add("display", "none");
            txtPassActual.Style.Add("border-color", "#dee2e6");
            txtPassNueva.Style.Add("border-color", "#dee2e6");
            txtPassCheck.Style.Add("border-color", "#dee2e6");
            actualPassMensajes.Style.Add("display", "none");
            nuevoPassMensajes.Style.Add("display", "none");
            btnCambiarPass.Enabled = true;
        }
        protected void btnPerfilImg_Click(object sender, EventArgs e)
        {
            cambiarImgDiv.Style.Remove("display");
            btnPerfilImg.Enabled = false;
            usuario = (Usuario)Session["usuario"];

            if (usuario.EsAdmin)
            {
                esAdminDiv.Visible = false;
            }
        }
        protected void btnOkPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                usuario = (Usuario)Session["usuario"];

                if (fluImgPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/userImg/");
                    fluImgPerfil.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagen = "perfil-" + usuario.Id + ".jpg";
                    negocio.actualizarImg(usuario);
                    imgUsuario.Src = "~/Images/userImg/" + usuario.UrlImagen;
                }

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/userImg/" + usuario.UrlImagen;

                if (usuario.EsAdmin)
                {
                    esAdminDiv.Visible = true;
                }
                cambiarImgDiv.Style.Add("display", "none");
                btnPerfilImg.Enabled = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnCancelarPerfil_Click(object sender, EventArgs e)
        {
            cambiarImgDiv.Style.Add("display", "none");
            btnPerfilImg.Enabled = true;
            usuario = (Usuario)Session["usuario"];

            if (usuario.EsAdmin)
            {
                esAdminDiv.Visible = true;
            }
        }
        protected void passError(int error)
        {
            switch (error)
            {
                case 0:
                    actualPassMensajes.Style.Remove("display");
                    actualPassMensajes.InnerHtml = "La contraseña no es correcta";
                    actualPassMensajes.Style.Add("color", "red");
                    txtPassActual.Style.Add("border-color", "red");
                    txtPassActual.BorderWidth = 1;
                    txtPassActual.Focus();
                    break;
                case 1:
                    nuevoPassMensajes.Style.Remove("display");
                    nuevoPassMensajes.InnerHtml = "Las contraseñas no coinciden";
                    nuevoPassMensajes.Style.Add("color", "red");
                    txtPassCheck.Style.Add("border-color", "red");
                    txtPassCheck.BorderWidth = 1;
                    txtPassCheck.Focus();
                    break;
                default:
                    break;
            }
        }
        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            usuario = (Usuario)Session["usuario"];

            if (nombreOriginal != txtNombre.Text || apellidoOriginal != txtApellido.Text)
            {
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                negocio.actualizarDatos(usuario);
                liveToast.Style.Add("display", "block");
            }
        }

        protected void btnCerrarNotificacion_Click(object sender, EventArgs e)
        {
            liveToast.Style.Remove("display");
        }
    }
}