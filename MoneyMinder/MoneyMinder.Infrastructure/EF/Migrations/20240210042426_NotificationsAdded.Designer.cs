﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Infrastructure.EF.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoneyMinder.Infrastructure.EF.Migrations
{
    [DbContext(typeof(MoneyMinderDbContext))]
    [Migration("20240210042426_NotificationsAdded")]
    partial class NotificationsAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MoneyMinderr")
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Role>("Role")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Accounts", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Notifications", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("Gender")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("CurrencyAccounts", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Balance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<Guid?>("CurrencyAccountId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyAccountId");

                    b.ToTable("Balances", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ExpectedIncome")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Budgets", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uuid");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Expenses", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Income", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<Guid>("CurrencyAccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyAccountId");

                    b.ToTable("Incomes", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.MonthlyIncome", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<Guid>("CurrencyAccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Month")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyAccountId");

                    b.ToTable("MonthlyIncomes", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.MonthlyPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<Guid>("CurrencyAccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Month")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyAccountId");

                    b.ToTable("MonthlyPayments", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<Guid>("CurrencyAccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyAccountId");

                    b.ToTable("Payments", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.SavingsPortfolios.Entities.SavingsTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SavingsPortfolioId")
                        .HasColumnType("uuid");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("SavingsPortfolioId");

                    b.ToTable("SavingsTransactions", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.SavingsPortfolios.SavingsPortfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("ActualAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PlannedAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("SavingsPortfolios", "MoneyMinderr");
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Entities.Address", b =>
                {
                    b.HasOne("MoneyMinder.Domain.Accounts.Entities.User", null)
                        .WithOne("Address")
                        .HasForeignKey("MoneyMinder.Domain.Accounts.Entities.Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Entities.Notification", b =>
                {
                    b.HasOne("MoneyMinder.Domain.Accounts.Account", null)
                        .WithMany("Notifications")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Entities.User", b =>
                {
                    b.HasOne("MoneyMinder.Domain.Accounts.Account", null)
                        .WithOne("User")
                        .HasForeignKey("MoneyMinder.Domain.Accounts.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", b =>
                {
                    b.HasOne("MoneyMinder.Domain.Accounts.Account", "Account")
                        .WithMany("CurrencyAccounts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Balance", b =>
                {
                    b.HasOne("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", null)
                        .WithMany("Balances")
                        .HasForeignKey("CurrencyAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Budget", b =>
                {
                    b.HasOne("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", null)
                        .WithOne("Budget")
                        .HasForeignKey("MoneyMinder.Domain.CurrencyAccounts.Entities.Budget", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Expense", b =>
                {
                    b.HasOne("MoneyMinder.Domain.CurrencyAccounts.Entities.Budget", null)
                        .WithMany("Expenses")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Income", b =>
                {
                    b.HasOne("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", null)
                        .WithMany("Incomes")
                        .HasForeignKey("CurrencyAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.MonthlyIncome", b =>
                {
                    b.HasOne("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", null)
                        .WithMany("MonthlyIncomes")
                        .HasForeignKey("CurrencyAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.MonthlyPayment", b =>
                {
                    b.HasOne("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", null)
                        .WithMany("MonthlyPayments")
                        .HasForeignKey("CurrencyAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Payment", b =>
                {
                    b.HasOne("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", null)
                        .WithMany("Payments")
                        .HasForeignKey("CurrencyAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.SavingsPortfolios.Entities.SavingsTransaction", b =>
                {
                    b.HasOne("MoneyMinder.Domain.SavingsPortfolios.SavingsPortfolio", null)
                        .WithMany("Transactions")
                        .HasForeignKey("SavingsPortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.SavingsPortfolios.SavingsPortfolio", b =>
                {
                    b.HasOne("MoneyMinder.Domain.Accounts.Account", "Account")
                        .WithMany("SavingsPortfolios")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Account", b =>
                {
                    b.Navigation("CurrencyAccounts");

                    b.Navigation("Notifications");

                    b.Navigation("SavingsPortfolios");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoneyMinder.Domain.Accounts.Entities.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.CurrencyAccount", b =>
                {
                    b.Navigation("Balances");

                    b.Navigation("Budget");

                    b.Navigation("Incomes");

                    b.Navigation("MonthlyIncomes");

                    b.Navigation("MonthlyPayments");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("MoneyMinder.Domain.CurrencyAccounts.Entities.Budget", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("MoneyMinder.Domain.SavingsPortfolios.SavingsPortfolio", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
