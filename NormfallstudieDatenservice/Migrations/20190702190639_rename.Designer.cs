﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Migrations
{
    [DbContext(typeof(SwissContext))]
    [Migration("20190702190639_rename")]
    partial class rename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("NormfallstudieDatenservice.Models.SwissDestination", b =>
                {
                    b.Property<int>("SwissDestinationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("SwissDestinationId");

                    b.ToTable("SwissDestinations");
                });

            modelBuilder.Entity("NormfallstudieDatenservice.Models.SwissFlight", b =>
                {
                    b.Property<int>("SwissFlightId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int>("EmptyPlaces");

                    b.Property<int?>("EndDestinationSwissDestinationId");

                    b.Property<int?>("StartDestinationSwissDestinationId");

                    b.HasKey("SwissFlightId");

                    b.HasIndex("EndDestinationSwissDestinationId");

                    b.HasIndex("StartDestinationSwissDestinationId");

                    b.ToTable("SwissFlights");
                });

            modelBuilder.Entity("NormfallstudieDatenservice.Models.SwissFlight", b =>
                {
                    b.HasOne("NormfallstudieDatenservice.Models.SwissDestination", "EndDestination")
                        .WithMany()
                        .HasForeignKey("EndDestinationSwissDestinationId");

                    b.HasOne("NormfallstudieDatenservice.Models.SwissDestination", "StartDestination")
                        .WithMany()
                        .HasForeignKey("StartDestinationSwissDestinationId");
                });
#pragma warning restore 612, 618
        }
    }
}