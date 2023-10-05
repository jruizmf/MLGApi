using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MLGDataAccessLayer.models.common;

namespace MLGDataAccessLayer.models
{
    public class UsuarioModelo : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string UsuarioNombre { get; set; }
        [Required]
        public int status { get; set; }
        public byte[] password { get; set; }
        public byte[] PasswordSalt { get; set; }

        public UsuarioClienteModelo UsuarioCliente { get; protected set; }



    }
}
