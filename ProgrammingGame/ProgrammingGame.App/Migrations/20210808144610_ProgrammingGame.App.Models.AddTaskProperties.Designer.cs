// <auto-generated />
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
    [Migration("20210808144610_ProgrammingGame.App.Models.AddTaskProperties")]
    partial class ProgrammingGameAppModelsAddTaskProperties
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("Task");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            Description = "Write a program in C# that outputs 'Hello World!' to console.",
                            Name = "Hello World",
                            Solution = "Hello World!"
                        },
                        new
                        {
                            TaskId = 2,
                            Description = "Write a program in C# that outputs 'AAA' to console.",
                            Name = "Test AAA",
                            Solution = "AAA"
                        },
                        new
                        {
                            TaskId = 3,
                            Description = "Write a program in C# that outputs 'BBB' to console.",
                            Name = "Test BBB",
                            Solution = "BBB"
                        });
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
