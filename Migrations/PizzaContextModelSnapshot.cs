﻿// <auto-generated />
using System;
using LaMiaPizzeria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaMiaPizzeria.Migrations
{
    [DbContext(typeof(PizzaContext))]
    partial class PizzaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IngredientePizza", b =>
                {
                    b.Property<int>("IngredienteListId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaListId")
                        .HasColumnType("int");

                    b.HasKey("IngredienteListId", "PizzaListId");

                    b.HasIndex("PizzaListId");

                    b.ToTable("IngredientePizza");
                });

            modelBuilder.Entity("LaMiaPizzeria.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaList");
                });

            modelBuilder.Entity("LaMiaPizzeria.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IngredienteList");
                });

            modelBuilder.Entity("LaMiaPizzeria.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("PizzaList");
                });

            modelBuilder.Entity("IngredientePizza", b =>
                {
                    b.HasOne("LaMiaPizzeria.Models.Ingrediente", null)
                        .WithMany()
                        .HasForeignKey("IngredienteListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaMiaPizzeria.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzaListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaMiaPizzeria.Models.Pizza", b =>
                {
                    b.HasOne("LaMiaPizzeria.Models.Categoria", "Category")
                        .WithMany("PizzaList")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LaMiaPizzeria.Models.Categoria", b =>
                {
                    b.Navigation("PizzaList");
                });
#pragma warning restore 612, 618
        }
    }
}
