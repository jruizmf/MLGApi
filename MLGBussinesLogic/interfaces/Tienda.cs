using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MLGBussinesLogic.models;

namespace MLGBussinesLogic.interfaces
{
    public interface ITienda
    {
        List<TiendaModelo> getAll();
        TiendaModelo getOne(Guid Id);
        TiendaModelo Add();
        TiendaModelo Update();
        Guid Delete();
    }
}
