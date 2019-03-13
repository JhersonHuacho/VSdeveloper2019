using App.DataAccess.Repository;
using App.Domain.Interfaces;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class TrackDomain :ITrackDomain
    {
        public IEnumerable<TrackAll> GetTrackAll(string nombre)
        {
            IEnumerable<TrackAll> result = new List<TrackAll>();

            using (AppUnitOfWork uw = new AppUnitOfWork())
            {
                //result = uw.ArtistRepository.GetAll();
                result = uw.TrackRepository.GetTracksAll(nombre);
            }

            return result;
        }
    }
}
