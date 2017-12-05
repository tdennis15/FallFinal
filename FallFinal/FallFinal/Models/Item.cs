namespace FallFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            Bids = new HashSet<Bid>();
            Bids1 = new HashSet<Bid>();
        }

        [Key]
        public int I_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string I_Name { get; set; }

        [StringLength(160)]
        public string I_Description { get; set; }

        public int? Seller_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids1 { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual Seller Seller1 { get; set; }
    }
}
