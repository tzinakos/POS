﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS_Model;

namespace POS_Model.Migrations
{
    [DbContext(typeof(PosContext))]
    [Migration("20201201191040_AddingTables_Table_TableStatus_Reservation")]
    partial class AddingTables_Table_TableStatus_Reservation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("POS_Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPoints")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("UserRoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("POS_Model.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UserRoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("POS_Model.User", b =>
                {
                    b.HasOne("POS_Model.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
