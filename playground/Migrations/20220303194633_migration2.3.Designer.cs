﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using playground.Data;

#nullable disable

namespace playground.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220303194633_migration2.3")]
    partial class migration23
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("playground.Models.Repository", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Userid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("playground.Models.Task", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("deadline")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("desc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("prior")
                        .HasColumnType("int");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("playground.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nickname")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("playground.Models.Repository", b =>
                {
                    b.HasOne("playground.Models.User", null)
                        .WithMany("Repositories")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("playground.Models.User", b =>
                {
                    b.Navigation("Repositories");
                });
#pragma warning restore 612, 618
        }
    }
}
