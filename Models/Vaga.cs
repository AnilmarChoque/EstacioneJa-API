using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cadastro.Models.Enuns;

namespace Cadastro.Models
{
    public class Vaga
    {
        public long Id { get; set;}
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Secao { get; set; }
        public DisponibilidadeEnum Disponibilidade { get; set; }
        public int Andar { get; set; }
        public double Numero { get; set; }
        public PreferenciaEnum Preferencia { get; set; }
        [JsonIgnore]
        public Sensor Sensor { get; set; }
        [JsonIgnore]
        public Estacionamento Estacionamento { get; set; }
        public long EstacionamentoId { get; set; }


        /*create table vaga (id_vaga numeric(6) constraint vaga_id_pk primary key,
        latitude varchar(40) constraint vaga_latitude_nn not null,
        longitude varchar(40) constraint vaga_longitude_nn not null,
        secao_vaga varchar(10) constraint vaga_secao_nn not null,
        disponibilidade_vaga smallint constraint vaga_disponibilidade_nn not null,
        andar_vaga smallint constraint vaga_andar_nn not null,
        numero_vaga numeric(6) constraint vaga_numero_nn not null,
        preferencial_vaga smallint constraint vaga_preferencia_nn not null,
        id_estacionamento numeric(6) constraint vaga_estacionamento_fk references estacionamento);*/
    }
}