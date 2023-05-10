﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SentenceBuilderAPI.Data;

#nullable disable

namespace SentenceBuilderAPI.Migrations
{
    [DbContext(typeof(AppliationDbContext))]
    [Migration("20230509202934_AddDbTables")]
    partial class AddDbTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SentenceBuilderAPI.Models.Sentence", b =>
                {
                    b.Property<int>("SentenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SentenceId"));

                    b.Property<string>("SentenceCeatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentenceCreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SentenceDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SentenceId");

                    b.ToTable("Sentences");
                });

            modelBuilder.Entity("SentenceBuilderAPI.Models.UserRoles", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<string>("UserRoleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("SentenceBuilderAPI.Models.Users", b =>
                {
                    b.Property<Guid>("UserKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("UserKey");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SentenceBuilderAPI.Models.WordType", b =>
                {
                    b.Property<int>("WordTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordTypeId"));

                    b.Property<string>("WordTypeDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordTypeId");

                    b.ToTable("WordType");
                });

            modelBuilder.Entity("SentenceBuilderAPI.Models.Words", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"));

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordTypeId")
                        .HasColumnType("int");

                    b.HasKey("WordId");

                    b.ToTable("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
