using MLGDataAccessLayer.models.common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLGDataAccessLayer.models
{
    public class TiendaModelo : BaseEntity
    {
        [Required]
        public string Sucursal { get; set; }
		public string Direccion { get; set; }
	}
}
