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

        public IEnumerable<Artist> Gets(string filterByName)
        {
            IQueryable<Artist> query = _context.Artist;
            if (!string.IsNullOrWhiteSpace(filterByName))
                query = query.Where(item => item.Name.Contains(filterByName));

            return query.ToList();
        }
        public Artist Get(int id)
        {
            return _context.Artist.Find(id);
        }

        public Artist GetEdgerLoading(int id)
        {
            return _context.Artist.Include(item=>item.Album.Select(item2=>item2.Track))
                .Where(item=>item.ArtistId==id).FirstOrDefault();
        }


        public int Insert(Artist entity)
        {
            //Se agrega la entidad al contexto de Entity Framework
            _context.Artist.Add(entity);

            //Se confirma la transaccion
            _context.SaveChanges();

            return entity.ArtistId;

        }

        public bool Update(Artist entity)
        {
            //Se atacha la entidad al contexto de Entity Framework
            _context.Artist.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

           //Se confirma la transaccion
           var result = _context.SaveChanges();

           return result>0;

        }

        public bool Update2(Artist entity)
        {
            //Se atacha la entidad al contexto de Entity Framework
            _context.Artist.Attach(entity);

            //Se indica al EF que la actualización sucede por campo
            //de la tabla
            _context.Entry(entity).Property(item => item.Name).IsModified = true;

            //Se confirma la transaccion
            var result = _context.SaveChanges();

            return result > 0;

        }

        public bool Update3(Artist entity)
        {

            var found = _context.Artist.Where(item=>item.Name=="Pedro");
            foreach (var item in found)
            {
                item.Name = "Juan Pedro";
            }            

            //Se confirma la transaccion
            var result = _context.SaveChanges();

            return result > 0;

        }

        public bool Delete(Artist entity)
        {
            _context.Artist.Attach(entity);
            _context.Artist.Remove(entity);

            //Se confirma la transaccion
            var result = _context.SaveChanges();

            return result > 0;
        }

        public bool DeleteBatch(List<int> ids)
        {
            foreach (var i in ids)
            {
                var entity = new Artist() { ArtistId = i };
                _context.Artist.Attach(entity);
                _context.Artist.Remove(entity);
            }
            //Se confirma la transaccion
            var result = _context.SaveChanges();

            return result > 0;
        }

    }
}
