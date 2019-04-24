using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace App.Entities.Queries
{
    [DataContract]
    class UsuarioLogin
    {
        [DataMember]
        public int UsuarioID { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
