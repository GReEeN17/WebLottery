﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebLottery.Infrastructure.Implementations.DataContext;

#nullable disable

namespace WebLottery.Infrastructure.Migrations.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240325092436_ChangedPurchasedDateToNull")]
    partial class ChangedPurchasedDateToNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.CurrencyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)")
                        .HasColumnName("abbreviation");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("currency", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.DrawEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentAmountPlayers")
                        .HasColumnType("integer")
                        .HasColumnName("cur_am_players");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEnded")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxAmountPlayers")
                        .HasColumnType("integer")
                        .HasColumnName("max_am_players");

                    b.Property<Guid>("PrizeId")
                        .HasColumnType("uuid");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("integer")
                        .HasColumnName("ticket_price");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PrizeId");

                    b.ToTable("draw", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PocketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("pocket", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PocketTicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PocketId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PocketId");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("pocket_ticket", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PrizeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("prize", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DrawId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("LuckyNumber")
                        .HasColumnType("integer")
                        .HasColumnName("lucky_number");

                    b.Property<DateTime>("PurchaseTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DrawId");

                    b.ToTable("ticket", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("username");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.WalletCurrencyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("WalletId");

                    b.ToTable("wallet_currency", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.WalletEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("wallet", (string)null);
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.DrawEntity", b =>
                {
                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.PrizeEntity", "Prize")
                        .WithMany("Draws")
                        .HasForeignKey("PrizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prize");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PocketEntity", b =>
                {
                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.UserEntity", "User")
                        .WithOne("Pocket")
                        .HasForeignKey("WebLottery.Infrastructure.Entities.Entities.PocketEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PocketTicketEntity", b =>
                {
                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.PocketEntity", "Pocket")
                        .WithMany("PocketTickets")
                        .HasForeignKey("PocketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.TicketEntity", "Ticket")
                        .WithOne("PocketTicket")
                        .HasForeignKey("WebLottery.Infrastructure.Entities.Entities.PocketTicketEntity", "TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pocket");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PrizeEntity", b =>
                {
                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.CurrencyEntity", "Currency")
                        .WithMany("Prizes")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.TicketEntity", b =>
                {
                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.DrawEntity", "Draw")
                        .WithMany("Tickets")
                        .HasForeignKey("DrawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Draw");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.WalletCurrencyEntity", b =>
                {
                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.CurrencyEntity", "Currency")
                        .WithMany("WalletCurrencies")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.WalletEntity", "Wallet")
                        .WithMany("WalletCurrencies")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.WalletEntity", b =>
                {
                    b.HasOne("WebLottery.Infrastructure.Entities.Entities.UserEntity", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("WebLottery.Infrastructure.Entities.Entities.WalletEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.CurrencyEntity", b =>
                {
                    b.Navigation("Prizes");

                    b.Navigation("WalletCurrencies");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.DrawEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PocketEntity", b =>
                {
                    b.Navigation("PocketTickets");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.PrizeEntity", b =>
                {
                    b.Navigation("Draws");
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.TicketEntity", b =>
                {
                    b.Navigation("PocketTicket")
                        .IsRequired();
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.UserEntity", b =>
                {
                    b.Navigation("Pocket")
                        .IsRequired();

                    b.Navigation("Wallet")
                        .IsRequired();
                });

            modelBuilder.Entity("WebLottery.Infrastructure.Entities.Entities.WalletEntity", b =>
                {
                    b.Navigation("WalletCurrencies");
                });
#pragma warning restore 612, 618
        }
    }
}
