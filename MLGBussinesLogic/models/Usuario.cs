using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MLGBussinesLogic.models.common;

namespace MLGBussinesLogic.models
{
    public class UsuarioModelo : BaseEntity
    {
        [Required]
        [StringLength(50)]

        public string UsuarioNombre { get; set; }
        [Required]
        public int status { get; set; }
        [Required]
        public string password { get; set; }
    }
}
