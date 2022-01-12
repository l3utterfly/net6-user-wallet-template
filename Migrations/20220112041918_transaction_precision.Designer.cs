﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220112041918_transaction_precision")]
    partial class transaction_precision
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(38, 8)
                        .HasColumnType("decimal(38,8)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Transaction");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SponsorId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId")
                        .IsUnique()
                        .HasFilter("[SponsorId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApi.Entities.InternalTransaction", b =>
                {
                    b.HasBaseType("WebApi.Entities.Transaction");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.HasIndex("FromUserId");

                    b.HasDiscriminator().HasValue("InternalTransaction");
                });

            modelBuilder.Entity("WebApi.Entities.Transaction", b =>
                {
                    b.HasOne("WebApi.Entities.User", "User")
                        .WithMany("AllTransactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.HasOne("WebApi.Entities.User", "Sponsor")
                        .WithMany("Referrals")
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("WebApi.Entities.InternalTransaction", b =>
                {
                    b.HasOne("WebApi.Entities.User", "FromUser")
                        .WithMany("InternalTransactions")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromUser");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Navigation("AllTransactions");

                    b.Navigation("InternalTransactions");

                    b.Navigation("Referrals");
                });
#pragma warning restore 612, 618
        }
    }
}
