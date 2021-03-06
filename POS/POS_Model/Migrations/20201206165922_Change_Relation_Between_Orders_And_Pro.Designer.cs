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
    [Migration("20201206165922_Change_Relation_Between_Orders_And_Pro")]
    partial class Change_Relation_Between_Orders_And_Pro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("POS_Model.Allergen", b =>
                {
                    b.Property<int>("AllergenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AllergenName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergenID");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("POS_Model.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("TableID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("POS_Model.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AllergenID")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("AllergenID");

                    b.HasIndex("ProductCategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("POS_Model.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ProductCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCategoryID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("POS_Model.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReservationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReservationTelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("TableID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("POS_Model.Table", b =>
                {
                    b.Property<int>("TableID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableSeats")
                        .HasColumnType("int");

                    b.Property<string>("TableSite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableStatusID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TableID");

                    b.HasIndex("TableStatusID");

                    b.HasIndex("UserID");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("POS_Model.TableStatus", b =>
                {
                    b.Property<int>("TableStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TableStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TableStatusID");

                    b.ToTable("TableStatuses");
                });

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

            modelBuilder.Entity("POS_Model.Order", b =>
                {
                    b.HasOne("POS_Model.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("POS_Model.Product", b =>
                {
                    b.HasOne("POS_Model.Allergen", "Allergen")
                        .WithMany()
                        .HasForeignKey("AllergenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS_Model.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergen");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("POS_Model.Reservation", b =>
                {
                    b.HasOne("POS_Model.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("POS_Model.Table", b =>
                {
                    b.HasOne("POS_Model.TableStatus", "TableStatus")
                        .WithMany()
                        .HasForeignKey("TableStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS_Model.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TableStatus");

                    b.Navigation("Users");
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
