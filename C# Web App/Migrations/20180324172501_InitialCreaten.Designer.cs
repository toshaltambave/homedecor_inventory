﻿// <auto-generated />
using HomeDecor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HomeDecor.Migrations
{
    [DbContext(typeof(HomeDecorContext))]
    [Migration("20180324172501_InitialCreaten")]
    partial class InitialCreaten
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeDecor.Models.DecorModel", b =>
                {
                    b.Property<int>("Resource_code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<int>("Facility_code");

                    b.Property<int>("Quantity");

                    b.Property<string>("Resource_description");

                    b.Property<string>("Resource_name")
                        .IsRequired();

                    b.Property<string>("Size");

                    b.Property<bool>("isActive");

                    b.HasKey("Resource_code");

                    b.HasIndex("Facility_code");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("HomeDecor.Models.FacilityModel", b =>
                {
                    b.Property<int>("Facility_code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Facility_description")
                        .IsRequired();

                    b.Property<string>("Facility_name")
                        .IsRequired();

                    b.Property<bool>("isActive");

                    b.HasKey("Facility_code");

                    b.ToTable("Facility");
                });

            modelBuilder.Entity("HomeDecor.Models.UserAccount", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessRights")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserPassword")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HomeDecor.Models.UserLogin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserPassword")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("HomeDecor.Models.DecorModel", b =>
                {
                    b.HasOne("HomeDecor.Models.FacilityModel", "FacilityModel")
                        .WithMany()
                        .HasForeignKey("Facility_code")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
