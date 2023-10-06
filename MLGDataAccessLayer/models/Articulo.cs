using MLGDataAccessLayer.models.common;
using System;
using System.ComponentModel.DataAnnotations;

namespace MLGDataAccessLayer.models
{
    public class ArticuloModelo : BaseEntity
    {
        [Required]
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }
}
