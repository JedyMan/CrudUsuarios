using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSoftNet.Models
{
    public class Usuario
    {
        public int cod_usuario { get; set; }
        public int tip_documento { get; set; }
        public string? var_doc_identidad { get; set; }
        public string? var_apellidos { get; set; }
        public string? var_nombres { get; set; }
        public string? var_password { get; set; }
        public string? var_num_telefono { get; set; }
        public int int_flg_eliminado { get; set; }
        public string? fec_registro { get; set; }
        public string? fec_modificacion { get; set; }
    }
}
