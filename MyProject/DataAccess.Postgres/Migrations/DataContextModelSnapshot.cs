﻿// <auto-generated />
using System;
using DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Postgres.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Postgres.Entity.EquipmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.ParametersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.SampleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EquipmentID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentID");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.UnityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ParametersID")
                        .HasColumnType("integer");

                    b.Property<int>("SampleID")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParametersID");

                    b.HasIndex("SampleID");

                    b.ToTable("Unity");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.SampleEntity", b =>
                {
                    b.HasOne("DataAccess.Postgres.Entity.EquipmentEntity", "Equipment")
                        .WithMany("Sample")
                        .HasForeignKey("EquipmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.UnityEntity", b =>
                {
                    b.HasOne("DataAccess.Postgres.Entity.ParametersEntity", "Parameters")
                        .WithMany("Unity")
                        .HasForeignKey("ParametersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Postgres.Entity.SampleEntity", "Sample")
                        .WithMany("Unity")
                        .HasForeignKey("SampleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parameters");

                    b.Navigation("Sample");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.EquipmentEntity", b =>
                {
                    b.Navigation("Sample");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.ParametersEntity", b =>
                {
                    b.Navigation("Unity");
                });

            modelBuilder.Entity("DataAccess.Postgres.Entity.SampleEntity", b =>
                {
                    b.Navigation("Unity");
                });
#pragma warning restore 612, 618
        }
    }
}
