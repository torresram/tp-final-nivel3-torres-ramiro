using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); 
            }
        }

        public void agregarMarca(string nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO MARCAS (Descripcion) VALUES (@Marca)");
                datos.setParametro("@Marca", nueva);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool validarMarca(string marca)
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                for (int x = 0; x < lista.Count(); x++)
                {
                    string marcaExistente = lista[x].Descripcion;

                    if (marcaExistente.ToUpper() == marca.ToUpper())
                        return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}
        }
    }
}
