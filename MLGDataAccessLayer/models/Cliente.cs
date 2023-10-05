using System;
using System.ComponentModel.DataAnnotations.Schema;
using MLGDataAccessLayer.models.common;

namespace MLGDataAccessLayer.models
{
    public class ClienteModelo : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
    }
}
