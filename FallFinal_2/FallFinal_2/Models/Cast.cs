namespace FallFinal_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cast
    {
        [Key]
        public int C_ID { get; set; }

        public int C_ActorID { get; set; }

        public int C_MovieID { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual Actor Actor1 { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Movie Movie1 { get; set; }
    }
}
