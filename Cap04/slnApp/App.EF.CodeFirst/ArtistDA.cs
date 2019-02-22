using App.EF.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EF.CodeFirst
{
    public class ArtistDA
    {
        private ChinookModel _context;

        public ArtistDA()
        {
            _context = new ChinookModel();
        }

        public int Count()
        {
            return _context.Artist.Count();
        }

        public IEnumerable<Artist> GetArtists(string filterByName)
        {
            return _context.Artist.Where(item => item.Name.Contains(filterByName)).ToList();
        }

        public Artist GetArtist(int id)
        {
            return _context.Artist.Find(id);
        }

        public int InsertArtist(Artist entity)
        {
            // se agrega la entidad al contexto de Entity Framework
            _context.Artist.Add(entity);

            // Se confirma la transacción
            _context.SaveChanges();

            return entity.ArtistId;
        }

        public bool UpdateArtist(Artist entity)
        {
            // se atacha la entidad al contexto de Entity Framework
            _context.Artist.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            // Se confirma la transacción
            var result = _context.SaveChanges();
            return result > 0;       
        }

        public bool DeleteArtist(Artist entity)
        {
            // se atacha la entidad al contexto de Entity Framework
            _context.Artist.Attach(entity);
            _context.Artist.Remove(entity);

            // Se confirma la transacción
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool DeleteBatchArtist(List<int> listEntity)
        {
            foreach (var item in listEntity)
            {
                var entity = new Artist() { ArtistId = item };
                // se atacha la entidad al contexto de Entity Framework
                _context.Artist.Attach(entity);
                _context.Artist.Remove(entity);
            }            

            // Se confirma la transacción
            var result = _context.SaveChanges();
            return result > 0;
        }

    }
}
