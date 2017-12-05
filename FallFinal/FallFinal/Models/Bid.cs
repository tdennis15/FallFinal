namespace FallFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        [Key]
        public int Bid_ID { get; set; }

        public int Price { get; set; }

        public int Buyer_ID { get; set; }

        public int Item_ID { get; set; }

        public DateTime Bid_Time { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer1 { get; set; }

        public virtual Item Item1 { get; set; }
    }
}
