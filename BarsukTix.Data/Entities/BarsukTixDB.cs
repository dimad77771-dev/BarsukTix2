using System;
using System.Collections.Generic;
using BarsukTix.Common;
using Microsoft.EntityFrameworkCore;

namespace BarsukTix.Data.Entities;

public partial class BarsukTixDB : DbContext
{
    public BarsukTixDB()
    {
    }

    public BarsukTixDB(DbContextOptions<BarsukTixDB> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Festival> Festivals { get; set; }

    public virtual DbSet<PaymentProcessing> PaymentProcessings { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketAttendee> TicketAttendees { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(BarsukTixSettings.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.Property(e => e.RowId).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(1000);
            entity.Property(e => e.Price).HasColumnType("decimal(30, 2)");
        });

        modelBuilder.Entity<Festival>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.Property(e => e.RowId).ValueGeneratedNever();
            entity.Property(e => e.FestivalFullName).HasMaxLength(1000);
            entity.Property(e => e.FestivalName).HasMaxLength(1000);
            entity.Property(e => e.FinishDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentProcessing>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.Property(e => e.RowId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(30, 2)");
            entity.Property(e => e.ApprovalCode).HasMaxLength(1000);
            entity.Property(e => e.AvsResponse).HasMaxLength(1000);
            entity.Property(e => e.CardExpiry).HasMaxLength(1000);
            entity.Property(e => e.CardHolderName).HasMaxLength(1000);
            entity.Property(e => e.CardNumber).HasMaxLength(1000);
            entity.Property(e => e.CardToken).HasMaxLength(1000);
            entity.Property(e => e.CardType).HasMaxLength(1000);
            entity.Property(e => e.Currency).HasMaxLength(1000);
            entity.Property(e => e.CustomerCode).HasMaxLength(1000);
            entity.Property(e => e.CvvResponse).HasMaxLength(1000);
            entity.Property(e => e.OrderNumber).HasMaxLength(1000);
            entity.Property(e => e.ProcessingDateTime).HasColumnType("datetime");
            entity.Property(e => e.Response).HasMaxLength(1000);
            entity.Property(e => e.ResponseDateTime).HasColumnType("datetime");
            entity.Property(e => e.ResponseType).HasMaxLength(1000);
            entity.Property(e => e.TransactionId).HasMaxLength(1000);
            entity.Property(e => e.UserId).HasMaxLength(450);
            entity.Property(e => e.XmlHash).HasMaxLength(1000);

            entity.HasOne(d => d.User).WithMany(p => p.PaymentProcessings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentProcessings_AspNetUsers");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.HasIndex(e => e.UserId, "UK_Tickets").IsUnique();

            entity.Property(e => e.RowId).ValueGeneratedNever();
            entity.Property(e => e.AddressCity).HasMaxLength(1000);
            entity.Property(e => e.AddressLine).HasMaxLength(1000);
            entity.Property(e => e.AddressState).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(1000);
            entity.Property(e => e.FirstName).HasMaxLength(1000);
            entity.Property(e => e.LastName).HasMaxLength(1000);
            entity.Property(e => e.MobilePhone).HasMaxLength(1000);
            entity.Property(e => e.RepeatEmail).HasMaxLength(1000);
            entity.Property(e => e.UserId).HasMaxLength(450);
            entity.Property(e => e.ZipCode).HasMaxLength(1000);

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_AspNetUsers");
        });

        modelBuilder.Entity<TicketAttendee>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.Property(e => e.RowId).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(1000);
            entity.Property(e => e.LastName).HasMaxLength(1000);

            entity.HasOne(d => d.TicketCategoryRow).WithMany(p => p.TicketAttendees)
                .HasForeignKey(d => d.TicketCategoryRowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketAttendees_TicketCategories");
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.HasKey(e => e.RowId);

            entity.HasIndex(e => new { e.TicketRowId, e.CategoryRowId }, "UK_TicketCategories").IsUnique();

            entity.Property(e => e.RowId).ValueGeneratedNever();

            entity.HasOne(d => d.CategoryRow).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.CategoryRowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketCategories_Categories");

            entity.HasOne(d => d.TicketRow).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.TicketRowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TicketCategories_Tickets");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
