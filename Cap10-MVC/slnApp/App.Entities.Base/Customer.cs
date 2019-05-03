namespace App.Entities.Base
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Invoice = new HashSet<Invoice>();
        }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [DataMember]
        [StringLength(80)]
        public string Company { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [DataMember]
        [StringLength(40)]
        public string City { get; set; }

        [DataMember]
        [StringLength(40)]
        public string State { get; set; }

        [DataMember]
        [StringLength(40)]
        public string Country { get; set; }

        [DataMember]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [DataMember]
        [StringLength(24)]
        public string Phone { get; set; }

        [DataMember]
        [StringLength(24)]
        public string Fax { get; set; }

        [DataMember]
        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        [DataMember]
        public int? SupportRepId { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
