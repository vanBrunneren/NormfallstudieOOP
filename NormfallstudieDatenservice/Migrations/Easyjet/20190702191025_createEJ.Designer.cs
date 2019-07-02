﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Migrations.Easyjet
{
    [DbContext(typeof(EasyjetContext))]
    [Migration("20190702191025_createEJ")]
    partial class createEJ
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("NormfallstudieDatenservice.Models.EasyjetDestination", b =>
                {
                    b.Property<int>("EasyjetDestinationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("EasyjetDestinationId");

                    b.ToTable("EasyjetDestinations");
                });

            modelBuilder.Entity("NormfallstudieDatenservice.Models.EasyjetFlight", b =>
                {
                    b.Property<int>("EasyjetFlightId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int>("EmptyPlaces");

                    b.Property<int?>("EndDestinationEasyjetDestinationId");

                    b.Property<int?>("StartDestinationEasyjetDestinationId");

                    b.HasKey("EasyjetFlightId");

                    b.HasIndex("EndDestinationEasyjetDestinationId");

                    b.HasIndex("StartDestinationEasyjetDestinationId");

                    b.ToTable("EasyjetFlights");
                });

            modelBuilder.Entity("NormfallstudieDatenservice.Models.EasyjetFlight", b =>
                {
                    b.HasOne("NormfallstudieDatenservice.Models.EasyjetDestination", "EndDestination")
                        .WithMany()
                        .HasForeignKey("EndDestinationEasyjetDestinationId");

                    b.HasOne("NormfallstudieDatenservice.Models.EasyjetDestination", "StartDestination")
                        .WithMany()
                        .HasForeignKey("StartDestinationEasyjetDestinationId");
                });
#pragma warning restore 612, 618
        }
    }
}