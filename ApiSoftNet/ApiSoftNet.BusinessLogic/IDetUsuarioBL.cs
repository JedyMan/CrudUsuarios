using ApiSoftNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSoftNet.BusinessLogic
{
    public interface IDetUsuarioBL
    {
        IEnumerable<UsuarioDet> ListarDetalleUsuario();

        int InsertarDetalleUsuario(UsuarioDet usuario);
    }
}
