﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfficeDL;

namespace OfficeData.Migrations
{
    [DbContext(typeof(Office_Context))]
    [Migration("20221209085939_theoffice1")]
    partial class theoffice1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("OfficeEntity.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("TaskBoardid")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("profileId")
                        .HasColumnType("int");

                    b.Property<int>("taskId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("TaskBoardid");

                    b.HasIndex("profileId");

                    b.HasIndex("taskId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("OfficeEntity.Contactus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("contact");
                });

            modelBuilder.Entity("OfficeEntity.Dashboard", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("getMonthComment")
                        .HasColumnType("int");

                    b.Property<int>("getMonthMessage")
                        .HasColumnType("int");

                    b.Property<int>("getMonthTask")
                        .HasColumnType("int");

                    b.Property<int>("getTodayComment")
                        .HasColumnType("int");

                    b.Property<int>("getTodayMessage")
                        .HasColumnType("int");

                    b.Property<int>("getTodayTask")
                        .HasColumnType("int");

                    b.Property<int>("getYearComment")
                        .HasColumnType("int");

                    b.Property<int>("getYearMessage")
                        .HasColumnType("int");

                    b.Property<int>("getYearTask")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("dashBoards");
                });

            modelBuilder.Entity("OfficeEntity.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("pId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("pId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("OfficeEntity.Profile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("profile");
                });

            modelBuilder.Entity("OfficeEntity.TaskBoard", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("commentsid")
                        .HasColumnType("int");

                    b.Property<int>("countMessage")
                        .HasColumnType("int");

                    b.Property<int?>("taskid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("commentsid");

                    b.HasIndex("taskid");

                    b.ToTable("taskBoards");
                });

            modelBuilder.Entity("OfficeEntity.Tasks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("profileId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("profileId");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("OfficeEntity.Comment", b =>
                {
                    b.HasOne("OfficeEntity.TaskBoard", null)
                        .WithMany("commentsList")
                        .HasForeignKey("TaskBoardid");

                    b.HasOne("OfficeEntity.Profile", "profile")
                        .WithMany()
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OfficeEntity.Tasks", "task")
                        .WithMany()
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("profile");

                    b.Navigation("task");
                });

            modelBuilder.Entity("OfficeEntity.Message", b =>
                {
                    b.HasOne("OfficeEntity.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("pId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("OfficeEntity.TaskBoard", b =>
                {
                    b.HasOne("OfficeEntity.Comment", "comments")
                        .WithMany()
                        .HasForeignKey("commentsid");

                    b.HasOne("OfficeEntity.Tasks", "task")
                        .WithMany()
                        .HasForeignKey("taskid");

                    b.Navigation("comments");

                    b.Navigation("task");
                });

            modelBuilder.Entity("OfficeEntity.Tasks", b =>
                {
                    b.HasOne("OfficeEntity.Profile", "profile")
                        .WithMany()
                        .HasForeignKey("profileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("profile");
                });

            modelBuilder.Entity("OfficeEntity.TaskBoard", b =>
                {
                    b.Navigation("commentsList");
                });
#pragma warning restore 612, 618
        }
    }
}
