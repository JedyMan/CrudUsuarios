using ApiSoftNet.DataAccess;
using ApiSoftNet.DataAccess.Impl;
using ApiSoftNet.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSoftNet.BusinessLogic.Impl
{
    public class DetUsuarioBL : IDetUsuarioBL
    {
        readonly IDetUsuarioDA DetUsuarioDA;

        public DetUsuarioBL(IConfiguration configuration)
        {
            DetUsuarioDA = new DetUsuarioDA(configuration);
        }

        public IEnumerable<UsuarioDet> ListarDetalleUsuario()
        {
            return DetUsuarioDA.ListarDetalleUsuario();
        }

        public int InsertarUsuario(UsuarioDet usuario)
        {
            return DetUsuarioDA.InsertarDetalleUsuario(usuario);
        }

    }
}
