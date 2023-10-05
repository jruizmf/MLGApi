using System;
using System.ComponentModel.DataAnnotations.Schema;
using MLGBussinesLogic.models.common;

namespace MLGBussinesLogic.models
{
    public class ClienteModelo : BaseEntity
    {
        public string Nombre { get; set; }
        public int Apellidos { get; set; }
        public string Direccion { get; set; }
    }
}
