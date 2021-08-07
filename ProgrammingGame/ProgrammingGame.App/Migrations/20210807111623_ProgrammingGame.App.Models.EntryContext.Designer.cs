﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammingGame.App.Models;

namespace ProgrammingGame.App.Migrations
{
    [DbContext(typeof(EntryContext))]
    [Migration("20210807111623_ProgrammingGame.App.Models.EntryContext")]
    partial class ProgrammingGameAppModelsEntryContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProgrammingGame.App.Models.Entry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("EntryId");

                    b.HasIndex("TaskId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("ProgrammingGame.App.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("ProgrammingGame.App.Models.Entry", b =>
                {
                    b.HasOne("ProgrammingGame.App.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");

                    b.Navigation("Task");
                });
#pragma warning restore 612, 618
        }
    }
}