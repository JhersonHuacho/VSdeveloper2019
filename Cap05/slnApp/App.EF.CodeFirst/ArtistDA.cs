using App.EF.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


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

        public Artist GetArtistEdgerLoading(int id)
        {
            // Include() funciona para relaciones directas
            return _context.Artist.Include(item => item.Album)
                   .Where(item => item.ArtistId == id).FirstOrDefault();
        }

        public Artist GetArtistEdgerLoadingDos(int id)
        {
            // Se tiene que utilizar Select para traer las otras que estan relacionadas
            return _context.Artist.Include(item => item.Album.Select(item2 => item2.Track))
                   .Where(item => item.ArtistId == id).FirstOrDefault();
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

        public bool UpdateArtistDos(Artist entity)
        {
            // se atacha la entidad al contexto de Entity Framework
            _context.Artist.Attach(entity);
            // se indica al EF que la actualización sucede por campo
            _context.Entry(entity).Property(item => item.Name).IsModified = true;           
            // Se confirma la transacción
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool UpdateArtistTres(Artist entity)
        {            
            var found = _context.Artist.Find(entity.ArtistId);
            found.Name = entity.Name;
            
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
