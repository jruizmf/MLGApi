using MLGBussinesLogic.models.common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLGBussinesLogic
{
    public class TiendaArticuloModelo : BaseEntity
    {
        [ForeignKey("Tienda")]
        public Guid TiendaId { get; set; }
        public TiendaModelo Tienda { get; set; }
        [ForeignKey("Articulo")]
        public Guid ArticuloId { get; set; }
        public ArticuloModelo Articulo { get; set; }
        public DateTime fecha { get; set; }
    }
}
