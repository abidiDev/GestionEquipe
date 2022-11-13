﻿// <auto-generated />
using System;
using Infrastruct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastruct.Migrations
{
    [DbContext(typeof(GEContext))]
    [Migration("20221113132131_OneToMany")]
    partial class OneToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Contrat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateContrat")
                        .HasColumnType("datetime2");

                    b.Property<int>("DureeMois")
                        .HasColumnType("int");

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<int>("MembreId")
                        .HasColumnType("int");

                    b.Property<double>("salaire")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("MembreId");

                    b.ToTable("Contrats");
                });

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Membre", b =>
                {
                    b.Property<int>("MembreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MembreId"));

                    b.Property<DateTime>("Datenaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("identifiant")
                        .HasColumnType("int");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MembreId");

                    b.ToTable("Membres");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Membre");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Trophe", b =>
                {
                    b.Property<int>("TropheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TropheId"));

                    b.Property<DateTime>("DateTrophee")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipeFK")
                        .HasColumnType("int");

                    b.Property<double>("Recompense")
                        .HasColumnType("float");

                    b.Property<string>("TypeTrophee")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TropheId");

                    b.HasIndex("EquipeFK");

                    b.ToTable("Trophes");
                });

            modelBuilder.Entity("Equ.ApplicationCore.Domain.Equipe", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipeId"));

                    b.Property<string>("AdressLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EquipeName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EquipeLogo");

                    b.HasKey("EquipeId");

                    b.ToTable("MyEquipe", (string)null);
                });

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Entraineur", b =>
                {
                    b.HasBaseType("Eq.ApplicationCore.Domain.Membre");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Entraineur");
                });

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Joueur", b =>
                {
                    b.HasBaseType("Eq.ApplicationCore.Domain.Membre");

                    b.HasDiscriminator().HasValue("Joueur");
                });

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Contrat", b =>
                {
                    b.HasOne("Equ.ApplicationCore.Domain.Equipe", "Equipe")
                        .WithMany("Contrats")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eq.ApplicationCore.Domain.Membre", "Membre")
                        .WithMany("Contrats")
                        .HasForeignKey("MembreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Membre");
                });

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Trophe", b =>
                {
                    b.HasOne("Equ.ApplicationCore.Domain.Equipe", "equipe")
                        .WithMany("Trophes")
                        .HasForeignKey("EquipeFK")
                        .IsRequired();

                    b.Navigation("equipe");
                });

            modelBuilder.Entity("Eq.ApplicationCore.Domain.Membre", b =>
                {
                    b.Navigation("Contrats");
                });

            modelBuilder.Entity("Equ.ApplicationCore.Domain.Equipe", b =>
                {
                    b.Navigation("Contrats");

                    b.Navigation("Trophes");
                });
#pragma warning restore 612, 618
        }
    }
}
