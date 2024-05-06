using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSoftNet.Models
{
    public class UsuarioDet
    {
        public int cod_empresa { get; set; }
        public int cod_usuario { get; set; }
        public string? var_cargo { get; set; }
        public string? var_correo { get; set; }
        public int int_estado { get; set; }
        public string? var_nom_imagen { get; set; }
        public int int_flg_eliminado { get; set; }
        public string? fec_registro { get; set; }
        public string? fec_modificacion { get; set; }
    }
}
