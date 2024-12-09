using Microsoft.EntityFrameworkCore;
using WebApp.Models.Domain;

namespace WebApp.Data
{
    //the database context representing the database
    public class RealDbContext : DbContext
    {
        public RealDbContext(DbContextOptions<RealDbContext> options) : base(options)
        {

        }

        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<Outfit> Outfits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClothingItem>()
                .ToTable("ClothingItems")
                .HasDiscriminator<string>("ClothingType")
                .HasValue<ClothingItem>("StandardClothingItem")
                .HasValue<BottomLayerClothingItem>("BottomLayer")
                .HasValue<TopBaseClothingItem>("TopLayer");

            modelBuilder.Entity<BottomLayerClothingItem>()
                .Property(b => b.Design)
                .HasConversion(
                    b=> b.ToString(),
                    b => (BottomDesign)Enum.Parse(typeof(BottomDesign), b));

            modelBuilder.Entity<TopBaseClothingItem>()
                .Property(t => t.Design)
                .HasConversion(
                    t => t.ToString(),
                    t => (TopDesign)Enum.Parse(typeof(TopDesign), t));

            modelBuilder.Entity<ClothingItem>()
                .Property(c => c.Material)
                .HasConversion(
                    m => m.ToString(),
                    m => (ClothesMaterial)Enum.Parse(typeof(ClothesMaterial), m));

            modelBuilder.Entity<ClothingItem>()
                .Property(c => c.Color)
                .HasConversion(
                    o => o.ToString(),
                    o => (ClothesColor)Enum.Parse(typeof(ClothesColor), o));

            modelBuilder.Entity<Outfit>()
                .HasMany(o => o.OutfitClothes)
                .WithMany(c => c.Outfits)
                .UsingEntity(j => j.ToTable("OutfitClothingItem"));
        }
    }
}
