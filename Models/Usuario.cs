using System.ComponentModel.DataAnnotations.Schema;
using Cadastro.Models.Enuns;

namespace Cadastro.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[]? Foto { get; set; }
        [NotMapped]
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public PreferenciaEnum Preferencia { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
        public byte[]? Senha_hash { get; set; }
        public byte[]? Senha_salt { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public List<Estacionamento> Estacionamentos { get; set; }
        public List<UsuarioVaga> UsuarioVagas  { get; set; }

    }
}

/*create table usuario (id_usuario numeric(6) constraint usuario_id_pk primary key,
nome_usuario varchar(60) constraint usuario_nome_nn not null,
email_usuario varchar(40) constraint usuario_email_nn not null,
cpf_usuario char(11) constraint usuario_cpf_nn not null,
preferencia_vaga smallint constraint usuario_preferencia_nn not null,
tipo_usuario varchar(20) constraint usuario_tipo_nn not null,
senha_hash varchar(40) constraint usuario_hash_nn not null,
senha_salt varchar(40) constraint usuario_salt_nn not null,
latitude varchar(40) constraint usuario_latitude_nn not null,
longitude varchar(40) constraint usuario_longitude_nn not null);*/