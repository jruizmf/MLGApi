using System;
using System.Collections.Generic;
using System.Text;

namespace MLGBussinesLogic.interfaces
{
    public interface IArticulo
    {
        List<ArticuloModelo> getAll();
        ArticuloModelo getOne(Guid Id);
        ArticuloModelo Add();
        ArticuloModelo Update();
        Guid Delete();
    }
}
