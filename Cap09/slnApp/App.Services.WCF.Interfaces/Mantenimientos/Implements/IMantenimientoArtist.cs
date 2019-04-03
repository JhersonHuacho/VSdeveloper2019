using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.WCF.Interfaces
{
    public partial interface IMantenimientoServices
    {
        [OperationContract]
        IEnumerable<Artist> GetArtistAll(string nombre);

        [OperationContract]
        bool SaveArtist(Artist Entity);

        [OperationContract]
        Artist GetArtist(int id);
    }
}
