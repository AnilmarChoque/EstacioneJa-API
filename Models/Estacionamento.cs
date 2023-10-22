using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cadastro.Models;

namespace Cadastro.Models
{
    public class Estacionamento
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string? Url { get; set; }
        [JsonIgnore]
        public Usuario Usuario { get; set;}
        public long UsuarioId { get; set;}
        public List<Vaga> Vagas { get; set; }
        
        /*create table estacionamento (id_estacionamento numeric(6) constraint estacionamento_id_pk primary key,
        nome_estacionamento varchar(40) constraint estacionamento_nome_nn not null,
        url_rede_sensores varchar(40) constraint estacionamento_url_nn not null,
        id_usuario numeric(6) constraint estacionamento_usuario_fk references usuario);*/
    }
}