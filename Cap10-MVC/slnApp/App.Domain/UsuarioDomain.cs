using App.DataAccess.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class UsuarioDomain : IUsuarioDomain
    {
        public bool LoginUsuario(Usuario Entity)
        {
            var result = false;

            try
            {
                using (var uw = new AppUnitOfWork())
                {                    
                    result = uw.UsuarioRepository.LoginUsuario(Entity);
                }

                //result = true;
            }
            catch (Exception ex)
            {
                // agregar a un log de errores
            }
            return result;
        }
    }
}
