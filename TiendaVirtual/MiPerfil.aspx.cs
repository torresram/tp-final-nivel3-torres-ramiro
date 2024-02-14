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
    public partial class MiPerfil : System.Web.UI.Page
    {
        public bool adminOk { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;

                        if (!string.IsNullOrEmpty(usuario.UrlImagen))
                        {
                            imgUsuario.Src = "~/Images/userImg/" + usuario.UrlImagen;
                        }

                        usuario.EsAdmin = true ? adminOk == true : adminOk == false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnPerfilImg_Click(object sender, EventArgs e)
        {
            cambiarImgDiv.Style.Remove("display");
            btnPerfilImg.Enabled = false;
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
                Usuario usuario = (Usuario)Session["usuario"];

                if (actualPass != usuario.Password)
                {
                    actualPassMensajes.Style.Remove("display");
                    actualPassMensajes.InnerHtml = "La contraseña no es correcta";
                    txtPassActual.Style.Add("border-color", "red");
                    txtPassActual.BorderWidth = 1;
                    txtPassActual.Focus();
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
                    nuevoPassMensajes.Style.Remove("display");
                    nuevoPassMensajes.InnerHtml = "Las contraseñas no coinciden";
                    txtPassCheck.Style.Add("border-color", "red");
                    txtPassCheck.BorderWidth = 1;
                    txtPassCheck.Focus();
                    errorCont++;
                }
                else
                {
                    nuevoPassMensajes.Style.Add("display", "none");
                    txtPassCheck.Style.Add("border-color", "#dee2e6");
                    txtPassCheck.BorderWidth = 0;
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
            btnCambiarPass.Enabled = true;
        }

        protected void btnOkPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];

                if (fluImgPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/userImg/");
                    fluImgPerfil.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagen = "perfil-" + usuario.Id + ".jpg";
                    negocio.actualizarImg(usuario);
                    imgUsuario.Src = usuario.UrlImagen;
                }

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/userImg/" + usuario.UrlImagen;
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
        }
    }
}