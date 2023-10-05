using MLGBussinesLogic.models.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLGBussinesLogic.interfaces
{
    public interface IAuth
    {
        string Login(AuthDto auth);
    }
}
