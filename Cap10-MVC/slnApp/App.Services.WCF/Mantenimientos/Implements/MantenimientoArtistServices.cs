﻿using App.Domain;
using App.Domain.Interfaces;
using App.Entities.Base;
using App.Services.WCF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace App.Services.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public partial class MantenimientoServices : IMantenimientoServices
    {
        public IEnumerable<Artist> GetArtistAll(string nombre)
        {
            IArtistDomain domain = new ArtistDomain();
            return domain.GetArtists(nombre);
        }

        public bool SaveArtist(Artist Entity)
        {
            var result = false;

            try
            {
                IArtistDomain domain = new ArtistDomain();
                result = domain.SaveArtist(Entity);
            }
            catch (Exception ex)
            {
                // se debera guardar el error en un log
            }
            return result;
        }

        public Artist GetArtist(int id)
        {
            IArtistDomain domain = new ArtistDomain();
            return domain.Get(id);
        }

        public bool LoginUsuario(Usuario entity)
        {
            IUsuarioDomain domain = new UsuarioDomain();
            return domain.LoginUsuario(entity);
        }
    }
}
