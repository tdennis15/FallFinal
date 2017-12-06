namespace FallFinal_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            Casts = new HashSet<Cast>();
            Casts1 = new HashSet<Cast>();
        }

        [Key]
        public int M_ID { get; set; }

        [Required]
        [StringLength(64)]
        public string M_Name { get; set; }

        [StringLength(24)]
        public string M_Year { get; set; }

        public int M_Dir { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cast> Casts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cast> Casts1 { get; set; }

        public virtual Director Director { get; set; }

        public virtual Director Director1 { get; set; }
    }
}
