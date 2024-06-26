﻿// <auto-generated />
using Handin3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Handin3.Migrations
{
    [DbContext(typeof(myDbContext))]
    [Migration("20240429031913_Migration3")]
    partial class Migration3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Handin3.Models.Allergen", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("Handin3.Models.Batch", b =>
                {
                    b.Property<long>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BatchId"));

                    b.Property<string>("ActualFinishTime")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<long>("ScheduleId")
                        .HasColumnType("bigint");

                    b.Property<string>("StartTime")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("TargetFinishTime")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("BatchId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("Handin3.Models.Driver", b =>
                {
                    b.Property<long>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DriverId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Handin3.Models.Ingredient", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Name");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Handin3.Models.IngredientAllergen", b =>
                {
                    b.Property<string>("IngredientName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllergenName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IngredientName", "AllergenName");

                    b.HasIndex("AllergenName");

                    b.ToTable("IngredientAllergens");
                });

            modelBuilder.Entity("Handin3.Models.Packet", b =>
                {
                    b.Property<long>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TrackId"));

                    b.Property<long>("DriverId")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("TrackId");

                    b.HasIndex("DriverId");

                    b.HasIndex("OrderId");

                    b.ToTable("Packets");
                });

            modelBuilder.Entity("Handin3.Models.Recipe", b =>
                {
                    b.Property<long>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RecipeId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Handin3.Models.RecipeIngredient", b =>
                {
                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<string>("IngredientName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("RecipeId", "IngredientName");

                    b.HasIndex("IngredientName");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("Handin3.Models.SOrder", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderId"));

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ScheduleId")
                        .HasColumnType("bigint");

                    b.Property<long>("SupermarketId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SupermarketId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Handin3.Models.Schedule", b =>
                {
                    b.Property<long>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ScheduleId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Handin3.Models.Supermarket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supermarkets");
                });

            modelBuilder.Entity("Handin3.Models.Batch", b =>
                {
                    b.HasOne("Handin3.Models.SOrder", "SOrder")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Handin3.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SOrder");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Handin3.Models.IngredientAllergen", b =>
                {
                    b.HasOne("Handin3.Models.Allergen", "Allergen")
                        .WithMany("IngredientAllergens")
                        .HasForeignKey("AllergenName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Handin3.Models.Ingredient", "Ingredient")
                        .WithMany("IngredientAllergens")
                        .HasForeignKey("IngredientName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergen");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Handin3.Models.Packet", b =>
                {
                    b.HasOne("Handin3.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Handin3.Models.SOrder", "SOrder")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("SOrder");
                });

            modelBuilder.Entity("Handin3.Models.RecipeIngredient", b =>
                {
                    b.HasOne("Handin3.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Handin3.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Handin3.Models.SOrder", b =>
                {
                    b.HasOne("Handin3.Models.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Handin3.Models.Supermarket", "Supermarket")
                        .WithMany()
                        .HasForeignKey("SupermarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("Supermarket");
                });

            modelBuilder.Entity("Handin3.Models.Allergen", b =>
                {
                    b.Navigation("IngredientAllergens");
                });

            modelBuilder.Entity("Handin3.Models.Ingredient", b =>
                {
                    b.Navigation("IngredientAllergens");
                });

            modelBuilder.Entity("Handin3.Models.Recipe", b =>
                {
                    b.Navigation("RecipeIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
