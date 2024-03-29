﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentPortal_DataAccess.Context;

#nullable disable

namespace StudentPortal_DataAccess.Context.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StudentPortal_Core.Entities.Concrete.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassroomDescription")
                        .HasColumnType("text");

                    b.Property<string>("ClassroomName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classrooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassroomDescription = "320 Saat .NET Full Stack Yazılım Uzmanlığı Eğitimi",
                            ClassroomName = "YZL-8445",
                            CreatedDate = new DateTime(2024, 3, 2, 13, 7, 23, 736, DateTimeKind.Local).AddTicks(7935),
                            Status = 1,
                            TeacherId = 1
                        });
                });

            modelBuilder.Entity("StudentPortal_Core.Entities.Concrete.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ClassroomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<double?>("Exam1")
                        .HasColumnType("double precision");

                    b.Property<double?>("Exam2")
                        .HasColumnType("double precision");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<double?>("ProjectExam")
                        .HasColumnType("double precision");

                    b.Property<string>("ProjectPath")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClassroomId = 1,
                            CreatedDate = new DateTime(2024, 3, 2, 13, 7, 23, 736, DateTimeKind.Local).AddTicks(8323),
                            Email = "student@test.com",
                            FirstName = "Öğrenci - 1",
                            LastName = "Öğrenci - 1",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1996, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClassroomId = 1,
                            CreatedDate = new DateTime(2024, 3, 2, 13, 7, 23, 736, DateTimeKind.Local).AddTicks(8333),
                            Email = "student2@test.com",
                            FirstName = "Öğrenci - 2",
                            LastName = "Öğrenci - 2",
                            Status = 1
                        });
                });

            modelBuilder.Entity("StudentPortal_Core.Entities.Concrete.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 3, 2, 13, 7, 23, 736, DateTimeKind.Local).AddTicks(7124),
                            Email = "teacher@test.com",
                            FirstName = "Öğretmen - 1",
                            LastName = "Öğretmen - 1",
                            Status = 1
                        });
                });

            modelBuilder.Entity("StudentPortal_Core.Entities.Concrete.Classroom", b =>
                {
                    b.HasOne("StudentPortal_Core.Entities.Concrete.Teacher", "Teacher")
                        .WithMany("Classrooms")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentPortal_Core.Entities.Concrete.Student", b =>
                {
                    b.HasOne("StudentPortal_Core.Entities.Concrete.Classroom", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomId");

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("StudentPortal_Core.Entities.Concrete.Classroom", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudentPortal_Core.Entities.Concrete.Teacher", b =>
                {
                    b.Navigation("Classrooms");
                });
#pragma warning restore 612, 618
        }
    }
}
