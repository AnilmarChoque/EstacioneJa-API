using Cadastro.Models;
using EstacioneJa.Models;

namespace Estacione_já.Models
{
    public class UsuarioVaga
    {
        public long Cod_data { get; set; }
        public long Cod_vaga { get; set; }
        public long Cod_usuario { get; set; }
        public string Forma_pagamento { get; set;}
        public DateTime Data { get; set; }
        public string Receptor_pagamento { get; set; }
        public string Emissor_pagamento { get; set; }
        public DateTime Ocupacao_inicial { get; set; }
        public DateTime Ocupacao_final { get; set; }
        public Vaga Vaga { get; set; }
        public Usuario Usuario { get; set; }

    }
}