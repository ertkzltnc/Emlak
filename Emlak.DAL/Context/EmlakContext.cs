namespace Emlak.DAL.Context
{
    using global::Emlak.Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmlakContext : DbContext
    {
       
        public EmlakContext()
            : base("name=EmlakContext")
        {
            Database.SetInitializer(new DataInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konut>()
                .HasRequired<Il>(s => s.Il)
                .WithMany(g => g.Konutlar)
                .HasForeignKey<int>(s => s.IlID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Konut>()
               .HasRequired<Ilce>(s => s.Ilce)
               .WithMany(g => g.Konutlar)
               .HasForeignKey<int>(s => s.IlceID)
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<Konut>()
               .HasRequired<Mahalle>(s => s.Mahalle)
               .WithMany(g => g.Konutlar)
               .HasForeignKey<int>(s => s.MahalleID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .HasRequired<Il>(s => s.Il)
                .WithMany(g => g.Musteriler)
                .HasForeignKey<int>(s => s.IlID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Musteri>()
               .HasRequired<Ilce>(s => s.Ilce)
               .WithMany(g => g.Musteriler)
               .HasForeignKey<int>(s => s.IlceID)
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<Musteri>()
               .HasRequired<Mahalle>(s => s.Mahalle)
               .WithMany(g => g.Musteriler)
               .HasForeignKey<int>(s => s.MahalleID)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmlakOfisi>()
                .HasRequired<Il>(s => s.Il)
                .WithMany(g => g.EmlakOfisler)
                .HasForeignKey<int>(s => s.IlID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<EmlakOfisi>()
               .HasRequired<Ilce>(s => s.Ilce)
               .WithMany(g => g.EmlakOfisler)
               .HasForeignKey<int>(s => s.IlceID)
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<EmlakOfisi>()
               .HasRequired<Mahalle>(s => s.Mahalle)
               .WithMany(g => g.EmlakOfisler)
               .HasForeignKey<int>(s => s.MahalleID)
               .WillCascadeOnDelete(false);






        }

        public virtual DbSet<EmlakOfisi> EmlakOfisi { get; set; }
        public virtual DbSet<Fotograf> Fotograf { get; set; }
        public virtual DbSet<Il> Il { get; set; }
        public virtual DbSet<IlanTur> IlanTur { get; set; }
        public virtual DbSet<Ilce> Ilce { get; set; }
        public virtual DbSet<IsitmaTur> IsitmaTur { get; set; }
        public virtual DbSet<Konut> Konut { get; set; }
        public virtual DbSet<Mahalle> Mahalle { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }

    }

   
}