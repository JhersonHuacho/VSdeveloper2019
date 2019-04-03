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
    public class ArtistDomain : IArtistDomain
    {
        public Artist Get(int id)
        {
            Artist result = new Artist();

            using (AppUnitOfWork uw = new AppUnitOfWork())
            {
                //result = uw.ArtistRepository.GetAll();
                result = uw.ArtistRepository.GetById<int>(id);
            }

            return result;
        }

        public IEnumerable<Artist> GetArtists(string nombre)
        {
            IEnumerable<Artist> result = new List<Artist>();

            using (AppUnitOfWork uw = new AppUnitOfWork())
            {
                //result = uw.ArtistRepository.GetAll();
                result = uw.ArtistRepository.GetAll(item => item.Name.Contains(nombre));
            }

            return result;
        }

        public bool SaveArtist(Artist Entity)
        {
            var result = false;

            try
            {
                using (var uw = new AppUnitOfWork())
                {
                    if(Entity.ArtistId > 0)
                    {
                        // editando artista
                        uw.ArtistRepository.Update(Entity);
                    }
                    else
                    {
                        // cuando es nuevo artista
                        uw.ArtistRepository.Add(Entity);
                    }
                    result = uw.Complete() > 0;
                }

                //result = true;
            }
            catch(Exception ex)
            {
                // agregar a un log de errores
            }
            return result;
        }
    }
}
