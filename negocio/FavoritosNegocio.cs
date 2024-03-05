using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritosNegocio
    {
        public AccesoDatos datos = new AccesoDatos();
        public List<Articulo> listaFavs(int id)
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setProcedimiento("storedFavs");
                datos.setParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["IdArticulo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenURL = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void agregarFav(int idUser, int idArticulo)
        {
            try
            {
                datos.setConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (@idUser,@idArticulo)");
                datos.setParametro("@idUser", idUser);
                datos.setParametro("@idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void quitarFav(int idUser, int idArticulo)
        {
            try
            {
                datos.setConsulta("DELETE FROM FAVORITOS WHERE IdUser = @idUser and IdArticulo = @idArticulo");
                datos.setParametro("@idUser", idUser);
                datos.setParametro("@idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
