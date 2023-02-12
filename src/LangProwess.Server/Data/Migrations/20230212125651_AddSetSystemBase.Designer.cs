﻿// <auto-generated />
using System;
using LangProwess.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LangProwess.Server.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230212125651_AddSetSystemBase")]
    partial class AddSetSystemBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("LangProwess.Server.Data.SetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Access")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("DefinitionLanguage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxLength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NameLanguage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("State")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("SetEntity");
                });

            modelBuilder.Entity("LangProwess.Server.Data.TermEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("DefinitionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxLength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.ToTable("TermEntity");
                });

            modelBuilder.Entity("LangProwess.Server.Data.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxLength")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PublicId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserEntity");
                });

            modelBuilder.Entity("LangProwess.Server.Data.WordEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Definition")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxLength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pronounciation")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("WordEntity");
                });

            modelBuilder.Entity("LangProwess.Server.Data.SetEntity", b =>
                {
                    b.HasOne("LangProwess.Server.Data.UserEntity", "Owner")
                        .WithMany("Sets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("LangProwess.Server.Data.TermEntity", b =>
                {
                    b.HasOne("LangProwess.Server.Data.WordEntity", "Definition")
                        .WithMany("Terms")
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Definition");
                });

            modelBuilder.Entity("LangProwess.Server.Data.WordEntity", b =>
                {
                    b.HasOne("LangProwess.Server.Data.SetEntity", "Set")
                        .WithMany("Words")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Set");
                });

            modelBuilder.Entity("LangProwess.Server.Data.SetEntity", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("LangProwess.Server.Data.UserEntity", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("LangProwess.Server.Data.WordEntity", b =>
                {
                    b.Navigation("Terms");
                });
#pragma warning restore 612, 618
        }
    }
}
