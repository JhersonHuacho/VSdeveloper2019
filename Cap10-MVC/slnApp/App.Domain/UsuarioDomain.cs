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
            int total;
            bool result = false;

            try
            {
                using (AppUnitOfWork uw = new AppUnitOfWork())
                {
                    //result = uw.ArtistRepository.GetAll();
                    total = uw.UsuarioRepository.GetAll(item => item.Login.Contains(Entity.Login) && item.Password.Contains(Entity.Password)).Count();
                }

                result = total >= 1 ? true : false;

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
