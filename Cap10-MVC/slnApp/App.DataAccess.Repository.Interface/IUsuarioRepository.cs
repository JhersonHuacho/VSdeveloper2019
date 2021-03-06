﻿using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository.Interface
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        bool LoginUsuario(Usuario Entity);
        bool LoginUsuarioDos(string login, string password);
    }
}
