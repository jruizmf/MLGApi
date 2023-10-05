using MLGBussinesLogic.models;
using MLGBussinesLogic.models.common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLGBussinesLogic
{
    public class ClienteArticuloModelo : BaseEntity
    {
        [ForeignKey("Cliente")]
        public Guid ClienteId { get; set; }
        public ClienteModelo Cliente { get; set; }
        [ForeignKey("Articulo")]
        public Guid ArticuloId { get; set; }
        public ArticuloModelo Articulo { get; set; }
        public DateTime fecha { get; set; }
    }
}
