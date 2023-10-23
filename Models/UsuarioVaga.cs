

using Cadastro.Models.Enuns;

namespace Cadastro.Models
{
    public class UsuarioVaga
    {
        public long CodData { get; set; }
        public PagamentoEnum Forma_pagamento { get; set;}
        public DateTime Data { get; set; }
        public string Receptor_pagamento { get; set; }
        public string Emissor_pagamento { get; set; }
        public DateTime Ocupacao_inicial { get; set; }
        public DateTime Ocupacao_final { get; set; }
        public Vaga Vaga { get; set; }
        public long CodVaga { get; set; }
        public Usuario Usuario { get; set; }
        public long CodUsuario { get; set; }

    }
}