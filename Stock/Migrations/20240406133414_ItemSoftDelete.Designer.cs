﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stock.Models;

#nullable disable

namespace Stock.Migrations
{
    [DbContext(typeof(ApplicationDataBaseContext))]
    [Migration("20240406133414_ItemSoftDelete")]
    partial class ItemSoftDelete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Stock.Models.DbModels.ItemModel.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("SoftDelete")
                        .HasColumnType("bit");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Stock.Models.DbModels.StoreModel.Store", b =>
                {
                    b.Property<Guid>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Stock.Models.DbModels.ItemModel.Item", b =>
                {
                    b.OwnsMany("Stock.Models.DbModels.ItemModel.ItemImage", "Images", b1 =>
                        {
                            b1.Property<Guid>("ItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("Src")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ItemId", "Id");

                            b1.ToTable("ItemImage");

                            b1.WithOwner()
                                .HasForeignKey("ItemId");
                        });

                    b.Navigation("Images");
                });

            modelBuilder.Entity("Stock.Models.DbModels.StoreModel.Store", b =>
                {
                    b.OwnsMany("Stock.Models.DbModels.StoreModel.Stock", "Stocks", b1 =>
                        {
                            b1.Property<Guid>("StoreId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("ItemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.HasKey("StoreId", "Id");

                            b1.HasIndex("ItemId");

                            b1.ToTable("Stock");

                            b1.HasOne("Stock.Models.DbModels.ItemModel.Item", "Item")
                                .WithMany()
                                .HasForeignKey("ItemId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner("Store")
                                .HasForeignKey("StoreId");

                            b1.Navigation("Item");

                            b1.Navigation("Store");
                        });

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
