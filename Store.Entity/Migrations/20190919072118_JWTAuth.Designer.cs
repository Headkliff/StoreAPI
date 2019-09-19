﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Entity.Db;

namespace Store.Entity.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190919072118_JWTAuth")]
    partial class JWTAuth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Store.Entity.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("FirstName");

                    b.Property<string>("Nickname");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("SecondName");

                    b.Property<DateTime?>("UpdateDateTime");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreateDateTime = new DateTime(2019, 9, 19, 10, 21, 18, 200, DateTimeKind.Local).AddTicks(9690),
                            FirstName = "test",
                            Nickname = "Standard 1",
                            Password = "111",
                            Role = "User",
                            SecondName = "test1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
