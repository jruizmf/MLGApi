using MLGBussinesLogic.models.common;
using System;

namespace MLGBussinesLogic
{
    public class ArticuloModelo : BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }
}
