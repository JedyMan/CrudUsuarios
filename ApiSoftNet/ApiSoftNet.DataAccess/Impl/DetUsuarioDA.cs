using ApiSoftNet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSoftNet.DataAccess.Impl
{
    public class DetUsuarioDA : IDetUsuarioDA
    {
        readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public DetUsuarioDA(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Conexion");
        }

        public IEnumerable<UsuarioDet> ListarDetalleUsuario()
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand("SP_Listar_Detalle_Usuarios", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<UsuarioDet> result = new List<UsuarioDet>();
                        while (reader.Read())
                        {
                            UsuarioDet item = new UsuarioDet();
                            {
                                item.cod_empresa = Convert.ToInt32(reader["cod_usuario"]);
                                item.cod_usuario= Convert.ToInt32(reader["tip_documento"]);
                                item.var_cargo = reader["var_doc_identidad"].ToString();
                                item.var_correo = reader["var_apellidos"].ToString();
                                item.int_estado = Convert.ToInt32(reader["int_estado"]);
                                item.var_nom_imagen = reader["var_password"].ToString();
                                item.int_flg_eliminado = Convert.ToInt32(reader["int_flg_eliminado"]);
                                item.fec_registro = reader["fec_registro"].ToString();
                                item.fec_modificacion = reader["fec_modificacion"].ToString();
                            }
                            result.Add(item);
                        }
                        return result;
                    }
                }
            }
        }

        public int InsertarDetalleUsuario(UsuarioDet usuario)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_Registra_Detalle_Usuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cod_empresa", usuario.cod_empresa);
                    command.Parameters.AddWithValue("@cod_usuario", usuario.cod_usuario);
                    command.Parameters.AddWithValue("@cargo", usuario.var_cargo);
                    command.Parameters.AddWithValue("@nombre_imagen", usuario.var_nom_imagen);

                    SqlParameter outputParameter = new SqlParameter
                    {
                        ParameterName = "@cod_usuario",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputParameter);
                    command.ExecuteNonQuery();
                    return Convert.ToInt32(outputParameter.Value);
                }
            }
        }
    }
}
