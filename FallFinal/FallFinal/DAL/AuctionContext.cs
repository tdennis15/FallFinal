namespace FallFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuctionContext : DbContext
    {
        public AuctionContext()
            : base("name=AuctionContext")
        {
        }

        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Buyer)
                .HasForeignKey(e => e.Buyer_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Bids1)
                .WithRequired(e => e.Buyer1)
                .HasForeignKey(e => e.Buyer_ID);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Bids)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.Item_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Bids1)
                .WithRequired(e => e.Item1)
                .HasForeignKey(e => e.Item_ID);

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Seller)
                .HasForeignKey(e => e.Seller_ID);

            modelBuilder.Entity<Seller>()
                .HasMany(e => e.Items1)
                .WithOptional(e => e.Seller1)
                .HasForeignKey(e => e.Seller_ID)
                .WillCascadeOnDelete();
        }
    }
}
