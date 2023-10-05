using MLGBussinesLogic.models.common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLGBussinesLogic
{
    public class TiendaModelo : BaseEntity
    {
        [Required]
        public string Sucursal { get; set; }
		public string Direccion { get; set; }
	}
}
