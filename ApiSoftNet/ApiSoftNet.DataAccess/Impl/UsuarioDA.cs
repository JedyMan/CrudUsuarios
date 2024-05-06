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
    public class UsuarioDA : IUsuarioDA
    {
        readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public UsuarioDA(IConfiguration configuration) 
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Conexion");
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand("SP_Listar_Usuarios", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Usuario> result = new List<Usuario>();
                        while (reader.Read())
                        {
                            Usuario item = new Usuario();
                            {
                                item.cod_usuario = Convert.ToInt32(reader["cod_usuario"]);
                                item.tip_documento = Convert.ToInt32(reader["tip_documento"]);
                                item.var_doc_identidad = reader["var_doc_identidad"].ToString();
                                item.var_apellidos = reader["var_apellidos"].ToString();
                                item.var_nombres = reader["var_nombres"].ToString();
                                item.var_password = reader["var_password"].ToString();
                                item.var_num_telefono = reader["var_num_telefono"].ToString();
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

        public Usuario ListarUsuarioID(int Id)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@cod_usuario", SqlDbType.Int) { Value = Id },
            };

            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand("SP_Listar_Usuario_Id", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Usuario> result = new List<Usuario>();
                        while (reader.Read())
                        {
                            Usuario item = new Usuario();
                            {
                                item.cod_usuario = Convert.ToInt32(reader["cod_usuario"]);
                                item.tip_documento = Convert.ToInt32(reader["tip_documento"]);
                                item.var_doc_identidad = reader["var_doc_identidad"].ToString();
                                item.var_apellidos = reader["var_apellidos"].ToString();
                                item.var_nombres = reader["var_nombres"].ToString();
                                item.var_password = reader["var_password"].ToString();
                                item.var_num_telefono = reader["var_num_telefono"].ToString();
                                item.int_flg_eliminado = Convert.ToInt32(reader["int_flg_eliminado"]);
                                item.fec_registro = reader["fec_registro"].ToString();
                                item.fec_modificacion = reader["fec_modificacion"].ToString();
                            }
                            return item;
                        }
                        return null;
                    }
                }
            }
        }

        public int InsertarUsuario(Usuario usuario) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_Registra_Usuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tip_documento", usuario.tip_documento);
                    command.Parameters.AddWithValue("@nro_documento", usuario.var_doc_identidad);
                    command.Parameters.AddWithValue("@apellidos", usuario.var_apellidos);
                    command.Parameters.AddWithValue("@nombres", usuario.var_nombres);
                    command.Parameters.AddWithValue("@clave", usuario.var_password);
                    command.Parameters.AddWithValue("@telefono", usuario.var_num_telefono);

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

        public int ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_Actualizar_Usuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@cod_usuario", usuario.cod_usuario);
                    command.Parameters.AddWithValue("@tip_documento", usuario.tip_documento);
                    command.Parameters.AddWithValue("@nro_documento", usuario.var_doc_identidad);
                    command.Parameters.AddWithValue("@apellidos", usuario.var_apellidos);
                    command.Parameters.AddWithValue("@nombres", usuario.var_nombres);
                    command.Parameters.AddWithValue("@clave", usuario.var_password);
                    command.Parameters.AddWithValue("@telefono", usuario.var_num_telefono);

                    SqlParameter outputParameter = new SqlParameter
                    {
                        ParameterName = "@cod_usuarios",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParameter);

                    command.ExecuteNonQuery();

                    return Convert.ToInt32(outputParameter.Value);
                }
            }
        }

        public int EliminarUsuario(int Id)
        {
            int resul = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_Eliminar_Usuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cod_usuario", Id);
                    resul = command.ExecuteNonQuery();
                    return resul;
                }
            }
        }
    }
}
