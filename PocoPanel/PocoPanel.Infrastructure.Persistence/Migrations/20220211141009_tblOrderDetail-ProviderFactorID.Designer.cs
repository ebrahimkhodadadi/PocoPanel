﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocoPanel.Infrastructure.Persistence.Contexts;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220211141009_tblOrderDetail-ProviderFactorID")]
    partial class tblOrderDetailProviderFactorID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentID");

                    b.ToTable("tblCountry");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(18,6)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPercent")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("tblProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tblProductId");

                    b.ToTable("tblDiscount");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotallPrice")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int?>("tblDiscountId")
                        .HasColumnType("int");

                    b.Property<int?>("tblPriceKindId")
                        .HasColumnType("int");

                    b.Property<int?>("tblStatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tblDiscountId");

                    b.HasIndex("tblPriceKindId");

                    b.HasIndex("tblStatusId");

                    b.ToTable("tblOrder");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblOrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProviderOrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SocialUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotallPrice")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int?>("tblOrderId")
                        .HasColumnType("int");

                    b.Property<int>("tblProductId")
                        .HasColumnType("int");

                    b.Property<int>("tblStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProviderOrderId");

                    b.HasIndex("tblOrderId");

                    b.HasIndex("tblProductId");

                    b.HasIndex("tblStatusId");

                    b.ToTable("tblOrderDetail");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblPriceKind", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("tblCountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tblCountryId");

                    b.ToTable("tblPriceKind");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rial"
                        },
                        new
                        {
                            Id = 2,
                            Name = "USD"
                        });
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Decending")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int?>("ProviderProductID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tblProductKindId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("tblProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tblProductKindId");

                    b.HasIndex("tblProviderId");

                    b.ToTable("tblProduct");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblProductKind", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentID");

                    b.ToTable("tblProductKind");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Telegram"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Instagram"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Member",
                            ParentID = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Like",
                            ParentID = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Comment",
                            ParentID = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "View",
                            ParentID = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "Follower",
                            ParentID = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Like",
                            ParentID = 2
                        },
                        new
                        {
                            Id = 9,
                            Name = "Comment",
                            ParentID = 2
                        });
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblProductPriceKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("tblPriceKindId")
                        .HasColumnType("int");

                    b.Property<int>("tblProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tblPriceKindId");

                    b.HasIndex("tblProductId");

                    b.ToTable("tblProductPriceKind");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProviderCredit")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("ProviderToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblProvider");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Waiting"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Accepted"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Completed"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Unknown"
                        },
                        new
                        {
                            Id = 6,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cancled"
                        },
                        new
                        {
                            Id = 8,
                            Name = "ReturnedMony"
                        });
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblCountry", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblCountry", "tblCountrys")
                        .WithMany()
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblDiscount", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblProduct", "tblProduct")
                        .WithMany()
                        .HasForeignKey("tblProductId");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblOrder", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblDiscount", "tblDiscount")
                        .WithMany()
                        .HasForeignKey("tblDiscountId");

                    b.HasOne("PocoPanel.Domain.Entities.tblPriceKind", "tblPriceKind")
                        .WithMany()
                        .HasForeignKey("tblPriceKindId");

                    b.HasOne("PocoPanel.Domain.Entities.tblStatus", "tblStatus")
                        .WithMany("tblOrder")
                        .HasForeignKey("tblStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblOrderDetail", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblProvider", "tblProvider")
                        .WithMany()
                        .HasForeignKey("ProviderOrderId");

                    b.HasOne("PocoPanel.Domain.Entities.tblOrder", "tblOrder")
                        .WithMany("tblOrderDetails")
                        .HasForeignKey("tblOrderId");

                    b.HasOne("PocoPanel.Domain.Entities.tblProduct", "tblProduct")
                        .WithMany()
                        .HasForeignKey("tblProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocoPanel.Domain.Entities.tblStatus", "tblStatus")
                        .WithMany("tblOrderDetails")
                        .HasForeignKey("tblStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblPriceKind", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblCountry", "tblCountry")
                        .WithMany()
                        .HasForeignKey("tblCountryId");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblProduct", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblProductKind", "tblProductKind")
                        .WithMany("tblProducts")
                        .HasForeignKey("tblProductKindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocoPanel.Domain.Entities.tblProvider", "tblProvider")
                        .WithMany("tblProduct")
                        .HasForeignKey("tblProviderId");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblProductKind", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblProductKind", "tblProductKinds")
                        .WithMany()
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("PocoPanel.Domain.Entities.tblProductPriceKind", b =>
                {
                    b.HasOne("PocoPanel.Domain.Entities.tblPriceKind", "tblPriceKind")
                        .WithMany("tblProductPriceKind")
                        .HasForeignKey("tblPriceKindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocoPanel.Domain.Entities.tblProduct", "tblProduct")
                        .WithMany("tblProductPriceKind")
                        .HasForeignKey("tblProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
