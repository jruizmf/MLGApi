using MLGBussinesLogic.models;
using MLGBussinesLogic.models.common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLGBussinesLogic
{
    public class UsuarioClienteModelo : BaseEntity
    {
        [ForeignKey("Cliente")]
        public Guid ClienteId { get; set; }
        public ClienteModelo Cliente { get; set; }
        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public UsuarioModelo Usuario { get; set; }
        public DateTime fecha { get; set; }
    }
}
