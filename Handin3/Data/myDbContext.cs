using Handin3.Models;
using Microsoft.EntityFrameworkCore;

namespace Handin3.Data
{
    public partial class myDbContext : DbContext
    {
        public myDbContext() { }

        public myDbContext(DbContextOptions<myDbContext> options) : base(options) { }

        public DbSet<Supermarket> Supermarkets { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SOrder> Orders { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Packet> Packets { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<IngredientAllergen> IngredientAllergens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SOrder>()
                        .HasOne(o => o.Supermarket)
                        .WithMany()
                        .HasForeignKey(o => o.SupermarketId);


            modelBuilder.Entity<SOrder>()
                        .HasOne(o => o.Schedule)
                        .WithMany()
                        .HasForeignKey(o => o.ScheduleId);

            modelBuilder.Entity<Batch>()
                        .HasOne(b => b.Schedule)
                        .WithMany()
                        .HasForeignKey(b => b.ScheduleId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Batch>()
                        .HasOne(b => b.SOrder)
                        .WithMany()
                        .HasForeignKey(b => b.OrderId);

            modelBuilder.Entity<RecipeIngredient>()
                        .HasKey(ri => new { ri.RecipeId, ri.IngredientName });

            modelBuilder.Entity<RecipeIngredient>()
                        .HasOne(ri => ri.Recipe)
                        .WithMany(r => r.RecipeIngredients)
                        .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                        .HasOne(ri => ri.Ingredient)
                        .WithMany()
                        .HasForeignKey(ri => ri.IngredientName);

            modelBuilder.Entity<Packet>()
                        .HasOne(p => p.SOrder)
                        .WithMany()
                        .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<Packet>()
                        .HasOne(p => p.Driver)
                        .WithMany()
                        .HasForeignKey(p => p.DriverId);

            modelBuilder.Entity<IngredientAllergen>()
            .HasKey(ia => new { ia.IngredientName, ia.AllergenName });

            modelBuilder.Entity<IngredientAllergen>()
                        .HasOne(ia => ia.Ingredient)
                        .WithMany(i => i.IngredientAllergens)
                        .HasForeignKey(ia => ia.IngredientName);

            modelBuilder.Entity<IngredientAllergen>()
                        .HasOne(ia => ia.Allergen)
                        .WithMany(a => a.IngredientAllergens)
                        .HasForeignKey(ia => ia.AllergenName);
        }
    }
}
