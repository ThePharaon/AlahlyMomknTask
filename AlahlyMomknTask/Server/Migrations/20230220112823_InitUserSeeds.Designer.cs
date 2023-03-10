// <auto-generated />
using System;
using AlahlyMomknTask.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlahlyMomknTask.Server.Migrations
{
    [DbContext(typeof(MainDBContext))]
    [Migration("20230220112823_InitUserSeeds")]
    partial class InitUserSeeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlahlyMomknTask.Models.Business.StepItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("TabStepID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("TabStepID");

                    b.ToTable("StepItems");
                });

            modelBuilder.Entity("AlahlyMomknTask.Models.Business.TabStep", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("TabSteps");
                });

            modelBuilder.Entity("AlahlyMomknTask.Models.Business.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = new Guid("ee99ef29-ba24-4d45-ad73-bbc674283af7"),
                            Email = "user1@mail.com",
                            IsActive = true,
                            Password = "$2a$12$64XpCZjUHeTY9WZc1NRJle9Imn1gBo29O3.QCTeniyP4f2Zkad2iy",
                            Username = "User1"
                        },
                        new
                        {
                            ID = new Guid("88106e82-3258-466d-a95d-afb9b8434791"),
                            Email = "user2@mail.com",
                            IsActive = true,
                            Password = "$2a$12$64XpCZjUHeTY9WZc1NRJle9Imn1gBo29O3.QCTeniyP4f2Zkad2iy",
                            Username = "User2"
                        });
                });

            modelBuilder.Entity("AlahlyMomknTask.Models.Business.StepItem", b =>
                {
                    b.HasOne("AlahlyMomknTask.Models.Business.TabStep", "Step")
                        .WithMany()
                        .HasForeignKey("TabStepID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Step");
                });
#pragma warning restore 612, 618
        }
    }
}
