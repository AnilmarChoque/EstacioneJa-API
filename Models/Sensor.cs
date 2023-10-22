using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cadastro.Models;

namespace Cadastro.Models
{
    public class Sensor
    {
        public long Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Vaga Vaga { get; set; }
        public long VagaId { get; set; }
        
        /*create table sensor (id_sensor numeric(6) constraint sensor_id_pk primary key,
        latitude varchar(40) constraint sensor_latitude_nn not null,
        longitude varchar(40) constraint sensor_longitude_nn not null,
        id_vaga numeric(6) constraint sensor_vaga_fk references vaga,*/
        
    }
}