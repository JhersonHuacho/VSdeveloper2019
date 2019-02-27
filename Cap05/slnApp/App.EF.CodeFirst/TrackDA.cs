using App.EF.Entities.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EF.CodeFirst
{
    public class TrackDA
    {
        private ChinookModel _context;

        public TrackDA()
        {
            _context = new ChinookModel();
        }

        public IEnumerable<TrackConsultas> GetTrackByName(string name)
        {
            //name = $"%{name}%" ?? "%";
            name = !string.IsNullOrWhiteSpace(name) ? $"%{name}%" : "%";
            return _context.Database.SqlQuery<TrackConsultas>("usp_GetTrack @name", new SqlParameter("@name", name)).ToList();
        }

        public IEnumerable<TrackConsultas> GetTrackByNameLinQ(string name)
        {
            name = !string.IsNullOrWhiteSpace(name) ? $"%{name}%" : "%";

            var q = from a in _context.Track
                    join b in _context.Album on a.AlbumId equals b.AlbumId
                    where a.Name.Contains(name)
                    select new TrackConsultas
                    {
                        TrackId = a.TrackId,
                        TrackName = a.Name,
                        AlbumId = a.AlbumId,
                        Title = b.Title
                    };

            return q.ToList();
        }
    }
}
