using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Backend.Models;

namespace Backend.Migrations
{
    [DbContext(typeof(WaitlessContext))]
    [Migration("20170327195256_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Backend.Models.Call", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CallStatus");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("OrderId");

                    b.Property<long?>("TabletId");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdateTime");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("TabletId");

                    b.ToTable("Call");
                });

            modelBuilder.Entity("Backend.Models.Configuration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<long?>("ItemtypId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ItemtypId");

                    b.ToTable("Configuration");
                });

            modelBuilder.Entity("Backend.Models.ConfigurationValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ConfigurationId");

                    b.Property<long?>("OrderPosId");

                    b.Property<double>("PriceApproximation");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.HasIndex("OrderPosId");

                    b.ToTable("ConfigurationValue");
                });

            modelBuilder.Entity("Backend.Models.Itemtyp", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<double>("ItemPrice");

                    b.Property<int>("Number");

                    b.Property<int>("Priority");

                    b.Property<long?>("SubmenuId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("SubmenuId");

                    b.ToTable("Itemtyp");
                });

            modelBuilder.Entity("Backend.Models.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Backend.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("Number");

                    b.Property<int>("OrderStatus");

                    b.Property<double>("PriceOrder");

                    b.Property<long?>("TableId");

                    b.Property<DateTime>("UpdateTime");

                    b.Property<long?>("WaiterId");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Backend.Models.OrderPos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreationDate");

                    b.Property<long?>("ItemtypId");

                    b.Property<int>("Number");

                    b.Property<long?>("OrderId");

                    b.Property<int>("PosStatus");

                    b.Property<double>("PricePaidByCustomer");

                    b.Property<double>("PricePos");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("ItemtypId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderPos");
                });

            modelBuilder.Entity("Backend.Models.Submenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<long?>("MenuId");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Submenu");
                });

            modelBuilder.Entity("Backend.Models.Table", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Backend.Models.Tablet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Mode");

                    b.Property<int>("Number");

                    b.Property<long?>("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Tablet");
                });

            modelBuilder.Entity("Backend.Models.Call", b =>
                {
                    b.HasOne("Backend.Models.Order", "Order")
                        .WithMany("Calls")
                        .HasForeignKey("OrderId");

                    b.HasOne("Backend.Models.Tablet", "Tablet")
                        .WithMany("Calls")
                        .HasForeignKey("TabletId");
                });

            modelBuilder.Entity("Backend.Models.Configuration", b =>
                {
                    b.HasOne("Backend.Models.Itemtyp")
                        .WithMany("Configurations")
                        .HasForeignKey("ItemtypId");
                });

            modelBuilder.Entity("Backend.Models.ConfigurationValue", b =>
                {
                    b.HasOne("Backend.Models.Configuration", "Configuration")
                        .WithMany("Values")
                        .HasForeignKey("ConfigurationId");

                    b.HasOne("Backend.Models.OrderPos")
                        .WithMany("ConfigurationValues")
                        .HasForeignKey("OrderPosId");
                });

            modelBuilder.Entity("Backend.Models.Itemtyp", b =>
                {
                    b.HasOne("Backend.Models.Submenu", "Submenu")
                        .WithMany("Items")
                        .HasForeignKey("SubmenuId");
                });

            modelBuilder.Entity("Backend.Models.Order", b =>
                {
                    b.HasOne("Backend.Models.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId");

                    b.HasOne("Backend.Models.Tablet", "Waiter")
                        .WithMany()
                        .HasForeignKey("WaiterId");
                });

            modelBuilder.Entity("Backend.Models.OrderPos", b =>
                {
                    b.HasOne("Backend.Models.Itemtyp", "Itemtyp")
                        .WithMany()
                        .HasForeignKey("ItemtypId");

                    b.HasOne("Backend.Models.Order", "Order")
                        .WithMany("Positions")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Backend.Models.Submenu", b =>
                {
                    b.HasOne("Backend.Models.Menu", "Menu")
                        .WithMany("Submenus")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("Backend.Models.Tablet", b =>
                {
                    b.HasOne("Backend.Models.Order")
                        .WithMany("Guests")
                        .HasForeignKey("OrderId");
                });
        }
    }
}
