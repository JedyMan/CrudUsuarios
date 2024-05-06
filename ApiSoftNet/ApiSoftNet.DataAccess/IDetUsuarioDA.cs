using ApiSoftNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSoftNet.DataAccess
{
    public interface IDetUsuarioDA
    {
        IEnumerable<UsuarioDet> ListarDetalleUsuario();

        int InsertarDetalleUsuario(UsuarioDet usuario);
    }
}
