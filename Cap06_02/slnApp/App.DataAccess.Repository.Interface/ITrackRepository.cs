using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository.Interface
{
    public interface ITrackRepository 
        : IGenericRepository<Track>
    {        
        IEnumerable<TrackAll> GetTracksAll(string nombre);
    }
}
