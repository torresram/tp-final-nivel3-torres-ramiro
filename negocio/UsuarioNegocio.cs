using System;
using System.Collections.Generic;
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
    }
}
