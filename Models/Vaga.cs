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
        public List<UsuarioVaga> UsuarioVagas  { get; set; }
    }
}