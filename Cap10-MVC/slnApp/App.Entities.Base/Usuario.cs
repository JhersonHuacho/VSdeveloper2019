namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("Usuario")]
    public partial class Usuario
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Usuario()
        //{
        //    Album = new HashSet<Album>();
        //}

        [DataMember]
        public int UsuarioID { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Login { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Password { get; set; }

        [DataMember]
        [StringLength(200)]
        public string Roles { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Nombres { get; set; }

        [DataMember]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [DataMember]
        [StringLength(100)]
        public string Email { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Album> Album { get; set; }
    }
}
