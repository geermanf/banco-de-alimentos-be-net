﻿// <auto-generated />
using System;
using BancoDeAlimentos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancoDeAlimentos.Migrations
{
    [DbContext(typeof(DB_FCDM_BackOfficeContext))]
    [Migration("20191121015027_deliveryFirstMigration")]
    partial class deliveryFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BancoDeAlimentos.Entities.Delivery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<DateTime>("EstimatedDate");

                    b.Property<bool>("ExpiredProducts");

                    b.Property<string>("Key");

                    b.Property<long>("OrganizationId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Deliverys");
                });

            modelBuilder.Entity("BancoDeAlimentos.Entities.InternalUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsOrganization");

                    b.Property<string>("Key");

                    b.Property<long?>("OrganizationInfoId");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationInfoId");

                    b.ToTable("InternalUsers");
                });

            modelBuilder.Entity("BancoDeAlimentos.Entities.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adults");

                    b.Property<string>("Children");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Key");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<string>("OpeningDays");

                    b.Property<string>("OrganizationName")
                        .IsRequired();

                    b.Property<string>("OrganizationPhone");

                    b.Property<string>("Reference");

                    b.Property<string>("ResponsableEmail");

                    b.Property<string>("ResponsableFirstName");

                    b.Property<string>("ResponsableLastName");

                    b.Property<string>("ResponsablePhone");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("BancoDeAlimentos.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DeliveryId");

                    b.Property<string>("Description");

                    b.Property<string>("Key");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Stock");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BancoDeAlimentos.Entities.Delivery", b =>
                {
                    b.HasOne("BancoDeAlimentos.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BancoDeAlimentos.Entities.InternalUser", b =>
                {
                    b.HasOne("BancoDeAlimentos.Entities.Organization", "OrganizationInfo")
                        .WithMany()
                        .HasForeignKey("OrganizationInfoId");
                });

            modelBuilder.Entity("BancoDeAlimentos.Entities.Product", b =>
                {
                    b.HasOne("BancoDeAlimentos.Entities.Delivery")
                        .WithMany("Products")
                        .HasForeignKey("DeliveryId");
                });
#pragma warning restore 612, 618
        }
    }
}
