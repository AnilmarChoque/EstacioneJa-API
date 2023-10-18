using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacioneJa.Models;

namespace Estacione_já.Models
{
    public class Sensor
    {
        public long Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double Vaga { get; set; }
        public List<Vaga> Vagas { get; set; }  
        
        /*create table sensor (id_sensor numeric(6) constraint sensor_id_pk primary key,
        latitude varchar(40) constraint sensor_latitude_nn not null,
        longitude varchar(40) constraint sensor_longitude_nn not null,
        vaga_sensor numeric(6) constraint sensor_vaga_nn not null);*/
    }
}