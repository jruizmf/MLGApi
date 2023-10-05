using MLGDataAccessLayer.models;
using MLGDataAccessLayer.models.common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLGDataAccessLayer.models
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
