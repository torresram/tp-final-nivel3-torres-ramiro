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
        public List<Favoritos> misFavoritos(int id)
        {
            List<Favoritos> favoritos = new List<Favoritos>();
            datos.setProcedimiento("storedFavoritos");
            datos.setParametro("@id", id);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Favoritos aux = new Favoritos();

                aux.Id = (int)datos.Lector["Id"];
                aux.Usuario = new Usuario();
                aux.Usuario.Email = (string)datos.Lector["Usuario"];
                aux.Articulo = new Articulo();
                aux.Articulo.Nombre = (string)datos.Lector["Articulo"];

                favoritos.Add(aux);
            }

            return favoritos;
        }
    }
}
