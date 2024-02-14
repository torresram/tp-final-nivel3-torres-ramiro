using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public AccesoDatos datos = new AccesoDatos();
        public int nuevoUsuario(Usuario nuevo)
        {
            try
            {
                datos.setProcedimiento("nuevoUsuario");
                datos.setParametro("@email", nuevo.Email);
                datos.setParametro("@pass", nuevo.Password);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void actualizarImg(Usuario usuario)
        {
            try
            {
                datos.setConsulta("UPDATE USERS SET urlImagenPerfil = @urlImg WHERE Id = @id");
                datos.setParametro("@id", usuario.Id);
                datos.setParametro("@urlImg", usuario.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void actualizarPass(Usuario usuario)
        {
            try
            {
                datos.setConsulta("UPDATE USERS SET pass = @pass WHERE Id = @id");
                datos.setParametro("@id", usuario.Id);
                datos.setParametro("@pass", usuario.Password);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool login(Usuario usuario)
        {
            try
            {
                datos.setConsulta("SELECT Id, email, pass,nombre,apellido, urlImagenPerfil, admin FROM USERS WHERE email=@email and pass = @pass");
                datos.setParametro("@pass", usuario.Password);
                datos.setParametro("@email", usuario.Email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.EsAdmin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull)) 
                    {
                        usuario.UrlImagen = (string)datos.Lector["urlImagenPerfil"];
                    }
                    if (!(datos.Lector["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    }
                    if (!(datos.Lector["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    }
                    return true;
                }                
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
