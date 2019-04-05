using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.Entities.Queries;
using App.Services.WCF.Interfaces;
using App.Services.WCF.Interfaces.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace App.Services.WCF.Reportes
{
    public partial class ReporteServices : IReporteServices
    {
        public IEnumerable<TrackAll> GetTrackAll(string nombre)
        {
            ITrackDomain domain = new TrackDomain();
            return domain.GetTrackAll(nombre);
        }
    }
}
