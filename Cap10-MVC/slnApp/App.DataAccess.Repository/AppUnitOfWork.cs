using App.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {

        private readonly DbContext _context;

        public AppUnitOfWork()
        {
            _context = new AppDataModel();
            CreateRepositories();
        }

        public AppUnitOfWork(DbContext context)
        {
            _context = context;
            CreateRepositories();
        }

        private void CreateRepositories()
        {
            this.ArtistRepository = new ArtistRepository(_context);
            this.TrackRepository = new TrackRepository(_context);
            this.UsuarioRepository = new UsuarioRepository(_context);
        }


        public IArtistRepository ArtistRepository { get ; set ; }
        public ITrackRepository TrackRepository { get; set; }
        public IUsuarioRepository UsuarioRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
