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
    public class UsuarioBL : IUsuarioBL
    { 
        readonly IUsuarioDA UsuarioDA;

        public UsuarioBL(IConfiguration configuration) 
        {
            UsuarioDA = new UsuarioDA(configuration);
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            return UsuarioDA.ListarUsuario();
        }

        public Usuario ListarUsuarioID(int ID)
        {
            return UsuarioDA.ListarUsuarioID(ID);
        }

        public int InsertarUsuario(Usuario usuario) 
        {
            return UsuarioDA.InsertarUsuario(usuario);
        }

        public int ActualizarUsuario(Usuario usuario)
        {
            return UsuarioDA.ActualizarUsuario(usuario);
        }

        public int EliminarUsuario(int ID)
        {
            return UsuarioDA.EliminarUsuario(ID);
        }

    }
}
