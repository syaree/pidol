﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pidol.Data;

namespace pidol.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201028131256_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("pidol.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intelligence")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("pidol.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
