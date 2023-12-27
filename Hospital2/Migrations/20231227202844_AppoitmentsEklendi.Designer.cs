﻿// <auto-generated />
using Hospital2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital2.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20231227202844_AppoitmentsEklendi")]
    partial class AppoitmentsEklendi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hospital2.Models.AnaBilimDali", b =>
                {
                    b.Property<int>("AnaBilimDaliId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnaBilimDaliId"), 1L, 1);

                    b.Property<string>("AnaBilimDaliName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnaBilimDaliId");

                    b.ToTable("AnaBilimDalis");
                });

            modelBuilder.Entity("Hospital2.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("userId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Hospital2.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorId"), 1L, 1);

                    b.Property<string>("DoktarAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliklinikId")
                        .HasColumnType("int");

                    b.HasKey("DoktorId");

                    b.HasIndex("PoliklinikId");

                    b.ToTable("Doktors");
                });

            modelBuilder.Entity("Hospital2.Models.Poliklinik", b =>
                {
                    b.Property<int>("PoliklinikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoliklinikId"), 1L, 1);

                    b.Property<int>("AnaBilimDaliId")
                        .HasColumnType("int");

                    b.Property<string>("PoliklinikIsmi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoliklinikId");

                    b.HasIndex("AnaBilimDaliId");

                    b.ToTable("Polikliniks");
                });

            modelBuilder.Entity("Hospital2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Boy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DogumTarihi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kilo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hospital2.Models.Appointment", b =>
                {
                    b.HasOne("Hospital2.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital2.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Hospital2.Models.Doktor", b =>
                {
                    b.HasOne("Hospital2.Models.Poliklinik", "Poliklinik")
                        .WithMany("Doktors")
                        .HasForeignKey("PoliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poliklinik");
                });

            modelBuilder.Entity("Hospital2.Models.Poliklinik", b =>
                {
                    b.HasOne("Hospital2.Models.AnaBilimDali", "AnaBilimDali")
                        .WithMany("Polikliniks")
                        .HasForeignKey("AnaBilimDaliId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnaBilimDali");
                });

            modelBuilder.Entity("Hospital2.Models.AnaBilimDali", b =>
                {
                    b.Navigation("Polikliniks");
                });

            modelBuilder.Entity("Hospital2.Models.Poliklinik", b =>
                {
                    b.Navigation("Doktors");
                });
#pragma warning restore 612, 618
        }
    }
}
