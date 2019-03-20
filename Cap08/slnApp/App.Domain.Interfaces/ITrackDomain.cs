using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ITrackDomain
    {
        IEnumerable<TrackAll> GetTrackAll(string nombre);
    }
}
