﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentMotorcycle.Repository;

#nullable disable

namespace RentMotorcycle.Repository.Migrations
{
    [DbContext(typeof(RentMotorcycleContext))]
    partial class RentMotorcycleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RentMotorcycle.Data.DeliveryManAggregate.Deliveryman", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IdentifyCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<string>("LicenseDriverNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("LicenseImage")
                        .HasColumnType("text");

                    b.Property<int>("LicenseType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.HasIndex("LicenseDriverNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Deliveryman");
                });

            modelBuilder.Entity("RentMotorcycle.Data.MotorcycleAggregate.Motorcycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IdentifyCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.ToTable("Motorcycle");
                });

            modelBuilder.Entity("RentMotorcycle.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Profile")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("RentMotorcycle.Data.DeliveryManAggregate.Deliveryman", b =>
                {
                    b.HasOne("RentMotorcycle.Domain.UserAggregate.User", "UserFk")
                        .WithOne()
                        .HasForeignKey("RentMotorcycle.Data.DeliveryManAggregate.Deliveryman", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFk");
                });
#pragma warning restore 612, 618
        }
    }
}
