using App.EF.CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.EF.CodeFirst
{
    public class GenreDA
    {
        private ChinookModel _context;

        public GenreDA()
        {
            _context = new ChinookModel();
        }

        public int Count()
        {
            return _context.Artist.Count();
        }

        public IEnumerable<Genre> GetGenres(string filterByName)
        {
            return _context.Genre.Where(item => item.Name.Contains(filterByName)).ToList();
        }

        public Genre GetGenre(int id)
        {
            return _context.Genre.Find(id);
        }

        public int InsertGenre(Genre entity)
        {
            // se agrega la entidad al contexto de Entity Framework
            _context.Genre.Add(entity);

            // Se confirma la transacción
            _context.SaveChanges();

            return entity.GenreId;
        }

        public bool UpdateGenre(Genre entity)
        {
            // se atacha la entidad al contexto de Entity Framework
            _context.Genre.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            // Se confirma la transacción
            var result = _context.SaveChanges();
            return result > 0;       
        }

        public bool DeleteGenre(Genre entity)
        {
            // se atacha la entidad al contexto de Entity Framework
            _context.Genre.Attach(entity);
            _context.Genre.Remove(entity);

            // Se confirma la transacción
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool DeleteBatchGenre(List<int> listEntity)
        {
            foreach (var item in listEntity)
            {
                var entity = new Genre() { GenreId = item };
                // se atacha la entidad al contexto de Entity Framework
                _context.Genre.Attach(entity);
                _context.Genre.Remove(entity);
            }            

            // Se confirma la transacción
            var result = _context.SaveChanges();
            return result > 0;
        }

    }
}
