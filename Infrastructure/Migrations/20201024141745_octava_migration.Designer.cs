﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ProyectoContext))]
    [Migration("20201024141745_octava_migration")]
    partial class octava_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Advisory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedHours")
                        .HasColumnType("int");

                    b.Property<int?>("MetodologicAdvisorId")
                        .HasColumnType("int");

                    b.Property<int?>("ProyectId")
                        .HasColumnType("int");

                    b.Property<int?>("ThematicAdvisorId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("semester")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MetodologicAdvisorId");

                    b.HasIndex("ProyectId");

                    b.HasIndex("ThematicAdvisorId");

                    b.ToTable("Advisorys");
                });

            modelBuilder.Entity("Domain.Entities.Asesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Complet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type_Asser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Asesors");
                });

            modelBuilder.Entity("Domain.Entities.CommitteeMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnName("full_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnName("identification")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("comittee_members");
                });

            modelBuilder.Entity("Domain.Entities.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semestre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("Domain.Entities.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cut")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Focus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Metodologic_AdvisorId")
                        .HasColumnType("int");

                    b.Property<int?>("Student_1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Student_2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Thematic_AdvisorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url_Archive")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Metodologic_AdvisorId");

                    b.HasIndex("Student_1Id");

                    b.HasIndex("Student_2Id");

                    b.HasIndex("Thematic_AdvisorId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("Domain.Entities.Advisory", b =>
                {
                    b.HasOne("Domain.Entities.Asesor", "MetodologicAdvisor")
                        .WithMany()
                        .HasForeignKey("MetodologicAdvisorId");

                    b.HasOne("Domain.Entities.Proyecto", "Proyect")
                        .WithMany()
                        .HasForeignKey("ProyectId");

                    b.HasOne("Domain.Entities.Asesor", "ThematicAdvisor")
                        .WithMany()
                        .HasForeignKey("ThematicAdvisorId");
                });

            modelBuilder.Entity("Domain.Entities.Proyecto", b =>
                {
                    b.HasOne("Domain.Entities.Asesor", "Metodologic_Advisor")
                        .WithMany()
                        .HasForeignKey("Metodologic_AdvisorId");

                    b.HasOne("Domain.Entities.Estudiante", "Student_1")
                        .WithMany()
                        .HasForeignKey("Student_1Id");

                    b.HasOne("Domain.Entities.Estudiante", "Student_2")
                        .WithMany()
                        .HasForeignKey("Student_2Id");

                    b.HasOne("Domain.Entities.Asesor", "Thematic_Advisor")
                        .WithMany()
                        .HasForeignKey("Thematic_AdvisorId");
                });
#pragma warning restore 612, 618
        }
    }
}
