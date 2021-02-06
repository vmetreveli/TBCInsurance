﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBCInsurance.Infastructure.Data.Context;

namespace TBCInsurance.Infastructure.Data.Migrations
{
    [DbContext(typeof(UniDbContext))]
    [Migration("20210206095150_InitialCreateR")]
    partial class InitialCreateR
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("TBCInsurance.Domain.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("TBCInsurance.Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SexId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SexId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TBCInsurance.Domain.Models.Student", b =>
                {
                    b.HasOne("TBCInsurance.Domain.Models.Gender", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId");

                    b.Navigation("Sex");
                });
#pragma warning restore 612, 618
        }
    }
}