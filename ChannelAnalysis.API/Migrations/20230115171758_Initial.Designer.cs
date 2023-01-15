﻿// <auto-generated />
using System;
using ChannelAnalysis.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChannelAnalysis.API.Migrations
{
    [DbContext(typeof(ChannelAnalysisDbContext))]
    [Migration("20230115171758_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChannelAnalysis.API.Models.AnalysisQueue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChannelLink")
                        .HasColumnType("text")
                        .HasColumnName("channel_link");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.HasKey("Id");

                    b.ToTable("AnalysisQueue");
                });

            modelBuilder.Entity("ChannelAnalysis.API.Models.Channel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_channel");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ChannelName")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("channel_name");

                    b.HasKey("Id");

                    b.ToTable("Channel");
                });

            modelBuilder.Entity("ChannelAnalysis.API.Models.ChannelStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("ChannelId")
                        .HasColumnType("bigint")
                        .HasColumnName("id_channel");

                    b.Property<long>("ForwardsTotalCount")
                        .HasColumnType("bigint")
                        .HasColumnName("forwards_total_count");

                    b.Property<DateTime>("LastPublicationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_publication_date");

                    b.Property<string>("Reactions")
                        .HasColumnType("jsonb")
                        .HasColumnName("reactions_total_count");

                    b.Property<long>("ViewsTotalCount")
                        .HasColumnType("bigint")
                        .HasColumnName("views_total_count");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId")
                        .IsUnique();

                    b.ToTable("ChannelStatistics");
                });

            modelBuilder.Entity("ChannelAnalysis.API.Models.FeedbackStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("content");

                    b.Property<string>("ReviewId")
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("id_review");

                    b.HasKey("Id");

                    b.ToTable("FeedbackStorage");
                });

            modelBuilder.Entity("ChannelAnalysis.API.Models.ProrussianCoefficient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("CalculatedCoefficient")
                        .HasColumnType("real")
                        .HasColumnName("calculated_coefficient");

                    b.Property<long>("ChannelId")
                        .HasColumnType("bigint")
                        .HasColumnName("id_channel");

                    b.Property<DateTime>("LastPublicationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_publication_date");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId")
                        .IsUnique();

                    b.ToTable("ProrussianCoefficient");
                });

            modelBuilder.Entity("ChannelAnalysis.API.Models.ChannelStatistics", b =>
                {
                    b.HasOne("ChannelAnalysis.API.Models.Channel", "Channel")
                        .WithOne("Statistics")
                        .HasForeignKey("ChannelAnalysis.API.Models.ChannelStatistics", "ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("ChannelAnalysis.API.Models.ProrussianCoefficient", b =>
                {
                    b.HasOne("ChannelAnalysis.API.Models.Channel", "Channel")
                        .WithOne("ProrussianCoefficient")
                        .HasForeignKey("ChannelAnalysis.API.Models.ProrussianCoefficient", "ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");
                });

            modelBuilder.Entity("ChannelAnalysis.API.Models.Channel", b =>
                {
                    b.Navigation("ProrussianCoefficient");

                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
