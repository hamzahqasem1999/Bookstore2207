﻿// <auto-generated />
using System;
using BookStore2207.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore2207.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20230612073510_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore2207.data.Auther", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("auther");
                });

            modelBuilder.Entity("BookStore2207.data.Bookstore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("autherId")
                        .HasColumnType("int");

                    b.Property<int>("auther_Id")
                        .HasColumnType("int");

                    b.Property<string>("booktitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("category_Id")
                        .HasColumnType("int");

                    b.Property<int?>("catgoryId")
                        .HasColumnType("int");

                    b.Property<string>("path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prise")
                        .HasColumnType("int");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("autherId");

                    b.HasIndex("catgoryId");

                    b.ToTable("BookStore");
                });

            modelBuilder.Entity("BookStore2207.data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("code")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BookStore2207.data.Bookstore", b =>
                {
                    b.HasOne("BookStore2207.data.Auther", "auther")
                        .WithMany("libookes")
                        .HasForeignKey("autherId");

                    b.HasOne("BookStore2207.data.Category", "catgory")
                        .WithMany("libookes")
                        .HasForeignKey("catgoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
