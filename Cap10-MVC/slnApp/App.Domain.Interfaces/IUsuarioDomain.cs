﻿using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IUsuarioDomain
    {
        bool LoginUsuario(Usuario Entity);
    }
}
