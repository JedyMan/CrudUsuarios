using ApiSoftNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSoftNet.BusinessLogic
{
    public interface IUsuarioBL
    {
        IEnumerable<Usuario> ListarUsuario();

        Usuario ListarUsuarioID(int Id);

        int InsertarUsuario(Usuario usuario);

        int ActualizarUsuario(Usuario usuario);

        int EliminarUsuario(int id);
    }
}
