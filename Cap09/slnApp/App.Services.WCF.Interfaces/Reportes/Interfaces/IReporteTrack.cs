using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.WCF.Interfaces.Reportes
{
    public partial interface IReporteServices
    {
        [OperationContract]
        IEnumerable<TrackAll> GetTrackAll(string trackName);
    }
}
