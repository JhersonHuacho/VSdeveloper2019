using App.Domain;
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
        public IEnumerable<Customer> GetCustomers(string nombre)
        {
            ICustomerDomain domain = new CustomerDomain();
            return domain.GetCustomers(nombre);
        }

    }
}
