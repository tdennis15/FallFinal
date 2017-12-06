namespace FallFinal_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=MovieContext")
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany(e => e.Casts)
                .WithRequired(e => e.Actor)
                .HasForeignKey(e => e.C_ActorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Actor>()
                .HasMany(e => e.Casts1)
                .WithRequired(e => e.Actor1)
                .HasForeignKey(e => e.C_ActorID);

            modelBuilder.Entity<Director>()
                .HasMany(e => e.Movies)
                .WithRequired(e => e.Director)
                .HasForeignKey(e => e.M_Dir)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Director>()
                .HasMany(e => e.Movies1)
                .WithRequired(e => e.Director1)
                .HasForeignKey(e => e.M_Dir);

            modelBuilder.Entity<Movie>()
                .Property(e => e.M_Year)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Casts)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.C_MovieID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Casts1)
                .WithRequired(e => e.Movie1)
                .HasForeignKey(e => e.C_MovieID);
        }
    }
}
