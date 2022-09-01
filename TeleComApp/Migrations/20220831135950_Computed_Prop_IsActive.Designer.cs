﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeleComApp.Data;

#nullable disable

namespace TeleComApp.Migrations
{
    [DbContext(typeof(TCcontext))]
    [Migration("20220831135950_Computed_Prop_IsActive")]
    partial class Computed_Prop_IsActive
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TeleComApp.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"), 1L, 1);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("TeleComApp.Models.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneNumberId"), 1L, 1);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.HasKey("PhoneNumberId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("TeleComApp.Models.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<int>("PhoneLines")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("TeleComApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeleComApp.Models.Device", b =>
                {
                    b.HasOne("TeleComApp.Models.Plan", null)
                        .WithMany("Devices")
                        .HasForeignKey("PlanId");

                    b.HasOne("TeleComApp.Models.User", null)
                        .WithMany("Devices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeleComApp.Models.Plan", b =>
                {
                    b.HasOne("TeleComApp.Models.User", null)
                        .WithMany("Plans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeleComApp.Models.Plan", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("TeleComApp.Models.User", b =>
                {
                    b.Navigation("Devices");

                    b.Navigation("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}
