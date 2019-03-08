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
        public IEnumerable<Artist> GetArtists()
        {
            IEnumerable<Artist> result = new List<Artist>();

            using (AppUnitOfWork uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetAll();
            }

            return result;
        }
    }
}
